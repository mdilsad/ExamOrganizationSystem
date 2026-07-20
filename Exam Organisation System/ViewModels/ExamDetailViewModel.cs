using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Views;
namespace Exam_Organisation_System.ViewModels;

public class ExamDetailViewModel : BaseViewModel
{
    private readonly SessionService _sessionService;
    private readonly NavigationService _navigationService;

    private Exam _selectedExam = new();
    public Exam SelectedExam
    {
        get => _selectedExam;
        set => SetProperty(ref _selectedExam, value);
    }

    public ICommand ShowQrCommand { get; }

    public ExamDetailViewModel(
        SessionService sessionService,
        NavigationService navigationService)
    {
        _sessionService = sessionService;
        SelectedExam = _sessionService.SelectedExam ?? new Exam();
        _navigationService = navigationService;

        ShowQrCommand = new Command(async () =>
            await _navigationService.GoToAsync(nameof(FakeQrPage)));
    }
}