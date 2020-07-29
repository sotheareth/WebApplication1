using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Discount
    {
        public int MinimumItemCount { get; set; }
        public double MinimumBillAmount { get; set; }
        public double Percentage { get; set; }
    }
}
