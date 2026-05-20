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
            // Пока заглушка — позже добавим реальную авторизацию
            MessageBox.Show("Подключение к PostgreSQL...\n\n(в следующей версии будет полный функционал)", 
                            "Вход", 
                            MessageBoxButton.OK, 
                            MessageBoxImage.Information);
        }
    }
}