namespace Tutorial_Delegate;

internal class DelegateAnonymousMethod
{
    // Declaring a delegate
    public delegate int MyDelegate(int num1, int num2);

    public DelegateAnonymousMethod()
    {
        // Instantiating the delegate using an anonymous method

        MyDelegate myDelegate = delegate (int num1, int num2)
        {
            return num1 + num2;
        };

        Console.WriteLine(myDelegate(10, 20));
    }
}


