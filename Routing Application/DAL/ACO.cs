using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Routing_Application.DAL
{

    public class ACO : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public ACO(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Paths_ACO(Router startRouter, Router endRouter, double p, double a, double b, int Max, int N, double p0, int Q, int K_paths)
        {
            K_paths = K_paths + 2;
            List<Individual> best_populations = new List<Individual>();
            //danh sach tat ca cac canh
            List<Wire> list_wires = network.Wires;
            //danh sach tat ca cac dinh
            List<Router> list_routers = network.Routers;
            //khoi tao N con kien
            Ant[] list_ants = new Ant[N];
            for (int k = 0; k < N; k++)
            {
                list_ants[k] = new Ant();
            }
            //vong lap thuat toan
            for (int i = 0; i < Max; i++)
            {
                for (int k = 0; k < N; k++)
                {
                    list_ants[k].Path.Clear();
                    list_ants[k].Delta = 0;
                }
                //thiet lap duong di cua kien
                for (int k = 0; k < N; k++)
                {
                tt2:
                    //khoi tao tung con kien
                    foreach (Wire w in list_wires)
                    {
                        w.Probability = 0;
                    }
                    Router current_router = startRouter;
                    List<Router> list_router_viewed = new List<Router>();
                    list_router_viewed.Add(startRouter);
                tt1:
                    //danh sach cac canh ke tiep
                    foreach (Wire w in list_wires)
                    {
                        w.Probability = 0;
                    }
                    List<Wire> list_wires_next = new List<Wire>();
                    foreach(Port port in current_router.Ports)
                    {
                        if (!list_router_viewed.Contains(port.Router))
                        {
                            list_wires_next.Add(port.Wire);
                        }
                    }
                    if(list_wires_next.Count==0)
                    {
                        goto tt2;
                    }
                    //tinh mau so
                    double sum_pro = 0;
                    foreach(Wire w in list_wires_next)
                    {
                        double x = w.Pheromone;
                        double y = (double)1 / (w.Criterion);
                        double z = Math.Pow(x, a) * Math.Pow(y, b);
                        sum_pro += z;
                    }
                    //tinh xac suat cho moi canh ke tiep
                    foreach (Wire w in list_wires_next)
                    {
                        double x = w.Pheromone;
                        double y = (double)1 / (w.Criterion);
                        w.Probability = (Math.Pow(x, a) * Math.Pow(y, b))/sum_pro;
                    }
                    //tim canh co xac suat cao nhat
                    Wire wire_max = list_wires_next[0];
                    foreach (Wire w in list_wires_next)
                    {
                        if(w.Probability > wire_max.Probability)
                        {
                            wire_max = w;
                        }
                    }
                    //random chon canh co xac suat cao nhat
                    double pr1 = ran.NextDouble();
                    if(pr1 <= p0)
                    {
                        list_ants[k].Path.Add(wire_max);
                        if(current_router == wire_max.StartRouter)
                        {
                            current_router = wire_max.EndRouter;
                        }
                        else
                        {
                            current_router = wire_max.StartRouter; 
                        }
                        list_router_viewed.Add(current_router);
                        if (current_router == endRouter)
                        {
                            continue;
                        }
                        else
                        {
                            goto tt1;
                        }
                    }
                    //hoac random theo xac suat cua tung canh ke tiep
                    else
                    {
                        double pr2 = ran.NextDouble();
                        if(pr2 <= list_wires_next[0].Probability)
                        {
                            list_ants[k].Path.Add(list_wires_next[0]);
                            if (current_router == list_wires_next[0].StartRouter)
                            {
                                current_router = list_wires_next[0].EndRouter;
                            }
                            else
                            {
                                current_router = list_wires_next[0].StartRouter;
                            }
                            list_router_viewed.Add(current_router);
                            if (current_router == endRouter)
                            {
                                continue;
                            }
                            else
                            {
                                goto tt1;
                            }
                        }
                        for(int j = 0; j < list_wires_next.Count-1; j++)
                        {
                            double sum_pr = 0;
                            for (int h = 0; h <= j; h++)
                            {
                                sum_pr = sum_pr + list_wires_next[h].Probability;
                            }
                            if((sum_pr < pr2) && (pr2 <= (sum_pr + list_wires_next[j+1].Probability)))
                            {
                                list_ants[k].Path.Add(list_wires_next[j+1]);
                                if (current_router == list_wires_next[j+1].StartRouter)
                                {
                                    current_router = list_wires_next[j+1].EndRouter;
                                }
                                else
                                {
                                    current_router = list_wires_next[j+1].StartRouter;
                                }
                                list_router_viewed.Add(current_router);
                                if (current_router == endRouter)
                                {
                                    break;
                                }
                                else
                                {
                                    goto tt1;
                                }
                            }
                        }
                    }
                }
                //tinh delta cho tung con kien
                for(int u=0;u<N;u++)
                {
                    //Individual population_2 = new Individual();
                    double leng = 0;
                    foreach(Wire wire in list_ants[u].Path)
                    {
                        //population_2.path_wires.Add(wire);
                        leng += wire.Criterion;
                    }
                    //population_2.fitness = leng;
                    list_ants[u].Delta = 1 / leng;
                    //populations.Add(population_2);
                }
                //cap nhat mui cho cac canh
                foreach (Wire w in list_wires)
                {
                    w.Pheromone = w.Pheromone * (1 - p);
                    foreach(Ant antt in list_ants)
                    {
                        if(antt.Path.Contains(w))
                        {
                            w.Pheromone += antt.Delta*Q;
                        }
                    }
                }
                List<Individual> population_i = new List<Individual>();
                for (int u = 0; u < N; u++)
                {
                    Individual indiv = new Individual();
                    double leng = 0;
                    foreach (Wire wire in list_ants[u].Path)
                    {
                        indiv.path_wires.Add(wire);
                        leng += wire.Criterion;
                    }
                    indiv.fitness = leng;
                    population_i.Add(indiv.DeepCopy());
                }
                //tim k duong tot nhat tai iteration thu k
                population_i.Sort(new NameCompare());
                List<Individual> best = new List<Individual>();
                best.Add(population_i[0].DeepCopy());
                for (int ii = 1; ii < N; ii++)
                {
                    if (best.Count == K_paths)
                    {
                        break;
                    }
                    bool dk = true;
                    for (int j = 0; j < best.Count; j++)
                    {
                        if (Enumerable.SequenceEqual(population_i[ii].path_wires, best[j].path_wires))
                        {
                            dk = false;
                            break;
                        }
                    }
                    if (dk)
                    {
                        best.Add(population_i[ii].DeepCopy());
                    }
                }
                foreach (Individual indiv in best)
                {
                    best_populations.Add(indiv.DeepCopy());
                }
            }
            best_populations.Sort(new NameCompare());
            List<Individual> population_noRepeat = new List<Individual>();
            population_noRepeat.Add(best_populations[0].DeepCopy());
            for (int i = 1; i < best_populations.Count; i++)
            {
                bool dk = true;
                for (int j = 0; j < population_noRepeat.Count; j++)
                {
                    if (Enumerable.SequenceEqual(best_populations[i].path_wires, population_noRepeat[j].path_wires))
                    {
                        dk = false;
                        break;
                    }
                }
                if (dk)
                {
                    population_noRepeat.Add(best_populations[i].DeepCopy());
                }
            }
            return population_noRepeat;
        }
    }
}
