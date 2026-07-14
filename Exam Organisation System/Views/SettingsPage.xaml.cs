using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }
    private void ThemeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Application.Current!.UserAppTheme =
            e.Value ? AppTheme.Dark : AppTheme.Light;
    }
}