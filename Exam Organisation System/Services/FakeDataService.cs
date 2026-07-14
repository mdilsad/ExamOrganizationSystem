using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.Services;

public class FakeDataService
{
    public static FakeDataService Instance { get; } = new FakeDataService();

    private readonly List<Exam> _exams;
    private readonly Student _student;
    private readonly List<Announcement> _announcements;

    private FakeDataService()
    {
        _student = new Student
        {
            StudentNumber = "2023556016",
            FullName = "Mehmet Dilşad Butekin",
            Faculty = "Mühendislik Fakültesi",
            Department = "Bilgisayar Mühendisliği",
            Grade = 4,
            Email = "2023556016@ogr.cu.edu.tr"
        };

        _exams =
        [
            new Exam
            {
                Id = 1,
                CourseName = "Database Management Systems",
                ExamDate = new DateTime(2026, 7, 15, 9, 30, 0),
                Building = "Rektörlük Derslikleri",
                Classroom = "R2",
                Supervisor = "Prof.Dr.Selma Ayşe ÖZEL",
                SeatNumber = 18,
                Description = "Sınav saatinden en az 15 dakika önce salonda hazır bulununuz."
            },

            new Exam
            {
                Id = 2,
                CourseName = "Computer Networks",
                ExamDate = new DateTime(2026, 7, 18, 13, 30, 0),
                Building = "Mühendislik Fakültesi",
                Classroom = "Yazılım Laboratuvarı 2",
                Supervisor = "Doç.Dr.Sedat BİLGİLİ",
                SeatNumber = 12,
                Description = "Kimlik kartınızı yanınızda bulundurunuz."
            },

            new Exam
            {
                Id = 3,
                CourseName = "Veri Yapıları",
                ExamDate = new DateTime(2026, 7, 22, 10, 00, 00),
                Building = "Mithat Özsan Amfisi",
                Classroom = "Amfi 3",
                Supervisor = "Doç.Dr.Serkan KARTAL",
                SeatNumber = 7,
                Description = "Elektronik cihazlar sınav salonuna alınmayacaktır."
            }
        ];

        _announcements =
        [
            new Announcement
            {
                Id = 1,
                Title = "Final Sınavları",
                Content = "Final sınav programı yayımlanmıştır.",
                PublishDate = DateTime.Today
            },

            new Announcement
            {
                Id = 2,
                Title = "Salon Güncellemesi",
                Content = "Bazı sınav salonlarında değişiklik yapılmıştır.",
                PublishDate = DateTime.Today.AddDays(-1)
            }
        ];
    }

    public Student GetStudent()
        => _student;
    
    public Exam? SelectedExam { get; set; }

    public List<Exam> GetExams()
        => _exams;

    public Exam? GetExamById(int id)
        => _exams.FirstOrDefault(x => x.Id == id);

    public List<Announcement> GetAnnouncements()
        => _announcements;
}