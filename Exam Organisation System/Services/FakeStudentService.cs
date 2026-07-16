using Exam_Organisation_System.Models;
namespace Exam_Organisation_System.Services;

public class FakeStudentService
{
    private readonly Student _student;

    public FakeStudentService()
    {
        _student = new Student
        {
            StudentNumber = "2023556016",
            FullName = "Mehmet Dilşad Butekin",
            Faculty = "Mühendislik Fakültesi",
            Department = "Bilgisayar Mühendisliği",
            Grade = 4,
            Email = "2023556016@ogr.cu.edu.tr"
        };
    }

    public Student GetStudent()
    {
        return _student;
    }
}