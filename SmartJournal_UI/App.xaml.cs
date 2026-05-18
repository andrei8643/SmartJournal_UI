using System.Windows;
using SmartJournal_UI.Database;

namespace SmartJournal_UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Автоматично створюємо базу даних та 4 таблиці при запуску додатка
            DatabaseManager.InitializeDatabase();
        }
    }
}