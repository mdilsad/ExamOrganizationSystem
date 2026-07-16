using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Exam_Organisation_System.ViewModels;

public class SettingsViewModel : BaseViewModel
{
    private bool _isDarkMode;
    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (SetProperty(ref _isDarkMode, value))
            {
                Application.Current!.UserAppTheme =
                    value ? AppTheme.Dark : AppTheme.Light;
            }
        }
    }

    public SettingsViewModel()
    {
        IsDarkMode = Application.Current?.UserAppTheme == AppTheme.Dark;
    }
}