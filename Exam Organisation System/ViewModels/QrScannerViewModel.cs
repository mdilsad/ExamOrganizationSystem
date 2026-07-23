using Exam_Organisation_System.Views;
using System.Threading.Tasks;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Services.Database;

namespace Exam_Organisation_System.ViewModels;

public class QrScannerViewModel : BaseViewModel
{
    protected readonly ExamRepository _examRepository;
    protected readonly SeatRepository _seatRepository;
    protected readonly StudentRepository _studentRepository;
    protected readonly SessionService _sessionService;
    protected readonly NavigationService _navigationService;

    public QrScannerViewModel(
        ExamRepository examRepository,
        SeatRepository seatRepository,
        StudentRepository studentRepository,
        SessionService sessionService,
        NavigationService navigationService)
    {
        _examRepository = examRepository;
        _seatRepository = seatRepository;
        _studentRepository = studentRepository;
        _sessionService = sessionService;
        _navigationService = navigationService;
    }

    public async Task OnBarcodeDetected(string qrValue)
    {
        if (!int.TryParse(qrValue, out int classroomId))
        {
            await Shell.Current.DisplayAlert("Hata", "Geçersiz QR kodu.", "Tamam");
            return;
        }

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

        var upcomingExam = await _examRepository.GetUpcomingExamByStudentAsync(student.Id);

        if (upcomingExam is null)
        {
            await Shell.Current.DisplayAlert("Bilgi", "Yaklaşan sınavınız bulunamadı.", "Tamam");
            return;
        }

        if (exam.Id != upcomingExam.Id)
        {
            await Shell.Current.DisplayAlert(
                "Hata",
                "Bu QR kod şu anki sınavınız için geçerli değildir.",
                "Tamam");
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

        await _navigationService.GoToAndRemoveCurrentAsync(nameof(SeatPage));
    }
}