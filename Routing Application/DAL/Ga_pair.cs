using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Routing_Application.DAL
{

    public class Ga_pair : Algorithm
    {
        public Random ran = new Random();
        public Ga_pair(Network network) : base(network)
        {
        }
        // основной метод
        public Individual Path_function(Router startRouter, Router endRouter, int max, double Pc, double Pm, int Si, List<Router> viewed, List<Wire> viewed_wire)
        {
            Individual PATH = new Individual();
            int[] fitness = new int[max];
            List<List<Wire>> paths_wire = new List<List<Wire>>();
            List<List<Router>> paths_router = new List<List<Router>>();
            List<Router> listt = new List<Router>();
            foreach (Router router in network.Routers)
            {
                if (router != startRouter && router != endRouter)
                {
                    listt.Add(router);
                }
            }
            //получение популяции
            for (int i = 0; i < max; i++)
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
            tt3:    int y = ran.Next(current_router.Ports.Count);
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
                paths_wire.Add(path_w);
                paths_router.Add(path_r);
            }
            //вычисление приспособленности
            for (int i = 0; i < max; i++)
            {
                fitness[i] = 0;
                foreach (Wire wire in paths_wire[i])
                {
                    fitness[i] += wire.Criterion;
                }
            }
            for (int p = 0; p < Si; p++)
            {
                //отбор
                int[] temp = new int[max];
                Array.Copy(fitness, 0, temp, 0, fitness.Length);
                Array.Sort(temp);
                int threshold = temp[80 * max / 100];
                for (int k = 0; k < max; k++)
                {
                    if (fitness[k] > threshold)
                    {
                        paths_wire[k].Clear();
                        paths_router[k].Clear();
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
                            paths_wire[k].Add(wire);
                        }
                        foreach (Router router1 in path_r)
                        {
                            paths_router[k].Add(router1);
                        }
                    }
                }
                for (int i = 0; i < max; i++)
                {
                    fitness[i] = 0;
                    foreach (Wire wire in paths_wire[i])
                    {
                        fitness[i] += wire.Criterion;
                    }
                }
                // Скрещивание
                for (int ht = 0; ht < max; ht++)
                {
                    double pc_r = ran.NextDouble();
                    if (pc_r < Pc)
                    {
                        tiep:
                        int father = ran.Next(max);
                        int mother = ran.Next(max);
                        List<Router> father_router = new List<Router>(paths_router[father]);
                        List<Router> mother_router = new List<Router>(paths_router[mother]);
                        List<Wire> father_wire = new List<Wire>(paths_wire[father]);
                        List<Wire> mother_wire = new List<Wire>(paths_wire[mother]);
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
                                    foreach (Router router1 in w2)
                                    {
                                        if (w11.Contains(router1))
                                        {
                                            goto tiep;
                                        }
                                    }
                                    foreach (Router router2 in w1)
                                    {
                                        if (w22.Contains(router2))
                                        {
                                            goto tiep;
                                        }
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
                                    int ch1 = 0;
                                    foreach (Wire wire in father_wire)
                                    {
                                        ch1 += wire.Criterion;
                                    }
                                    int m1 = 0;
                                    foreach (Wire wire in mother_wire)
                                    {
                                        m1 += wire.Criterion;
                                    }
                                    if (fitness[father] > ch1)
                                    {
                                        paths_router[father] = new List<Router>(father_router);
                                        paths_wire[father] = new List<Wire>(father_wire);
                                    }
                                    if (fitness[mother] > m1)
                                    {
                                        paths_router[mother] = new List<Router>(mother_router);
                                        paths_wire[mother] = new List<Wire>(mother_wire);
                                    }
                                    goto tieptuc;
                                }
                            }
                        }
                    }
                tieptuc:
                    int tin = 0;
                }
                for (int i = 0; i < max; i++)
                {
                    fitness[i] = 0;
                    foreach (Wire wire in paths_wire[i])
                    {
                        fitness[i] += wire.Criterion;
                    }
                }
                for (int ht = 0; ht < max; ht++)
                {
                    // мутация
                    double pm_r = ran.NextDouble();
                    if (pm_r < Pm)
                    {
                        int gen = ran.Next(max);
                        int pt = ran.Next(1, paths_router[gen].Count - 1);
                        List<Wire> path = new List<Wire>();
                        List<Router> path_r = new List<Router>();
                        List<Router> list = new List<Router>();
                        foreach (Router router in listt)
                        {
                            list.Add(router);
                        }
                        for (int r = 0; r < pt; r++)
                        {
                            list.Remove(paths_router[gen][r]);
                        }
                    tt1: Router current_router = paths_router[gen][pt-1];
                        for (int r = 0; r < pt; r++)
                        {
                            path_r.Add(paths_router[gen][r]);
                        }
                        for (int r = 0; r < pt - 1; r++)
                        {
                            path.Add(paths_wire[gen][r]);
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
                        paths_wire[gen].Clear();
                        paths_router[gen].Clear();
                        foreach (Wire wire in path)
                        {
                            paths_wire[gen].Add(wire);
                        }
                        foreach (Router router1 in path_r)
                        {
                            paths_router[gen].Add(router1);
                        }
                    }
                }
                for (int i = 0; i < max; i++)
                {
                    fitness[i] = 0;
                    foreach (Wire wire in paths_wire[i])
                    {
                        fitness[i] += wire.Criterion;
                    }
                }
            }
            // выбор лучшего
            int[] temp1 = new int[max];
            Array.Copy(fitness, 0, temp1, 0, fitness.Length);
            Array.Sort(temp1);
            int best = temp1[0];
            for (int k = 0; k < max; k++)
            {
                if (fitness[k] == best)
                {
                    foreach (Wire wire in paths_wire[k])
                    {
                        PATH.path_wires.Add(wire);
                    }
                    foreach (Router router in paths_router[k])
                    {
                        PATH.view_router.Add(router);
                    }
                    break;
                }
            }
            return PATH;
        }
        public void Do(Router startRouter, Router endRouter, int max, double Pc, double Pm, int Si)
        {
            List<Router> r = new List<Router>();
            List<Wire> w = new List<Wire>();
            Individual Pth = Path_function(startRouter, endRouter, max, Pc, Pm, Si, r, w);
            Pen pp = new Pen(Color.Red, 6);
            foreach (Wire wire in Pth.path_wires)
            {
                wire.Pen = pp;
            }
        }
    }
}
