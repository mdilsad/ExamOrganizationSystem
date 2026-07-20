using SQLite;
using Exam_Organisation_System.Models;
using System.Linq;

namespace Exam_Organisation_System.Services.Database;

public class StudentRepository
{
    private readonly SQLiteAsyncConnection _database;

    public StudentRepository(AppDatabase appDatabase)
    {
        _database = appDatabase.Database;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _database.Table<Student>().ToListAsync();
    }

    public async Task<Student?> GetByStudentNumberAsync(string studentNumber)
    {
        return await _database.Table<Student>()
            .FirstOrDefaultAsync(s => s.StudentNumber == studentNumber);
    }

    public async Task<int> AddAsync(Student student)
    {
        return await _database.InsertAsync(student);
    }

    public async Task<int> UpdateAsync(Student student)
    {
        return await _database.UpdateAsync(student);
    }

    public async Task<int> DeleteAsync(Student student)
    {
        return await _database.DeleteAsync(student);
    }
    public async Task<Student?> GetByCredentialsAsync(string studentNumber, string password)
    {
        return await _database.Table<Student>()
            .FirstOrDefaultAsync(s =>
                s.StudentNumber == studentNumber &&
                s.Password == password);
    }
}
