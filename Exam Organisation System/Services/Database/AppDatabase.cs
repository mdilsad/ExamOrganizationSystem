using SQLite;
using Exam_Organisation_System.Models;
namespace Exam_Organisation_System.Services.Database;

public class AppDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public SQLiteAsyncConnection Database => _database;

    public AppDatabase()
    {
        _database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath);
    }

    public async Task InitializeAsync()
    {
        await _database.CreateTableAsync<Student>();
        await _database.CreateTableAsync<Exam>();
        await _database.CreateTableAsync<Announcement>();
    }
}