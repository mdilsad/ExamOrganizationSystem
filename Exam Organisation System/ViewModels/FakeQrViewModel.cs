using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Views;
using Exam_Organisation_System.Services.Database;

namespace Exam_Organisation_System.ViewModels;

public class FakeQrViewModel : BaseViewModel
{
    private readonly SessionService _sessionService;
    private readonly NavigationService _navigationService;
    private readonly ExamRepository _examRepository;
    private readonly SeatRepository _seatRepository;

    public ICommand ScanCommand { get; }

    public FakeQrViewModel(
        SessionService sessionService,
        NavigationService navigationService,
        ExamRepository examRepository,
        SeatRepository seatRepository)
    {
        _sessionService = sessionService;
        _navigationService = navigationService;
        _examRepository = examRepository;
        _seatRepository = seatRepository;

        ScanCommand = new Command(async () =>
        {
            int classroomId = 2309;

            var exam = await _examRepository.GetUpcomingExamByClassroomAsync(classroomId);

            if (exam is null)
            {
                await Shell.Current.DisplayAlert("Bilgi", "Bu sınıfta size ait yaklaşan bir sınav bulunamadı.", "Tamam");
                return;
            }

            var student = _sessionService.CurrentStudent;

            if (student is null)
            {
                await Shell.Current.DisplayAlert("Hata", "Öğrenci oturumu bulunamadı.", "Tamam");
                return;
            }
            var seat = await _seatRepository.GetSeatAsync(student.Id, exam.Id, classroomId);
            if (seat is null)
            {
                await Shell.Current.DisplayAlert("Bilgi", "Oturma bilgisi bulunamadı.", "Tamam");
                return;
            }

            _sessionService.SelectedExam = exam;
            _sessionService.SelectedSeat = seat;
            _sessionService.ExamId = exam.Id;
            _sessionService.ClassroomId = classroomId;

            await _navigationService.GoToAsync(nameof(SeatPage));
        });
    }
}