using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Routing_Application.DAL
{

    public class Ga_paths : Ga_pair
    {
        // список кратчайших путей
        private List<Individual> paths = new List<Individual>();
        private Random randColor = new Random();
        // конструктор
        public Ga_paths(Network network) : base(network)
        {
        }
        // основной метод
        public void Do_Ga_paths(Router startRouter, Router endRouter, int max, double xx, double yy, int sobuoc, int K)
        {
            // список кандидатов
            List<Individual> paths_new = new List<Individual>();
            List<Router> r = new List<Router>();
            List<Wire> w = new List<Wire>();
            //получение первой пути
            Individual number = Path_function(startRouter, endRouter, max, xx, yy, sobuoc, r, w);
            paths.Add(number);
            for (int t = 1; t < K; t++)
            {
                Individual pt = paths[paths.Count - 1];
                for (int i = 0; i < pt.path_wires.Count; i++)
                {
                    List<Wire> w1 = new List<Wire>();
                    for (int u = 0; u < i; u++)
                    {
                        w1.Add(pt.path_wires[u]);
                    }
                    int rs = w1.Count;
                    foreach (Individual tr in paths)
                    {
                        if (tr.path_wires.Count > i)
                        {
                            List<Wire> w2 = new List<Wire>();
                            for (int u = 0; u < i; u++)
                            {
                                w2.Add(tr.path_wires[u]);
                            }
                            int e = 0;
                            foreach (Wire wire in w2)
                            {
                                if (w1.Contains(wire))
                                {
                                    e++;
                                }
                            }
                            if (e == rs)
                            {
                                w1.Add(tr.path_wires[i]);
                            }
                        }
                    }
                    foreach (Individual tr in paths_new)
                    {
                        if (tr.path_wires.Count > i)
                        {
                            List<Wire> w2 = new List<Wire>();
                            for (int u = 0; u < i; u++)
                            {
                                w2.Add(tr.path_wires[u]);
                            }
                            int e = 0;
                            foreach (Wire wire in w2)
                            {
                                if (w1.Contains(wire))
                                {
                                    e++;
                                }
                            }
                            if (e == rs)
                            {
                                w1.Add(tr.path_wires[i]);
                            }
                        }
                    }
                    Individual number1 = Path_function(pt.view_router[i], endRouter, max, xx, yy, sobuoc, r, w1);
                    Individual noi = new Individual();
                    for (int j = 0; j < i; j++)
                    {
                        noi.path_wires.Add(pt.path_wires[j]);
                        noi.view_router.Add(pt.view_router[j]);
                    }
                    noi.path_wires.AddRange(number1.path_wires);
                    noi.view_router.AddRange(number1.view_router);
                    if (number1.path_wires.Count != 0)
                    {
                        paths_new.Add(noi);
                    }
                    else if (number1.path_wires.Count == 0)
                    {
                        continue;
                    }
                }
                paths_new.Sort(new namecompare());
                // получение следующей пути
                if (paths_new.Count != 0)
                {
                    paths.Add(paths_new[0]);
                    paths_new.RemoveAt(0);
                }
            }
            List<Wire> tong = new List<Wire>();
            for (int k = 0; k < paths.Count; k++)
            {
                tong.AddRange(paths[k].path_wires);
            }
            int s = 0;
            List<Wire> truoc = new List<Wire>();
            List<Wire> khong = new List<Wire>();
            List<Wire> co = new List<Wire>();
            for (int i = 0; i < tong.Count; i++)
            {
                if (!truoc.Contains(tong[i]))
                {
                    khong.Add(tong[i]);
                    s += tong[i].Criterion;
                }
                if (truoc.Contains(tong[i]))
                {
                    co.Add(tong[i]);
                }
                truoc.Add(tong[i]);
            }
            // вычисление количество вхождений ребер
            foreach (Wire wire in khong)
            {
                foreach (Wire wires in tong)
                {
                    if (wire == wires)
                    {
                        wire.NumberRepeat++;
                    }
                }
            }
            // окраска путей
            for (int k = 0; k < paths.Count; k++)
            {
                Color c = Color.FromArgb(randColor.Next(255), randColor.Next(255), randColor.Next(255));
                foreach (Wire wire in paths[k].path_wires)
                {
                    Pen ppp = new Pen(c,4 * (wire.NumberRepeat));
                    wire.Pen = ppp;
                }
            }
        }

    }
    public class namecompare : IComparer<Individual>
    {
        public int Compare(Individual x, Individual y)
        {
            if (x == null || y == null)
            {
                throw new InvalidOperationException();
            }
            int sum1 = 0, sum2 = 0;
            foreach (Wire wire in x.path_wires)
            {
                sum1 += wire.Criterion;
            }
            foreach (Wire wire in y.path_wires)
            {
                sum2 += wire.Criterion;
            }
            if (sum1 < sum2)
            {
                return -1;
            }
            else if (sum1 == sum2)
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
