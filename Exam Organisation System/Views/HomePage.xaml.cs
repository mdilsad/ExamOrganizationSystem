using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}