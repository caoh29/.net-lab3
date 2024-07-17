using Npgsql;
using week10.Models;

namespace week10.Data
{
    public class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<PriceModel> GetData()
        {
            List<PriceModel> dataList = new List<PriceModel>();

            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT pid, productname FROM prices", conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PriceModel data = new PriceModel
                            {
                                // Assuming YourModel has properties that match your table columns
                                pid = reader.GetInt32(reader.GetOrdinal("pid")),
                                productname = reader.GetString(reader.GetOrdinal("productname"))
                                // Add other properties here
                            };
                            dataList.Add(data);
                        }
                    }
                }
            }
            return dataList;
        }

    }
}
