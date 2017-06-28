using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Licence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DBConnection dbc;
        private static string query;
        private static MySqlCommand cmd;

        public MainWindow()
        {
            InitializeComponent();
            RebindData();
            SetTimer();
        }

        private static decimal ComputeDifference(decimal firstVal, decimal secondVal)
        {
            return Math.Abs(((firstVal - secondVal) * 100) / ((firstVal + secondVal) / 2));
        }

        private void MenuItem_Click_FRA_BMW(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "FRA - Bayerische Motoren Werke AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 1 AND Id_Exchange = 1", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_BAYN(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "FRA - Bayer AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 2 AND Id_Exchange = 1", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_LHA(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "FRA - Deutsche Lufthansa AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 3 AND Id_Exchange = 1", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_SIE(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "FRA - Siemens AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 4 AND Id_Exchange = 1", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_DBK(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "FRA - Deutsche Bank AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 5 AND Id_Exchange = 1", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_BVB_BMW(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "BVB - Bayerische Motoren Werke AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 1 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_BVB_BAYN(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "BVB - Bayer AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 2 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_BVB_LHA(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "BVB - Deutsche Lufthansa AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 3 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_BVB_SIE(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "BVB - Siemens AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 4 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_BVB_DBK(object sender, RoutedEventArgs e)
        {
            ChartSingleCompany cf = new ChartSingleCompany();
            cf.Text = "BVB - Deutsche Bank AG";
            SetChart1DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 5 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_vs_BVB_BMW(object sender, RoutedEventArgs e)
        {
            ChartTwoCompanies cf = new ChartTwoCompanies();
            cf.Text = "FRA vs BVB - Bayerische Motoren Werke AG";
            SetChart2DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 1 AND Id_Exchange = 1", "SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 1 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_vs_BVB_BAYN(object sender, RoutedEventArgs e)
        {
            ChartTwoCompanies cf = new ChartTwoCompanies();
            cf.Text = "FRA vs BVB - Bayer AG";
            SetChart2DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 2 AND Id_Exchange = 1", "SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 2 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_vs_BVB_LHA(object sender, RoutedEventArgs e)
        {
            ChartTwoCompanies cf = new ChartTwoCompanies();
            cf.Text = "FRA vs BVB - Deutsche Lufthansa AG";
            SetChart2DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 3 AND Id_Exchange = 1", "SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 3 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_vs_BVB_SIE(object sender, RoutedEventArgs e)
        {
            ChartTwoCompanies cf = new ChartTwoCompanies();
            cf.Text = "FRA vs BVB - Siemens AG";
            SetChart2DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 4 AND Id_Exchange = 1", "SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 4 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void MenuItem_Click_FRA_vs_BVB_DBK(object sender, RoutedEventArgs e)
        {
            ChartTwoCompanies cf = new ChartTwoCompanies();
            cf.Text = "FRA vs BVB - Deutsche Bank AG";
            SetChart2DataBinding("SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 5 AND Id_Exchange = 1", "SELECT Price, LastTradeDateTime FROM Stock.Data WHERE Id_Company = 5 AND Id_Exchange = 2", ref cf);
            cf.Show();
        }

        private void SetChart1DataBinding(string query, ref ChartSingleCompany cf)
        {
            dbc = new DBConnection();
            dbc.OpenConnection();
            cmd = new MySqlCommand(query, dbc.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                cf.chart1.Series["Series1"].Points.AddXY(dataReader.GetDateTime("LastTradeDateTime"), dataReader.GetDecimal("Price"));
            }
            dataReader.Close();
            dbc.CloseConnection();
        }

        private void SetChart2DataBinding(string queryFirstSeries, string querySecondSeries, ref ChartTwoCompanies cf)
        {
            dbc = new DBConnection();
            dbc.OpenConnection();
            cmd = new MySqlCommand(queryFirstSeries, dbc.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                cf.chart2.Series["Frankfurt"].Points.AddXY(dataReader.GetDateTime("LastTradeDateTime"), dataReader.GetDecimal("Price"));
            }
            dataReader.Close();

            cmd = new MySqlCommand(querySecondSeries, dbc.connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                cf.chart2.Series["Bucharest"].Points.AddXY(dataReader.GetDateTime("LastTradeDateTime"), dataReader.GetDecimal("Price"));
            }
            dataReader.Close();
            dbc.CloseConnection();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RebindData();
        }

        private void RebindData()
        {
            dbc = new DBConnection();
            dbc.OpenConnection();
            query = "SELECT Pret.PretFRA, Pret.PretBVB, Companies.Name FROM Pret INNER JOIN Companies ON Pret.Id = Companies.Id";
            List<CompanyPriceInfo> list = new List<CompanyPriceInfo>();
            cmd = new MySqlCommand(query, dbc.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                CompanyPriceInfo item = new CompanyPriceInfo()
                {
                    Name = (string)dataReader["Name"],
                    FRAPrice = (decimal)dataReader["PretFRA"],
                    BVBPrice = (decimal)dataReader["PretBVB"],
                    Difference = 0
                };
                item.Difference = ComputeDifference(item.FRAPrice, item.BVBPrice);
                list.Add(item);
            }

            dataReader.Close();
            dbc.CloseConnection();
            realTimeGrid.AutoGenerateColumns = false;
            realTimeGrid.ItemsSource = list;

            dbc = new DBConnection();
            dbc.OpenConnection();
            query = "SELECT Companies.Name, Exchanges.Ticker, Data.Price, Data.LastTradeDateTime FROM Stock.Data INNER JOIN Stock.Companies ON Data.Id_Company = Companies.Id INNER JOIN Stock.Exchanges ON Data.Id_Exchange = Exchanges.Id ORDER BY LastTradeDateTime DESC;";
            cmd = new MySqlCommand(query, dbc.connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            historicalpriceGrid.AutoGenerateColumns = false;
            historicalpriceGrid.DataContext = ds;
            dbc.CloseConnection();
        }

        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
    }
}
