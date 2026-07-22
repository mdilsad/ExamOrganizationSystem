using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Services;

namespace Exam_Organisation_System.ViewModels;

public class TeacherLoginViewModel : BaseViewModel
{
    private readonly NavigationService _navigationService;
    private readonly AuthenticationService _authenticationService;

    private string _username = string.Empty;
    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public ICommand LoginCommand { get; }

    public TeacherLoginViewModel(
        NavigationService navigationService,
        AuthenticationService authenticationService)
    {
        _navigationService = navigationService;
        _authenticationService = authenticationService;
        LoginCommand = new Command(async () => await LoginAsync());
    }

    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await Application.Current!.Windows[0].Page.DisplayAlert(
                "Hata",
                "Kullanıcı adı ve şifre giriniz.",
                "Tamam");
            return;
        }

        if (!await _authenticationService.TeacherLoginAsync(Username, Password))
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