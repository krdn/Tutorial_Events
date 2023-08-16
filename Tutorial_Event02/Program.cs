// https://lightgg.tistory.com/15

class Program
{
    static void Main()
    {
        var pub = new Publisher();
        var sub1 = new Subscriber("sub1", pub);
        var sub2 = new Subscriber("sub2", pub);

        // Call the method that raises the event.
        pub.DoSomething();

        // Keep the console window open
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}



// 이벤트 정보를 담을 클래스 정의
public class CustomEventArgs
{
    public CustomEventArgs(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}

// 이벤트를 발행하는 클래스
class Publisher
{
    // 닷넷에서 기본 제공하는 EventHandler<T> 대리자를 사용하여 이벤트 선언
    public event EventHandler<CustomEventArgs> RaiseCustomEvent;

    public void DoSomething()
    {
        // 이벤트 실행
        OnRaiseCustomEvent(new CustomEventArgs("Event triggered"));
    }

    // 하위 클래스에서 재정의 가능한 메서드
    protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
    {
        // 임시 변수에 이벤트 복사(Thread safety 때문)
        EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

        e.Message += $" at {DateTime.Now}";
        raiseEvent?.Invoke(this, e);
    }
}

// 이벤트 구독 클래스
class Subscriber
{
    private readonly string _id;

    public Subscriber(string id, Publisher pub)
    {
        _id = id;

        // 이벤트 구독
        // pub.RaiseCustomEvent 이벤트에 이벤트 핸들러(HandleCustomEvent 메서드)를 구독
        pub.RaiseCustomEvent += HandleCustomEvent;
    }

    // 이벤트 핸들러(실제 이벤트 처리)
    void HandleCustomEvent(object sender, CustomEventArgs e)
    {
        Console.WriteLine($"{_id} received this message: {e.Message}");
    }
}

