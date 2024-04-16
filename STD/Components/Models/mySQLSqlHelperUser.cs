using MySqlConnector;

namespace STD.Components.Models
{
    public class mySQLSqlHelperUser
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

        public static async Task<int> InsertHistory(string symbol, string description, float bid, int amount, DateTime date, float profit)
        {
            using (MySqlConnection connection = mySQLSqlHelper.GetConnection())
            {
                connection.Open();
                Console.WriteLine("Otwarto połączenie:" + connection.ConnectionString);
                string insertQuery = "INSERT INTO `history` (`his_id`, `user_id`, `symbol`, `description`, `bid`, `amount`, `date`, `sell_date`, `profit`)\r\nVALUES (NULL, '1', @Symbol, @Description, @Bid, @Amount, @Date, current_timestamp(), @Profit)";
                using (var cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Symbol", symbol);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Bid", bid);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Profit", profit);
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        

        
    
}
}
