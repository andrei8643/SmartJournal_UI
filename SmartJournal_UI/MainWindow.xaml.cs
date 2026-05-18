using System.Windows;

namespace SmartJournal_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (PinInput.Password == "1234")
            {
                LockScreenGrid.Visibility = Visibility.Collapsed;

                if (RoleSelector.SelectedIndex == 1) // Роль "Психолог"
                {
                    NewEntryTab.Visibility = Visibility.Collapsed;
                    StatsTab.Visibility = Visibility.Collapsed;
                    SettingsTab.Visibility = Visibility.Collapsed;
                    TasksTab.Visibility = Visibility.Collapsed;
                    WaterTab.Visibility = Visibility.Collapsed;

                    CommentPanel.Visibility = Visibility.Visible;
                    MainAppTabs.SelectedIndex = 0;

                    MessageBox.Show("Режим Психолога активовано. Вам доступний лише перегляд хронології та залишення терапевтичних коментарів.", "Контроль доступу");
                }
                else // Роль "Автор"
                {
                    NewEntryTab.Visibility = Visibility.Visible;
                    StatsTab.Visibility = Visibility.Visible;
                    SettingsTab.Visibility = Visibility.Visible;
                    TasksTab.Visibility = Visibility.Visible;
                    WaterTab.Visibility = Visibility.Visible;

                    CommentPanel.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }

        private void CalculateWaterGoal_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(WeightInput.Text, out double weight) && int.TryParse(AgeInput.Text, out int age))
            {
                int waterGoal = (int)(weight * 30);
                WaterGoalText.Text = $"Випито: 0 / {waterGoal} мл";
                WaterSetupPanel.Visibility = Visibility.Collapsed;
                WaterTrackerPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні дані цифрами!", "Помилка");
            }
        }
    }
}