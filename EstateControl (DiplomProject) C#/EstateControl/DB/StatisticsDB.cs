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
    class StatisticsDB
    {
        Connect con;
        public StatisticsDB()
        {
            this.con = new Connect();
        }

        public List<ClientsModel> clients(DateTime start, DateTime end)
        {
            string expression = $"SELECT [NUMBER], [PASSPORT_NUMBER], [FULL_NAME] FROM [CLIENTS] WHERE [CREATED_AT] >= CONVERT(datetime, '{start}', 105) and [CREATED_AT] <= CONVERT(datetime, '{end}', 105)";

            List<ClientsModel> res = new List<ClientsModel>();

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        res.Add(new ClientsModel { Номер_Телефона = data.GetString(0), Номер_Паспорта = data.GetString(1), ФИО = data.GetString(2) });
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return res;
        }

        public List<DocumentsModel> documents(DateTime start, DateTime end)
        {
            string expression = "SELECT [DOCUMENTATION].[COST], [CREATE_DATE], [DOC_TYPE], [ESTATE].[OBJECT_TYPE], [CLIENTS].[FULL_NAME], [AREA], [APARTMENT_NUMBER], [HOUSE_NUMBER], [ESTATE].[COST], [STREETS].[STREET_NAME] " +
                $"FROM [DOCUMENTATION] JOIN [CLIENTS] ON" +
                $" [CLIENTS].[ID] = [DOCUMENTATION].[CLIENT_ID] JOIN [ESTATE]" +
                $" ON [ESTATE].[ID] = [DOCUMENTATION].[ESTATE_ID] JOIN [TOWNS]" +
                $" ON [TOWNS].[ID] = [ESTATE].[TOWN_ID] JOIN [STREETS]" +
                $" ON [STREETS].[ID] = [ESTATE].[STREET_ID] WHERE [DOCUMENTATION].[CREATE_DATE] >= CONVERT(datetime, '{start}', 105) and [DOCUMENTATION].[CREATE_DATE] <= CONVERT(datetime, '{end}', 105)";

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

        public List<AreaFromDate> areaFromDate(DateTime start, DateTime end)
        {
            string expression = "SELECT [TOWNS].[TOWN_NAME], [CREATE_DATE], [ESTATE].[OBJECT_TYPE], [CLIENTS].[FULL_NAME], [AREA], [APARTMENT_NUMBER], [HOUSE_NUMBER], [ESTATE].[COST], [STREETS].[STREET_NAME] " +
                $"FROM [DOCUMENTATION] JOIN [CLIENTS] ON" +
                $" [CLIENTS].[ID] = [DOCUMENTATION].[CLIENT_ID] JOIN [ESTATE]" +
                $" ON [ESTATE].[ID] = [DOCUMENTATION].[ESTATE_ID] JOIN [TOWNS]" +
                $" ON [TOWNS].[ID] = [ESTATE].[TOWN_ID] JOIN [STREETS]" +
                $" ON [STREETS].[ID] = [ESTATE].[STREET_ID] WHERE [DOCUMENTATION].[CREATE_DATE] >= CONVERT(datetime, '{start}', 105) and [DOCUMENTATION].[CREATE_DATE] <= CONVERT(datetime, '{end}', 105)";

            List<AreaFromDate> res = new List<AreaFromDate>();

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        res.Add(new AreaFromDate
                        {
                            Город = data.GetString(0),
                            Дата_Создания = data.GetDateTime(1).ToString("G"),
                            Тип_Имущества = data.GetString(2),
                            ФИО = data.GetString(3),
                            Площадь = data.GetString(4),
                            Номер_Квартиры = data.GetInt32(5),
                            Номер_Дома = data.GetString(6),
                            Цена_Квартиры = data.GetString(7),
                            Улица = data.GetString(8)
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
