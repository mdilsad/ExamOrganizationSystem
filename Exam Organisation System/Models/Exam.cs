using SQLite;
namespace Exam_Organisation_System.Models;

public class Exam
{
    [PrimaryKey]
    public int Id { get; set; }

    public string CourseName { get; set; } = string.Empty;

    public DateTime ExamDate { get; set; }
    
    [Ignore]
    public string FormattedDate =>
        ExamDate.ToString("dd MMMM yyyy");

    [Ignore]
    public string FormattedTime =>
        ExamDate.ToString("HH:mm");

    public string Building { get; set; } = string.Empty;

    public string Classroom { get; set; } = string.Empty;

    public int ClassroomId { get; set; }

    public string Supervisor { get; set; } = string.Empty;

    public int SeatNumber { get; set; }
    
    public string Description { get; set; } = string.Empty;
}