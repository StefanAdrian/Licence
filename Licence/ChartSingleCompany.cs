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
    public partial class ChartSingleCompany : Form
    {
        public ChartSingleCompany()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            chart1.Series["Series1"].XValueMember = "LastTradeDateTime";
            chart1.Series["Series1"].YValueMembers = "Price";
            chart1.Series["Series1"].BorderWidth = 3;
        }
    }
}
