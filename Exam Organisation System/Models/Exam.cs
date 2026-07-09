namespace Exam_Organisation_System.Models;

public class Exam
{
    public string CourseName { get; set; }

    public DateTime ExamDate { get; set; }

    public string Building { get; set; }

    public string Classroom { get; set; }

    public int SeatNumber { get; set; }
}