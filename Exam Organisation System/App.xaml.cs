// APP.XAML.CS
using Exam_Organisation_System.Views;

namespace Exam_Organisation_System;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        // 1. İlk olarak App.xaml'i ve tüm ResourceDictionary kaynaklarını yükle!
        InitializeComponent();
        
        _serviceProvider = serviceProvider;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // 2. Kaynaklar artık tamamen bellekte yüklendi. 
        // Şimdi LoginPage'i güvenle çağırıp pencereyi oluşturabiliriz.
        var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
        return new Window(new NavigationPage(loginPage));
    }
}