using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace Furniture
{
    public class DataBaseAccess
    {
        private string connString;

        public DataBaseAccess()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public User GetUser(string userName)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM users where name=\"" + userName + "\";";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    {
                        User user = new User();
                        user.idUser = reader.GetInt32("idUser");
                        user.name = reader.GetString("name");
                        user.pass = reader.GetString("pass");
                        user.tip = reader.GetString("tip");
                        return user;
                    }
                }
            }

            return null;
        }
        public void AddUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO users(idUser, name, pass, tip) VALUES(@userid, @username, @password, @tip)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@userid", user.idUser);
                cmd.Parameters.AddWithValue("@username", user.name);
                cmd.Parameters.AddWithValue("@password", user.pass);
                cmd.Parameters.AddWithValue("@tip", user.tip);

                cmd.ExecuteNonQuery();
            }
        }
       
    }
}
