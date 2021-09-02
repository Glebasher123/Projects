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
using EstateControl.DB;
using EstateControl.Models;
using EstateControl.Utils;

namespace EstateControl.UI
{
    /// <summary>
    /// Логика взаимодействия для Towns.xaml
    /// </summary>
    public partial class Towns : Window
    {
        custom_action ca = new custom_action();
        TownsDB townsDB = new TownsDB();
        private int cellId;
        private TownsModel chooseTown;

        internal TownsModel ChooseTown { get => chooseTown; set => chooseTown = value; }

        public Towns()
        {
            InitializeComponent();
            table.ItemsSource = townsDB.getTowns("");
            this.cellId = -1;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.cellId == -1)
            {
                MessageBox.Show("Выбирите запись в таблице которую хотите удалить");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.cellId);
            TownsModel town = data.Item as TownsModel;
            townsDB.deleteTown(town.Имя_Города);
            table.ItemsSource = townsDB.getTowns("");
        }

        private void name_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(name, "Имя города");
        }

        private void name_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(name, "Имя города");
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            townsDB.addTown(name.Text);
            string searchStr = "";
            if (search.Text != "Поиск")
            {
                searchStr = name.Text;
            }
            table.ItemsSource = townsDB.getTowns(searchStr);
        }

        private void search_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(search, "Поиск");
        }

        private void search_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(search, "Поиск");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            table.ItemsSource = townsDB.getTowns(search.Text);
        }

        private void table_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            this.cellId = table.Items.IndexOf(table.CurrentItem);
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            if (this.cellId == -1)
            {
                MessageBox.Show("Выбирите город");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.cellId);
            this.chooseTown = data.Item as TownsModel;
            this.Close();
        }
    }
}
