using Exam_Organisation_System.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam_Organisation_System.Services.Database;

public class SeatRepository
{
    private readonly SQLiteAsyncConnection _database;

    public SeatRepository(AppDatabase database)
    {
        _database = database.Database;
    }

    public Task<List<Seat>> GetAllAsync()
        => _database.Table<Seat>().ToListAsync();

    public Task<Seat?> GetByIdAsync(int id)
        => _database.Table<Seat>().FirstOrDefaultAsync(s => s.Id == id);

    public Task<int> AddAsync(Seat seat)
        => _database.InsertAsync(seat);

    public Task<int> UpdateAsync(Seat seat)
        => _database.UpdateAsync(seat);

    public Task<int> DeleteAsync(Seat seat)
        => _database.DeleteAsync(seat);

    public Task<Seat?> GetSeatAsync(int studentId, int examId, int classroomId)
        => _database.Table<Seat>()
            .FirstOrDefaultAsync(s => s.StudentId == studentId && s.ExamId == examId && s.ClassroomId == classroomId);
}