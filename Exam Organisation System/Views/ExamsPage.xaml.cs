using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class ExamsPage : ContentPage
{
    public ExamsPage(ExamsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}