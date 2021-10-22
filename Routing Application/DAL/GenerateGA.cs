using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Routing_Application.DAL
{

    public class GenerateGA : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public GenerateGA(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Generate_GA(Router startRouter, Router endRouter, int N)
        {
            List<Individual> population = new List<Individual>();
            for (int i = 0; i < N; i++)
            {
                population.Add(new Individual());
            }
            List<Router> listt = new List<Router>();
            foreach (Router router in network.Routers)
            {
                if (router != startRouter && router != endRouter)
                {
                    listt.Add(router);
                }
            }
            //получение популяции
            for (int i = 0; i < N; i++)
            {
                List<Wire> path_w = new List<Wire>();
                List<Router> path_r = new List<Router>();
                List<Router> list = new List<Router>();
                foreach (Router router in listt)
                {
                    list.Add(router);
                }
            tt1:
                Router current_router = startRouter;
                path_r.Add(startRouter);
                List<Router> lis = new List<Router>();
            tt2:
                Boolean x = false;
                foreach (Port prt in current_router.Ports)
                {
                    if (!path_r.Contains(prt.Router))
                    {
                        x = true;
                        break;
                    }
                }
                if (x)
                {
                tt3: int y = ran.Next(current_router.Ports.Count);
                    Port port = current_router.Ports[y];
                    if (path_r.Contains(port.Router))
                    {
                        goto tt3;
                    }
                    if (port.Router == endRouter)
                    {
                        path_w.Add(port.Wire);
                        path_r.Add(endRouter);
                    }
                    if (list.Count != 0)
                    {
                        foreach (Router rtu in list)
                        {
                            if (port.Router == rtu)
                            {
                                current_router = rtu;
                                path_w.Add(port.Wire);
                                path_r.Add(current_router);
                                lis.Add(current_router);
                                list.Remove(current_router);
                                goto tt2;
                            }
                        }
                    }
                }
                else
                {
                    path_w.Clear();
                    path_r.Clear();
                    foreach (Router router in lis)
                    {
                        list.Add(router);
                    }
                    goto tt1;
                }
                foreach (Router router in path_r)
                {
                    population[i].path_routers.Add(router);
                }
                foreach (Wire wire in path_w)
                {
                    population[i].path_wires.Add(wire);
                }                
            }
            return population;
        }
    }
}
