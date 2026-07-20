using SQLite;

namespace Exam_Organisation_System.Models;

public class Student
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public string Faculty { get; set; } = string.Empty;

    public int Grade { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}