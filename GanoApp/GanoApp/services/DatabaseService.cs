using SQLite;
using GanoApp.Models;

namespace GanoApp.Services;

public class DatabaseService
{
    private SQLiteConnection _database;

    public DatabaseService()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "gano.db");

        _database = new SQLiteConnection(dbPath);

        _database.CreateTable<Course>();
    }

    public List<Course> GetCourses()
    {
        return _database.Table<Course>().ToList();
    }

    public int AddCourse(Course course)
    {
        return _database.Insert(course);
    }

    public int UpdateCourse(Course course)
    {
        return _database.Update(course);
    }

    public int DeleteCourse(Course course)
    {
        return _database.Delete(course);
    }
}