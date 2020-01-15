using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ
{
    public class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;

        public DBConnection()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "cs322_pz";
            username = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + username + ";" +
                               "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //  MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //   MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //  MessageBox.Show(ex.Message);
                //  Console.Out(ex.Message);
                return false;
            }
        }

    }
}
