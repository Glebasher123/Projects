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
    class ClientsDB
    {
        Connect con;
        public ClientsDB()
        {
            this.con = new Connect();
        }

        public void addClient(string number, string passport_number, string fullname)
        {
            string expression = $"INSERT INTO [CLIENTS] VALUES (N'{number}', N'{passport_number}', N'{fullname}', CONVERT(datetime, '{DateTime.Now}', 105))";
            con.execute(expression);
        }

        public void delClient(string number, string pass_number, string fullname)
        {
            string expression = $"DELETE FROM [CLIENTS] WHERE [NUMBER] = N'{number}' and [PASSPORT_NUMBER] = N'{pass_number}' and [FULL_NAME] = N'{fullname}'";
            con.execute(expression);
        }

        public List<ClientsModel> getClients(string filter)
        {
            string expression = $"SELECT [NUMBER], [PASSPORT_NUMBER], [FULL_NAME] FROM [CLIENTS] WHERE [NUMBER] LIKE N'%{filter}%' or [PASSPORT_NUMBER] LIKE N'%{filter}%' or [FULL_NAME] LIKE N'%{filter}%'";

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
                        res.Add(new ClientsModel { Номер_Телефона = data.GetString(0), Номер_Паспорта = data.GetString(1), ФИО = data.GetString(2)});
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return res;
        }

        public int getId(string passport_number)
        {
            string expression = $"SELECT [ID] FROM [CLIENTS] WHERE [FULL_NAME] = N'{passport_number}'";

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

        public ClientsModel getClientById(int id)
        {
            string expression = $"SELECT [NUMBER], [PASSPORT_NUMBER], [FULL_NAME] FROM [CLIENTS] WHERE [ID] = N'{id}'";

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
                        return new ClientsModel{ Номер_Телефона = data.GetString(0), Номер_Паспорта = data.GetString(1), ФИО = data.GetString(2) };
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return new ClientsModel();
        } 
    }
}
