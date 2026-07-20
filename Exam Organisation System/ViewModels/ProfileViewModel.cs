using Exam_Organisation_System.Views;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Services;
using System.Threading.Tasks;
using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.ViewModels;

public class ProfileViewModel : BaseViewModel
{
    private readonly NavigationService _navigationService;
    private readonly SessionService _sessionService;

    public Student CurrentStudent { get; }

    public ICommand LogoutCommand { get; }

    public ProfileViewModel(NavigationService navigationService, SessionService sessionService)
    {
        _navigationService = navigationService;
        _sessionService = sessionService;
        CurrentStudent = _sessionService.CurrentStudent ?? new Student();

        LogoutCommand = new Command(async () => await LogoutAsync());
    }

    public string StudentNumberText => $"Numara: {CurrentStudent.StudentNumber}";
    public string FacultyText => $"Fakülte: Mühendislik Fakültesi";
    public string DepartmentText => $"Bölüm: {CurrentStudent.Department}";
    public string EmailText => $"E-posta: {CurrentStudent.Email}";

    private async Task LogoutAsync()
    {
        await _navigationService.NavigateToLoginAsync();
    }
}