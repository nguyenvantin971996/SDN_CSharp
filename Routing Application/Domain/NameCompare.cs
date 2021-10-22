using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Application.Domain
{
    public class NameCompare : IComparer<Individual>
    {
        public int Compare(Individual x, Individual y)
        {
            if (x == null || y == null)
            {
                throw new InvalidOperationException();
            }
            if (x.fitness < y.fitness)
            {
                return -1;
            }
            else if (x.fitness == y.fitness)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
