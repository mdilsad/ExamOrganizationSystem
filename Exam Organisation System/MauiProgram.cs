using Exam_Organisation_System.Services.Database;
using Exam_Organisation_System.ViewModels;
using Exam_Organisation_System.Views;
using Microsoft.Extensions.Logging;
using Exam_Organisation_System.Services;
using ZXing.Net.Maui.Controls;

namespace Exam_Organisation_System;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Cinzel-Regular.ttf", "CinzelRegular");
                fonts.AddFont("Cinzel-Bold.ttf", "CinzelBold");
            });
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<AppShell>();
        // Uygulama oturum bilgilerini (CurrentStudent ve SelectedExam) tutar.
        builder.Services.AddSingleton<SessionService>();
        builder.Services.AddSingleton<NavigationService>();
        builder.Services.AddSingleton<AuthenticationService>();
        builder.Services.AddSingleton<AppDatabase>();
        builder.Services.AddSingleton<DatabaseInitializer>();
        builder.Services.AddSingleton<StudentRepository>();
        builder.Services.AddSingleton<TeacherRepository>();
        builder.Services.AddSingleton<ExamRepository>();
        builder.Services.AddSingleton<AnnouncementRepository>();

        builder.Services.AddTransient<StudentLoginViewModel>();
        builder.Services.AddTransient<StudentLoginPage>();
        builder.Services.AddTransient<LoginSelectionViewModel>();
        builder.Services.AddTransient<LoginSelectionPage>();
        builder.Services.AddTransient<TeacherLoginViewModel>();
        builder.Services.AddTransient<TeacherLoginPage>();
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
        builder.Services.AddTransient<QrScannerPage>();
        builder.Services.AddTransient<SeatPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}