using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagonClass
{
    public class Comparer : IComparer<Wagon>
    {
        public int Compare(Wagon? x, Wagon? y)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
    }
}