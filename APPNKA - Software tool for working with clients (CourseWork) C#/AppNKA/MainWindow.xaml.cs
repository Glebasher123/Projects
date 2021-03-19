using System.Windows;
using System.Windows.Input;

namespace AppNKA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.OpenConnection();
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new RegisterWindow() { Title = "Регистрация" }.Show();
        }

        private void HelpLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new HelpSystem().Show();
            this.Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string loginUser = loginField.Text;
            string passUser = passField.Password;

            if (Database.LoginUser(loginUser, passUser))
            {
                new AfterAutorizWindow() { Title = "Выбор" }.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так...");
            }
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonLogin_Click(sender, e);
            }
        }

    }
}
