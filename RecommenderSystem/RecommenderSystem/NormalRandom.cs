using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    public class NormalRandom
    {
        private Random rand;
        private double mean;
        private double stdDev;

        public NormalRandom(double mean, double stdDev)
        {
            rand = new Random();
            this.mean = mean;
            this.stdDev = stdDev;
        }

        public double Next()
        {
            double u1 = 1.0 - rand.NextDouble(); 
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); 
            return mean + stdDev * randStdNormal; 
        }
    }
}
