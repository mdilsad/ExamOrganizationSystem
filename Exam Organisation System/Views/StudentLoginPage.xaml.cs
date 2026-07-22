using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class StudentLoginPage : ContentPage
{
    public StudentLoginPage(StudentLoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}