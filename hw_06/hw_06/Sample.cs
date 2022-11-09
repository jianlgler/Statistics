using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace hw_06
{
    class Sample
    {
        private int size;
        private List<Data> batch;
        private double mean, variance;

        public Sample(int size)
        {
            this.size = size;

            Random rnd = new Random();
            
            batch = new List<Data>();
            for (int i = 0; i < size; i++) batch.Add(new Data(rnd.Next(100)));

            mean = batch.Average(d => d.getValue());
            variance = (batch.Average(d => Math.Pow(d.getValue() - mean, 2)));
        }

        public int getSize() { return this.size; }
        public List<Data> getBatch() { return batch; } 
        public double getMean() { return mean; }
        public double getVariance() { return variance; }
    }
}
