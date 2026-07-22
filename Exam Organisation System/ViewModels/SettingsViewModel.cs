using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Microsoft.Maui.Storage;

namespace Exam_Organisation_System.ViewModels;

public class SettingsViewModel : BaseViewModel
{
    public ObservableCollection<string> ThemeOptions { get; } =
        new ObservableCollection<string>
        {
            "Sistem",
            "Açık",
            "Koyu"
        };

    private string _selectedTheme = "Sistem";

    public string SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            if (SetProperty(ref _selectedTheme, value))
            {
                Preferences.Default.Set("AppTheme", value);

                Application.Current!.UserAppTheme = value switch
                {
                    "Açık" => AppTheme.Light,
                    "Koyu" => AppTheme.Dark,
                    _ => AppTheme.Unspecified
                };
            }
        }
    }

    public SettingsViewModel()
    {
        var savedTheme = Preferences.Default.Get("AppTheme", "Sistem");

        Application.Current!.UserAppTheme = savedTheme switch
        {
            "Açık" => AppTheme.Light,
            "Koyu" => AppTheme.Dark,
            _ => AppTheme.Unspecified
        };

        _selectedTheme = savedTheme;
        OnPropertyChanged(nameof(SelectedTheme));
    }
}