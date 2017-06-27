using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence
{
    class DBConnection
    {
        public MySqlConnection connection;
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
            server = "89.238.232.245";
            database = "Stock";
            username = "sab";
            password = "SAB";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
