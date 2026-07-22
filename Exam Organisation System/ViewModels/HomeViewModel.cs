using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Views;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Services.Database;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

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
        set
        {
            if (SetProperty(ref _nextExam, value))
            {
                OnPropertyChanged(nameof(HasExamToday));
                OnPropertyChanged(nameof(HasNoExamToday));
            }
        }
    }

    public bool HasExamToday => NextExam.Id > 0;

    public bool HasNoExamToday => !HasExamToday;

    public string CurrentDate =>
        DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("tr-TR"));

    private int _totalExamCount;
    public int TotalExamCount
    {
        get => _totalExamCount;
        set => SetProperty(ref _totalExamCount, value);
    }

    private int _completedExamCount;
    public int CompletedExamCount
    {
        get => _completedExamCount;
        set => SetProperty(ref _completedExamCount, value);
    }

    private int _upcomingExamCount;
    public int UpcomingExamCount
    {
        get => _upcomingExamCount;
        set => SetProperty(ref _upcomingExamCount, value);
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
            if (!HasExamToday)
                return;
            _sessionService.SelectedExam = NextExam;
            await _navigationService.GoToAsync(nameof(QrScannerPage));
        });

        OpenExamDetailCommand = new Command(async () =>
        {
            if (!HasExamToday)
                return;
            _sessionService.SelectedExam = NextExam;
            await _navigationService.GoToAsync(nameof(ExamDetailPage));
        });
    }

    private async Task LoadDataAsync()
    {
        var student = _sessionService.CurrentStudent;
        if (student != null)
        {
            Student = student;
            OnPropertyChanged(nameof(CurrentDate));
        }

        var exams = (await _examRepository.GetAllAsync()).ToList();

        TotalExamCount = exams.Count;
        CompletedExamCount = exams.Count(x => x.ExamDate < DateTime.Now);
        UpcomingExamCount = exams.Count(x => x.ExamDate >= DateTime.Now);

        var nextExam = exams
            .Where(x => x.ExamDate.Date == DateTime.Today)
            .Where(x => x.ExamDate >= DateTime.Now)
            .OrderBy(x => x.ExamDate)
            .FirstOrDefault();

        NextExam = nextExam ?? new Exam();
    }
}