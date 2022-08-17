using MySql.Data.MySqlClient;

namespace PMS_Net.Models
{
    public class Connection
    {
        public MySqlConnection con { get; }
        public Connection()
        {
            string conString = "server=localhost;user=root;database=projectdb;port=3306;password=";
            MySqlConnection connection = new MySqlConnection(conString);
            connection.Open();
            this.con = connection;
        }
    }
}
