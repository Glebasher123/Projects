using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EstateControl.DB
{
    class Connect
    {
        
        public string connectString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.CurrentDirectory}\\Database1.mdf;Integrated Security=True;";

        public Connect()
        {
        }

        public void execute(string expression)
        {

            using (SqlConnection connect = new SqlConnection(this.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Готово");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
     }
    
}
