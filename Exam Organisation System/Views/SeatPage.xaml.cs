using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class SeatPage : ContentPage
{
    public SeatPage(SeatViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}