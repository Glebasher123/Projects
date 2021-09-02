using EstateControl.DB;
using EstateControl.Models;
using EstateControl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Estate.xaml
    /// </summary>
    public partial class Estate : Window
    {
        custom_action ca = new custom_action();
        EstateDB estateDB = new EstateDB();
        private int index;
        public int estateIndex;
        public Estate()
        {
            InitializeComponent();
            type.ItemsSource = new List<string>{ "Квартира", "Дом" };
            table.ItemsSource = estateDB.getEstate("");
            this.index = -1;
        }

        private void town_Click(object sender, RoutedEventArgs e)
        {
            Towns t = new Towns();
            t.ShowDialog();
            try
            {
                townName.Text = t.ChooseTown.Имя_Города;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void street_Click(object sender, RoutedEventArgs e)
        {
            Streets s = new Streets();
            s.ShowDialog();
            try
            {
                streetName.Text = s.ChoeseStreet.Имя_Улицы;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void roomsCount_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(roomsCount, "Количество комнат");
        }

        private void roomsCount_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(roomsCount, "Количество комнат");
        }

        private void floor_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(floor, "Этаж");
        }

        private void floor_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(floor, "Этаж");
        }

        private void area_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(area, "Площадь");
        }

        private void area_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(area, "Площадь");
        }

        private void apartmentNumber_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(apartmentNumber, "Номер квартиры");
        }

        private void apartmentNumber_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(apartmentNumber, "Номер квартиры");
        }

        private void houseNumber_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(houseNumber, "Номер дома");
        }

        private void houseNumber_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(houseNumber, "Номер дома");
        }

        private void notes_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(notes, "Примечания");
        }

        private void notes_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(notes, "Примечания");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (new Regex(@"\D").IsMatch(floor.Text) || new Regex(@"\D").IsMatch(roomsCount.Text) || !(new Regex(@"(\d|\.|\,)*").IsMatch(area.Text)) || new Regex(@"\D").IsMatch(apartmentNumber.Text) || !(new Regex(@"(\d|\.|\,)*").IsMatch(price.Text)) ||
                Convert.ToInt32(floor.Text) <= 0 || Convert.ToInt32(roomsCount.Text) <= 0 || Convert.ToInt32(apartmentNumber.Text) <= 0 || Convert.ToDouble(area.Text.Replace(".", ",")) <= 0 || Convert.ToDouble(price.Text.Replace(".", ",")) <= 0)
            {
                MessageBox.Show("Этаж, количество комнат, номер квартиры должны быть целыми положительными числами; площадь, цена должны быть положительными");
                return;
            }
            estateDB.addEstate(type.SelectedItem.ToString(), Convert.ToInt32(floor.Text), Convert.ToInt32(roomsCount.Text), area.Text.Replace(".", ",") + " m2", Convert.ToInt32(apartmentNumber.Text), houseNumber.Text, price.Text.Replace(".", ",") + " BYN", notes.Text, townName.Text, streetName.Text);
            table.ItemsSource = estateDB.getEstate("");
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.index == -1)
            {
                MessageBox.Show("Выберите элемент таблицы");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.index);
            EstateModel estate = data.Item as EstateModel;
            estateDB.delEstate(estate.Тип, estate.Этаж, estate.Количесвто_Комнат, estate.Площадь, estate.Номер_Квартиры, estate.Номер_Дома, estate.Цена, estate.Примечания, estate.Город, estate.Улица);
            table.ItemsSource = estateDB.getEstate("");
        }

        private void chooseButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.index == -1)
            {
                MessageBox.Show("Выберите элемент таблицы");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.index);
            EstateModel estate = data.Item as EstateModel;
            this.estateIndex = estateDB.getId(estate.Тип, estate.Площадь, estate.Номер_Квартиры, estate.Номер_Дома, estate.Цена, estate.Улица);
            this.Close();
        }

        private void price_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(price, "Стоимость");
        }

        private void price_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(price, "Стоимость");
        }

        private void table_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (table.Items.IndexOf(table.CurrentItem) >= 0)
            {
                this.index = table.Items.IndexOf(table.CurrentItem);
            }
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "Поиск")
            table.ItemsSource = estateDB.getEstate(search.Text);
        }

        private void search_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(search, "Поиск");
        }

        private void search_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(search, "Поиск");
        }
    }
}
