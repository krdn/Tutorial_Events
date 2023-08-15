internal class Program
{
    static void Main(string[] args)
    {
        MyPublisher publisher = new MyPublisher();
        MySubscriber subscriber1 = new MySubscriber("Subscriber 1");
        MySubscriber subscriber2 = new MySubscriber("Subscriber 2");

        publisher.MyEvent += subscriber1.OnMyEvent;
        publisher.MyEvent += subscriber2.OnMyEvent;

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
    public delegate void MyEventHandler(object sender, MyEventArgs e);
    public event MyEventHandler MyEvent;

    public void PublishEvent(string message)
    {
        MyEvent?.Invoke(this, new MyEventArgs(message));
    }
}

public class MySubscriber
{
    private string name;

    public MySubscriber(string name)
    {
        this.name = name;
    }

    public void OnMyEvent(object sender, MyEventArgs e)
    {
        Console.WriteLine($"{name} received event: {e.Message}");
    }
}
