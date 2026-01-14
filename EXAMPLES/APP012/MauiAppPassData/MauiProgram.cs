using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace MauiAppPassData;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            
            ;

        // Registrazione Servizi
        builder.Services.AddSingleton<Services.IDataService, Services.DataService>();

        // Registrazione Pagine per DI
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ServicePage>();
        builder.Services.AddTransient<ServiceDetailPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}