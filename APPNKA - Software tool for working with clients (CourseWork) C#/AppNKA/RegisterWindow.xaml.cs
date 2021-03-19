using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppNKA
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

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            CheckInfo();
            if(Database.RegisterUser(loginField.Text, passField.Password, userNameField.Text))
            {
                MessageBox.Show("Зарегистрирован!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так..");
            }
        }

        private void CheckInfo()
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
        }
       
    }
}
