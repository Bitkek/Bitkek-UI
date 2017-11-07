using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web;

namespace crawler
{
    class DatabaseWebsite
    {
        private DatabaseConnection conn = null;

        public DatabaseWebsite(DatabaseConnection con) {
            conn = con;
        }

        public void createTables() {
            string query = "CREATE TABLE Websites (id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY, domain TEXT, title TEXT, description TEXT,keywords TEXT, time datetime);";
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            try { cmd.ExecuteNonQuery(); }
            catch { }
        }

        public bool doWebsiteExist(Website web) {
            string query = "SELECT EXISTS(SELECT * FROM Websites WHERE domain = \"" + web.getHost() + "\");";
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader re = cmd.ExecuteReader();
            re.Read();
            bool exists = (Int64)re.GetValue(0) == 1;
            re.Close();
            return exists;
        }

        public void entryWbsite(Website web) {
            DateTime t = DateTime.Now;
            string query = "INSERT Websites (domain, time, title, description, keywords) VALUES " +
                "(\"" + web.getHost() +"\", " +
                "\""+ t.ToString("yyyy-MM-dd H:mm:ss") +"\", " +
                "\""+ HttpUtility.HtmlEncode(web.getTitle())+"\", " +
                "\""+ HttpUtility.HtmlEncode(web.getDescription())+"\", " +
                "\"" + HttpUtility.HtmlEncode ( web.getTags())+"\");";

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
