using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppNKA
{
    /// <summary>
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Window
    {
        AfterAutorizWindow window;
        string sql = "select [ID клиента], Имя, Фамилия, Отчество, [Контактный номер], [Адрес проживания], [Стоимость м2, руб], [Уточненная площадь], [Состояние объекта], [Кадастровая стоимость, руб], [Поставщики отделочных материалов], [Стоимость фундамента], [Объект сдан или нет], [Метод оценки участка], [Заказчик кадастровой оценки], [Используемый регистр контроля], [Поставлен ли участок на учёт] from [Данные клиента]";
        public ClientList(AfterAutorizWindow window)
        {
            InitializeComponent();
            this.ClientGrid.ItemsSource = Database.FillDataGrid(sql);
            this.window = window;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            window.Show();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Database.RemoveUser((DataRowView)ClientGrid.SelectedItems[0]))
                {
                    MessageBox.Show("Удалено");
                }
                this.ClientGrid.ItemsSource = Database.FillDataGrid(sql);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Поиск_Click(object sender, RoutedEventArgs e)
        {
            string id = IdBox.Text;
            string sql = $"Select [ID клиента], Имя, Фамилия, Отчество, [Контактный номер], [Адрес проживания], [Стоимость м2, руб], [Уточненная площадь], [Состояние объекта], [Кадастровая стоимость, руб], [Поставщики отделочных материалов], [Стоимость фундамента], [Объект сдан или нет], [Метод оценки участка], [Заказчик кадастровой оценки], [Используемый регистр контроля], [Поставлен ли участок на учёт] from [Данные Клиента]";
            bool flag = false;

            if (id != "" && id != null)
            {
                sql += $" where [ID клиента] = '{id}'";

            }
            if (FirstDate.SelectedDate != null && SecondDate.SelectedDate != null)
            {
                var date = Convert.ToDateTime(FirstDate.SelectedDate).ToString("yyyy-MM-dd");
                var date2 = Convert.ToDateTime(SecondDate.SelectedDate).ToString("yyyy-MM-dd");
                if (flag == true)
                    if (date == date2)
                    {
                        sql += $" and [Дата регистрации] = '{date}'";
                    }
                    else
                    {
                        sql += $" and [Дата регистрации] > '{date}' AND [Дата регистрации] < '{date2}'";
                    }
                else
                    if (date == date2)
                    {
                        sql += $" where [Дата регистрации] = '{date}'";
                    }
                    else
                    {
                        sql += $" where [Дата регистрации] > '{date}' and [Дата регистрации] < '{date2}'";
                    }
            }
            Debug.WriteLine(sql);
            this.ClientGrid.ItemsSource = Database.FillDataGrid(sql);

        }

        private string id;
        private void ClientGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DataRowView)ClientGrid.SelectedItem != null)
            {
                EditGrid.ItemsSource = ClientGrid.SelectedItems;
            }
        }

        private void ReactButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataRowView)ClientGrid.SelectedItem != null)
            {

                var row = (DataRowView)EditGrid.Items[0];
                this.id = row[0].ToString();
                string Name = row[1].ToString();
                string Surname = row[2].ToString();
                string Lastname = row[3].ToString();
                string Contact = row[4].ToString();
                string Adress = row[5].ToString();
                string Stoimost = row[6].ToString();
                string utochn = row[7].ToString();
                string sostoy = row[8].ToString();
                string kadastr = row[9].ToString();
                string postavka = row[10].ToString();
                string stoim2 = row[11].ToString();
                string oBject = row[12].ToString();
                string method = row[13].ToString();
                string zakaz = row[14].ToString();
                string register = row[15].ToString();
                string ispolz = row[16].ToString();


                try
                {
                    Database.UpdateUser(this.id, Name, Surname, Lastname, Contact, Adress, Stoimost, utochn, sostoy, kadastr, postavka, stoim2, oBject, method, zakaz, register, ispolz);
                    this.ClientGrid.ItemsSource = Database.FillDataGrid(sql);
                    MessageBox.Show("Успешно", ":)");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show("Не удалось", ":/");
                }
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel file | *.csv";
                if (saveFileDialog.ShowDialog() == true)
                {
                    ClientGrid.SelectAllCells();
                    ClientGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, ClientGrid);
                    ClientGrid.UnselectAllCells();
                    String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                    result = result.Replace(',', ';');
                    File.AppendAllText(saveFileDialog.FileName, result.ToString(), Encoding.UTF8);

                    var p = new Process
                    {
                        StartInfo = new ProcessStartInfo(saveFileDialog.FileName)
                        {
                            UseShellExecute = true
                        }
                    };
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}