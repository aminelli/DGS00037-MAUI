namespace DependencyInjectionDemo.Services;

/// <summary>
/// Implementazione semplice del logger
/// </summary>
public class SimpleLogger : ILogger
{
    private readonly Guid _instanceId;

    public SimpleLogger()
    {
        _instanceId = Guid.NewGuid();
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG {_instanceId:N}] {DateTime.Now:HH:mm:ss} - {message}");
    }
}
