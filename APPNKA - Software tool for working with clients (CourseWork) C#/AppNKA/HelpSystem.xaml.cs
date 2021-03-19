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
    /// Логика взаимодействия для HelpSystem.xaml
    /// </summary>
    public partial class HelpSystem : Window
    {
        
        public HelpSystem()
        {
            InitializeComponent();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AfterAutorizWindow afterAutorizWindow = new AfterAutorizWindow();
            afterAutorizWindow.Show();
            this.Close();
        }
    }
}
