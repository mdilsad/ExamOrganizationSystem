using Exam_Organisation_System.Models;
using SQLite;

namespace Exam_Organisation_System.Services.Database;

public class ExamRepository
{
    private readonly SQLiteAsyncConnection _database;

    public ExamRepository(AppDatabase appDatabase)
    {
        _database = appDatabase.Database;
    }

    public async Task<List<Exam>> GetAllAsync()
    {
        return await _database.Table<Exam>().ToListAsync();
    }

    public async Task<Exam?> GetByIdAsync(int id)
    {
        return await _database.Table<Exam>()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Exam?> GetUpcomingExamByClassroomAsync(int classroomId)
    {
        var now = DateTime.Now;

        return await _database.Table<Exam>()
            .Where(e => e.ClassroomId == classroomId && e.ExamDate >= now)
            .OrderBy(e => e.ExamDate)
            .FirstOrDefaultAsync();
    }

    public async Task<Exam?> GetUpcomingExamByStudentAsync(int studentId)
    {
        var now = DateTime.Now;

        var seat = await _database.Table<Seat>()
            .ToListAsync();

        var studentExamIds = seat
            .Where(s => s.StudentId == studentId)
            .Select(s => s.ExamId)
            .ToList();

        return await _database.Table<Exam>()
            .Where(e => studentExamIds.Contains(e.Id) && e.ExamDate >= now)
            .OrderBy(e => e.ExamDate)
            .FirstOrDefaultAsync();
    }

    public async Task<int> AddAsync(Exam exam)
    {
        return await _database.InsertAsync(exam);
    }

    public async Task<int> UpdateAsync(Exam exam)
    {
        return await _database.UpdateAsync(exam);
    }

    public async Task<int> DeleteAsync(Exam exam)
    {
        return await _database.DeleteAsync(exam);
    }
}