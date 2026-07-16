using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}