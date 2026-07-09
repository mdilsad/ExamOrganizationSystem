using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.Services;

public class ExamService
{
    public Exam GetTodayExam()
    {
        return new Exam
        {
            CourseName = "Database Management Systems",
            ExamDate = new DateTime(2026, 7, 10, 9, 30, 0),
            Building = "Bilgisayar Mühendisliği Binası",
            Classroom = "Yazılım 1",
            SeatNumber = 18
        };
    }
}