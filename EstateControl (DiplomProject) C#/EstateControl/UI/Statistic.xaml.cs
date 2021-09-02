using EstateControl.DB;
using EstateControl.Models;
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
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {
        StatisticsDB statisticsDB = new StatisticsDB();
        public Statistic()
        {
            InitializeComponent();
            statistic.ItemsSource = new List<string> { "Клиенты за период", "Площади за период", "Стоимость документов за период", "Стоимость квартир за период" };
            start.SelectedDate = DateTime.Now.AddDays(-1);
            end.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void statistic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (statistic.SelectedItem.ToString() == "Клиенты за период")
                {
                    List<ClientsModel> clients = statisticsDB.clients(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = clients;
                    sum.Content = $"Количество клиентов: {clients.Count}";
                }
                if (statistic.SelectedItem.ToString() == "Площади за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Количество Площади: {documents.Sum(el => Utils.Utils.getNumber(el.Площадь))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость документов за период")
                {
                    List<DocumentsModel> documents = statisticsDB.documents(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость документов: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Документа))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость квартир за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость квартир: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Квартиры))}";
                }
                type.ItemsSource = table.ItemsSource.GetType().GetProperty("Item").PropertyType.GetProperties().Select(f => f.Name).ToList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void start_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (statistic.SelectedItem.ToString() == "Клиенты за период")
                {
                    List<ClientsModel> clients = statisticsDB.clients(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = clients;
                    sum.Content = $"Количество клиентов: {clients.Count}";
                }
                if (statistic.SelectedItem.ToString() == "Площади за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Количество Площади: {documents.Sum(el => Utils.Utils.getNumber(el.Площадь))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость документов за период")
                {
                    List<DocumentsModel> documents = statisticsDB.documents(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость документов: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Документа))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость квартир за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость квартир: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Квартиры))}";
                }
            }
            catch { }
        }

        private void end_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (statistic.SelectedItem.ToString() == "Клиенты за период")
                {
                    List<ClientsModel> clients = statisticsDB.clients(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = clients;
                    sum.Content = $"Количество клиентов: {clients.Count}";
                }
                if (statistic.SelectedItem.ToString() == "Площади за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Количество Площади: {documents.Sum(el => Utils.Utils.getNumber(el.Площадь))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость документов за период")
                {
                    List<DocumentsModel> documents = statisticsDB.documents(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость документов: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Документа))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость квартир за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость квартир: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Квартиры))}";
                }
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (statistic.SelectedItem.ToString() == "Клиенты за период")
                {
                    List<ClientsModel> clients = statisticsDB.clients(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = clients;
                    sum.Content = $"Количество клиентов: {clients.Count}";
                }
                if (statistic.SelectedItem.ToString() == "Площади за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Количество Площади: {documents.Sum(el => Utils.Utils.getNumber(el.Площадь))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость документов за период")
                {
                    List<DocumentsModel> documents = statisticsDB.documents(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость документов: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Документа))}";
                }
                if (statistic.SelectedItem.ToString() == "Стоимость квартир за период")
                {
                    List<AreaFromDate> documents = statisticsDB.areaFromDate(Convert.ToDateTime(start.SelectedDate), Convert.ToDateTime(end.SelectedDate));
                    table.ItemsSource = documents;
                    sum.Content = $"Общая стоимость квартир: {documents.Sum(el => Utils.Utils.getNumber(el.Цена_Квартиры))}";
                }
                var data = table.ItemContainerGenerator.Items;
                if (stringTextbox.Text != "" || lowerNuber.Text == "" && highNumber.Text == "")
                {
                    table.ItemsSource = data.Where(el => el.GetType().GetProperty(type.SelectedItem.ToString()).GetValue(el).ToString().Contains(stringTextbox.Text));
                }
                else
                {
                    table.ItemsSource = data.Where(el => Utils.Utils.getNumber(el.GetType().GetProperty(type.SelectedItem.ToString()).GetValue(el).ToString()) >= Utils.Utils.getNumber(lowerNuber.Text) &&
                    Utils.Utils.getNumber(el.GetType().GetProperty(type.SelectedItem.ToString()).GetValue(el).ToString()) <= Utils.Utils.getNumber(highNumber.Text));
                }
            }
            catch {
                MessageBox.Show("Выбирете тип");
            }
}
    }
}
