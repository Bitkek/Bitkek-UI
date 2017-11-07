using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace crawler
{
    class DatabasePage
    {
        DatabaseConnection conn = null;
        public DatabasePage(DatabaseConnection con) {
            conn = con;
        }

        public void createTables()
        {
            string query = "CREATE TABLE Pages (id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY, url TEXT, time datetime);";
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            try { cmd.ExecuteNonQuery(); }
            catch { }
        }

        public bool doPageExist(Page web)
        {
            string query = "SELECT EXISTS(SELECT * FROM Pages WHERE url = \"" + HttpUtility.HtmlEncode(web.getPagePath()) + "\");";
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader re = cmd.ExecuteReader();
            re.Read();
            bool exists = (Int64)re.GetValue(0) == 1;
            re.Close();
            return exists;
        }

        public void entryPage(Page web)
        {
            DateTime t = DateTime.Now;
            string query = "INSERT Pages (url, time) VALUES " +
                "(\"" + HttpUtility.HtmlEncode(web.getPagePath()) + "\", " +
                "\"" + t.ToString("yyyy-MM-dd H:mm:ss") + "\");";

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.ExecuteNonQuery();
        }

    }
}
