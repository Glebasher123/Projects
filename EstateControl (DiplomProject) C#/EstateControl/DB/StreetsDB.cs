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
    class StreetsDB
    {
        private Connect con;
        public StreetsDB()
        {
            this.con = new Connect();
        }

        public void addStreet(string street_name)
        {
            string expression = $"INSERT INTO [STREETS] " +
                                  $"VALUES(N'{street_name}')";
            con.execute(expression);
        }

        public void updateStreet(string old_name, string new_name)
        {
            string expression = $"UPDATE [STREETS] " +
                               $"SET [STREET_NAME] = N'{new_name}' WHERE [STREET_NAME] = N'{old_name}'";
            con.execute(expression);
        }

        public void deleteStreet(string street_name)
        {
            string expression = $"DELETE FROM [STREETS] " +
                               $"WHERE [STREET_NAME] = N'{street_name}'";
            con.execute(expression);
        }

        public List<StreetsModel> getStreets(string filter)
        {
            string expression = "SELECT [STREET_NAME] " +
                $"FROM [STREETS] WHERE [STREET_NAME] LIKE N'%{filter}%'";

            List<StreetsModel> res = new List<StreetsModel>();

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        res.Add(new StreetsModel { Имя_Улицы = data.GetString(0) });
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return res;
        }

        public int getId(string street)
        {
            string expression = "SELECT [ID] " +
                $"FROM [STREETS] WHERE [STREET_NAME] = N'{street}'";
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
    }
}
