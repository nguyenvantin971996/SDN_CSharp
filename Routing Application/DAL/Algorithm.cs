using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Routing_Application.Domain;
using Routing_Application.View;
using Routing_Application.Enums;
using Routing_Application.Structures;
using System.Diagnostics;
using Routing_Application.Forms;

namespace Routing_Application.DAL
{
    /// <summary>
    /// Класс, проводящий основные алгоритмические преобразования сети
    /// </summary>
    public class Algorithm
    {
        public Individual Particle_Decoding(Router startRouter, Router endRouter, double[] priority, Router[] list_rtrs)
        {
            //router hien tai
            Router current_router = startRouter;
            //path
            Individual path = new Individual();
            path.path_routers.Add(startRouter);
            double infinite = double.MaxValue;
            for (int i = 0; i < list_rtrs.Length; i++)
            {
                list_rtrs[i].Prio = priority[i];
                path.code_path.Add(priority[i]);
            }
            list_rtrs[0].Prio = infinite;
            while (current_router != endRouter)
            {
                //danh sach routers vs wires tiep theo
                List<Router> next_routers = new List<Router>();
                List<Wire> next_wires = new List<Wire>();
                foreach (Port port in current_router.Ports)
                {
                    if (port.Router.Prio != infinite)
                    {
                        next_routers.Add(port.Router);
                        next_wires.Add(port.Wire);
                    }
                }
                if (next_routers.Count == 0)
                {
                    path.path_routers.Clear();
                    path.path_wires.Clear();
                    path.code_path.Clear();
                    break;
                }
                else
                {
                    double min_prio = infinite;
                    Router router_min = new Router();
                    Wire wire_min = new Wire();
                    for (int i = 0; i < next_routers.Count; i++)
                    {
                        if (next_routers[i].Prio * next_wires[i].Criterion <= min_prio)
                        {
                            min_prio = next_routers[i].Prio * next_wires[i].Criterion;
                            router_min = next_routers[i];
                            wire_min = next_wires[i];
                        }
                    }
                    router_min.Prio = infinite;
                    path.path_routers.Add(router_min);
                    path.path_wires.Add(wire_min);
                    current_router = router_min;
                }
            }
            for (int i = 0; i < list_rtrs.Length; i++)
            {
                list_rtrs[i].Prio = 0;
            }
            return path;
        }
        // ссылка на сеть
        protected Network network;

        /* Конструктор */
        public Algorithm(Network network)
        {
            this.network = network;
        }

        // основные методы
        #region MainMethods

        // сброс результатов
        public void Reset()
        {
            Pen pen = new Pen(Color.Gray, 1);
            // удаление сегментов
            network.Segments.Clear();
            // создание нулевого сегмента
            network.Segments.Add(new Segment());

            foreach (Wire wire in network.Wires)
            {
                wire.Pen = pen;
                wire.Segment = network.Segments[0];
                network.Segments[0].Wires.Add(wire);
                wire.NumberRepeat = 0;
                wire.Pheromone = 1;
                wire.Probability = 0;
            }

            foreach (Router router in network.Routers)
            {
                router.Mark = Marks.None;
                router.Segment = network.Segments[0];
                network.Segments[0].Routers.Add(router);
                foreach (Port port in router.Ports)
                {
                    port.Distance = Const.INF;
                }
            }

            network.Segments[0].Repaint(Properties.Resources.router0);
        }

        // алгоритм сегментации
        public void Segmentation(Router startRouter, double Q)
        {
            // сброс топологии
            Reset();

            // этап 1
            // получение минимального остова
            AlgPrim algPrim = new AlgPrim(network);
            algPrim.DoAlg(startRouter, false);
            startRouter.Mark = Marks.Segmentation;

            // этап 2.1
            // формирование первичных сегментов 
            int segmentNumber = 0;
            foreach (Router router in network.Routers)
            {
                // идентификация листа минимального остовного дерева 
                if (router.TPorts.Count == 1)
                {
                    Router ancestor = router.TPorts[0].Router;
                    // если предок листа распределен в сегмент,
                    // то добавляем лист к существующему сегменту
                    if (ancestor.Segment.Number > 0)
                    {
                        ancestor.Segment.Routers.Add(router);
                        router.Segment = ancestor.Segment;
                    }
                    else
                    // ... иначе создаем новый сегмент ( лист + его предок )
                    {
                        network.Segments.Add(new Segment(router, ancestor, ++segmentNumber));
                        router.Segment = ancestor.Segment = network.Segments[network.Segments.Count - 1];
                    }
                }
            }

            // этап 2.2
            // распределение роутеров, не имеющих сегментов

            // получаем список нераспределенных роутеров
            List<Router> viewingRouters = (from r in network.Routers
                                           where r.Segment.Number == 0
                                           select r).ToList();

            // пока в сети есть нераспределенные роутеры
            // проводим распределение
            while (viewingRouters.Count > 0)
            {
                RoutersDistribution(viewingRouters);

                viewingRouters = (from r in network.Routers
                                  where r.Segment.Number == 0
                                  select r).ToList();
            }


            // этап 3 
            // раасчет Q для сегментов
            foreach (Segment segment in network.Segments)
            {
                segment.UpdateStructure();
            }

            // этап 4
            // объединение сегментов с недостаточно большим Q

            // получение списка сегментов с недостаточно большим Q
            List<Segment> viewingSegments = (from s in network.Segments
                                             where s.Q < Q && s.Number > 0
                                             select s).ToList();

            while (viewingSegments.Count > 0)
            {
                SegmentsDistribution(viewingSegments, Q);

                // обновление списка сегментов с недостаточно большим Q
                viewingSegments = (from s in network.Segments
                                   where s.Q < Q && s.Number > 0
                                   select s).ToList();
            }

            foreach (Wire wire in network.Wires)
            {
                if (wire.StartRouter.Segment.Number == wire.EndRouter.Segment.Number)
                {
                    wire.Segment = wire.StartRouter.Segment;
                    wire.Segment.Wires.Add(wire);
                }
                else
                {
                    wire.Segment = null;
                }
            }

            network.Segments[0].Routers.Clear();
            network.Segments[0].Wires.Clear();
        }

        // алгоритм Дейкстры для роутеров
        public void Dejkstra(Router startRouter)
        {
            // переопределение цветов дуг внутри сегментов
            network.WiresRecolor();
            List<Router> routers = new List<Router>();

            foreach (Router r in startRouter.Segment.Routers)
            {
                // обновление меток роутеров
                if (r.Segment.Number != startRouter.Segment.Number)
                {
                    if (r.Mark != Marks.Dejkstra)
                    {
                        r.Mark = Marks.None;
                    }
                }
                else
                {
                    r.Mark = Marks.None;
                }
                // установка исходных данных 
                r.DistancePointer = Const.INF;
                r.ShortTrack.Clear();
                r.Used = false;
            }

            Pen pen = new Pen(Color.Gray, 1);
            // сброс цветов для каналов
            foreach (Wire wire in network.Wires)
            {
                if (((wire.StartRouter.Segment.Number == startRouter.Segment.Number) &&
                    (wire.EndRouter.Segment.Number == startRouter.Segment.Number)) ||
                    (wire.Pen.Color == Color.Black) || (wire.Pen.Color == Color.Red))
                {
                    wire.Pen = pen;
                }
                else if (wire.StartRouter.Segment.Number != wire.EndRouter.Segment.Number)
                {
                    wire.Pen = pen;
                }

                wire.BelongTree = false;
            }

            // установки для исходного роутера
            startRouter.DistancePointer = 0;
            startRouter.Mark = Marks.Dejkstra;
            Router router = startRouter;

            int n = startRouter.Segment.Routers.Count;
            for (int i = 0; i < n; i++)
            {
                foreach (Port port in router.Ports)
                {
                    // обновление меток расстояния роутеров
                    if ((port.Router.DistancePointer > (router.DistancePointer + port.Wire.Criterion)) &&
                        (port.Router.Used == false) && (port.Router.Segment.Number == router.Segment.Number))
                    {
                        port.Router.DistancePointer = router.DistancePointer + port.Wire.Criterion;
                    }
                }

                // пометить роутер как исследованный
                router.Used = true;
                routers.Add(router);
                router.UpdateText();

                double min = Const.INF;
                foreach (Router r in startRouter.Segment.Routers)
                {
                    // поиск следующего роутера 
                    if ((r.DistancePointer < min) && (r.Used == false))
                    {
                        min = r.DistancePointer;
                        router = r;
                    }
                }

                foreach (Port port in router.Ports)
                {
                    if (port.Router.DistancePointer == router.DistancePointer - port.Wire.Criterion)
                    {
                        port.Wire.Pen = new Pen(startRouter.Segment.WireColor, 4);
                        port.Wire.BelongTree = true;
                        router.ShortTrack.Clear();
                        router.ShortTrack.AddRange(port.Router.ShortTrack);
                        router.ShortTrack.Add(port.OppositePort);
                        break;
                    }
                }
            }

            startRouter.Segment.Routers = routers;
        }

        // алгоритм проверки целостности графа
        public int Check(List<Router> routers)
        {
            if (network.Routers.Count < 2)
            {
                return -1;
            }

            if (routers.Count == 0)
            {
                return 1;
            }

            foreach (Router r in network.Routers)
            {
                r.Used = false;
            }

            int counter = 1;
            routers[0].Used = true;

            CheckLoop(routers[0], ref counter);

            if (network.Routers.Count != counter)
            {
                return -1;
            }

            return 0;
        }

        // алгоритм вычисления диаметра графа
        public int GetDiameter(List<Router> routers)
        {
            int[] variants = new int[routers.Count];
            int iteration = 0;

            foreach (Router startRouter in routers)
            {
                foreach (Router r in routers)
                {
                    // установка исходных данных 
                    r.DistancePointer = Const.INF;
                    r.Used = false;
                }

                // установки для исходного роутера
                startRouter.DistancePointer = 0;
                Router router = startRouter;

                int n = routers.Count;
                for (int i = 0; i < n; i++)
                {
                    foreach (Port port in router.Ports)
                    {
                        // обновление меток расстояния роутеров
                        if ((port.Router.DistancePointer > (router.DistancePointer + 1)) &&
                            (port.Router.Used == false))
                        {
                            port.Router.DistancePointer = router.DistancePointer + 1;
                        }
                    }
                    // пометить роутер как исследованный
                    router.Used = true;

                    double min = Const.INF;
                    foreach (Router r in routers)
                    {
                        // поиск следующего роутера 
                        if ((r.DistancePointer < min) && (r.Used == false))
                        {
                            min = r.DistancePointer;
                            router = r;
                        }
                    }
                }

                int max = 0;
                foreach (Router r in routers)
                {
                    if (r.DistancePointer > max)
                    {
                        max = (int)r.DistancePointer;
                    }
                }

                variants[iteration] = max;
                iteration += 1;
            }

            int maxVariant = 0;
            for (int i = 0; i < routers.Count; i++)
            {
                if (variants[i] > maxVariant)
                {
                    maxVariant = variants[i];
                }
            }

            return maxVariant;
        }

        // алгоритм вычисления кратчайшего пути между двумя вершинами
        public int ShortPath(Router startRouter, Router endRouter)
        {
            Pen pen = new Pen(Color.Gray, 1);
            // сброс цветов каналов
            foreach (Wire wire in network.Wires)
            {
                wire.Pen = pen;
            }

            foreach (Router router in network.Routers)
            {
                router.Mark = Marks.None;
            }

            startRouter.Mark = Marks.Rout;
            endRouter.Mark = Marks.Rout;

            // 1 
            if (startRouter.Segment.Number == endRouter.Segment.Number)
            {
                GetPath(startRouter, endRouter);
                return (startRouter.Segment.Routers.Count * endRouter.Segment.Routers.Count);
            }

            // 2
            List<Router> shortRout = GetRout(startRouter.Segment, endRouter.Segment);

            if (shortRout.Contains(endRouter) == false)
            {
                shortRout.Insert(0, endRouter);
            }

            if (shortRout.Contains(startRouter) == false)
            {
                shortRout.Add(startRouter);
            }

            // 3
            int laboriousness = 0;
            for (int i = 0; i < shortRout.Count - 1; i++)
            {
                if (shortRout[i].Segment.Number == shortRout[i + 1].Segment.Number)
                {
                    GetPath(shortRout[i], shortRout[i + 1]);
                    laboriousness += (shortRout[i].Segment.Routers.Count * shortRout[i].Segment.Routers.Count);
                }
            }

            return (laboriousness + ((network.Segments.Count - 1) * (network.Segments.Count - 1)));
        }

        #endregion

        // вспомогоательные методы
        #region AuxiliaryMethods

        // анализ вершины: алгоритм проверки целостности графа
        private void CheckLoop(Router router, ref int counter)
        {
            foreach (Port port in router.Ports)
            {
                if (port.Router.Used == false)
                {
                    port.Router.Used = true;
                    counter += 1;
                    CheckLoop(port.Router, ref counter);
                }

            }
        }

        // распределение роутеров по сегментам: алгоритм сегментации
        private void RoutersDistribution(List<Router> viewingRouters)
        {
            List<Router_Connect_Segment> rcsList = new List<Router_Connect_Segment>();

            foreach (Router router in viewingRouters)
            {
                List<Segment> viewingSegments = new List<Segment>();

                // поиск сегментов, с которыми роутер имеет связь по
                // минимальному остову
                foreach (Port port in router.TPorts)
                {
                    Segment segment = port.Router.Segment;
                    if ((segment.Number > 0) && (viewingSegments.Contains(port.Router.Segment) == false))
                    {
                        viewingSegments.Add(segment);
                    }
                }

                // если у роутера есть соседние сегменты ...
                if (viewingSegments.Count > 0)
                {
                    Segment connectedSegment = null;
                    List<Segment> maxSegments = new List<Segment>();
                    int trigger = 0;
                    int max = 0;
                    // нахождение сегмента с наибольшим числом связей к роутеру
                    foreach (Segment segment in viewingSegments)
                    {
                        int count = segment.GetConnectedWiresCount(router);
                        if (count > max)
                        {
                            max = count;
                            connectedSegment = segment;
                            trigger = 0;
                            maxSegments.Clear();
                        }
                        else if (count == max)
                        {
                            // счетчик срабатывает, если найдены два и более сегмента с 
                            // одинаковым максимальным числом связей к роутеру
                            if (maxSegments.Contains(segment) == false)
                            {
                                trigger += 1;
                                maxSegments.Add(segment);
                                if (connectedSegment != null)
                                {
                                    maxSegments.Add(connectedSegment);
                                    connectedSegment = null;
                                }
                            }
                        }
                    }

                    // добавление роутера к сегменту по максимальному числу связей
                    if (trigger == 0)
                    {
                        rcsList.Add(new Router_Connect_Segment(router, connectedSegment.MinConnectivity(router), connectedSegment));
                    }
                    else // добавление роутера к сегменту по минимальному весу дуги
                    {
                        int min = Const.INF;
                        Segment minSegment = null;

                        foreach (Segment seg in maxSegments)
                        {
                            int count = seg.MinConnectivity(router);
                            if (count < min)
                            {
                                min = count;
                                minSegment = seg;
                            }
                        }
                        rcsList.Add(new Router_Connect_Segment(router, minSegment.MinConnectivity(router), minSegment));
                    }
                }
            }

            int minConnectivity = Const.INF;
            Router_Connect_Segment minRcs = new Router_Connect_Segment();
            foreach (Router_Connect_Segment rcs in rcsList)
            {
                if (rcs.Connectivity < minConnectivity)
                {
                    minConnectivity = rcs.Connectivity;
                    minRcs = rcs;
                }
            }

            minRcs.Router.Segment = minRcs.Segment;
            minRcs.Segment.Routers.Add(minRcs.Router);
        }

        // объединение сегментов: алгоритм сегментации
        private void SegmentsDistribution(List<Segment> viewingSegments, double Q)
        {
            List<Segment_Connect_Segment> scsList = new List<Segment_Connect_Segment>(); 

            foreach (Segment segment in viewingSegments)
            {
                List<Segment> adjacentSegments = new List<Segment>();

                foreach (Port port in segment.TGateways)
                {
                    Segment adjSeg = port.Router.Segment;
                    if ((segment.Number != adjSeg.Number) && (adjacentSegments.Contains(port.Router.Segment) == false))
                    {
                        adjacentSegments.Add(adjSeg);
                    }
                }

                if (adjacentSegments.Count > 0)
                {
                    Segment connectedSegment = null;
                    List<Segment> minConnectivitySegments = new List<Segment>();
                    int trigger = 0;
                    int minSumConnectivity = adjacentSegments[0].GetInternalConnectivity();

                    foreach (Segment adjSeg in adjacentSegments)
                    {
                        int count = adjSeg.GetInternalConnectivity();
                        if (count < minSumConnectivity)
                        {
                            minSumConnectivity = count;
                            connectedSegment = adjSeg;
                            trigger = 0;
                            minConnectivitySegments.Clear();
                        }
                        else if (count == minSumConnectivity)
                        {
                            if (minConnectivitySegments.Contains(adjSeg) == false)
                            {
                                trigger += 1;
                                minConnectivitySegments.Add(adjSeg);
                                if (connectedSegment != null)
                                {
                                    minConnectivitySegments.Add(connectedSegment);
                                    connectedSegment = null;
                                }
                            }
                        }
                    }

                    if (trigger == 0)
                    {
                        scsList.Add(new Segment_Connect_Segment(segment, connectedSegment.MinConnectivity(segment), connectedSegment));
                    }
                    else
                    {
                        int min = Const.INF;
                        Segment minSegment = null;

                        foreach (Segment seg in minConnectivitySegments)
                        {
                            int count = seg.MinConnectivity(segment);
                            if (count < min)
                            {
                                min = count;
                                minSegment = seg;
                            }
                        }
                        scsList.Add(new Segment_Connect_Segment(segment, minSegment.MinConnectivity(segment), minSegment));
                    }
                }
            }

            int minConnectivity = Const.INF;
            Segment_Connect_Segment minScs = new Segment_Connect_Segment();
            foreach (Segment_Connect_Segment scs in scsList)
            {
                if (scs.Connectivity < minConnectivity)
                {
                    minConnectivity = scs.Connectivity;
                    minScs = scs;
                }
            }

            // объединение сегментов
            foreach (Router router in minScs.Segment.Routers)
            {
                router.Segment = minScs.ConnectedSegment;
                minScs.ConnectedSegment.Routers.Add(router);
            }

            minScs.Segment.Routers.Clear();
            network.Segments.Remove(minScs.Segment);

            // обновление Q для вновь полученного сегмента
            minScs.ConnectedSegment.UpdateStructure();
        }

        // алгоритм Дейкстры между сегментами: алгоритм вычисления кратчайшего пути
        private void Dejkstra(Segment startSegment)
        {
            foreach (Segment seg in network.Segments)
            {
                // установка исходных данных 
                seg.UpdateStructure();
                seg.DistancePointer = Const.INF;
                seg.Used = false;
            }

            // установки для исходного роутера
            startSegment.DistancePointer = 0;
            Segment segment = startSegment;

            int n = network.Segments.Count - 2;
            for (int i = 0; i < n; i++)
            {
                foreach (Port port in segment.Gateways)
                {
                    // обновление меток расстояния сегментов
                    if ((port.Router.Segment.DistancePointer > (segment.DistancePointer + port.Wire.Criterion)) &&
                        (port.Router.Segment.Used == false))
                    {
                        port.Router.Segment.DistancePointer = segment.DistancePointer + port.Wire.Criterion;
                    }
                }
                // пометить сегмент как исследованный
                segment.Used = true;

                double min = Const.INF;
                foreach (Segment seg in network.Segments)
                {
                    // поиск следующего роутера 
                    if ((seg.DistancePointer < min) && (seg.Used == false))
                    {
                        min = seg.DistancePointer;
                        segment = seg;
                    }
                }

                // добавление дуги к дереву ( окраска канала )
                foreach (Port port in segment.Gateways)
                {
                    if (port.Wire.Criterion == segment.DistancePointer - port.Router.Segment.DistancePointer)
                    {
                        port.Wire.Pen = new Pen(Color.Green, 4);
                        break;
                    }
                }
            }
        }

        // прокладка пути между двумя вершинами: алгоритм вычисления кратчайшего пути
        private void GetPath(Router startRouter, Router endRouter)
        {
            foreach (Router r in startRouter.Segment.Routers)
            {
                // установка исходных данных 
                r.DistancePointer = Const.INF;
                r.Used = false;
            }

            startRouter.DistancePointer = 0;
            Router router = startRouter;

            while (router != endRouter)
            {
                foreach (Port port in router.Ports)
                {
                    // обновление меток расстояния роутеров
                    if ((port.Router.DistancePointer > (router.DistancePointer + port.Wire.Criterion)) &&
                        (port.Router.Used == false) && (port.Router.Segment.Number == router.Segment.Number))
                    {
                        port.Router.DistancePointer = router.DistancePointer + port.Wire.Criterion;
                    }
                }
                router.Used = true;

                double min = Const.INF;
                foreach (Router r in router.Segment.Routers)
                {
                    if ((r.DistancePointer < min) && (r.Used == false))
                    {
                        min = r.DistancePointer;
                        router = r;
                    }
                }
            }

            // прокладка пути между роутерами
            Router pathRouter = endRouter;
            Pen pathPen = new Pen(Color.Red, 4);

            while (pathRouter != startRouter)
            {
                foreach (Port port in pathRouter.Ports)
                {
                    if ((port.Router.DistancePointer == (pathRouter.DistancePointer - port.Wire.Criterion)) &&
                        (port.Router.Segment.Number == startRouter.Segment.Number))
                    {
                        pathRouter = port.Router;
                        port.Wire.Pen = pathPen;
                        break;
                    }
                }
            }
        }

        // получение списка вершин, составляющих путь между двумя исходными вершинами:
        // алгоритм вычисления кратчайшего пути
        private List<Router> GetRout(Segment startSegment, Segment endSegment)
        {
            foreach (Segment seg in network.Segments)
            {
                seg.UpdateStructure();
                seg.DistancePointer = Const.INF;
                seg.Used = false;
            }

            startSegment.DistancePointer = 0;
            Segment segment = startSegment;

            while (segment.Number != endSegment.Number)
            {
                foreach (Port port in segment.Gateways)
                {
                    if ((port.Router.Segment.DistancePointer > (segment.DistancePointer + port.Wire.Criterion)) &&
                        (port.Router.Segment.Used == false))
                    {
                        port.Router.Segment.DistancePointer = segment.DistancePointer + port.Wire.Criterion;
                    }
                }
                segment.Used = true;

                double min = Const.INF;
                foreach (Segment seg in network.Segments)
                {
                    if ((seg.DistancePointer < min) && (seg.Used == false))
                    {
                        min = seg.DistancePointer;
                        segment = seg;
                    }
                }
            }

            // прокладка пути между сегментами
            List<Router> shortRout = new List<Router>();
            Segment pathSegment = endSegment;
            Pen pathPen = new Pen(Color.Red, 4);

            while (pathSegment != startSegment)
            {
                foreach (Port port in pathSegment.Gateways)
                {
                    if (port.Router.Segment.DistancePointer == (pathSegment.DistancePointer - port.Wire.Criterion))
                    {
                        if (port.Router == port.Wire.StartRouter)
                        {
                            shortRout.Add(port.Wire.EndRouter);
                            shortRout.Add(port.Wire.StartRouter);
                        }
                        else
                        {
                            shortRout.Add(port.Wire.StartRouter);
                            shortRout.Add(port.Wire.EndRouter);
                        }

                        pathSegment = port.Router.Segment;
                        port.Wire.Pen = pathPen;
                        break;
                    }
                }
            }
            return shortRout;
        }

        #endregion
    }
}


