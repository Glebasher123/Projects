using EstateControl.Utils;
using System;
using System.Collections.Generic;
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

namespace EstateControl.UI
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        custom_action ca = new custom_action();

        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (password.Password == "1234" && login.Text == "admin")
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                password.Password = "";
                login.Text = "";
                label.Text = "Неверный логин или пароль";
            }
        }

        private void login_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(login, "Введите логин");
        }

        private void login_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(login, "Введите логин");
        }
    }
}
