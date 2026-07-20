using Exam_Organisation_System.Models;
using SQLite;

namespace Exam_Organisation_System.Services.Database;

public class AnnouncementRepository
{
    private readonly SQLiteAsyncConnection _database;

    public AnnouncementRepository(AppDatabase appDatabase)
    {
        _database = appDatabase.Database;
    }

    public async Task<List<Announcement>> GetAllAsync()
    {
        return await _database.Table<Announcement>().ToListAsync();
    }

    public async Task<Announcement?> GetByIdAsync(int id)
    {
        return await _database.Table<Announcement>()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<int> AddAsync(Announcement announcement)
    {
        return await _database.InsertAsync(announcement);
    }

    public async Task<int> UpdateAsync(Announcement announcement)
    {
        return await _database.UpdateAsync(announcement);
    }

    public async Task<int> DeleteAsync(Announcement announcement)
    {
        return await _database.DeleteAsync(announcement);
    }
}