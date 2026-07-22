// APP.XAML.CS
using Exam_Organisation_System.Views;
using Exam_Organisation_System.Services.Database;

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
        var databaseInitializer = _serviceProvider.GetRequiredService<DatabaseInitializer>();
        _ = Task.Run(async () => await databaseInitializer.InitializeAsync());
        var loginSelectionPage = _serviceProvider.GetRequiredService<LoginSelectionPage>();
        return new Window(new NavigationPage(loginSelectionPage));
    }
}