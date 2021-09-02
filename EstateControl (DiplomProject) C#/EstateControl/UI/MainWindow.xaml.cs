using EstateControl.DB;
using EstateControl.Models;
using EstateControl.UI;
using EstateControl.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EstateControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int estateId;
        private int clietId;
        private int index;
        DocumentsDB documentsDB = new DocumentsDB();
        EstateDB estateDB = new EstateDB();
        ClientsDB clientsDB = new ClientsDB();
        custom_action ca = new custom_action();
        public MainWindow()
        {
            InitializeComponent();
            docType.ItemsSource = new List<string>{ "ЗАЯВЛЕНИЕ " +
                "о предоставлении сведений и документов из единого " +
                "государственного регистра недвижимого имущества, " +
                "прав на него и сделок с ним и государственного земельного кадастра",
                "СПРАВКА о принадлежащих лицу правах на объекты недвижимого имущества",
                "СПРАВКА о правах на объекты недвижимого имущества" };
            table.ItemsSource = documentsDB.getDocuments("");
        }

        private void estate_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Estate es = new Estate();
                es.ShowDialog();
                this.estateId = es.estateIndex;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
            Clients c = new Clients();
            c.ShowDialog();
            try
            {
                this.clietId = c.clientId;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void docType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (docType.SelectedItem.ToString() == "ЗАЯВЛЕНИЕ " +
                "о предоставлении сведений и документов из единого " +
                "государственного регистра недвижимого имущества, " +
                "прав на него и сделок с ним и государственного земельного кадастра")
            {
                type.Content = "25 BYN";
            }
            if (docType.SelectedItem.ToString() == "СПРАВКА о принадлежащих лицу правах на объекты недвижимого имущества")
            {
                type.Content = "30 BYN";
            }
            if (docType.SelectedItem.ToString() == "СПРАВКА о правах на объекты недвижимого имущества")
            {
                type.Content = "35 BYN";
            }
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            EstateModel estate = estateDB.getEstate(this.estateId)[0];
            ClientsModel client = clientsDB.getClientById(this.clietId);
            if (docType.SelectedItem.ToString() == "ЗАЯВЛЕНИЕ " +
                "о предоставлении сведений и документов из единого " +
                "государственного регистра недвижимого имущества, " +
                "прав на него и сделок с ним и государственного земельного кадастра")
            {
                word.createFile1("template1.docx", client.ФИО, client.Номер_Паспорта, DateTime.Now.ToString("d"), $"г.{estate.Город} {estate.Улица} д.{estate.Номер_Дома} к.{estate.Номер_Квартиры}", estate.Примечания);
            }
            if (docType.SelectedItem.ToString() == "СПРАВКА о принадлежащих лицу правах на объекты недвижимого имущества")
            {
                word.createFile2("template2.docx", client.Номер_Паспорта, this.estateId.ToString(), $"г.{estate.Город} {estate.Улица} д.{estate.Номер_Дома} к.{estate.Номер_Квартиры}", estate.Площадь, DateTime.Now.ToString("d"), estate.Примечания);
            }
            if (docType.SelectedItem.ToString() == "СПРАВКА о правах на объекты недвижимого имущества")
            {
                word.createFile3(client.Номер_Паспорта , this.estateId.ToString(), $"г.{estate.Город} {estate.Улица} д.{estate.Номер_Дома} к.{estate.Номер_Квартиры}", estate.Площадь, estate.Примечания);
            }
        }

        private void registrate_Click(object sender, RoutedEventArgs e)
        {
            documentsDB.addDocument(type.Content.ToString(), this.clietId, this.estateId, docType.SelectedItem.ToString());
            table.ItemsSource = documentsDB.getDocuments("");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "Поиск")
            table.ItemsSource = documentsDB.getDocuments(search.Text);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.index == -1)
            {
                MessageBox.Show("Выберите элемент таблицы");
                return;
            }
            DataGridRow data = (DataGridRow)table.ItemContainerGenerator.ContainerFromIndex(this.index);
            DocumentsModel document = data.Item as DocumentsModel;
            documentsDB.delDocument(documentsDB.getId(document.Цена_Документа, Convert.ToDateTime(document.Дата_Создания), clientsDB.getId(document.ФИО),
                estateDB.getId(document.Тип_Имущества, document.Площадь, document.Номер_Квартиры, document.Номер_Дома, document.Цена_Квартиры, document.Улица)));
            table.ItemsSource = documentsDB.getDocuments("");
        }

        private void table_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (table.Items.IndexOf(table.CurrentItem) >= 0)
            {
                this.index = table.Items.IndexOf(table.CurrentItem);
            }
        }

        private void search_MouseEnter(object sender, MouseEventArgs e)
        {
            ca.mouseEnter(search, "Поиск");
        }

        private void search_MouseLeave(object sender, MouseEventArgs e)
        {
            ca.mouseLeave(search, "Поиск");
        }

        private void statistic_Click(object sender, RoutedEventArgs e)
        {
            Statistic s = new Statistic();
            s.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelpSystem help = new HelpSystem();
            help.Show();
        }
    }
}
