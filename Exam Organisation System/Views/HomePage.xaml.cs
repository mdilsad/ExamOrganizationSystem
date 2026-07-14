namespace Exam_Organisation_System.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnShowQrClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(FakeQrPage));
    }

    private async void OnExamDetailClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ExamDetailPage));
    }
}