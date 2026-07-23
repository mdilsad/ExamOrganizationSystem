using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Views;
using System.Collections.ObjectModel;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Services.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace Exam_Organisation_System.ViewModels;

public class ExamsViewModel : BaseViewModel
{
    private readonly ExamRepository _examRepository;
    private readonly NavigationService _navigationService;
    private readonly SessionService _sessionService;

    public ObservableCollection<Exam> Exams { get; }

    public ICommand OpenExamDetailCommand { get; }

    public ExamsViewModel(
        ExamRepository examRepository,
        NavigationService navigationService,
        SessionService sessionService)
    {
        _examRepository = examRepository;
        _navigationService = navigationService;
        _sessionService = sessionService;

        Exams = new ObservableCollection<Exam>();
        _ = LoadExamsAsync();

        OpenExamDetailCommand = new Command<Exam>(async exam =>
        {
            if (exam is null)
                return;

            _sessionService.SelectedExam = exam;
            _sessionService.ShowQrButton = false;

            await _navigationService.GoToAsync(nameof(ExamDetailPage));
        });
    }

    private async Task LoadExamsAsync()
    {
        var exams = (await _examRepository.GetAllAsync())
            .OrderBy(e => e.ExamDate)
            .ToList();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Exams.Clear();
            foreach (var exam in exams)
                Exams.Add(exam);
        });
    }
}