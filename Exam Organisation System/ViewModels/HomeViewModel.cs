using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly FakeDataService _fakeDataService;
    
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

    public HomeViewModel(FakeDataService fakeDataService)
    {
        _fakeDataService = fakeDataService;
        Student = _fakeDataService.GetStudent();
        NextExam = _fakeDataService
            .GetExams()
            .OrderBy(x => x.ExamDate)
            .First();
    }
}