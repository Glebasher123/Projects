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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        custom_action ca = new custom_action();
        ClientsDB clientsDB = new ClientsDB();
        private int index;
        public int clientId;
        public Clients()
        {
            InitializeComponent();
            this.index = -1;
            table.ItemsSource = clientsDB.getClients("");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (new Regex(@"^((8|\+375)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{9,10}$").IsMatch(phone.Text.TrimEnd().TrimStart()) && phone.Text.TrimEnd().TrimStart().Length == 13)
            {
                clientsDB.addClient(phone.Text, passport.Text, fullname.Text);
                table.ItemsSource = clientsDB.getClients("");
            }
            else
            {
                MessageBox.Show("Введите мобильный номер правильно");
            }
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.index == -1)
            {
                MessageBox.Show("Выберите элемент таблицы");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.index);
            ClientsModel client = data.Item as ClientsModel;
            clientsDB.delClient(client.Номер_Телефона, client.Номер_Паспорта, client.ФИО);
            table.ItemsSource = clientsDB.getClients("");
        }

        private void chooseButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.index == -1)
            {
                MessageBox.Show("Выберите элемент таблицы");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.index);
            ClientsModel client = data.Item as ClientsModel;
            this.clientId = clientsDB.getId(client.ФИО);
            this.Close();
        }

        private void search_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(search, "Поиск");
        }

        private void search_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(search, "Поиск");
        }

        private void fullname_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(fullname, "ФИО");
        }

        private void fullname_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(fullname, "ФИО");
        }

        private void phone_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(phone, "Телефон");
        }

        private void phone_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(phone, "Телефон");
        }

        private void passport_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(passport, "Номер паспорта");
        }

        private void passport_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(passport, "Номер паспорта");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "Поиск")
            table.ItemsSource = clientsDB.getClients(search.Text);
        }

        private void table_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (table.Items.IndexOf(table.CurrentItem) >= 0)
            {
                this.index = table.Items.IndexOf(table.CurrentItem);
            }
        }
    }
}
