using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Views;
using System.Collections.ObjectModel;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using System.Collections.Generic;

namespace Exam_Organisation_System.ViewModels;

public class ExamsViewModel : BaseViewModel
{
    private readonly FakeExamService _fakeExamService;
    private readonly FakeDataService _fakeDataService;
    private readonly NavigationService _navigationService;

    public ObservableCollection<Exam> Exams { get; }

    public ICommand OpenExamDetailCommand { get; }

    public ExamsViewModel(
        FakeExamService fakeExamService,
        FakeDataService fakeDataService,
        NavigationService navigationService)
    {
        _fakeExamService = fakeExamService;
        _fakeDataService = fakeDataService;
        _navigationService = navigationService;

        Exams = new ObservableCollection<Exam>(_fakeExamService.GetExams());
        OpenExamDetailCommand = new Command<Exam>(async exam =>
        {
            if (exam is null)
                return;

            await _navigationService.GoToAsync(
                nameof(ExamDetailPage),
                new Dictionary<string, object>
                {
                    ["ExamId"] = exam.Id
                });
        });
    }
}