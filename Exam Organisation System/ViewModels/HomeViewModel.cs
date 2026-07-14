using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System.ViewModels;

public class HomeViewModel
{
    private readonly FakeDataService _fakeDataService;

    public Student Student { get; }

    public Exam NextExam { get; }

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