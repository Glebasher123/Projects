using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursa4Wpf
{
    class DataBase
    {
        SqlConnection Connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Authoriz;Integrated Security=True"); //подключение к sql

        public void OpenConnection ()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();
        }

        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }

        public SqlConnection getConnection()
        {
            return Connection;
        }
    }
}
