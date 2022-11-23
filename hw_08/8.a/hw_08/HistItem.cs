using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_8._1
{
    class HistItem
    {
        public int lower_bound { get; set; }
        public int upper_bound  { get; set; }
        public Boolean contains(double x) { return lower_bound <= x && x <= upper_bound; }
    }
}
