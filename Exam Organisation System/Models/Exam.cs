namespace Exam_Organisation_System.Models;

public class Exam
{
    public int Id { get; set; }

    public string CourseName { get; set; } = string.Empty;

    public DateTime ExamDate { get; set; }
    
    public string FormattedDate =>
        ExamDate.ToString("dd MMMM yyyy");

    public string FormattedTime =>
        ExamDate.ToString("HH:mm");

    public string Building { get; set; } = string.Empty;

    public string Classroom { get; set; } = string.Empty;

    public string Supervisor { get; set; } = string.Empty;

    public int SeatNumber { get; set; }
    
    public string Description { get; set; } = string.Empty;
}