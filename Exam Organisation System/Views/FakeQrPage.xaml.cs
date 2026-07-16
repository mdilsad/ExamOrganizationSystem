using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class FakeQrPage : ContentPage
{
    public FakeQrPage(FakeQrViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
