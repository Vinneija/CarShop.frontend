using System;
using System.Data.SqlClient;


namespace CarShop.Library
{
    public class DbOperations
    {
        public void AddCarToDB ()
        {
            string connectionString =
                @"Data Source=LAPTOP-9KVL4IOV\SQLEXPRESS01;Initial Catalog=CarsInStore;Integrated Security=true";
            string queryString= "insert into Car (Id, Model, Year, Color, Sold, IsAvailable)" + "Values (@ID, @Model, @Year, @Color, @Sold, @IsAvailable)";

            var paramValue1 = "7";
            var paramValue2 = "MB";
            var paramValue3 = "2014";
            var paramValue4 = "grey";
            var paramValue5 = "1";
            var paramValue6 = "3";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", paramValue1);
                command.Parameters.AddWithValue("@Model", paramValue2);
                command.Parameters.AddWithValue("@Year", paramValue3);
                command.Parameters.AddWithValue("@Color", paramValue4);
                command.Parameters.AddWithValue("@@Sold", paramValue5);
                command.Parameters.AddWithValue("@IsAvailable", paramValue6);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    //SqlDataReader reader = command.ExecuteReader();
                    //while (reader.Read())
                    //{
               
                    //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                    //reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    //}
                    //reader.Close();
                    Console.WriteLine("Successfuly execute script");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
    

