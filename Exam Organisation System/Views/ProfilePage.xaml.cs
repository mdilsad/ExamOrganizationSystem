using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }
    private void LogoffClicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new NavigationPage(new LoginPage());
    }
}