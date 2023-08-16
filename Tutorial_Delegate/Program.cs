using Tutorial_Delegate;

internal class Program
{

    static void Main(string[] args)
    {
        //_ = new DelegateDefault();
        //_ = new DelegateChain();
        //_ = new DelegateBasic();
        //_ = new SinglecastDelegate();
        //_ = new MulticastDelegateBasic();
        //_ = new MulticastDelegateCombine();
        //_ = new MulticastDelegateOperator();
        //_ = new DelegateCallbackNotification();
        //_ = new DelegateAnonymousMethod();

        _ = new DelegateGeneric();
        //_ = new DelegateAction();


    }
}

public class DelegateDefault
{
    public delegate void FunctionPointer();

    static void Print1()
    {
        Console.WriteLine("Print 1");
    }
    static void Print2()
    {
        Console.WriteLine("Print 2");
    }
    static void Print3()
    {
        Console.WriteLine("Print 3");
    }
    static void Print4()
    {
        Console.WriteLine("Print 4");
    }

    static void Execute(FunctionPointer fp)
    {
        fp();
    }

    public DelegateDefault()
    {
        Execute(Print1);
        Execute(Print2);
        Execute(Print3);
        Execute(Print4);
        /*
            Print 1
            Print 2
            Print 3
            Print 4
        */
    }

}

public class DelegateChain
{
    public delegate void FunctionPointer();

    static void Print1()
    {
        Console.WriteLine("Print 1");
    }
    static void Print2()
    {
        Console.WriteLine("Print 2");
    }
    static void Print3()
    {
        Console.WriteLine("Print 3");
    }
    static void Print4()
    {
        Console.WriteLine("Print 4");
    }

    static void Execute(FunctionPointer fp)
    {
        fp();
    }

    public DelegateChain()
    {
        FunctionPointer fp = new FunctionPointer(Print1);
        fp += Print2;
        fp += Print3;
        fp += Print4;

        fp();
        /*
            Print 1
            Print 2
            Print 3
            Print 4
        */
    }
}

public class EventDefault
{
    delegate void EventHandler(string message);

    public EventDefault()
    {
            
    }
}

public class DelegateBasic
{
    delegate int CalcDelegate(int x, int y);

    public DelegateBasic()
    {
        CalcDelegate calc = Add;
        calc += Subtract;
        calc += Multiply;
        calc += Divide;


        CalcDelegate temp = new CalcDelegate(Add);
        Calc(10, 5, temp);

        Calc(10, 5, new CalcDelegate(Add));

        Calc(10, 5, Subtract);

        /*
         *  사용함수 : Int32 Add(Int32, Int32)
         *  f(10, 5) = : 15
         *  사용함수 : Int32 Subtract(Int32, Int32)
         *  f(10, 5) = : 5
         *  사용함수 : Int32 Multiply(Int32, Int32)
         *  f(10, 5) = : 50
         *  사용함수 : Int32 Divide(Int32, Int32)
         *  f(10, 5) = : 2
         * */

    }

    void Calc(int a, int b, CalcDelegate calc)
    {
        int res = calc(a, b);
        Console.WriteLine($"사용함수 : {calc.Method}");
        Console.WriteLine($"f({a}, {b}) = {res}");
    }

    private int Divide(int x, int y)
    {        
        return x / y;
    }

    private int Multiply(int x, int y)
    {
        return x * y;
    }

    private int Subtract(int x, int y)
    {
        return x - y;
    }

    private int Add(int x, int y)
    {
        return x + y;
    }
}

