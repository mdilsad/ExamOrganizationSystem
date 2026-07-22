using Exam_Organisation_System.Models;

namespace Exam_Organisation_System.Services;

public class SessionService
{

    public Exam? SelectedExam { get; set; }
    public Student? CurrentStudent { get; set; }
    
    public Teacher? CurrentTeacher { get; set; }

}