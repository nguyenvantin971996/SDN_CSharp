using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Routing_Application.DAL
{

    public class Generate : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public Generate(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> GeneratePopulation(Router startRouter, Router endRouter, int N)
        {
            List<Individual> population = new List<Individual>();
            for (int i = 0; i < N; i++)
            {
                population.Add(new Individual());
            }
            //danh sach tat ca cac dinh
            List<Router> list_routers = network.Routers;
            Router[] list_rtrs = new Router[list_routers.Count];
            list_rtrs[0] = startRouter;
            int ii = 1;
            foreach (Router rt in list_routers)
            {
                if (rt != startRouter && rt != endRouter)
                {
                    list_rtrs[ii] = rt;
                    ii++;
                }
            }
            int m = list_routers.Count;
            list_rtrs[m - 1] = endRouter;
            for (int i = 0; i < N; i++)
            {
            tt1:
                double[] priority = new double[m];
                for (int j = 0; j < m; j++)
                {
                    priority[j] = ran.NextDouble() * 2 - 1;
                }
                Individual path = Particle_Decoding(startRouter, endRouter, priority, list_rtrs);
                if (path.path_wires.Count == 0)
                {
                    goto tt1;
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        population[i]=path.DeepCopy();
                    }
                }
            }
            return population;
        }
    }
}
