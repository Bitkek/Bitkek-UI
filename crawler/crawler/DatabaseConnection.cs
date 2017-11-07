using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace crawler
{
    class DatabaseConnection
    {
        private MySqlConnection connection = null;
        public DatabaseConnection() {
            String server = "localhost";
            String database = "engine";
            String uid = "root";
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "User=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public MySqlConnection getConnection() {
            return connection;
        }

    }
}
