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
    class EstateDB
    {
        Connect con;
        TownsDB townsDB = new TownsDB();
        StreetsDB streetsDB = new StreetsDB();
        public EstateDB()
        {
            this.con = new Connect();
        }

        public void addEstate(string type, int floor, int number_of_rooms, string area, int apartment_number, string house_number, string cost, string notes, string town, string street)
        {
            int townId = this.townsDB.getId(town);
            int streetId = this.streetsDB.getId(street);
            string expression = "INSERT INTO [ESTATE] " +
                $"VALUES (N'{type}', {floor}, {number_of_rooms}, N'{area}', {apartment_number}, {house_number}, N'{cost}', N'{notes}', {townId}, {streetId})";
            con.execute(expression);
        }

        public void delEstate(string type, int floor, int number_of_rooms, string area, int apartment_number, string house_number, string cost, string notes, string town, string street)
        {
            int townId = this.townsDB.getId(town);
            int streetId = this.streetsDB.getId(street);
            string expression = $"DELETE FROM [ESTATE] " +
                               $"WHERE [OBJECT_TYPE] = N'{type}' and [FLOOR] = {floor} and [NUMBER_OF_ROOMS] = {number_of_rooms} and [AREA] = N'{area}' and [APARTMENT_NUMBER] = {apartment_number} and [HOUSE_NUMBER] = N'{house_number}' and [COST] = N'{cost}' and [NOTES] = N'{notes}' and [TOWN_ID] = {townId} and [STREET_ID] = {streetId}";
            con.execute(expression);
        }

        public List<EstateModel> getEstate(string filter)
        {
            string expression = "SELECT [OBJECT_TYPE], [FLOOR], [NUMBER_OF_ROOMS], [AREA], [APARTMENT_NUMBER], [HOUSE_NUMBER], [COST], [TOWN_NAME], [STREET_NAME], [NOTES] " +
                $"FROM [ESTATE] JOIN [TOWNS] ON [TOWNS].[ID] = [ESTATE].[TOWN_ID] JOIN [STREETS] ON [STREETS].[ID] = [ESTATE].[STREET_ID] " +
                $"WHERE [OBJECT_TYPE] LIKE N'%{filter}%' or " +
                $"[FLOOR] LIKE N'%{filter}%' or " +
                $"[NUMBER_OF_ROOMS] LIKE N'%{filter}%' or " +
                $"[AREA] LIKE N'%{filter}%' or " +
                $"[APARTMENT_NUMBER] LIKE N'%{filter}%' or " +
                $"[HOUSE_NUMBER] LIKE N'%{filter}%' or " +
                $"[COST] LIKE N'%{filter}%' or " +
                $"[TOWN_NAME] LIKE N'%{filter}%' or " +
                $"[STREET_NAME] LIKE N'%{filter}%' or " +
                $"[NOTES] LIKE N'%{filter}%'";

            List<EstateModel> res = new List<EstateModel>();

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        res.Add(new EstateModel { Тип = data.GetString(0), Этаж = data.GetInt32(1), Количесвто_Комнат = data.GetInt32(2), Площадь = data.GetString(3), Номер_Квартиры = data.GetInt32(4), Номер_Дома = data.GetString(5), Цена = data.GetString(6), Город = data.GetString(7), Улица = data.GetString(8), Примечания = data.GetString(9) });
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return res;
        }

        public List<EstateModel> getEstate(int id)
        {
            string expression = "SELECT [OBJECT_TYPE], [FLOOR], [NUMBER_OF_ROOMS], [AREA], [APARTMENT_NUMBER], [HOUSE_NUMBER], [COST], [TOWN_NAME], [STREET_NAME], [NOTES] " +
                $"FROM [ESTATE] JOIN [TOWNS] ON [TOWNS].[ID] = [ESTATE].[TOWN_ID] JOIN [STREETS] ON [STREETS].[ID] = [ESTATE].[STREET_ID] WHERE [ESTATE].[ID] = {id}";

            List<EstateModel> res = new List<EstateModel>();

            using (SqlConnection connect = new SqlConnection(con.connectString))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(expression, connect);
                    SqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        res.Add(new EstateModel { Тип = data.GetString(0), Этаж = data.GetInt32(1), Количесвто_Комнат = data.GetInt32(2), Площадь = data.GetString(3), Номер_Квартиры = data.GetInt32(4), Номер_Дома = data.GetString(5), Цена = data.GetString(6), Город = data.GetString(7), Улица = data.GetString(8), Примечания = data.GetString(9) });
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return res;
        }

        public int getId(string type, string area, int apartment_number, string house_number, string cost, string street)
        {
            int streetId = this.streetsDB.getId(street);
            string expression = "SELECT [ID] FROM [ESTATE] " +
                $"WHERE [OBJECT_TYPE] = N'{type}' and [AREA] = N'{area}' and [APARTMENT_NUMBER] = {apartment_number} and [HOUSE_NUMBER] = N'{house_number}' and [COST] = N'{cost}' and [STREET_ID] = {streetId}";
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
