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

namespace Kursa4Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainAfterAutoriz.xaml
    /// </summary>
    public partial class MainAfterAutoriz : Window
    {
        string User = null;
        public MainAfterAutoriz(string username)
        {
            User = username;
            InitializeComponent();

            DearBlock.Text = $"Добро пожаловать, {username}";
        }
 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AizenkTest aizenkTest = new AizenkTest(User);
            aizenkTest.Show();
            this.Close();
        }

        private void ButtonBelov_Click(object sender, RoutedEventArgs e)
        {
            BelovTest belov = new BelovTest(User);
            belov.Show();
            this.Close();
            
        }
    }
}
