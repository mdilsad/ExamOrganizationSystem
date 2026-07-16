using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.Services;

public class FakeDataService
{

    private readonly List<Exam> _exams;

    public FakeDataService()
    {
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

    }

    
    
    public Exam? SelectedExam { get; set; }

    public List<Exam> GetExams()
        => _exams;

    public Exam? GetExamById(int id)
        => _exams.FirstOrDefault(x => x.Id == id);

}