namespace Exam_Organisation_System.Services;

public class AuthenticationService
{
    public bool Login(string studentNumber, string password)
    {
        return studentNumber == "20230001" &&
               password == "1234";
    }
}