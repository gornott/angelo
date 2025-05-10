using Microsoft.Extensions.Logging;
using FiveCast.Services;

namespace FiveCast
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register services
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AppShell>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
