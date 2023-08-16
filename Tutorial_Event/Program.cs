using Tutorial_Event;

internal class Program
{
    /// <summary>
    /// https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/events/
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        //_ = new EventPublisherSubscriber();
        //_ = new DelegateEventHandler();



        // .NET 지침을 따르는 이벤트를 게시하는 방법
        _ = new EventHandlerPattern();



        // 파생 클래스에서 기본 클래스 이벤트를 발생하는 방법




    }
}
