namespace Tutorial_MulticastDelegate;


/// <summary>
/// 멀티캐스트(delegate) 델리게이트는 C#에서 한 개 이상의 메서드를 동시에 호출
/// https://www.notion.so/krdn/Delegate-f405a171a41e462ca433bc2bd9bccba9
/// </summary>
internal class Program
{
    public delegate void MyDelegate(string message);

    static void Main(string[] args)
    {
        
        MyDelegate myDelegate = Method1;
        myDelegate += Method2;
        myDelegate += Method3;

        myDelegate("Hello, multicast delegates!");

        Console.ReadLine();
    }

    static void Method1(string message)
    {
        Console.WriteLine("Method 1: " + message);
    }

    static void Method2(string message)
    {
        Console.WriteLine("Method 2: " + message);
    }

    static void Method3(string message)
    {
        Console.WriteLine("Method 3: " + message);
    }
}
