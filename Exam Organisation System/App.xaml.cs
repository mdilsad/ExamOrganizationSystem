using Microsoft.Extensions.DependencyInjection;

namespace Exam_Organisation_System;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new Views.LoginPage()));
    }
}