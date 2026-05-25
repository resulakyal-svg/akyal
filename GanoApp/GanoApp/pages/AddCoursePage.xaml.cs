using GanoApp.Models;

namespace GanoApp.Pages;

public partial class AddCoursePage : ContentPage
{
    public AddCoursePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        double midterm = Convert.ToDouble(txtMidterm.Text);
        double final = Convert.ToDouble(txtFinal.Text);

        double average = midterm * 0.4 + final * 0.6;

        string letter = CalculateLetter(average);

        Course course = new Course()
        {
            CourseCode = txtCode.Text,
            CourseName = txtName.Text,
            WeeklyHour = int.Parse(txtHour.Text),
            AKTS = int.Parse(txtAKTS.Text),

            Midterm = midterm,
            Final = final,
            Average = average,

            LetterGrade = letter,
            Semester = txtSemester.Text,

            IncludedInAverage = switchInclude.IsToggled
        };

        App.Database.AddCourse(course);

        await DisplayAlert("Başarılı", "Ders eklendi", "Tamam");

        await Navigation.PopAsync();
    }

    string CalculateLetter(double average)
    {
        if (average >= 90) return "AA";
        if (average >= 85) return "BA";
        if (average >= 80) return "BB";
        if (average >= 75) return "CB";
        if (average >= 70) return "CC";
        if (average >= 60) return "DC";
        if (average >= 50) return "DD";
        return "FF";
    }
}