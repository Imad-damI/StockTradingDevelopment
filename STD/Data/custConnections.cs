using MySqlConnector;
using STD.Components.Models;
using System.Data;

namespace STD.Data
{
    public class custConnections
    {
        public async Task<UserMaster[]> GetCustDetails(string login, String password)
        {
            List<UserMaster> list = new List<UserMaster>();
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("sp_custGet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter
                    {
                        ParameterName = "@logins",
                        DbType = DbType.String,
                        Value = login,
                        Direction = ParameterDirection.Input,
                    });
                    cmd.Parameters.Add(new MySqlParameter
                    {
                        ParameterName = "@passwords",
                        DbType = DbType.String,
                        Value = password,
                        Direction = ParameterDirection.Input,
                    });
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new UserMaster()
                            {
                                id = reader.GetInt32("id"),
                                login = reader.GetString("login"),
                                password = reader.GetString("password"),
                                wallet = reader.GetDouble("wallet"),
                            });
                        }
                    }
                }
            }
            return list.ToArray();
        }
    }
}
