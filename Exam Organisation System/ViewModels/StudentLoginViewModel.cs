using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System.ViewModels;

public class StudentLoginViewModel : BaseViewModel
{
    private readonly NavigationService _navigationService;
    private readonly AuthenticationService _authenticationService;
    private readonly SessionService _sessionService;

    private string _studentNumber = string.Empty;
    public string StudentNumber
    {
        get => _studentNumber;
        set => SetProperty(ref _studentNumber, value);
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public ICommand LoginCommand { get; }

    public StudentLoginViewModel(
        NavigationService navigationService,
        AuthenticationService authenticationService,
        SessionService sessionService)
    {
        _navigationService = navigationService;
        _authenticationService = authenticationService;
        _sessionService = sessionService;
        LoginCommand = new Command(async () => await LoginAsync());
    }

    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(StudentNumber) || string.IsNullOrWhiteSpace(Password))
        {
            await Application.Current!.Windows[0].Page.DisplayAlert(
                "Hata",
                "Öğrenci numarası ve şifre giriniz.",
                "Tamam");
            return;
        }

        if (!await _authenticationService.LoginAsync(StudentNumber, Password))
        {
            await Application.Current!.Windows[0].Page.DisplayAlert(
                "Hata",
                "Kullanıcı adı veya şifre hatalı.",
                "Tamam");
            return;
        }

        await _navigationService.NavigateToShellAsync();
    }
}