namespace Tutorial_Delegate;

internal class DelegateGeneric
{
    /// <summary>
    /// Generic Delegates in C# With Examples: Func, Action, and Predicate delegates [Updated 2022]
    /// https://www.shekhali.com/generic-delegates-in-csharp-with-examples/
    /// </summary>
	public DelegateGeneric()
	{
        //*****************************************************************************************
        // Signature to define Func delegate.
        // public delegate TResult Func<in T, out TResult>(T arg);

        // Func delegate can take up to 16 input parameters and one out parameter.
        // public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

        //The last parameter is an out parameter

        //Func 대리자의 예
        Func<int, float, double> funcDelegate = AddNumbers;
        double output = funcDelegate.Invoke(10, 20.5f);
        Console.WriteLine($"Output : {output}");

        // 익명 메서드를 사용하는 Func 대리자의 예
        Func<int, float, double> funcDelegate2 = delegate (int num1, float num2)
        {
            return num1 + num2;
        };
        double output2 = funcDelegate2.Invoke(10, 20.5f);
        Console.WriteLine($"Output2: {output2}");

        // 람다 식을 사용한 Func 대리자의 예
        Func<int, float, double> funcDelegate3 = (int num1, float num2) => (num1 + num2);
        double output3 = funcDelegate2.Invoke(10, 20.5f);
        Console.WriteLine($"Output3: {output3}");

        //*****************************************************************************************
        // Encapsulates a method that has a single parameter and does not return a value.
        // public delegate void Action<in T>(T obj);

        // Encapsulates a method that can accept up to 16 input parameter and
        // does not return a value.
        // public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

        // The Action generic delegate can accept zero to 16 input parameters.

        // Non generic action delegate
        Action action = PrintName;
        action.Invoke();

        // Generic Action delegate
        Action<int, int> action2 = AddTwoNumbers;
        action2.Invoke(30, 20);

        // Generic Action delegate with anonymous method
        Action<int, int> action3 = delegate (int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        };
        action3.Invoke(30, 20);

        // Generic Action delegate with lambda expression
        Action<int, int> action4 = (num1, num2) =>
        {
            Console.WriteLine(num1 + num2);
        };
        action4.Invoke(30, 20);

        //*****************************************************************************************
        // C#의 조건자 제네릭 대리자
        // public delegate bool Predicate<in T>(T obj);
        // System 네임스페이스 에서 사용할 수 있는 일반 대리자입니다 .
        // 하나의 입력 매개변수를 사용하고  부울 값을 반환합니다.

        // Predicate delegate
        Predicate<int> predicate = IsEvenNumber;
        bool result = predicate.Invoke(10);
        Console.WriteLine(result);

        // Predicate delegate with anonymous method
        Predicate<int> predicate2 = delegate (int number)
        {
            if (number % 2 == 0)
                return true;
            else
                return false;
        };
        bool result2 = predicate2.Invoke(10);
        Console.WriteLine(result2);

        // Predicate delegate with lambda expression
        Predicate<int> predicate3 = (number) =>
        {
            if (number % 2 == 0)
                return true;
            else
                return false;
        };

        bool result3 = predicate3.Invoke(10);
        Console.WriteLine(result3);

    }

    public static double AddNumbers(int num1, float num2)
    {
        return num1 + num2;
    }

    public static void PrintName()
    {
        Console.WriteLine("Shekh Ali");
    }

    public static void AddTwoNumbers(int num1, int num2)
    {
        Console.WriteLine(num1 + num2);
    }

    public static bool IsEvenNumber(int number)
    {
        if (number % 2 == 0)
            return true;
        else
            return false;
    }

}
