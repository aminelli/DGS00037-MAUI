namespace DependencyInjectionDemo.Services;

/// <summary>
/// Servizio che riceve le sue dipendenze tramite Constructor Injection
/// Questo è l'esempio chiave della Dependency Injection
/// </summary>
public class GreetingService : IGreetingService
{
    private readonly IMessageService _messageService;
    private readonly ILogger _logger;

    // Constructor Injection: le dipendenze vengono iniettate tramite il costruttore
    // Non creiamo direttamente le istanze, ma le riceviamo dall'esterno (IoC Container)
    public GreetingService(IMessageService messageService, ILogger logger)
    {
        _messageService = messageService;
        _logger = logger;
    }

    public void Greet(string name)
    {
        var message = _messageService.GetMessage();
        var greeting = $"Ciao {name}! {message}";
        
        _logger.Log(greeting);
        Console.WriteLine(greeting);
    }
}
