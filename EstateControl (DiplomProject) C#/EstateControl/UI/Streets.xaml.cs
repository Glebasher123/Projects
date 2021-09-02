using EstateControl.DB;
using EstateControl.Models;
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
    /// Логика взаимодействия для Streets.xaml
    /// </summary>
    public partial class Streets : Window
    {
        custom_action ca = new custom_action();
        StreetsDB streetsDB = new StreetsDB();
        private int cellId;
        private StreetsModel choeseStreet;

        internal StreetsModel ChoeseStreet { get => choeseStreet; set => choeseStreet = value; }

        public Streets()
        {
            InitializeComponent();
            table.ItemsSource = streetsDB.getStreets("");
            this.cellId = -1;
        }

        private void table_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            this.cellId = table.Items.IndexOf(table.CurrentItem);
        }

        private void name_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(name, "Имя улицы");
        }

        private void name_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(name, "Имя улицы");
        }

        private void search_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(search, "Поиск");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            table.ItemsSource = streetsDB.getStreets(search.Text);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            streetsDB.addStreet(name.Text);
            table.ItemsSource = streetsDB.getStreets("");
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.cellId == -1)
            {
                MessageBox.Show("Выбирите запись в таблице которую хотите удалить");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.cellId);
            StreetsModel street = data.Item as StreetsModel;
            streetsDB.deleteStreet(street.Имя_Улицы);
            table.ItemsSource = streetsDB.getStreets("");
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            if (this.cellId == -1)
            {
                MessageBox.Show("Выбирите улицу");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.cellId);
            this.choeseStreet = data.Item as StreetsModel;
            this.Close();
        }

        private void search_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(search, "Поиск");
        }
    }
}
