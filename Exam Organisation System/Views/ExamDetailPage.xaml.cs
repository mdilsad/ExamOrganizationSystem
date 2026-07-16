namespace Exam_Organisation_System.Views;

using Exam_Organisation_System.ViewModels;

public partial class ExamDetailPage : ContentPage
{
    public ExamDetailPage(ExamDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}