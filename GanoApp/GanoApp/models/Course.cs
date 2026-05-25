using SQLite;

namespace GanoApp.Models;

public class Course
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string CourseCode { get; set; }
    public string CourseName { get; set; }

    public int WeeklyHour { get; set; }
    public int AKTS { get; set; }

    public double Midterm { get; set; }
    public double Final { get; set; }
    public double Average { get; set; }

    public string LetterGrade { get; set; }

    public string Semester { get; set; }

    public bool IncludedInAverage { get; set; }
}