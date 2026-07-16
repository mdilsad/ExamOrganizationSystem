using Microsoft.Maui.Controls;
namespace Exam_Organisation_System.Views;

using Exam_Organisation_System.ViewModels;

// Enable Shell query parameter support for "ExamId"
[QueryProperty(nameof(ExamId), "ExamId")]
public partial class ExamDetailPage : ContentPage
{
    public int ExamId
    {
        set
        {
            if (BindingContext is ExamDetailViewModel vm)
            {
                vm.LoadExam(value);
            }
        }
    }

    public ExamDetailPage(ExamDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}