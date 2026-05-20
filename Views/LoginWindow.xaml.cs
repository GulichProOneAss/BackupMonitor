using System;
using System.Windows;
using Npgsql;
using BackupMonitor.Views;   // если MainWindow в той же папке

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
            string server = ServerBox.Text.Trim();
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            // Разбор адреса сервера (поддержка "127.0.0.1:5432")
            string host = "127.0.0.1";
            int port = 5432;

            if (!string.IsNullOrEmpty(server))
            {
                var parts = server.Split(':');
                host = parts[0];
                if (parts.Length > 1 && int.TryParse(parts[1], out int p))
                    port = p;
            }

            string connectionString = $"Host={host};Port={port};Username={username};Password={password};";

            try
            {
                await using var conn = new NpgsqlConnection(connectionString);
                await conn.OpenAsync();

                // Успешное подключение
                MessageBox.Show("Подключение к PostgreSQL успешно!", "Успех", 
                                MessageBoxButton.OK, MessageBoxImage.Information);

                // Открываем главное окно
                var mainWindow = new MainWindow();
                mainWindow.Show();

                // Закрываем окно авторизации
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключиться к PostgreSQL:\n\n{ex.Message}", 
                                "Ошибка подключения", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}