using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication4.Models;

namespace WebApplication4.Data

{
    internal class FlowerDAO
    {
        public string connectionString = @"Data Source=DESKTOP-HGVMRFD;Initial Catalog=Flowers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<FlowerModel> FetchAll()
        {
            List<FlowerModel> list = new List<FlowerModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT  * from [dbo].[table] ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FlowerModel flower = new FlowerModel(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        list.Add(flower);

                    }
                }
            }

            return list;
        }
        public FlowerModel FetchOne(int Id)
        {
            FlowerModel flower = new FlowerModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT  * from [dbo].[table]  WHERE Id=@id ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = Id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        flower = new FlowerModel(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));

                    }
                }
                            }
            return flower;
        }
        public int CreateAndEdit(FlowerModel flowermodel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
				if (flowermodel.Id <= 0)
				{
                    sqlQuery = "INSERT INTO [dbo].[table] VALUES (@Name,@Price,@Amount)";
                                    }
				else
				{
					sqlQuery = "UPDATE  [dbo].[table]  SET Name=@Name ,Price=@Price, Amount=@Amount  WHERE Id=@id";
				}
				SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = flowermodel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 100).Value = flowermodel.Name;
                command.Parameters.Add("@Price", System.Data.SqlDbType.Int, 100).Value = flowermodel.Price;
                command.Parameters.Add("@Amount", System.Data.SqlDbType.Int, 100).Value = flowermodel.Amount;
                connection.Open();
                int newId=command.ExecuteNonQuery();
                return newId;
            }
                    }
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM [dbo].[table] WHERE Id = @id";
                 SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                 connection.Open();
                int DeleteId = command.ExecuteNonQuery();
               return DeleteId;
            }
        }
    }
}