using System.Windows;

namespace BackupMonitor.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Пока заглушка — позже подключим реальную логику
            MessageBox.Show("Проверка подключения к PostgreSQL...\n\n(в следующей версии будет полный функционал)", 
                            "Подключение", 
                            MessageBoxButton.OK, 
                            MessageBoxImage.Information);
        }
    }
}