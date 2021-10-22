using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Routing_Application.DAL
{

    public class GA : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public GA(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Paths_GA(Router startRouter, Router endRouter, List<Individual> population_starting, int N, double Pc, double Pm, int Max, int K_paths)
        {
            List<Individual> population = new List<Individual>();
            for (int i = 0; i < N; i++)
            {
                population.Add(new Individual());
            }
            for (int i = 0; i < N; i++)
            {
                population[i]=population_starting[i].DeepCopy();
            }
            List<Router> listt = new List<Router>();
            foreach (Router router in network.Routers)
            {
                if (router != startRouter && router != endRouter)
                {
                    listt.Add(router);
                }
            }             
            //вычисление приспособленности
            for (int i = 0; i < N; i++)
            {
                double leng = 0;
                foreach (Wire wire in population[i].path_wires)
                {
                    leng += wire.Criterion;
                }
                population[i].fitness = leng;
            }
            List<Individual> populations = new List<Individual>();
            for (int i = 0; i < N; i++)
            {
                populations.Add(new Individual());
            }
            for (int i = 0; i < N; i++)
            {
                populations[i] = population[i].DeepCopy();
            }
            populations.Sort(new NameCompare());
            //АЛГОРИТМ ГА
            for (int p = 0; p < Max; p++)
            {
                 // Скрещивание
                for (int ht = 0; ht < N; ht++)
                {
                    double pc_r = ran.NextDouble();
                    if (pc_r < Pc)
                    {
                    tiep:
                        int father = ran.Next(N);
                        int mother = ran.Next(N);
                        List<Router> father_router = new List<Router>(population[father].path_routers);
                        List<Router> mother_router = new List<Router>(population[mother].path_routers);
                        List<Wire> father_wire = new List<Wire>(population[father].path_wires);
                        List<Wire> mother_wire = new List<Wire>(population[mother].path_wires);
                        List<Router> w1 = new List<Router>();
                        List<Router> w2 = new List<Router>();
                        List<Router> w11 = new List<Router>();
                        List<Router> w22 = new List<Router>();
                        for (int i = 1; i < father_router.Count - 2; i++)
                        {
                            for (int j = 1; j < mother_router.Count - 2; j++)
                            {
                                if (father_router[i] == mother_router[j])
                                {
                                    for (int m = i + 1; m < father_router.Count; m++)
                                    {
                                        w1.Add(father_router[m]);
                                    }
                                    for (int mm = 0; mm < i; mm++)
                                    {
                                        w11.Add(father_router[mm]);
                                    }
                                    for (int nn = 0; nn < j; nn++)
                                    {
                                        w22.Add(mother_router[nn]);
                                    }
                                    for (int n = j + 1; n < mother_router.Count; n++)
                                    {
                                        w2.Add(mother_router[n]);
                                    }
                                    foreach (Router router in w1)
                                    {
                                        father_router.Remove(router);
                                    }
                                    foreach (Router router in w2)
                                    {
                                        mother_router.Remove(router);
                                    }
                                    father_router.AddRange(w2);
                                    mother_router.AddRange(w1);
                                    for (int n = 1; n < w11.Count ; n++)
                                    {
                                        for (int m = w11.Count+1; m < father_router.Count-1; m++)
                                        {
                                            if (father_router[n]==father_router[m])
                                            {
                                                father_router.RemoveRange(n,m-n);
                                            }
                                        }
                                    }
                                    for (int n = 1; n < w22.Count; n++)
                                    {
                                        for (int m = w22.Count + 1; m < mother_router.Count - 1; m++)
                                        {
                                            if (mother_router[n] == mother_router[m])
                                            {
                                                mother_router.RemoveRange(n, m - n);
                                            }
                                        }
                                    }
                                    mother_wire.Clear();
                                    father_wire.Clear();
                                    for (int t1 = 0; t1 < father_router.Count - 1; t1++)
                                    {
                                        foreach (Wire wire in network.Wires)
                                        {
                                            if (wire.StartRouter == father_router[t1] && wire.EndRouter == father_router[t1 + 1]
                                                || wire.StartRouter == father_router[t1 + 1] && wire.EndRouter == father_router[t1])
                                            {
                                                father_wire.Add(wire);
                                            }
                                        }
                                    }
                                    for (int t1 = 0; t1 < mother_router.Count - 1; t1++)
                                    {
                                        foreach (Wire wire in network.Wires)
                                        {
                                            if (wire.StartRouter == mother_router[t1] && wire.EndRouter == mother_router[t1 + 1]
                                                || wire.StartRouter == mother_router[t1 + 1] && wire.EndRouter == mother_router[t1])
                                            {
                                                mother_wire.Add(wire);
                                            }
                                        }
                                    }
                                    population[father].path_routers = new List<Router>(father_router);
                                    population[father].path_wires = new List<Wire>(father_wire);
                                    population[mother].path_routers = new List<Router>(mother_router);
                                    population[mother].path_wires = new List<Wire>(mother_wire);
                                    goto tieptuc;
                                }
                            }
                        }
                        goto tiep;
                    }
                tieptuc:
                    int tin = 0;
                }
                //вычисление приспособленности
                for (int i = 0; i < N; i++)
                {
                    double leng = 0;
                    foreach (Wire wire in population[i].path_wires)
                    {
                        leng += wire.Criterion;
                    }
                    population[i].fitness = leng;
                }
                // мутация
                for (int ht = 0; ht < N; ht++)
                {
                    double pm_r = ran.NextDouble();
                    if (pm_r < Pm)
                    {
                        int gen = ran.Next(N);
                        int pt = ran.Next(1, population[gen].path_routers.Count - 1);
                        List<Wire> path = new List<Wire>();
                        List<Router> path_r = new List<Router>();
                        List<Router> list = new List<Router>();
                        foreach (Router router in listt)
                        {
                            list.Add(router);
                        }
                        for (int r = 0; r < pt; r++)
                        {
                            list.Remove(population[gen].path_routers[r]);
                        }
                    tt1: Router current_router = population[gen].path_routers[pt - 1];
                        for (int r = 0; r < pt; r++)
                        {
                            path_r.Add(population[gen].path_routers[r]);
                        }
                        for (int r = 0; r < pt - 1; r++)
                        {
                            path.Add(population[gen].path_wires[r]);
                        }
                        List<Router> lis = new List<Router>();
                    tt2:
                        Boolean x = false;
                        foreach (Port prt in current_router.Ports)
                        {
                            if (!path_r.Contains(prt.Router))
                            {
                                x = true;
                            }
                        }
                        if (x)
                        {
                            int y = ran.Next(current_router.Ports.Count);
                            Port port = current_router.Ports[y];
                            if (path_r.Contains(port.Router))
                            {
                                goto tt2;
                            }
                            if (port.Router == endRouter)
                            {
                                path.Add(port.Wire);
                                path_r.Add(endRouter);
                            }
                            if (list.Count != 0)
                            {
                                foreach (Router rtu in list)
                                {
                                    if (port.Router == rtu)
                                    {
                                        current_router = rtu;
                                        path.Add(port.Wire);
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
                            path.Clear();
                            path_r.Clear();
                            foreach (Router router in lis)
                            {
                                list.Add(router);
                            }
                            goto tt1;
                        }
                        population[gen].path_wires.Clear();
                        population[gen].path_routers.Clear();
                        foreach (Wire wire in path)
                        {
                            population[gen].path_wires.Add(wire);
                        }
                        foreach (Router router1 in path_r)
                        {
                            population[gen].path_routers.Add(router1);
                        }
                    }
                }
                //вычисление приспособленности
                for (int i = 0; i < N; i++)
                {
                    double leng = 0;
                    foreach (Wire wire in population[i].path_wires)
                    {
                        leng += wire.Criterion;
                    }
                    population[i].fitness = leng;
                }
                //отбор
                double[] temp = new double[N];
                for (int i = 0; i < N; i++)
                {
                    temp[i] = population[i].fitness;
                }
                Array.Sort(temp);
                double threshold = temp[80 * N / 100];
                for (int k = 0; k < N; k++)
                {
                    if (population[k].fitness > threshold)
                    {
                        population[k].path_wires.Clear();
                        population[k].path_routers.Clear();
                        List<Wire> path = new List<Wire>();
                        List<Router> path_r = new List<Router>();
                        List<Router> list = new List<Router>(listt);
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
                            }
                        }
                        if (x)
                        {
                            int y = ran.Next(current_router.Ports.Count);
                            Port port = current_router.Ports[y];
                            if (path_r.Contains(port.Router))
                            {
                                goto tt2;
                            }
                            if (port.Router == endRouter)
                            {
                                path.Add(port.Wire);
                                path_r.Add(endRouter);
                            }
                            if (list.Count != 0)
                            {
                                foreach (Router rtu in list)
                                {
                                    if (port.Router == rtu)
                                    {
                                        current_router = rtu;
                                        path.Add(port.Wire);
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
                            path.Clear();
                            path_r.Clear();
                            foreach (Router router in lis)
                            {
                                list.Add(router);
                            }
                            goto tt1;
                        }

                        foreach (Wire wire in path)
                        {
                            population[k].path_wires.Add(wire);
                        }
                        foreach (Router router1 in path_r)
                        {
                            population[k].path_routers.Add(router1);
                        }
                    }
                }
                //вычисление приспособленности
                for (int i = 0; i < N; i++)
                {
                    double leng = 0;
                    foreach (Wire wire in population[i].path_wires)
                    {
                        leng += wire.Criterion;
                    }
                    population[i].fitness = leng;
                }
            }
            population.Sort(new NameCompare());
            List<Individual> population_noRepeat = new List<Individual>();
            population_noRepeat.Add(population[0].DeepCopy());
            for (int i = 1; i < N; i++)
            {
                bool dk = true;
                for (int j = 0; j < population_noRepeat.Count; j++)
                {
                    if (Enumerable.SequenceEqual(population[i].path_wires, population_noRepeat[j].path_wires))
                    {
                        dk = false;
                        break;
                    }
                }
                if (dk)
                {
                    population_noRepeat.Add(population[i].DeepCopy());
                }
            }
            return population_noRepeat;
        }
    }
}
