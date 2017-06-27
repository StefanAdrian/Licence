using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence
{
    public class CompanyPriceInfo
    {
        public string Name { get; set; }
        public decimal FRAPrice { get; set; }
        public decimal BVBPrice { get; set; }
        public decimal Difference { get; set; }
    }
}
