using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== DIMOSTRAZIONE DEPENDENCY INJECTION E INVERSION OF CONTROL ===\n");

        // Creazione del Service Container (IoC Container)
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Registrazione dei servizi nel container
                // Questo è l'Inversion of Control: il container gestisce la creazione degli oggetti
                
                Console.WriteLine("Configurazione del Service Container...\n");
                
                // Transient: una nuova istanza ogni volta che viene richiesta
                services.AddTransient<ILogger, SimpleLogger>();
                
                // Singleton: una sola istanza condivisa per tutta l'applicazione
                services.AddSingleton<IMessageService, ConsoleMessageService>();
                
                // Scoped: una istanza per scope (utile nelle web app)
                services.AddScoped<IGreetingService, GreetingService>();
            })
            .Build();

        Console.WriteLine("=== ESEMPIO 1: Risoluzione semplice ===");
        DemoBasicResolution(host.Services);

        Console.WriteLine("\n=== ESEMPIO 2: Lifetime dei servizi ===");
        DemoServiceLifetimes(host.Services);

        Console.WriteLine("\n=== ESEMPIO 3: Dependency Injection a catena ===");
        DemoChainedDependencies(host.Services);

        Console.WriteLine("\n=== ESEMPIO 4: Confronto con approccio tradizionale (senza DI) ===");
        DemoWithoutDI();

        Console.WriteLine("\n\nPremi un tasto per uscire...");
        Console.ReadKey();
    }

    static void DemoBasicResolution(IServiceProvider serviceProvider)
    {
        // Richiediamo un servizio al container
        var messageService = serviceProvider.GetRequiredService<IMessageService>();
        Console.WriteLine($"Messaggio ottenuto: {messageService.GetMessage()}");
    }

    static void DemoServiceLifetimes(IServiceProvider serviceProvider)
    {
        Console.WriteLine("Transient (ILogger): ogni richiesta crea una nuova istanza");
        var logger1 = serviceProvider.GetRequiredService<ILogger>();
        var logger2 = serviceProvider.GetRequiredService<ILogger>();
        logger1.Log("Prima istanza");
        logger2.Log("Seconda istanza");
        Console.WriteLine("Nota: gli ID delle istanze sono diversi!\n");

        Console.WriteLine("Singleton (IMessageService): sempre la stessa istanza");
        var msg1 = serviceProvider.GetRequiredService<IMessageService>();
        var msg2 = serviceProvider.GetRequiredService<IMessageService>();
        Console.WriteLine($"msg1 == msg2? {ReferenceEquals(msg1, msg2)}");
    }

    static void DemoChainedDependencies(IServiceProvider serviceProvider)
    {
        // Creiamo uno scope per dimostrare il lifetime Scoped
        using var scope = serviceProvider.CreateScope();
        
        // Il container risolve automaticamente tutte le dipendenze
        // GreetingService richiede IMessageService e ILogger
        // Il container li crea automaticamente e li inietta
        var greetingService = scope.ServiceProvider.GetRequiredService<IGreetingService>();
        
        Console.WriteLine("Il GreetingService ha ricevuto automaticamente:");
        Console.WriteLine("- IMessageService (Singleton)");
        Console.WriteLine("- ILogger (Transient)\n");
        
        greetingService.Greet("Mario");
        greetingService.Greet("Luigi");
    }

    static void DemoWithoutDI()
    {
        Console.WriteLine("SENZA Dependency Injection (tight coupling):");
        Console.WriteLine("class GreetingService {");
        Console.WriteLine("    public GreetingService() {");
        Console.WriteLine("        _messageService = new ConsoleMessageService(); // Dipendenza diretta!");
        Console.WriteLine("        _logger = new SimpleLogger();                  // Dipendenza diretta!");
        Console.WriteLine("    }");
        Console.WriteLine("}\n");
        
        Console.WriteLine("CON Dependency Injection (loose coupling):");
        Console.WriteLine("class GreetingService {");
        Console.WriteLine("    public GreetingService(IMessageService messageService, ILogger logger) {");
        Console.WriteLine("        _messageService = messageService; // Ricevuto dall'esterno!");
        Console.WriteLine("        _logger = logger;                 // Ricevuto dall'esterno!");
        Console.WriteLine("    }");
        Console.WriteLine("}\n");
        
        Console.WriteLine("VANTAGGI:");
        Console.WriteLine("✓ Testabilità: possiamo iniettare mock/stub nei test");
        Console.WriteLine("✓ Flessibilità: possiamo cambiare implementazione senza modificare il codice");
        Console.WriteLine("✓ Manutenibilità: le dipendenze sono esplicite e chiare");
        Console.WriteLine("✓ Riusabilità: il codice non è legato a implementazioni specifiche");
    }
}
