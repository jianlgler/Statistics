using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_8._1
{
    class HistItem
    {
        public double lower_bound { get; set; }
        public double upper_bound  { get; set; }
        public Boolean contains(double x) { return lower_bound <= x && x <= upper_bound; }
    }
}
