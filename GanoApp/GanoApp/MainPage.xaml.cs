using GanoApp.Models;
using GanoApp.Pages;
using System.Linq;

namespace GanoApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadCourses();
    }

    void LoadCourses()
    {
        var list = App.Database.GetCourses();

        courseList.ItemsSource = list;

        CalculateGano(list);
    }

    void CalculateGano(List<Course> courses)
    {
        double total = 0;
        double akts = 0;

        foreach (var c in courses)
        {
            if (!c.IncludedInAverage)
                continue;

            total += c.Average * c.AKTS;
            akts += c.AKTS;
        }

        lblGano.Text = akts == 0 ? "GANO: 0" : $"GANO: {(total / akts):F2}";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCoursePage());
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var item = sender as SwipeItem;

        int id = (int)item.CommandParameter;

        var course = App.Database.GetCourses()
            .FirstOrDefault(x => x.Id == id);

        if (course != null)
        {
            bool ok = await DisplayAlert("Sil", "Silinsin mi?", "Evet", "Hayır");

            if (ok)
            {
                App.Database.DeleteCourse(course);
                LoadCourses();
            }
        }
    }
}