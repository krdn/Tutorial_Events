using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_Delegate;

/// <summary>
/// Example of multicast delegate using “+” and “-“ operator.
/// </summary>
internal class MulticastDelegateOperator
{
    public delegate void MyDelegate();

	public MulticastDelegateOperator()
	{
        // Add MethodA
        MyDelegate multicastDelegate = MulticastDelegateOperator.MethodA;

        // To MethodB
        multicastDelegate += MulticastDelegateOperator.MethodB;

        // To remove MethodA from the invocation list
        // multicastDelegate -= Program.MethodA;

        // Get the list of all delegates added to Multicast Delegate.
        Delegate[] delegateList = multicastDelegate.GetInvocationList();
        Console.WriteLine($"MulticastDelegate contains {delegateList.Length} delegate(s).");

        // Invokes the multicast delegate
        multicastDelegate.Invoke();
    }

    static void MethodA()
    {
        Console.WriteLine("Executed method A.");
    }

    static void MethodB()
    {
        Console.WriteLine("Executed method B.");
    }

}
