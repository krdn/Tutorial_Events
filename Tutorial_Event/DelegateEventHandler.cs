namespace Tutorial_Event;


// Declare delegate
public delegate void sampleEventHandler(int num1, int num2);

/// <summary>
/// https://www.shekhali.com/csharp-events/
/// </summary>
internal class DelegateEventHandler
{
    // Declare event
    public static event sampleEventHandler MyEvent;

    public DelegateEventHandler()
    {
        // Register event handler methods with an event
        MyEvent += new sampleEventHandler(Add);
        MyEvent += new sampleEventHandler(Substract);
        MyEvent.Invoke(20, 10);
        Console.ReadLine();
    }

    // Event Handler methods
    static void Add(int num1, int num2)
    {
        Console.WriteLine($" Addition: {num1} + {num2} = {num1 + num2} ");
    }
    static void Substract(int num1, int num2)
    {
        Console.WriteLine($" Substraction: {num1} - {num2} = {num1 - num2} ");
    }
}
