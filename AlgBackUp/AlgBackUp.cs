using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Routing_Application.Domain;
using System;
using Routing_Application.View;
using Routing_Application.Enums;
using Routing_Application.Structures;

namespace Routing_Application.DAL
{
    /// <summary>
    /// Класс, проводящий основные алгоритмические преобразования сети
    /// </summary>
    public class Algorithms
    {
        // ссылка на сеть
        private Network network;

        /* Конструктор */
        public Algorithms(Network network)
        {
            this.network = network;
        }

        // основные методы
        #region MainMethods

        // сброс результатов
        public void Reset()
        {
            Pen pen = new Pen(Color.Gray, 1);
            // сброс цветов каналов
            foreach (Wire wire in network.Wires)
            {
                wire.Pen = pen;
            }
            // удаление сегментов
            network.Segments.Clear();
            // создание нулевого сегмента
            network.Segments.Add(new Segment());
            foreach (Router router in network.Routers)
            {
                router.Mark = Marks.None;
                router.Tracks = new List<int>() { Const.INF, Const.INF, Const.INF };
                router.Order = 0;
                router.Segment = network.Segments[0];
                network.Segments[0].Routers.Add(router);
            }
            network.Segments[0].Repaint(Properties.Resources.router0);
        }

        // алгоритм Прима
        public void Prim(Router startRouter, bool paint)
        {
            Pen taggedPen = new Pen(Color.Black, 4);
            Pen pen = new Pen(Color.Gray, 1);
            if (paint == true)
            {
                // сброс цветов каналов
                foreach (Wire wire in network.Wires)
                {
                    wire.Pen = pen;
                }
            }
            // установка исходных данных для роутеров
            foreach (Router router in network.Routers)
            {
                router.Mark = Marks.None;
                router.Used = false;
                router.TPorts.Clear();
            }

            // получение величины проходов
            int n = network.Routers.Count - 1;
            // создание списка просматриваемых роутеров
            List<Router> viewingRouters = new List<Router>();

            // установки для исходного роутера 
            viewingRouters.Add(startRouter);
            startRouter.Mark = Marks.Prim;
            startRouter.Used = true;

            // проход по всем роутерам в списке
            for (int i = 0; i < n; i++)
            {
                Port connectablePort = null;
                Router deletedRouter = null;
                double min = Const.INF;
                // просмотр ближайших к роуторам из сформированного остова роутеров
                foreach (Router router in viewingRouters)
                {
                    bool del = false;
                    foreach (Port port in router.Ports)
                    {
                        if (port.Router.Used == false)
                        {
                            del = true;
                            if (port.Wire.Criterion < min)
                            {
                                min = port.Wire.Criterion;
                                connectablePort = port;
                            }
                        }
                    }

                    // если существует роутер, окруженный уже вошедшими в остов соседями
                    // то он помечается и удаляется из списка просматриваемых
                    if (del == false)
                    {
                        deletedRouter = router;
                    }
                }

                if (connectablePort != null)
                {
                    if (paint == true)
                    {
                        connectablePort.Wire.Pen = taggedPen;
                    }
                    // обновление списка просматриваемых роутеров
                    connectablePort.Router.Used = true;
                    viewingRouters.Add(connectablePort.Router);
                    connectablePort.Wire.StartRouter.TPorts.Add((from p in connectablePort.Wire.StartRouter.Ports
                                                                 where p.Router == connectablePort.Wire.EndRouter && p.Wire == connectablePort.Wire
                                                                 select p).Single());

                    connectablePort.Wire.EndRouter.TPorts.Add((from p in connectablePort.Wire.EndRouter.Ports
                                                                 where p.Router == connectablePort.Wire.StartRouter && p.Wire == connectablePort.Wire
                                                                 select p).Single());
                }

                if (deletedRouter != null)
                {
                    viewingRouters.Remove(deletedRouter);
                }
            }
        }

        // алгоритм сегментации
        public void Segmentation(Router startRouter, double Q)
        {
            // сброс топологии
            Reset();

            // этап 1
            // получение минимального остова
            Prim(startRouter, false);
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

            network.Segments[0].Routers.Clear();
        }

        // алгоритм Дейкстры для роутеров
        public void Dejkstra(Router startRouter)
        {
            // переопределение цветов дуг внутри сегментов
            network.SegmentsReColor();

            foreach (Router r in network.Routers)
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
                r.Used = false;
                r.TPorts.Clear();
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
            }

            // установки для исходного роутера
            startRouter.Order = 0;
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
                router.UpdateText();

                // добавление дуги к дереву ( окраска канала )
                foreach (Port port in router.Ports)
                {
                    if (port.Wire.Criterion == router.DistancePointer - port.Router.DistancePointer)
                    {
                        port.Wire.Pen = new Pen(startRouter.Segment.Color, 4);
                        port.Wire.StartRouter.TPorts.Add((from p in port.Wire.StartRouter.Ports
                                                          where p.Router == port.Wire.EndRouter && p.Wire == port.Wire
                                                          select p).Single());

                        port.Wire.EndRouter.TPorts.Add((from p in port.Wire.EndRouter.Ports
                                                        where p.Router == port.Wire.StartRouter && p.Wire == port.Wire
                                                        select p).Single());
                        break;
                    }
                }

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
            }
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

        public int PairTransition(Wire wire)
        {
            UpdateOrders();
            UpdateTracks1();
            UpdateTracks2();
            int pt = UpdateStaticInfo();

            foreach (Router r in network.Routers)
            {
                r.UpdateText();
            }
            foreach (Wire w in network.Wires)
            {
                w.UpdateInfo(Criterias.Metric);
            }

            return pt;
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

        // OK
        private void UpdateDistancePointer(Router router)
        {
            router.DistancePointer = Const.INF;
            foreach (Port port in router.Ports)
            {
                double sum = port.Router.DistancePointer + port.Wire.Criterion;
                if ((port.Router.Order >= router.Order) && (sum < router.DistancePointer))
                {
                    router.DistancePointer = sum;
                }
            }

            foreach (Port port in router.Ports)
            {
                if (port.Router.Order < router.Order)
                {
                    UpdateDistancePointer(port.Router);
                }
            }
        }

        private void UpdateOrders()
        {
            List<Router> leafs = new List<Router>();
            Router startRouter = (from r in network.Routers
                                  where r.DistancePointer == 0
                                  select r).Single();
            int i = 0;
            leafs = (from router in network.Routers
                     where router.TPorts.Count == 1 && router != startRouter
                     select router).ToList();

            while (leafs.Count > 0)
            {
                foreach (Router router in leafs)
                {
                    router.Order = i;
                    router.TPorts[0].Router.TPorts.Remove(router.TPorts[0].Pair);
                    router.TPorts.Clear();
                }

                i = i + 1;

                leafs = (from router in network.Routers
                         where router.TPorts.Count == 1 && router != startRouter
                         select router).ToList();
            }

            startRouter.Order = i;

            foreach (Wire wire in network.Wires)
            {
                if (wire.Pen.Color == Color.Red)
                {
                    wire.StartRouter.TPorts.Add((from p in wire.StartRouter.Ports
                                                 where p.Router == wire.EndRouter && p.Wire == wire
                                                 select p).Single());

                    wire.EndRouter.TPorts.Add((from p in wire.EndRouter.Ports
                                               where p.Router == wire.StartRouter && p.Wire == wire
                                               select p).Single());
                }
            }
        }

        private void UpdateTracks1()
        {
            Router startRouter = null;

            foreach (Router router in network.Routers)
            {
                router.Tracks = new List<int>() { Const.INF, Const.INF, Const.INF };
                if (router.DistancePointer == 0)
                {
                    startRouter = router;
                }
            }

            network.Routers = network.Routers.OrderBy(r => r.Order).ToList();
            foreach (Router router in network.Routers)
            {
                if (router != startRouter)
                {
                    List<int> allTracks = new List<int>();
                    foreach (Port port in router.Ports)
                    {
                        if ((port.Router.Tracks[0] < Const.INF) && (port.Router.DistancePointer > 0))
                        {
                            if (router.DistancePointer + port.Wire.Criterion != port.Router.Tracks[0])
                            {
                                allTracks.Add(port.Wire.Criterion + port.Router.Tracks[0]);
                            }
                            if (router.DistancePointer + port.Wire.Criterion != port.Router.Tracks[1])
                            {
                                allTracks.Add(port.Wire.Criterion + port.Router.Tracks[1]);
                            }
                            if (router.DistancePointer + port.Wire.Criterion != port.Router.Tracks[2])
                            {
                                allTracks.Add(port.Wire.Criterion + port.Router.Tracks[2]);
                            }
                        }
                        else
                        {
                            allTracks.Add(port.Wire.Criterion + (int)port.Router.DistancePointer);
                        }
                    }

                    allTracks.Sort();
                    for (int j = 0; j < allTracks.Count; j++)
                    {
                        if (j < 3)
                        {
                            router.Tracks[j] = allTracks[j];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void UpdateTracks2()
        {
            Router startRouter = null;

            foreach (Router router in network.Routers)
            {
                if (router.DistancePointer == 0)
                {
                    startRouter = router;
                }
            }

            foreach (Router router in network.Routers) 
            {
                if (router != startRouter)
                {
                    List<int> allTracks = new List<int>();
                    foreach (Port port in router.Ports)
                    {
                        if (port.Router.DistancePointer > 0)
                        {
                            if (router.DistancePointer + port.Wire.Criterion != port.Router.Tracks[0])
                            {
                                allTracks.Add(port.Wire.Criterion + port.Router.Tracks[0]);
                            }
                            if (router.DistancePointer + port.Wire.Criterion != port.Router.Tracks[1])
                            {
                                allTracks.Add(port.Wire.Criterion + port.Router.Tracks[1]);
                            }
                            if (router.DistancePointer + port.Wire.Criterion != port.Router.Tracks[2])
                            {
                                allTracks.Add(port.Wire.Criterion + port.Router.Tracks[2]);
                            }
                        }
                        else
                        {
                            allTracks.Add(port.Wire.Criterion + (int)port.Router.DistancePointer);
                        }
                    }

                    allTracks.Sort();
                    for (int j = 0; j < allTracks.Count; j++)
                    {
                        if (j < 3)
                        {
                            router.Tracks[j] = allTracks[j];
                        }
                        else
                        {
                            break;
                        }
                    }

                }

                router.DistancePointer = router.Tracks[0];
            }

            startRouter.DistancePointer = 0;
        }

        private int UpdateStaticInfo()
        {
            int pt = 0;

            foreach (Wire wire in network.Wires)
            {
                int d0 = 0;
                int d1 = 0;
                int d2 = 0;
                Router bigRouter = null;
                Router smallRouter = null;
                List<int> tracks;

                if (wire.StartRouter.DistancePointer > wire.EndRouter.DistancePointer)
                {
                    bigRouter = wire.StartRouter;
                    smallRouter = wire.EndRouter;
                }
                else
                {
                    smallRouter = wire.StartRouter;
                    bigRouter = wire.EndRouter;
                }

                tracks = new List<int>() { bigRouter.Tracks[0], bigRouter.Tracks[1], bigRouter.Tracks[2] };
                d0 = (int)smallRouter.DistancePointer + wire.Criterion;

                if (d0 == tracks[0])
                {
                    // OK
                }
                else if (d0 == tracks[1])
                {
                    tracks[1] = tracks[0];
                }
                else
                {
                    tracks[2] = tracks[1];
                    tracks[1] = tracks[0];
                }

                d1 = tracks[1];
                d2 = tracks[2];

                wire.PointT = wire.Criterion + (d1 - d0);
                wire.PointS = wire.Criterion + (d2 - d0);

                if (wire.Criterion < wire.PointT)
                {
                    if (wire.Pen.Color != Color.Red)
                    {
                        pt += 1;
                    }

                    wire.Pen = new Pen(Color.Red, 4);
                }
                else if ((wire.Criterion > wire.PointT) && (wire.Criterion < wire.PointS))
                {
                    wire.Pen = new Pen(Color.Green, 4);
                }
                else if (wire.Criterion > wire.PointS)
                {
                    wire.Pen = new Pen(Color.Gray, 1);
                }
                else if (wire.Criterion == wire.PointT)
                {
                    if (wire.Pen.Color == Color.Gray)
                    {
                        wire.Pen = new Pen(Color.Green, 4);
                    }
                }
                else if (wire.Criterion == wire.PointS)
                {
                    if (wire.Pen.Color == Color.Red)
                    {
                        wire.Pen = new Pen(Color.Green, 4);
                    }
                }

            }

            return pt;
        }

        // распределение роутеров по сегментам: алгоритм сегментации
        private void RoutersDistribution(List<Router> viewingRouters)
        {
            List<RCS> rcsList = new List<RCS>();

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
                        rcsList.Add(new RCS(router, connectedSegment.MinConnectivity(router), connectedSegment));
                    }
                    // добавление роутера к сегменту по минимальному весу дуги
                    else
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
                        rcsList.Add(new RCS(router, minSegment.MinConnectivity(router), minSegment));
                    }
                }
            }

            int minConnectivity = Const.INF;
            RCS minRcs = new RCS();
            foreach (RCS rcs in rcsList)
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
            List<SCS> scsList = new List<SCS>(); 

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
                    int minSumConnectivity = Const.INF;

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
                        scsList.Add(new SCS(segment, connectedSegment.MinConnectivity(segment), connectedSegment));
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
                        scsList.Add(new SCS(segment, minSegment.MinConnectivity(segment), minSegment));
                    }
                }
            }

            int minConnectivity = Const.INF;
            SCS minScs = new SCS();
            foreach (SCS scs in scsList)
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


