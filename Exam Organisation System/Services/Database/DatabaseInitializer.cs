using Exam_Organisation_System.Models;
using Exam_Organisation_System.Services.Database;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Exam_Organisation_System.Services.Database;


public class DatabaseInitializer
{
    private readonly AppDatabase _database;

    public DatabaseInitializer(AppDatabase database)
    {
        _database = database;
    }

    public async Task InitializeAsync()
    {
        await _database.InitializeAsync();

        var studentRepository = new StudentRepository(_database);
        var examRepository = new ExamRepository(_database);
        var announcementRepository = new AnnouncementRepository(_database);

        if (!(await studentRepository.GetAllAsync()).Any())
        {
            await studentRepository.AddAsync(new Student
            {
                StudentNumber = "1",
                Password = "1",
                FullName = "Troll GPT",
                Department = "Bilgisayar Mühendisliği",
                Faculty = "Mühendislik Fakültesi",
                Grade = 4,
                Email = "2023556016@ogr.cu.edu.tr"
            });
        }

        if (!(await examRepository.GetAllAsync()).Any())
        {
            await examRepository.AddAsync(new Exam
            {
                CourseName = "Mobil Uygulama Geliştirme",
                Classroom = "R2-309",
                Building = "Rektörlük Derslikleri",
                Supervisor = "Dr. Serkan KARTAL",
                ExamDate = DateTime.Today.AddDays(2).AddHours(9).AddMinutes(30)
            });

            await examRepository.AddAsync(new Exam
            {
                CourseName = "Veritabanı Yönetim Sistemleri",
                Classroom = "Yazılım 1",
                Building = "Bilgisayar Mühendisliği Yazılım Laboratuvarları",
                Supervisor = "Doç.Selma Ayşe ÖZEL",
                ExamDate = DateTime.Today.AddDays(4).AddHours(13)
            });

            await examRepository.AddAsync(new Exam
            {
                CourseName = "Yapay Zeka",
                Classroom = "R2-301",
                Building = "Rektörlük Derslikleri",
                Supervisor = "Dr. Mehmet SARIGÜL",
                ExamDate = DateTime.Today.AddDays(6).AddHours(10)
            });

            await examRepository.AddAsync(new Exam
            {
                CourseName = "Bilgisayar Ağları",
                Classroom = "R2-308",
                Building = "Rektörlük Derslikleri",
                Supervisor = "Dr. Elif Emel FIRAT",
                ExamDate = DateTime.Today.AddDays(8).AddHours(14)
            });

            await examRepository.AddAsync(new Exam
            {
                CourseName = "İşletim Sistemleri",
                Classroom = "Yazılım 2",
                Building = "Bilgisayar Mühendisliği Yazılım Laboratuvarları",
                Supervisor = "Prof. Dr. Barış ATA",
                ExamDate = DateTime.Today.AddDays(10).AddHours(9)
            });

            await examRepository.AddAsync(new Exam
            {
                CourseName = "Theory Of Computation",
                Classroom = "Yazılım 1",
                Building = "Bilgisayar Mühendisliği Yazılım Laboratuvarları",
                Supervisor = "Prof. Dr. Umut ORHAN",
                ExamDate = DateTime.Today.AddDays(12).AddHours(11)
            });
        }

        if (!(await announcementRepository.GetAllAsync()).Any())
        {
            await announcementRepository.AddAsync(new Announcement
            {
                Title = "2026 Güz Dönemi Final Takvimi",
                Content = "Final sınav programı yayınlanmıştır. Lütfen sınav salonlarınızı kontrol ediniz.",
                PublishDate = DateTime.Today
            });

            await announcementRepository.AddAsync(new Announcement
            {
                Title = "Kimlik Kartı Zorunluluğu",
                Content = "Sınava girişte öğrenci kimlik kartı bulundurulması zorunludur.",
                PublishDate = DateTime.Today
            });

            await announcementRepository.AddAsync(new Announcement
            {
                Title = "Salon Güncellemesi",
                Content = "Bilgisayar Ağları sınavının salonu A110 olarak güncellenmiştir.",
                PublishDate = DateTime.Today.AddDays(1)
            });

            await announcementRepository.AddAsync(new Announcement
            {
                Title = "Sınav Başlangıç Saati",
                Content = "Sınavlardan en az 15 dakika önce salon önünde hazır bulunmanız gerekmektedir.",
                PublishDate = DateTime.Today.AddDays(2)
            });
        }
    }
}