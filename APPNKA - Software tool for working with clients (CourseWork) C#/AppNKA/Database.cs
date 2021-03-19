using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AppNKA
{
    static class Database
    {
        static SqlConnection Connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=NKA1;Integrated Security=True;MultipleActiveResultSets=True"); //подключение к sql

        public static void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open(); Debug.WriteLine("Connected");
        }

        public static void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }


        public static bool RegisterUser(string Login, string Password, string Name)
        {
            try
            {
                SqlCommand command = new SqlCommand("exec registeruser @login, @pass, @name", Connection);
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = Login;
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = Password;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = Name;
                command.ExecuteNonQuery();
                return true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return false;
            }
        }




        public static bool LoginUser(string Login, string Password)
        {

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE login_ like '{Login}';", Connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {

                        string password = reader.GetValue(1).ToString();
                        reader.Close();
                        if (password == Password)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return false;
        }

        public struct Options
        {
            public int id;
            public string kad;
            public string name;
            public string fam;
            public string otch;
            public string number;
            public string address;

            public double stoim2;
            public double square;
            public string sost;
            public double sumstoim;

            public string postavka;
            public double stoimfun;
            public string objectsd;

            public string method;
            public string zakazchik;

            public string regist;
            public string ychet;
            public string datereg;
        }

        public static bool AddUser(Options options)
        {
            try
            {
                SqlCommand command = new SqlCommand("insert into [Данные клиента] ([ID клиента], Фамилия, Имя, Отчество, [Контактный номер], [Адрес проживания]) values (@id, @fam, @im, @ot4, @num, @adr)", Connection); goto Flex;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = options.id;
                command.Parameters.Add("@fam", SqlDbType.VarChar).Value = options.fam;
                command.Parameters.Add("@im", SqlDbType.VarChar).Value = options.name;
                command.Parameters.Add("@ot4", SqlDbType.VarChar).Value = options.otch;
                command.Parameters.Add("@num", SqlDbType.VarChar).Value = options.number;
                command.Parameters.Add("@adr", SqlDbType.VarChar).Value = options.address;
                command.ExecuteNonQuery();

                command = new SqlCommand("insert into [Информация о участке] ([Кадастровый номер участка],[Стоимость м2, руб], [Уточненная площадь], [Состояние объекта], [Кадастровая стоимость, руб], [ID клиента])  values (@kad, @stoim2, @sq, @sost, @stoim, @id)", Connection);
                command.Parameters.Add("@stoim2", SqlDbType.VarChar).Value = options.stoim2;
                command.Parameters.Add("@sq", SqlDbType.VarChar).Value = options.square;
                command.Parameters.Add("@sost", SqlDbType.VarChar).Value = options.sost;
                command.Parameters.Add("@stoim", SqlDbType.VarChar).Value = options.sumstoim;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = options.id;
                command.Parameters.Add("@Kad", SqlDbType.VarChar).Value = options.kad;
                command.ExecuteNonQuery();

                command = new SqlCommand("insert into [Информация о строительстве] ([Номер строительства],[Поставщики отделочных материалов], [Стоимость фундамента], [Объект сдан или нет], [Кадастровый номер участка]) values (@numst, @post, @stoimfun, @sdan, @kad)", Connection);
                command.Parameters.Add("@post", SqlDbType.VarChar).Value = options.postavka;
                command.Parameters.Add("@stoimfun", SqlDbType.VarChar).Value = options.stoimfun;
                command.Parameters.Add("@sdan", SqlDbType.VarChar).Value = options.objectsd;
                command.Parameters.Add("@kad", SqlDbType.VarChar).Value = options.kad;
                command.Parameters.Add("@numst", SqlDbType.VarChar).Value = options.kad + 1;
                command.ExecuteNonQuery();

                command = new SqlCommand("insert into [Таблица оценки участка] ([Метод оценки участка], [Заказчик кадастровой оценки], [Кадастровый номер участка], [Номер строительства], [ID оценки]) values (@met, @zak, @kad, @num, @idoc)", Connection);
                command.Parameters.Add("@met", SqlDbType.VarChar).Value = options.method;
                command.Parameters.Add("@zak", SqlDbType.VarChar).Value = options.zakazchik;
                command.Parameters.Add("@num", SqlDbType.VarChar).Value = options.number;
                command.Parameters.Add("@kad", SqlDbType.VarChar).Value = options.kad;
                command.Parameters.Add("@idoc", SqlDbType.VarChar).Value = options.kad + 3;
                command.ExecuteNonQuery(); Flex:

                command = new SqlCommand("insert into [Данные клиента] ([ID клиента], Фамилия, Имя, Отчество, [Контактный номер], [Адрес проживания], [Стоимость м2, руб], [Уточненная площадь], [Состояние объекта], [Кадастровая стоимость, руб], [Поставщики отделочных материалов], [Стоимость фундамента], [Объект сдан или нет], [Метод оценки участка], [Заказчик кадастровой оценки], [Используемый регистр контроля], [Поставлен ли участок на учёт], [Дата регистрации]) values (@id, @fam, @name, @otch, @number, @address, @stoim2, @square, @sost, @sumstoim, @postavka, @stoimfun, @objectsd, @method, @zakazchik, @regist, @ychet, @datereg)", Connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = options.id;
                command.Parameters.Add("@fam", SqlDbType.VarChar).Value = options.name; //@stoim2,, , , @postavka, @stoimfun, @objectsd, @method, @zakazchik, @regist, @ychet
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = options.fam;
                command.Parameters.Add("@otch", SqlDbType.VarChar).Value = options.otch;
                command.Parameters.Add("@number", SqlDbType.VarChar).Value = options.number;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = options.address;
                command.Parameters.Add("@stoim2", SqlDbType.VarChar).Value = options.stoim2;
                command.Parameters.Add("@square", SqlDbType.VarChar).Value = options.square;
                command.Parameters.Add("@sost", SqlDbType.VarChar).Value = options.sost;
                command.Parameters.Add("@sumstoim", SqlDbType.VarChar).Value = options.sumstoim;
                command.Parameters.Add("@postavka", SqlDbType.VarChar).Value = options.postavka;
                command.Parameters.Add("@stoimfun", SqlDbType.VarChar).Value = options.stoimfun;
                command.Parameters.Add("@objectsd", SqlDbType.VarChar).Value = options.objectsd;
                command.Parameters.Add("@method", SqlDbType.VarChar).Value = options.method;
                command.Parameters.Add("@zakazchik", SqlDbType.VarChar).Value = options.zakazchik;
                command.Parameters.Add("@regist", SqlDbType.VarChar).Value = options.regist;
                command.Parameters.Add("@ychet", SqlDbType.VarChar).Value = options.ychet;
                command.Parameters.Add("@datereg", SqlDbType.VarChar).Value = options.datereg;
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public static bool ExtendedUser(string Num, string Post, string Stoim, string Sdan, string Kadr)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Информация о строительстве] ([Номер строительства], [Поставщики отделочных материалов], [Стоимость фундамента], [Объект сдан или нет], [Кадастровый номер участка]) VALUES (@num, @post, @fun, @obj, @kad)", Connection);
                command.Parameters.Add("num", SqlDbType.Int).Value = Num;
                command.Parameters.Add("@post", SqlDbType.VarChar).Value = Post;
                command.Parameters.Add("@fun", SqlDbType.Int).Value = Stoim;
                command.Parameters.Add("@obj", SqlDbType.VarChar).Value = Sdan;
                command.Parameters.Add("@kad", SqlDbType.Int).Value = Kadr;


                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddUserInfo(string stoim, string square, string sost, double calc, string IDClient)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Информация о участке] ([Стоимость м2, руб], [Уточненная площадь], [Состояние объекта], [Кадастровая стоимость, руб], [ID клиента]) VALUES (@mk, @sq, @sost, @stoim, @id)", Connection);
            command.Parameters.Add("@mk", SqlDbType.Int).Value = stoim;
            command.Parameters.Add("@sq", SqlDbType.Int).Value = square;
            command.Parameters.Add("@sost", SqlDbType.VarChar).Value = sost;
            command.Parameters.Add("@stoim", SqlDbType.Int).Value = calc;
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = IDClient;
            command.ExecuteNonQuery();
            return true;
        }

        public static DataView FillDataGrid(string sqlCommand)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(sqlCommand, Connection));
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Debug.WriteLine(adapter.SelectCommand);
            return dt.DefaultView;
        }

        public static bool RemoveUser(DataRowView dataRow)
        {
            using (SqlCommand RemoveViewed = new SqlCommand($"delete from [Данные Клиента] where [ID Клиента] = {dataRow[0]}", Connection))
            {
                RemoveViewed.ExecuteReader().Close();
                return true;
            }
        }

        public static void UpdateUser(string id, string name, string surname, string lastname, string contact, string adres, string Stoimost, string utochn, string sostoy, string kadastr, string postavka, string stoim2, string oBject, string method, string zakaz, string register, string ispolz)
        {
            using (SqlCommand UpdateItem = new SqlCommand($"update [Данные клиента] set [Имя] = '{name}', Фамилия = '{surname}', [Адрес проживания] = '{adres}', [Контактный номер] = '{contact}', [Отчество] = '{lastname}', [Стоимость м2, руб] = '{stoim2}', [Уточненная площадь] = '{utochn}',  [Состояние объекта] = '{sostoy}', [Кадастровая стоимость, руб] = '{kadastr}', [Поставщики отделочных материалов] = '{postavka}', [Стоимость фундамента] = '{Stoimost}', [Объект сдан или нет] = '{oBject}', [Метод оценки участка] = '{method}', [Заказчик кадастровой оценки] = '{zakaz}', [Используемый регистр контроля] = '{register}', [Поставлен ли участок на учёт] = '{ispolz}' where [ID клиента] = '{id}' ", Connection))

            {
                UpdateItem.ExecuteNonQuery();
            }
        }

    }

}
