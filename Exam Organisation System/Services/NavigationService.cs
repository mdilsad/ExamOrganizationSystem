using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Exam_Organisation_System.Views;

namespace Exam_Organisation_System.Services;

public class NavigationService
{
    private readonly AppShell _appShell;
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(AppShell appShell, IServiceProvider serviceProvider)
    {
        _appShell = appShell;
        _serviceProvider = serviceProvider;
    }

    public Task NavigateToShellAsync()
    {
        Application.Current!.Windows[0].Page = _appShell;
        return Task.CompletedTask;
    }

    public Task NavigateToLoginAsync()
    {
        var loginPage = _serviceProvider.GetRequiredService<LoginPage>();

        Application.Current!.Windows[0].Page =
            new NavigationPage(loginPage);

        return Task.CompletedTask;
    }

    public Task GoToAsync(string route)
    {
        return Shell.Current.GoToAsync(route);
    }

    public Task GoToAsync(string route, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(route, parameters);
    }

    public Task GoBackAsync()
    {
        return Shell.Current.GoToAsync("..");
    }

    public Task GoToRootAsync()
    {
        return Shell.Current.GoToAsync("//HomePage");
    }
}