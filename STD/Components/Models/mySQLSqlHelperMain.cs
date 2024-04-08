using MySqlConnector;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace STD.Components.Models
{
    public class mySQLSqlHelperMain
    {
        // This field gets initialized at Startup.cs
        public static string? conStr;
        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(conStr);
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task<int> InsertPortfolio(string symbol, string description, float bid)
        {
            using (MySqlConnection connection = mySQLSqlHelper.GetConnection())
            {
                connection.Open();
                Console.WriteLine("Otwarto połączenie:" + connection.ConnectionString);
                string insertQuery = "INSERT INTO `portfolio` (`stock_id`, `user_id`, `symbol`, `description`, `bid`, `amount`, `date`) VALUES (NULL, '1', @Symbol, @Description, @Bid, '5', current_timestamp())";
                using (var cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Symbol", symbol);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Bid", bid);
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
