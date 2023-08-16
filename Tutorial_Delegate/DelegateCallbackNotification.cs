namespace Tutorial_Delegate;


public delegate void MyDelegateCallback(int num);

class DelegateCallBack
{
    public static void LongRunningMethod(MyDelegateCallback myDelegate)
    {
        for (int num = 1; num <= 5; num++)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            myDelegate(num);
        }
    }
}

/// <summary>
/// Example: Callback notification using C# delegate
/// 다음 선언은 대리자를 사용하여 콜백 알림을 선언하는 방법을 보여줍니다.
/// </summary>
internal class DelegateCallbackNotification
{

    public DelegateCallbackNotification()
    {
        DelegateCallBack.LongRunningMethod(Print);

        Console.ReadLine();
    }

    public static void Print(int number)
    {
        Console.WriteLine($" num : {number}");

    }
}

