using Exam_Organisation_System.ViewModels;
using Exam_Organisation_System.Views;
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
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<AppShell>();
        // Şimdilik sadece FakeDataService kullanıyoruz.
        builder.Services.AddSingleton<FakeDataService>();
        builder.Services.AddSingleton<NavigationService>();
        builder.Services.AddSingleton<AuthenticationService>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ExamsViewModel>();
        builder.Services.AddTransient<ExamDetailViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<ExamsPage>();
        builder.Services.AddTransient<ExamDetailPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<FakeQrViewModel>();
        builder.Services.AddTransient<SeatViewModel>();
        builder.Services.AddTransient<FakeQrPage>();
        builder.Services.AddTransient<SeatPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}