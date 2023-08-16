namespace Tutorial_Delegate;

delegate void MyMultiDelegate();

internal class MulticastDelegateBasic
{

    void Method1()
    {
        Console.WriteLine("Method 1");
    }

    void Method2()
    {
        Console.WriteLine("Method 2");
    }

    public MulticastDelegateBasic()
	{
        // Create a multicast delegate and add both methods to it
        MyMultiDelegate multiDel = Method1;
        multiDel += Method2;

        // Invoke the multicast delegate, which will call both methods
        multiDel(); // Output: Method 1
                    //         Method 2

    }
}
