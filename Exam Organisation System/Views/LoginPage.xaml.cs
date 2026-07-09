using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        if (StudentNumberEntry.Text == null && PasswordEntry.Text == null)
        {
            Application.Current!.Windows[0].Page = new AppShell();
            return;
        }
        
        await DisplayAlert(
            "Hata",
            "Öğrenci numarası veya şifre yanlış.",
            "Tamam");
    }
}