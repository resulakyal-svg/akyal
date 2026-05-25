using GanoApp.Services;

namespace GanoApp;

public partial class App : Application
{
    public static DatabaseService Database;

    public App()
    {
        InitializeComponent();

        Database = new DatabaseService();

        MainPage = new AppShell();
    }
}