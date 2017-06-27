using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection dbc = new DBConnection();
            dbc.OpenConnection();
            string query = "SELECT Price FROM Stock.Data WHERE Id_Exchange = 1 AND Id_Company = 1";

            MySqlCommand cmd = new MySqlCommand(query, dbc.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                this.chart1.Series["Price"].Points.AddXY(dataReader.GetDecimal("Price"));
            }

            dataReader.Close();
            dbc.CloseConnection();
        }
    }
}
