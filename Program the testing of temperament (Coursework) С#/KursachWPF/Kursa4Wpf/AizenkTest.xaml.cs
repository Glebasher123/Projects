using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для AizenkTest.xaml
    /// </summary>
    public partial class AizenkTest : Window
    {

        public AizenkTest(string userName)
        {
            username = userName;
            InitializeComponent();
            Tests = new StreamReader("aizenkque.txt");
            string line;
            while ((line = Tests.ReadLine()) != null) //читаем по одной линии формат "Вопрос|БаллыЗаДа|БаллыЗаНет"
            {
                max++;
            }
            Tests.BaseStream.Position = 0;
            LabelCounter1.Content = "/" + max.ToString();

            GetQuest();
        }

        public int Flex = 0; // Points
        public int counter = 0; // Номер вопроса
        public int max = 0; // Всего тестов

        public string QuestText = null;
        public string pointsYes = null;
        public string pointsNo = null;
        public string username = null;
        public StreamReader Tests;




        private void GetQuest()
        {
            if (counter != max)
            {
                ++counter;
                var result = Tests.ReadLine().Split('|');
                QuestText = result[0];
                pointsYes = result[1];
                pointsNo = result[2];
            }
            MainTextBlock1.Text = QuestText;
            LabelCounter.Content = counter;
        }

        private void GoNext_Flex(bool Check)
        {
            if (Check)
            {
                Flex += Convert.ToInt32(pointsYes);
            }
            else
            {
                Flex += Convert.ToInt32(pointsNo);
            }

            Debug.WriteLine(Flex);
            if (counter == max)
            {
                EndQuests();
            }
            GetQuest();
        }

        private void EndQuests()
        {
            string Result = null;
            if (Flex < -40)
            {
                Result = "Сангвиник";
            }
            if (Flex > 40)
            {
                Result = "Холерик";
            }
            if (Flex < 40 && Flex > 0)
            {
                Result = "Меланхолик";
            }
            if (Flex > -40 && Flex <= 0)
            {
                Result = "Флегматик";
            }



            ResultWindow window = new ResultWindow(Result, username);
            window.Show();
            this.Close();
        }

        private void YesButtonClick(object sender, MouseButtonEventArgs e)
        {
            GoNext_Flex(true);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainAfterAutoriz mainAfterAutoriz = new MainAfterAutoriz(username);
            mainAfterAutoriz.Show();
            this.Close();
        }

        private void NoBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            GoNext_Flex(false);
        }
    }
}
