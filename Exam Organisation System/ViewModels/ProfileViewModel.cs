using Exam_Organisation_System.Views;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Services;
using System.Threading.Tasks;

namespace Exam_Organisation_System.ViewModels;

public class ProfileViewModel : BaseViewModel
{
    private readonly NavigationService _navigationService;

    public ICommand LogoutCommand { get; }

    public ProfileViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;

        LogoutCommand = new Command(async () => await LogoutAsync());
    }

    private async Task LogoutAsync()
    {
        await _navigationService.NavigateToLoginAsync();
    }
}