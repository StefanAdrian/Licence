using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licence
{
    public partial class ChartTwoCompanies : Form
    {
        public ChartTwoCompanies()
        {
            InitializeComponent();
        }

        private void ChartFormTwoCompanies_Load(object sender, EventArgs e)
        {
            chart2.Series["Frankfurt"].XValueMember = "LastTradeDateTime";
            chart2.Series["Frankfurt"].YValueMembers = "Price";
            chart2.Series["Frankfurt"].BorderWidth = 3;
            chart2.Series["Bucharest"].BorderWidth = 3;
        }
    }
}
