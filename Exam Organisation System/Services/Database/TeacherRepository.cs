using Exam_Organisation_System.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Services.Database;

public class TeacherRepository
{
    private readonly SQLiteAsyncConnection _database;

    public TeacherRepository(AppDatabase database)
    {
        _database = database.Database;
    }

    public Task<List<Teacher>> GetAllAsync()
        => _database.Table<Teacher>().ToListAsync();

    public Task<Teacher?> GetByUsernameAsync(string username)
        => _database.Table<Teacher>()
            .FirstOrDefaultAsync(t => t.Username == username);

    public Task<int> AddAsync(Teacher teacher)
        => _database.InsertAsync(teacher);

    public Task<int> UpdateAsync(Teacher teacher)
        => _database.UpdateAsync(teacher);

    public Task<int> DeleteAsync(Teacher teacher)
        => _database.DeleteAsync(teacher);
}