using Exam_Organisation_System.Services.Database;

namespace Exam_Organisation_System.Services;

public class AuthenticationService
{
    private readonly StudentRepository _studentRepository;
    private readonly SessionService _sessionService;
    private readonly TeacherRepository _teacherRepository;

    public AuthenticationService(StudentRepository studentRepository, SessionService sessionService, TeacherRepository teacherRepository)
    {
        _studentRepository = studentRepository;
        _sessionService = sessionService;
        _teacherRepository = teacherRepository;
    }

    public async Task<bool> LoginAsync(string studentNumber, string password)
    {
        var student = await _studentRepository.GetByCredentialsAsync(studentNumber, password);
        if (student == null)
            return false;

        _sessionService.CurrentStudent = student;
        return true;
    }

    public async Task<bool> TeacherLoginAsync(string username, string password)
    {
        var teacher = await _teacherRepository.GetByUsernameAsync(username);

        if (teacher == null)
            return false;

        if (teacher.Password != password)
            return false;

        _sessionService.CurrentTeacher = teacher;
        return true;
    }
}