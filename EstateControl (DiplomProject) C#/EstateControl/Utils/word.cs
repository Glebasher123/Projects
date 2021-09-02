using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateEngine.Docx;

namespace EstateControl.Utils
{
    class word
    {
        public static void createFile1(string fileName,
            string fullName,
            string passportNum,
            string date,
            string adress,
            string notes)
        {
            try
            {
                File.Delete("OutputDocument.docx");
            }
            catch
            {
                MessageBox.Show("Закройте открытый документ");
                return;
            }

            File.Copy(fileName, "OutputDocument.docx");

            Content valuesToFill = new Content(
                new FieldContent("fullName", fullName),
                new FieldContent("passportNum", passportNum),
                new FieldContent("date", date),
                new FieldContent("adress", adress),
                new FieldContent("notes", notes),
                new FieldContent("dateNow", DateTime.Now.ToString("d")));

            using (TemplateProcessor outputDocument = new TemplateProcessor("OutputDocument.docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

        }

        public static void createFile2(string fileName,
            string passportNumber,
            string id,
            string adress,
            string area,
            string date,
            string notes)
        {
            try
            {
                File.Delete("OutputDocument.docx");
            }
            catch
            {
                MessageBox.Show("Закройте открытый документ");
                return;
            }

            File.Copy(fileName, "OutputDocument.docx");

            Content valuesToFill = new Content(
                new FieldContent("passportNumber", passportNumber),
                new FieldContent("id", id),
                new FieldContent("adress", adress),
                new FieldContent("area", area),
                new FieldContent("date", date),
                new FieldContent("notes", notes)
                );

            using (TemplateProcessor outputDocument = new TemplateProcessor("OutputDocument.docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

        }
        public static void createFile3(
            string passportNumber,
            string estateId,
            string adress,
            string area,
            string notes)
        {
            try
            {
                File.Delete("OutputDocument.docx");
            }
            catch
            {
                MessageBox.Show("Закройте открытый документ");
                return;
            }

            File.Copy("template3.docx", "OutputDocument.docx");

            Content valuesToFill = new Content(
                new FieldContent("passportNumber", passportNumber),
                new FieldContent("estateId", estateId),
                new FieldContent("adress", adress),
                new FieldContent("area", area),
                new FieldContent("notes", notes),
                new FieldContent("passportNumber1", passportNumber),
                new FieldContent("estateId1", estateId),
                new FieldContent("adress1", adress),
                new FieldContent("area1", area),
                new FieldContent("notes1", notes)
                );

            using (TemplateProcessor outputDocument = new TemplateProcessor("OutputDocument.docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

        }

    }
}
