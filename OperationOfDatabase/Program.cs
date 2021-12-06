using System.Data.SqlClient;

namespace DataBaseOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"Data Source=laptop-9kvl4iov\sqlexpress01;Initial Catalog=UniversityDB;Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            //string queryString = "select * from Students " +
                                 //"where Name = @name";

            string queryString = "insert into Students (Name, Surname, Age, Gender, UniversityID)" + "Values (@Name, @Surname, @Age, @Gender, @UniversityId)";

            // Specify the parameter value.
            var paramValue1 = "Janis";
            var paramValue2 = "Akmentins";
            var paramValue3 = "18";
            var paramValue4 = "male";
            var paramValue5 = "1";


            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Name", paramValue1);
                command.Parameters.AddWithValue("@Surname", paramValue2);
                command.Parameters.AddWithValue("@Age", paramValue3);
                command.Parameters.AddWithValue("@Gender", paramValue4);
                command.Parameters.AddWithValue("@UniversityID", paramValue5);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    //SqlDataReader reader = command.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //please full field your object properties here
                    //Console.WriteLine("\t{0}\t{1}\t{2}",
                    // reader[0], reader[1], reader[2]);
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
