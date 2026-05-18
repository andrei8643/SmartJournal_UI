using System.Windows;

namespace SmartJournal_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Логіка для входу (Lock Screen)
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (PinInput.Password == "1234")
            {
                LockScreenGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }

        // Логіка для калькулятора води
        private void CalculateWaterGoal_Click(object sender, RoutedEventArgs e)
        {
            // Намагаємося отримати вагу та вік з текстових полів
            if (double.TryParse(WeightInput.Text, out double weight) && int.TryParse(AgeInput.Text, out int age))
            {
                // Рахуємо норму: 30 мл на 1 кг ваги 
                // (Можна додати додаткові коефіцієнти для віку, але 30 мл - це універсальний стандарт)
                int waterGoal = (int)(weight * 30);

                // Оновлюємо текст у трекері
                WaterGoalText.Text = $"Випито: 0 / {waterGoal} мл";

                // Ховаємо екран налаштувань і показуємо сам трекер
                WaterSetupPanel.Visibility = Visibility.Collapsed;
                WaterTrackerPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні дані (вік, зріст та вагу) цифрами!", "Помилка");
            }
        }
    }
}