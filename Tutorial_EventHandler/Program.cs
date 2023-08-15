namespace Tutorial_MulticastDelegate;


/// <summary>
/// 멀티캐스트(delegate) 델리게이트는 C#에서 한 개 이상의 메서드를 동시에 호출
/// https://www.notion.so/krdn/Delegate-f405a171a41e462ca433bc2bd9bccba9
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        MyPublisher publisher = new MyPublisher();
        MySubscriber subscriber = new MySubscriber();

        publisher.MyEvent += subscriber.OnMyEvent;

        publisher.PublishEvent("Hello from the event!");

        Console.ReadLine();
    }
}

public class MyEventArgs : EventArgs
{
    public string Message { get; }

    public MyEventArgs(string message)
    {
        Message = message;
    }
}

public class MyPublisher
{
    public event EventHandler<MyEventArgs> MyEvent;

    public void PublishEvent(string message)
    {
        MyEvent?.Invoke(this, new MyEventArgs(message));
    }
}

public class MySubscriber
{
    public void OnMyEvent(object sender, MyEventArgs e)
    {
        Console.WriteLine($"Received event: {e.Message}");
    }
}
