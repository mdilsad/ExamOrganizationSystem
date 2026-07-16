using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Views;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly FakeDataService _fakeDataService;
    private readonly NavigationService _navigationService;
    
    public ICommand ShowQrCommand { get; }
    public ICommand OpenExamDetailCommand { get; }
    
    private Student _student = new();
    public Student Student
    {
        get => _student;
        set => SetProperty(ref _student, value);
    }

    private Exam _nextExam = new();
    public Exam NextExam
    {
        get => _nextExam;
        set => SetProperty(ref _nextExam, value);
    }

    public HomeViewModel(FakeDataService fakeDataService, NavigationService navigationService)
    {
        _fakeDataService = fakeDataService;
        _navigationService = navigationService;
        Student = _fakeDataService.GetStudent();
        NextExam = _fakeDataService
            .GetExams()
            .OrderBy(x => x.ExamDate)
            .First();
        ShowQrCommand = new Command(async () =>
            await _navigationService.GoToAsync(nameof(FakeQrPage)));

        OpenExamDetailCommand = new Command(async () =>
            await _navigationService.GoToAsync(nameof(ExamDetailPage)));
    }
}