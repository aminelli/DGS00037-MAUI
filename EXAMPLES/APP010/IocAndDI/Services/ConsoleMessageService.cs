namespace DependencyInjectionDemo.Services;

/// <summary>
/// Implementazione concreta del servizio di messaggistica
/// </summary>
public class ConsoleMessageService : IMessageService
{
    public string GetMessage()
    {
        return "Messaggio dalla Console!";
    }
}
