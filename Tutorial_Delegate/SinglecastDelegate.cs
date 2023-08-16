namespace Tutorial_Delegate;

public delegate void MyDelegate(string message);

internal class SinglecastDelegate
{
	public static void Print(string message)
	{
        Console.WriteLine($"{message}");
    }

	public SinglecastDelegate()
	{
		MyDelegate myDelegate = new MyDelegate(Print);

		myDelegate.Invoke("Hello, single cast delegates!");
        // Or
        // myDelegate("Hello Shekh");

        Console.ReadLine();
    }
}
