using Exam_Organisation_System.Models;
namespace Exam_Organisation_System.Services;

public class FakeAnnouncementService
{
    private readonly List<Announcement> _announcements;

    public FakeAnnouncementService()
    {
        _announcements =
        [
            new Announcement
            {
                Title = "Final Sınav Programı",
                Content = "2025-2026 Bahar Dönemi final sınav programı yayımlandı.",
                PublishDate = DateTime.Today
            },
            new Announcement
            {
                Title = "Sınav Giriş Belgeleri",
                Content = "Sınav giriş belgelerinizi öğrenci bilgi sistemi üzerinden indirebilirsiniz.",
                PublishDate = DateTime.Today.AddDays(-1)
            }
        ];
    }

    public List<Announcement> GetAnnouncements()
    {
        return _announcements;
    }
}