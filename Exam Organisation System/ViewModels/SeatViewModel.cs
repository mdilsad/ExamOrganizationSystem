using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
namespace Exam_Organisation_System.ViewModels;

public class SeatViewModel : BaseViewModel
{
    private readonly SessionService _sessionService;
    private readonly NavigationService _navigationService;

    private Exam _selectedExam = new();
    public Exam SelectedExam
    {
        get => _selectedExam;
        set => SetProperty(ref _selectedExam, value);
    }

    public ICommand BackToHomeCommand { get; }

    public SeatViewModel(
        SessionService sessionService,
        NavigationService navigationService)
    {
        _sessionService = sessionService;
        _navigationService = navigationService;

        SelectedExam = _sessionService.SelectedExam ?? new Exam();

        BackToHomeCommand = new Command(async () =>
            await _navigationService.GoToRootAsync());
    }
}