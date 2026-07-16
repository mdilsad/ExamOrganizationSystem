namespace Exam_Organisation_System.Services;

public class AuthenticationService
{
    public bool Login(string studentNumber, string password)
    {
        return studentNumber == "1" &&
               password == "1";
    }
}