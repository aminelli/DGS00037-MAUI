# Dependency Injection e Inversion of Control - Demo

Questo progetto dimostra i concetti fondamentali di **Dependency Injection (DI)** e **Inversion of Control (IoC)** in C#.

## Concetti Chiave

### Inversion of Control (IoC)
Il principio per cui il controllo del flusso del programma viene invertito: invece di essere il nostro codice a creare le dipendenze, è un framework esterno (IoC Container) che le crea e le fornisce.

### Dependency Injection (DI)
Il pattern di design che implementa l'IoC. Le dipendenze vengono "iniettate" negli oggetti invece di essere create al loro interno.

## Struttura del Progetto

```
Services/
├── IMessageService.cs       - Interfaccia per il servizio messaggi
├── ConsoleMessageService.cs - Implementazione concreta
├── ILogger.cs               - Interfaccia per il logging
├── SimpleLogger.cs          - Implementazione logger
├── IGreetingService.cs      - Servizio con dipendenze
└── GreetingService.cs       - Dimostra Constructor Injection

Program.cs                   - Configurazione e esempi
```

## Service Lifetimes

Il progetto dimostra tre tipi di lifetime:

1. **Transient**: Nuova istanza ad ogni richiesta (`AddTransient`)
2. **Scoped**: Una istanza per scope (`AddScoped`)
3. **Singleton**: Una sola istanza per l'intera applicazione (`AddSingleton`)

## Come Eseguire

```bash
dotnet run
```

## Cosa Imparerai

- Come configurare un IoC Container con `Microsoft.Extensions.DependencyInjection`
- Come registrare servizi con diversi lifetime
- Come il container risolve automaticamente le dipendenze
- I vantaggi di DI/IoC rispetto all'approccio tradizionale
- Constructor Injection pattern

## Esempi nel Codice

Il programma esegue 4 dimostrazioni:
1. Risoluzione base di un servizio
2. Differenze tra i vari lifetime
3. Dependency Injection a catena
4. Confronto con/senza DI
