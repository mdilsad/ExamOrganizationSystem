using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
namespace Exam_Organisation_System.ViewModels;

public class SeatViewModel : BaseViewModel
{
    private readonly FakeDataService _fakeDataService;
    private readonly NavigationService _navigationService;

    private Exam _selectedExam = new();
    public Exam SelectedExam
    {
        get => _selectedExam;
        set => SetProperty(ref _selectedExam, value);
    }

    public ICommand BackToHomeCommand { get; }

    public SeatViewModel(
        FakeDataService fakeDataService,
        NavigationService navigationService)
    {
        _fakeDataService = fakeDataService;
        _navigationService = navigationService;

        SelectedExam = _fakeDataService.SelectedExam ?? new Exam();

        BackToHomeCommand = new Command(async () =>
            await _navigationService.GoToRootAsync());
    }
}