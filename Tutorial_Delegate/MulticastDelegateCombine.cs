using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_Delegate;
internal class MulticastDelegateCombine
{
    public delegate void MyDelegate();

	public MulticastDelegateCombine()
	{
        // Declares the single delegate that points to MethodA
        MyDelegate delegateA = new MyDelegate(MethodA);

        // Declares the single delegate that points to MethodB
        MyDelegate delegateB = new MyDelegate(MethodB);

        // multicast delegate combining both delegates A and B
        MyDelegate multicastDeligate = (MyDelegate)Delegate.Combine(delegateA, delegateB);
        // Invokes the multicast delegate
        multicastDeligate.Invoke();
    }

    static void MethodA()
    {
        Console.WriteLine("Executing method A.");
    }

    static void MethodB()
    {
        Console.WriteLine("Executing method B.");
    }
}
