using System.Collections.ObjectModel;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System.ViewModels;

public class ExamsViewModel : BaseViewModel
{
    private readonly FakeDataService _fakeDataService;

    public ObservableCollection<Exam> Exams { get; }

    public ExamsViewModel(FakeDataService fakeDataService)
    {
        _fakeDataService = fakeDataService;

        Exams = new ObservableCollection<Exam>(_fakeDataService.GetExams());
    }
}