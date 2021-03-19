using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursa4Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBelov_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            String loginUser = loginField.Text;
            String passUser = passField.Password;

            DataBase dataBase = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE login = @uL AND pass = @uP", dataBase.getConnection());
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", SqlDbType.VarChar).Value = passUser;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (loginField.Text == "" || passField.Password == "")
            {
                MessageBox.Show("Не удалось! Попробуйте ещё раз.");
            }
            else { 

                if (table.Rows.Count > 0)
                {
                    if (loginField.Text.ToLower() == "Admin".ToLower())
                    {
                        new AdminPanel().Show();
                        this.Close();
                    }
                    else
                    {
                        MainAfterAutoriz autoriz = new MainAfterAutoriz(loginField.Text);
                        autoriz.Title = buttonLogin.Content.ToString();
                        this.Close();
                        autoriz.Show();
                    }
                }
                else
                    MessageBox.Show("Не удалось! Попробуйте ещё раз.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Title = RegistrationBlock.Visibility.ToString();

            this.Close();
            registerWindow.Show();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Title = RegistrationBlock.Visibility.ToString();

            this.Close();
            registerWindow.Show();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Title = RegistrationBlock.Visibility.ToString();

            this.Close();
            registerWindow.Show();
        }

        private void HelpLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HelpSystem help = new HelpSystem();
            help.Show();
            this.Close();
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
