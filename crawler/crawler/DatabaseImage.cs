using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler
{
    class DatabaseImage
    {
        private DatabaseConnection conn = null;

        public DatabaseImage(DatabaseConnection con) {
            conn = con;
        }

        public void createTables()
        {
            string query = "CREATE TABLE Images (id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY, url TEXT, description TEXT, time datetime);";
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            try { cmd.ExecuteNonQuery(); }
            catch { }
        }

        public bool doImageExist(HtmlImage web)
        {
            string query = "SELECT EXISTS(SELECT * FROM Images WHERE url = \"" + web.url.AbsoluteUri + "\");";
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader re = cmd.ExecuteReader();
            re.Read();
            bool exists = (Int64)re.GetValue(0) == 1;
            re.Close();
            return exists;
        }

        public void entryImage(HtmlImage web)
        {
            DateTime t = DateTime.Now;
            string query = "INSERT Images (url, description, time) VALUES " +
                "(\"" + web.url.AbsoluteUri + "\", " +
                "\"" + web.description + "\"," +
                "\"" + t.ToString("yyyy-MM-dd H:mm:ss") + "\");";

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
