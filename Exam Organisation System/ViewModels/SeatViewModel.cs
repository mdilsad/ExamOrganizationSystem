using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Services.Database;
namespace Exam_Organisation_System.ViewModels;

public class SeatViewModel : BaseViewModel
{
    private readonly SessionService _sessionService;
    private readonly NavigationService _navigationService;


    private Seat? _seat;
    public Seat? Seat
    {
        get => _seat;
        set => SetProperty(ref _seat, value);
    }

    private Exam? _selectedExam;
    public Exam? SelectedExam
    {
        get => _selectedExam;
        set => SetProperty(ref _selectedExam, value);
    }

    private string _statusMessage = string.Empty;
    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            if (SetProperty(ref _statusMessage, value))
            {
                OnPropertyChanged(nameof(HasStatusMessage));
            }
        }
    }

    public bool HasStatusMessage => !string.IsNullOrWhiteSpace(StatusMessage);

    public ICommand BackToHomeCommand { get; }

    public SeatViewModel(
        SessionService sessionService,
        NavigationService navigationService)
    {
        _sessionService = sessionService;
        _navigationService = navigationService;

        BackToHomeCommand = new Command(async () =>
            await _navigationService.GoToRootAsync());
    }

    public async Task LoadSeatAsync()
    {
        SelectedExam = _sessionService.SelectedExam;
        Seat = _sessionService.SelectedSeat;

        StatusMessage = Seat == null
            ? "Oturma bilgisi bulunamadı."
            : string.Empty;
    }
}