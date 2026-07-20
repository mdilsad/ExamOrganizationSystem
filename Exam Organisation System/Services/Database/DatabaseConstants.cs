using System;

namespace Exam_Organisation_System.Services.Database;

public static class DatabaseConstants
{
    public const string DatabaseFileName = "examorganisation.db3";

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
}