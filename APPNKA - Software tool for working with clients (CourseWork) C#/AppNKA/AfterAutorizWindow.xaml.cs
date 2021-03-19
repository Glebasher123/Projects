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

namespace AppNKA
{
    /// <summary>
    /// Логика взаимодействия для AfterAutorizWindow.xaml
    /// </summary>
    public partial class AfterAutorizWindow : Window
    {



        public AfterAutorizWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new HelpSystem().Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           new RegisterClient(this).Show();
            this.Hide();
        }

        private void SpisokButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new ClientList(this).Show();
            this.Hide();
        }
    }
}
