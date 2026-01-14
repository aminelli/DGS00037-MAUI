namespace DependencyInjectionDemo.Services;

/// <summary>
/// Servizio che dipende da altri servizi (dimostrazione di DI a catena)
/// </summary>
public interface IGreetingService
{
    void Greet(string name);
}
