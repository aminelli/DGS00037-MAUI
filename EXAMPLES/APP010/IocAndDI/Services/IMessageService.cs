namespace DependencyInjectionDemo.Services;

/// <summary>
/// Interfaccia per il servizio di messaggistica
/// Questo è un esempio di astrazione - la parte chiave dell'IoC
/// </summary>
public interface IMessageService
{
    string GetMessage();
}
