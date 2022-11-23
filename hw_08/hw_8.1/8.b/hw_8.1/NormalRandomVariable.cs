using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_8._1
{
    class NormalRandomVariableGenerator
    {
        double mean;
        double stdDev;
        double variance;
        Random r1, r2;

        public NormalRandomVariableGenerator(double mean, double variance)
        {
            this.mean = mean;
            this.stdDev = Math.Sqrt(variance);
            this.variance = variance;

            r1 = new Random();  r2 = new Random();
        }

        public double getMean() { return this.mean; }
        public double getStdDev() { return this.stdDev; }
        public double getVariance() { return this.variance; }

        public double X() 
        {
            double r = Math.Sqrt(-2 * Math.Log(r1.NextDouble()));
            double theta = r2.NextDouble() * 2 * Math.PI;

            double x = r * Math.Cos(theta) * this.getStdDev() + this.getMean();

            return x;
        }

        public double Y()
        {
            double r = Math.Sqrt(-2 * Math.Log(r1.NextDouble()));
            double theta = r2.NextDouble() * 2 * Math.PI;

            double y = r * Math.Sin(theta) * this.getStdDev() + this.getMean();

            return y;
        }

        public static NormalRandomVariableGenerator getStdGenerator() { return new NormalRandomVariableGenerator(0, 1); }
    }
}
