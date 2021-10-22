using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Routing_Application.DAL
{
    public class Ga_Dejkstra : Algorithm
    {
        private Random ran = new Random();
        private List<Individual> tre = new List<Individual>();
        // конструктор 
        public Ga_Dejkstra(Network network) : base(network)
        {
            
        }
        // основной метод
        public void DoAlg(Router startRouter, bool toPaint, int max, double Pc, double Pm, int Si)
        {
            double[] fitness = new double[max];
            List<Wire> tr = new List<Wire>();
            // подготовка исходного графа
            Preparation(toPaint);
            // установки для исходного узла 
            startRouter.Mark = Marks.Ga_Dejkstra;
            startRouter.Used = true;
            startRouter.DistancePointer = 0;
            // получение популяции
            for (int i = 0; i < max; i++)
            {
                tre.Add(GetTree(startRouter, new List<Router>() { startRouter }));
                // подготовка исходного графа
                Preparation(toPaint);
                // установки для исходного узла 
                startRouter.Mark = Marks.Ga_Dejkstra;
                startRouter.Used = true;
                startRouter.DistancePointer = 0;

            }
            //вычисление приспособленности
            for (int i = 0; i < max; i++)
            {
                fitness[i] = 0;
                foreach (double dbb in tre[i].viewingg)
                {
                    fitness[i] += dbb;
                }

            }
            for (int p = 0; p < Si; p++)
            {
                //отбор
                double[] tempp = new double[max];
                Array.Copy(fitness, 0, tempp, 0, fitness.Length);
                Array.Sort(tempp);
                double nguong = tempp[80 * max / 100];
                for (int k = 0; k < max; k++)
                {
                    if (fitness[k] > nguong)
                    {
                        // подготовка исходного графа
                        Preparation(toPaint);
                        // установки для исходного узла 
                        startRouter.Mark = Marks.Ga_Dejkstra;
                        startRouter.Used = true;
                        startRouter.DistancePointer = 0;
                        tre[k] = null;
                        tre[k] = GetTree(startRouter, new List<Router>() { startRouter });
                    }
                }
                for (int i = 0; i < max; i++)
                {
                    fitness[i] = 0;
                    foreach (double db1 in tre[i].viewingg)
                    {
                        fitness[i] += db1;
                    }

                }
                for (int ht = 0; ht < max; ht++)
                {
                    //скрещивание
                    int pc = ran.Next(11);
                    if (pc < Pc * 10)
                    {
                        int father = ran.Next(max);
                        Individual ch = tre[father].DeepCopy();
                        int mother = ran.Next(father);
                        Individual m = tre[mother].DeepCopy();
                        int n = network.Routers.Count;
                        for (int j = 0; j < n - 2; j++)
                        {
                            ch.view_router.Reverse();
                            m.view_router.Reverse();
                            List<Router> a1 = new List<Router>();
                            List<Router> a2 = new List<Router>();
                            a1 = ch.view_router.GetRange(n - j - 2, j + 1);
                            a2 = m.view_router.GetRange(n - j - 2, j + 1);
                            a1.Reverse();
                            a2.Reverse();
                            ch.view_router.Reverse();
                            m.view_router.Reverse();
                            int k = 0;
                            foreach (Router r1 in a1)
                            {
                                if (a2.Contains(r1))
                                {
                                    k++;
                                }
                            }
                            if (k == j + 1)
                            {
                                List<Router> a3 = new List<Router>();
                                List<Router> a4 = new List<Router>();
                                a3 = ch.view_router.GetRange(j + 1, n - j - 2);
                                a4 = m.view_router.GetRange(j + 1, n - j - 2);
                                ch.view_router.RemoveRange(j + 1, n - j - 2);
                                ch.view_router.AddRange(a4);
                                m.view_router.RemoveRange(j + 1, n - j - 2);
                                m.view_router.AddRange(a3);

                                List<Wire> a5 = new List<Wire>();
                                List<Wire> a6 = new List<Wire>();
                                a5 = ch.path_wires.GetRange(j + 1, n - j - 2);
                                a6 = m.path_wires.GetRange(j + 1, n - j - 2);
                                ch.path_wires.RemoveRange(j + 1, n - j - 2);
                                ch.path_wires.AddRange(a6);
                                m.path_wires.RemoveRange(j + 1, n - j - 2);
                                m.path_wires.AddRange(a5);

                                ch.viewingg.RemoveRange(j + 1, n - j - 2);
                                for (int u = j + 1; u < n - 1; u++)
                                {
                                    double t = 0;
                                    Router rr = new Router();
                                    if (ch.view_router[u] == ch.path_wires[u].EndRouter)
                                    {
                                        rr = ch.path_wires[u].StartRouter;
                                    }
                                    else if (ch.view_router[u] == ch.path_wires[u].StartRouter)
                                    {
                                        rr = ch.path_wires[u].EndRouter;
                                    }
                                    for (int w = 0; w < ch.viewingg.Count; w++)
                                    {
                                        if (ch.view_router[w] == rr)
                                        {
                                            t = ch.viewingg[w] + ch.path_wires[u].Criterion;
                                        }
                                    }
                                    if (rr == startRouter)
                                    {
                                        t = ch.path_wires[u].Criterion; ;
                                    }
                                    ch.viewingg.Add(t);
                                }

                                m.viewingg.RemoveRange(j + 1, n - j - 2);
                                for (int u = j + 1; u < n - 1; u++)
                                {
                                    double t = 0;
                                    Router rr = new Router();
                                    if (m.view_router[u] == m.path_wires[u].EndRouter)
                                    {
                                        rr = m.path_wires[u].StartRouter;
                                    }
                                    else if (m.view_router[u] == m.path_wires[u].StartRouter)
                                    {
                                        rr = m.path_wires[u].EndRouter;
                                    }
                                    for (int w = 0; w < m.viewingg.Count; w++)
                                    {
                                        if (m.view_router[w] == rr)
                                        {
                                            t = m.viewingg[w] + m.path_wires[u].Criterion;
                                        }
                                    }
                                    if (rr == startRouter)
                                    {
                                        t = m.path_wires[u].Criterion; ;
                                    }
                                    m.viewingg.Add(t);
                                }
                                double ch1 = 0;
                                foreach (double bb in ch.viewingg)
                                {
                                    ch1 += bb;
                                }
                                double m1 = 0;
                                foreach (double bb in m.viewingg)
                                {
                                    m1 += bb;
                                }
                                if (fitness[father] > ch1)
                                {
                                    tre[father] = null;
                                    tre[father] = ch.DeepCopy();
                                }
                                if (fitness[mother] > m1)
                                {
                                    tre[mother] = null;
                                    tre[mother] = m.DeepCopy();
                                }
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < max; i++)
                {
                    fitness[i] = 0;
                    foreach (double b in tre[i].viewingg)
                    {
                        fitness[i] += b;
                    }

                }
                for (int ht = 0; ht < max; ht++)
                {
                    //мутация
                    int pm = ran.Next(11);
                    if (pm < Pm * 10)
                    {
                        int db = ran.Next(max);
                        int f = ran.Next(tre[db].path_wires.Count);
                        tre[db].path_wires.RemoveRange(f, tre[db].path_wires.Count - f);
                        // подготовка исходного графа
                        Preparation(toPaint);
                        // установки для исходного узла 
                        startRouter.Mark = Marks.Ga_Dejkstra;
                        startRouter.Used = true;
                        startRouter.DistancePointer = 0;
                        List<Router> lis = new List<Router>();
                        lis.Add(startRouter);
                        for (int k = 0; k < f; k++)
                        {
                            tre[db].view_router[k].DistancePointer = tre[db].viewingg[k];
                            tre[db].view_router[k].Used = true;
                            lis.Add(tre[db].view_router[k]);
                        }
                        Individual treee = GetTree(startRouter, lis);
                        tre[db].view_router.Clear();
                        tre[db].view_router.AddRange(treee.view_router);
                        tre[db].viewingg.Clear();
                        tre[db].viewingg.AddRange(treee.viewingg);
                        tre[db].path_wires.AddRange(treee.path_wires);
                    }
                }
                for (int i = 0; i < max; i++)
                {
                    fitness[i] = 0;
                    foreach (double d in tre[i].viewingg)
                    {
                        fitness[i] += d;
                    }
                }
            }
            // выбор лучшего
            double[] temp = new double[max];
            Array.Copy(fitness, 0, temp, 0, fitness.Length);
            Array.Sort(temp);
            double bestt = temp[0];
            for (int k = 0; k < max; k++)
            {
                if (fitness[k] == bestt)
                {
                    Paint(tre[k].path_wires);
                    break;
                }
            }
        }
        // получение остовного дерева
        private Individual GetTree(Router startRouter, List<Router> viewingRouters)
        {
            // список ребер, которые вошли в остовное дерево
            Individual tr = new Individual();
            // узел и ребро, подсоединяемые к остовному дереву
            Port connectablePort = null;
            // узлы, к которым нельзя присоединить новые компоненты остова
            List<Wire> t = new List<Wire>();
            // проход по всем узлам в списке
            do
            {
                // найти вершину для присоединения к остовному дереву
                connectablePort = FindNextPort(ref viewingRouters);
                if (connectablePort != null)
                {
                    // добавить вершину и ребро к остовному дереву
                    ConnectPort(connectablePort, ref viewingRouters, ref t);
                }
            }
            while (viewingRouters.Count < network.Routers.Count);
            foreach(Router router in viewingRouters)
            {
                if (router != startRouter)
                {
                    tr.view_router.Add(router);
                    double g = router.DistancePointer;
                    tr.viewingg.Add(g);
                }
            }
            foreach (Wire wire in t)
            {
                tr.path_wires.Add(wire);
            }
            return tr;
        }
        // поиск вершины для присоединения к остовному дереву
        private Port FindNextPort(ref List<Router> viewingRouters)
        {
            double min = Const.INF;
            Port connectablePort = null;
            // просмотр ближайших к роуторам из сформированного остова роутеров
            int x = ran.Next(viewingRouters.Count);
            foreach (Router router in viewingRouters)
            {
                if (router == viewingRouters[x])
                {
                    int y = ran.Next(router.Ports.Count);
                    foreach (Port port in router.Ports)
                    {
                        if (port == router.Ports[y])
                        {
                            if (port.Router.Used == false)
                            {
                                connectablePort = port;
                                port.Router.DistancePointer = router.DistancePointer + port.Wire.Criterion;
                            }

                        }
                    }
                }
            }

            return connectablePort;
        }
        // присоединение вершины и ребра к остовному дереву
        private void ConnectPort(Port connectablePort, ref List<Router> viewingRouters, ref List<Wire> tree)
        {
            // обновление списка просматриваемых узлов
            connectablePort.Router.Used = true;
            viewingRouters.Add(connectablePort.Router);
            CreateTPorts(connectablePort);
            tree.Add(connectablePort.Wire);
        }
        // подготовка исходного графа
        private void Preparation(bool toPaint)
        {
            if (toPaint == true)
            {
                // сброс цветов каналов
                Pen pen = new Pen(Color.Gray, 1);
                foreach (Wire wire in network.Wires)
                {
                    wire.Pen = pen;
                }
            }
            // установка исходных данных для роутеров
            foreach (Router router in network.Routers)
            {
                router.DistancePointer = Const.INF;
                router.Mark = Marks.None;
                router.Used = false;
                router.TPorts.Clear();
            }
        }
        // окраска ребер
        private void Paint(List<Wire> wiresForPainting)
        {
            Pen pen = new Pen(Color.Purple, 6);
            foreach (Wire wire in wiresForPainting)
            {
                wire.Pen = pen;
            }
        }
        // зоздание портов, входящих в остовное дерево
        private void CreateTPorts(Port connectablePort)
        {
            // поиск портов, которые вошли в остовное дерево
            connectablePort.Wire.StartRouter.TPorts.Add(connectablePort.Wire.StartPort);
            connectablePort.Wire.EndRouter.TPorts.Add(connectablePort.Wire.EndPort);
        }
    }
}

