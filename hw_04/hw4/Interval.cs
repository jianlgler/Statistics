using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    internal class Interval
    {
        public double up;
        public double down;
        public Interval(double down, double up)
        {
            this.up = up;
            this.down = down;
        }

        public override string ToString()
        {
            return down.ToString() + " - " + up.ToString();
        }
    }
}
