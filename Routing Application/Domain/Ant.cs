using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Routing_Application.DAL;

namespace Routing_Application.Domain
{
    class Ant
    {
        private List<Wire> path = new List<Wire>();
        private double delta;
        public Ant()
        {
            
        }
        public List<Wire> Path
        {
            get { return path; }
            set { path = value; }
        }
        public double Delta
        {
            get { return delta; }
            set { delta = value; }
        }

    }
}
//hello