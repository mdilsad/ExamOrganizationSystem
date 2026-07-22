using System.Windows.Input;
using Microsoft.Maui.Controls;
using Exam_Organisation_System.Services;
using Exam_Organisation_System.Views;

namespace Exam_Organisation_System.ViewModels;

public class LoginSelectionViewModel : BaseViewModel
{
    private readonly NavigationService _navigationService;

    public ICommand StudentLoginCommand { get; }
    public ICommand TeacherLoginCommand { get; }

    public LoginSelectionViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        StudentLoginCommand = new Command(async () => await _navigationService.GoToAsync(nameof(StudentLoginPage)));
        TeacherLoginCommand = new Command(async () => await _navigationService.GoToAsync(nameof(TeacherLoginPage)));
    }
}