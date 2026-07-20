using Exam_Organisation_System.Views;
namespace Exam_Organisation_System;

public partial class AppShell : Shell
{

    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ExamDetailPage), typeof(ExamDetailPage));
        Routing.RegisterRoute(nameof(FakeQrPage), typeof(FakeQrPage));
        Routing.RegisterRoute(nameof(SeatPage), typeof(SeatPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
    }
}