using Exam_Organisation_System.Views;
namespace Exam_Organisation_System;

public partial class AppShell : Shell
{

    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ExamDetailPage), typeof(ExamDetailPage));
        Routing.RegisterRoute(nameof(QrScannerPage), typeof(QrScannerPage));
        Routing.RegisterRoute(nameof(SeatPage), typeof(SeatPage));
        Routing.RegisterRoute(nameof(StudentLoginPage), typeof(StudentLoginPage));
        Routing.RegisterRoute(nameof(TeacherLoginPage), typeof(TeacherLoginPage));
        Routing.RegisterRoute(nameof(LoginSelectionPage), typeof(LoginSelectionPage));
        Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
    }
}