using Exam_Organisation_System.Services.Database;

namespace Exam_Organisation_System.Services;

public class AuthenticationService
{
    private readonly StudentRepository _studentRepository;
    private readonly SessionService _sessionService;

    public AuthenticationService(StudentRepository studentRepository, SessionService sessionService)
    {
        _studentRepository = studentRepository;
        _sessionService = sessionService;
    }

    public async Task<bool> LoginAsync(string studentNumber, string password)
    {
        var student = await _studentRepository.GetByCredentialsAsync(studentNumber, password);
        if (student == null)
            return false;

        _sessionService.CurrentStudent = student;
        return true;
    }
}