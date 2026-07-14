using Exam_Organisation_System.Services;
using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.Views;

public partial class ExamsPage : ContentPage
{
    private readonly FakeDataService _fakeDataService;

    public ExamsPage()
    {
        InitializeComponent();

        _fakeDataService = FakeDataService.Instance;
        ExamCollection.ItemsSource = _fakeDataService.GetExams();
    }

    private async void OnExamDetailClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var exam = (Exam)button.BindingContext;
        _fakeDataService.SelectedExam = exam;
        await Shell.Current.GoToAsync(nameof(ExamDetailPage));
    }
}