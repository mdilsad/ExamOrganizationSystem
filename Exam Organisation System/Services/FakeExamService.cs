using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.Services;

public class FakeExamService
{
    private readonly List<Exam> _exams;

    public FakeExamService()
    {
        _exams =
        [
            new Exam
            {
                Id = 1,
                CourseName = "Veritabanı Yönetim Sistemleri",
                Supervisor = "Dr. Ahmet Yılmaz",
                ExamDate = DateTime.Today.AddDays(2),
                Classroom = "D-101",
                Building = "Mühendislik Fakültesi",
                Description = "DBMS final sınavı",
                SeatNumber = 24,
            },
            new Exam
            {
                Id = 2,
                CourseName = "Yazılım Mühendisliği",
                Supervisor = "Doç. Ayşe Demir",
                ExamDate = DateTime.Today.AddDays(5),
                Classroom = "B-204",
                Building = "Mühendislik Fakültesi",
                Description = "Yazılım Mühendisliği final sınavı",
                SeatNumber = 11,
            }
        ];
    }

    public List<Exam> GetExams()
    {
        return _exams;
    }

    public Exam? GetExamById(int id)
    {
        return _exams.FirstOrDefault(x => x.Id == id);
    }
}