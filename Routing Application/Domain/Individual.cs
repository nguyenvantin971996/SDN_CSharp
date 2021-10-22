using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Application.Domain
{
    public class Individual
    {
        public List<Wire> path_wires { get; set; }
        public List<Router> path_routers { get; set; }
        public double fitness { get; set; }

        public List<double> velocity { get; set; }
        public List<double> best_code_path { get; set; }
        public double best_fitness { get; set; }
        public double fitness_vector { get; set; }
        public List<double> code_path { get; set; }
        public List<double> viewingg { get; set; }
        public List<Router> view_router { get; set; }
        public int tc { get; set; }
        public int ts { get; set; }
        public int trc { get; set; }
        public Individual()
        {
            this.path_wires =  new List<Wire>();
            this.path_routers = new List<Router>();
            this.viewingg = new List<double>();
            this.view_router = new List<Router>();
            this.tc = new int();
            this.ts = new int();
            this.trc = new int();
            this.fitness = new double();
            this.best_fitness = new double();
            this.velocity = new List<double>();
            this.best_code_path = new List<double>();
            this.fitness_vector = new double();
            this.code_path = new List<double>();
        }
        public Individual ShallowCopy()
        {
            return (Individual)this.MemberwiseClone();
        }

        public Individual DeepCopy()
        {
            Individual other = (Individual)this.MemberwiseClone();
            other.path_wires = new List<Wire>(this.path_wires);
            other.path_routers = new List<Router>(this.path_routers);
            other.viewingg = new List<double>(this.viewingg);
            other.view_router = new List<Router>(this.view_router);
            other.tc = this.tc;
            other.ts = this.ts;
            other.trc = this.trc;
            other.fitness = this.fitness;
            other.best_fitness = this.best_fitness;
            other.velocity = new List<double>(this.velocity);
            other.best_code_path = new List<double>(this.best_code_path);
            other.fitness_vector = this.fitness_vector;
            other.code_path = new List<double>(this.code_path);
            return other;
        }
    }
}
