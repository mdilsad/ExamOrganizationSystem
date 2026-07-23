using Exam_Organisation_System.Services;
using Exam_Organisation_System.ViewModels;

namespace Exam_Organisation_System.Views;

public partial class SeatPage : ContentPage
{
    private readonly SeatViewModel _viewModel;

    public SeatPage(SeatViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadSeatAsync();
    }
}