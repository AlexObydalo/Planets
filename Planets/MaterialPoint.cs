using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets
{
    class MaterialPoint
    {
        public Vector R { get; set; }
        public Vector V { get; set; }
        public double M { get; set; }
        
        public void Move(double dt, Vector F)
        {
            Vector a = F / M;
            V += a * dt;
            R += V * dt;
        }
    }
}
