using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services.Database;
using Microsoft.Maui.ApplicationModel;

namespace Exam_Organisation_System.ViewModels;

public class AnnouncementsViewModel : BaseViewModel
{
    private readonly AnnouncementRepository _announcementRepository;

    public ObservableCollection<Announcement> Announcements { get; }

    public AnnouncementsViewModel(AnnouncementRepository announcementRepository)
    {
        _announcementRepository = announcementRepository;

        Announcements = new ObservableCollection<Announcement>();
        _ = LoadAnnouncementsAsync();
    }

    private async Task LoadAnnouncementsAsync()
    {
        var announcements = await _announcementRepository.GetAllAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Announcements.Clear();
            foreach (var announcement in announcements)
                Announcements.Add(announcement);
        });
    }
}