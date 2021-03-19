using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using static AppNKA.Database;

namespace AppNKA
{
    /// <summary>
    /// Логика взаимодействия для RegisterClient.xaml
    /// </summary>
    public partial class RegisterClient : Window
    {
        AfterAutorizWindow mw;
        public RegisterClient(AfterAutorizWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            this.IDClientField.Text = Convert.ToString(NewId());
        }

        private int NewId()
        {
            //var ticks = new DateTime(2016, 1, 1).Ticks;
            //var ans = DateTime.Now.Ticks - ticks;
            //return ans.ToString("x");

            Random rand = new Random();
            var res = rand.Next(100000);
            return res;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        private bool ChekedField()
        {
            if (FIOField.Text == "")
            {
                MessageBox.Show("Введите фамилию");
                return false;
            }

            if (OT4Field.Text == "")
            {
                MessageBox.Show("Введите отчество");
                return false;
            }

            if (NameField.Text == "")
            {
                MessageBox.Show("Введите имя");
                return false;
            }

            //if (BirthField.Text == "")
            //{
            //    MessageBox.Show("Введите дату рождения");
            //    return false;
            //}

            //if (AreaField.Text == "")
            //{
            //    MessageBox.Show("Введите площадь участка");
            //   return false;
            //}

            if (AddressField.Text == "")
            {
                MessageBox.Show("Введите адрес");
                return false;
            }

            if (NumberField.Text == "")
            {
                MessageBox.Show("Введите номер телефона");
                return false;
            }
            return true;
        }

        private void ButtonRegister_Click_1(object sender, RoutedEventArgs e)
        {
            if (ChekedField())
            {
                var opt = new Options() { id = Convert.ToInt32(IDClientField.Text), fam = FIOField.Text, name = NameField.Text, otch = OT4Field.Text, address = AddressField.Text, method = Method_marks.Text, number = NumberField.Text, objectsd = ObjectSdan.Text, postavka = Pastawka.Text, regist = registerControl.Text, sost = ObjectSost.Text, square = Convert.ToDouble(SquareField.Text), sumstoim = Convert.ToDouble(Stoim2Field.Text) * Convert.ToDouble(SquareField.Text), stoim2 = Convert.ToDouble(Stoim2Field.Text), stoimfun = Convert.ToDouble(SostObjField.Text), ychet = Uchet.Text, zakazchik = Zajazal.Text, datereg = DateTime.Now.ToString("yyyy-MM-dd") };
                if (Database.AddUser(opt))
                {
                    MessageBox.Show("Успешно.");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Show();
        }
    }
}
