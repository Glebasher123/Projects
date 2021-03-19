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
using System.Windows.Shapes;

namespace Kursa4Wpf
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (userNameField.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }
 
            if (loginField.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (passField.Password == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (isUserExists())
                return; 

            DataBase dataBase = new DataBase();
            SqlCommand command = new SqlCommand("INSERT INTO Users (login, pass, name) VALUES (@login, @pass, @name)", dataBase.getConnection());
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = passField.Password;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = userNameField.Text;

            dataBase.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Создано!");
            else
                MessageBox.Show("Не удачно! :(");

            dataBase.CloseConnection();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Title = mainWindow.Content.ToString();
            
            
            
            this.Hide();
            mainWindow.Show();

        }

        public Boolean isUserExists()
        {
            DataBase dataBase = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE login = @uL", dataBase.getConnection());
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует, введите другой.");
                return true;
            }
            else
                return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Title = mainWindow.Content.ToString();

            this.Hide();
            mainWindow.Show();
        }
    }
}
