namespace Exam_Organisation_System.Models;

public class Seat
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ExamId { get; set; }

    public int ClassroomId { get; set; }

    public int SeatNumber { get; set; }

    public string Classroom { get; set; } = string.Empty;

    public string Building { get; set; } = string.Empty;
}