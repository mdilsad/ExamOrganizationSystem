using Microsoft.Extensions.Logging;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System;

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
                fonts.AddFont("Cinzel-Regular.ttf", "CinzelRegular");
                fonts.AddFont("Cinzel-Bold.ttf", "CinzelBold");
            });

        // Şimdilik sadece FakeDataService kullanıyoruz.
        builder.Services.AddSingleton<FakeDataService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}