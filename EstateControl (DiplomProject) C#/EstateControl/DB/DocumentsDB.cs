using EstateControl.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EstateControl.DB
{
    class DocumentsDB
    {
        Connect con;
        public DocumentsDB()
        {
            this.con = new Connect();
        }

        public void addDocument(string cost, int clientId, int estateId, string text)
        {
            string expression = $"INSERT INTO [DOCUMENTATION] VALUES (" +
                $"N'{cost}', N'{text}', CONVERT(datetime, '{DateTime.Now}', 105), {clientId}, {estateId})";
            con.execute(expression);
        }

        public void delDocument(int id)
        {
            string expression = $"DELETE FROM [DOCUMENTATION] " +
                                              $"WHERE [ID] = {id}";
            con.execute(expression);
        }

        public int getId(string cost, DateTime date, int clientId, int estateId)
        {
            string expression = "SELECT [ID] FROM [DOCUMENTATION] " +
                $"WHERE [COST] = N'{cost}' and [CREATE_DATE] = CONVERT(datetime, '{date}', 105) and [CLIENT_ID] = {clientId} and [ESTATE_ID] = {estateId}";

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        return data.GetInt32(0);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return -1;
        }

        public List<DocumentsModel> getDocuments(string filter)
        {
            string expression = "SELECT [DOCUMENTATION].[COST], [CREATE_DATE], [DOC_TYPE], [ESTATE].[OBJECT_TYPE], [CLIENTS].[FULL_NAME], [AREA], [APARTMENT_NUMBER], [HOUSE_NUMBER], [ESTATE].[COST], [STREET_NAME] " +
                $"FROM [DOCUMENTATION] JOIN [CLIENTS] ON" +
                $" [CLIENTS].[ID] = [DOCUMENTATION].[CLIENT_ID] JOIN [ESTATE]" +
                $" ON [ESTATE].[ID] = [DOCUMENTATION].[ESTATE_ID] JOIN [TOWNS]" +
                $" ON [TOWNS].[ID] = [ESTATE].[TOWN_ID] JOIN [STREETS]" +
                $" ON [STREETS].[ID] = [ESTATE].[STREET_ID] " +
                $"WHERE [DOCUMENTATION].[COST] LIKE N'%{filter}%' or " +
                $" [CREATE_DATE] LIKE N'%{filter}%' or " +
                $" [ESTATE].[OBJECT_TYPE] LIKE N'%{filter}%' or " +
                $" [DOC_TYPE] LIKE N'%{filter}%' or " +
                $" [CLIENTS].[FULL_NAME] LIKE N'%{filter}%' or " +
                $" [AREA] LIKE N'%{filter}%' or " +
                $" [APARTMENT_NUMBER] LIKE N'%{filter}%' or " +
                $" [HOUSE_NUMBER] LIKE N'%{filter}%' or " +
                $" [ESTATE].[COST] LIKE N'%{filter}%' or " +
                $" [STREET_NAME] LIKE N'%{filter}%'";

            List<DocumentsModel> res = new List<DocumentsModel>();

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        res.Add(new DocumentsModel
                        {
                            Цена_Документа = data.GetString(0),
                            Дата_Создания = data.GetDateTime(1).ToString("G"),
                            Имя_Документа = data.GetString(2),
                            Тип_Имущества = data.GetString(3),
                            ФИО = data.GetString(4),
                            Площадь = data.GetString(5),
                            Номер_Квартиры = data.GetInt32(6),
                            Номер_Дома = data.GetString(7),
                            Цена_Квартиры = data.GetString(8),
                            Улица = data.GetString(9)
                        });
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return res;
        }
    }
}
