using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Views;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Services.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Organisation_System.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly ExamRepository _examRepository;
    private readonly StudentRepository _studentRepository;
    private readonly NavigationService _navigationService;
    private readonly SessionService _sessionService;
    
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

    public HomeViewModel(
        ExamRepository examRepository,
        StudentRepository studentRepository,
        NavigationService navigationService,
        SessionService sessionService)
    {
        _examRepository = examRepository;
        _studentRepository = studentRepository;
        _navigationService = navigationService;
        _sessionService = sessionService;
        _ = LoadDataAsync();
        ShowQrCommand = new Command(async () =>
        {
            _sessionService.SelectedExam = NextExam;
            await _navigationService.GoToAsync(nameof(FakeQrPage));
        });

        OpenExamDetailCommand = new Command(async () =>
        {
            _sessionService.SelectedExam = NextExam;
            await _navigationService.GoToAsync(nameof(ExamDetailPage));
        });
    }

    private async Task LoadDataAsync()
    {
        var student = (await _studentRepository.GetAllAsync()).FirstOrDefault();
        if (student != null)
            Student = student;

        var nextExam = (await _examRepository.GetAllAsync())
            .OrderBy(x => x.ExamDate)
            .FirstOrDefault();

        if (nextExam != null)
            NextExam = nextExam;
    }
}