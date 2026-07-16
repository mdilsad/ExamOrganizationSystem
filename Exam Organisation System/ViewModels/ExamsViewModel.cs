using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Views;
using System.Collections.ObjectModel;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System.ViewModels;

public class ExamsViewModel : BaseViewModel
{
    private readonly FakeDataService _fakeDataService;
    private readonly NavigationService _navigationService;

    public ObservableCollection<Exam> Exams { get; }

    public ICommand OpenExamDetailCommand { get; }

    public ExamsViewModel(FakeDataService fakeDataService, NavigationService navigationService)
    {
        _fakeDataService = fakeDataService;
        _navigationService = navigationService;

        Exams = new ObservableCollection<Exam>(_fakeDataService.GetExams());
        OpenExamDetailCommand = new Command<Exam>(async exam =>
        {
            if (exam is null)
                return;

            _fakeDataService.SelectedExam = exam;
            await _navigationService.GoToAsync(nameof(ExamDetailPage));
        });
    }
}