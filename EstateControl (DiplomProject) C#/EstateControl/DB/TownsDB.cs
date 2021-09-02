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
    class TownsDB
    {
        private Connect con;
        public TownsDB()
        {
            this.con = new Connect();
        }

        public void addTown(string town_name)
        {
            string expression = $"INSERT INTO [TOWNS] " +
                                  $"VALUES(N'{town_name}')";
            con.execute(expression);
        }

        public void updateTown(string old_name, string new_name)
        {
            string expression = $"UPDATE [TOWNS] " +
                               $"SET [TOWN_NAME] = N'{new_name}' WHERE [TOWN_NAME] = N'{old_name}'";
            con.execute(expression);
        }

        public void deleteTown(string town_name)
        {
            string expression = $"DELETE FROM [TOWNS] " +
                               $"WHERE [TOWN_NAME] = N'{town_name}'";
            con.execute(expression);
        }

        public List<TownsModel> getTowns(string filter)
        {
            string expression = "SELECT [TOWN_NAME] " +
                $"FROM [TOWNS] WHERE [TOWN_NAME] LIKE N'%{filter}%'";

            List<TownsModel> res = new List<TownsModel>();

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        res.Add(new TownsModel { Имя_Города = data.GetString(0)});
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return res;
        }

        public int getId(string town)
        {
            string expression = "SELECT [ID] " +
                $"FROM [TOWNS] WHERE [TOWN_NAME] = N'{town}'";

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
