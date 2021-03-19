using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Kursa4Wpf
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public class Quest
        {
            public string Question { get; set; }
            public string Yes { get; set; }
            public string No { get; set; }

            public Quest(string question, string yes, string no)
            {
                Question = question;
                Yes = yes;
                No = no;
            }
        }

        public void AddQuestsBelov()
        {
            DataTable.Items.Clear();
            using (var sr = new StreamReader("tests.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var flex = sr.ReadLine().Split('|');
                        var f = new Quest(flex[0], flex[1], flex[2]);
                        DataTable.Items.Add(f);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        public void AddQuestsAizenk()
        {
            DataTable1.Items.Clear();
            using (var sr = new StreamReader("aizenkque.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var flex = sr.ReadLine().Split('|');
                        var f = new Quest(flex[0], flex[1], flex[2]);
                        DataTable1.Items.Add(f);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }



        public AdminPanel()
        {
            InitializeComponent();
            AddQuestsBelov();
            CounterStats();
            AddQuestsAizenk();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TabTable.SelectedIndex == 0)
            {
                if (VoprosBox.Text != null && YesBals.Text != null && NopeBals != null)
                {
                    using (var sw = new StreamWriter("tests.txt", true))
                        sw.WriteLine($"{VoprosBox.Text}|{YesBals.Text}|{NopeBals.Text}");
                }
            }
            else
            {
                if (VoprosBox.Text != null && YesBals.Text != null && NopeBals != null)
                {
                    using (var sw = new StreamWriter("aizenkque.txt", true))
                        sw.WriteLine($"{VoprosBox.Text}|{YesBals.Text}|{NopeBals.Text}");
                }
            }
            AddQuestsBelov();
            AddQuestsAizenk();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            string tempFile = System.IO.Path.GetTempFileName();
            if (TabTable.SelectedIndex == 0)
            {
                Quest row = (Quest)DataTable.SelectedItems[0];
                string line_to_delete = $"{row.Question}|{row.Yes}|{row.No}";

                using (StreamReader reader = new StreamReader(@"tests.txt"))
                {
                    using (StreamWriter writer = new StreamWriter(tempFile))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (!(line == line_to_delete))
                            {
                                writer.WriteLine(line);
                            }
                        }
                        reader.Close();
                        File.Delete(@"tests.txt");
                        writer.Close();
                        File.Move(tempFile, @"tests.txt");
                    }
                }
            }
            else
            {
                Quest row = (Quest)DataTable1.SelectedItems[0];
                string line_to_delete = $"{row.Question}|{row.Yes}|{row.No}";

                using (StreamReader reader = new StreamReader(@"aizenkque.txt"))
                {
                    using (StreamWriter writer = new StreamWriter(tempFile))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (!(line == line_to_delete))
                            {
                                writer.WriteLine(line);
                            }
                        }
                        reader.Close();
                        File.Delete(@"aizenkque.txt");
                        writer.Close();
                        File.Move(tempFile, @"aizenkque.txt");
                    }
                }
            }
            AddQuestsBelov();
            AddQuestsAizenk();
        }
        void CounterStats()
        {
            using(StreamReader flex = new StreamReader("stats.txt"))
            {

                SangLabel.Content = flex.ReadLine();
                HollLabel.Content = flex.ReadLine();
                MelLabel.Content = flex.ReadLine();
                FlexLabel.Content = flex.ReadLine();

            }
        }
        private void FindAndReplace(Microsoft.Office.Interop.Word.Document wordApp, string ToFindText, string replaceWithText)
        {
            var range = wordApp.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: ToFindText, ReplaceWith: replaceWithText);
        }

        string fileTemp;
        private void SaveOtchet()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                FileInfo info = new FileInfo(dlg.FileName);
                fileTemp = info.Directory.ToString() + @"\Temp.docx";
            }

            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Word Format (*.docx)|*.docx|All files (*.*)|*.*";
            if (dlgSave.ShowDialog() == true)
            {
                FileInfo info = new FileInfo(dlgSave.FileName);

               
                    var wordApp = new Microsoft.Office.Interop.Word.Application();
                    wordApp.Visible = false;
                    var wordDocument = wordApp.Documents.Open(fileTemp);

                    this.FindAndReplace(wordDocument, "<1>", SangLabel.Content.ToString());
                    this.FindAndReplace(wordDocument, "<2>", HollLabel.Content.ToString());
                    this.FindAndReplace(wordDocument, "<3>", MelLabel.Content.ToString());
                    this.FindAndReplace(wordDocument, "<4>", FlexLabel.Content.ToString());

                    wordDocument.SaveAs2(dlgSave.FileName);
                    wordApp.Quit();
                    MessageBox.Show("File Created!", "Good");
             
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveOtchet();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void YesBals_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
