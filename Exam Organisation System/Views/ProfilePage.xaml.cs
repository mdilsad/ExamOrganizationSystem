using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}