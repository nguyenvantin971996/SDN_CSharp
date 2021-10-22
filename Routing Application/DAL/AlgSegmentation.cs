using Routing_Application.Domain;
using Routing_Application.Enums;
using Routing_Application.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Application.DAL
{
    public class AlgSegmentation : Algorithm
    {
        // конструктор
        public AlgSegmentation(Network network) : base(network)
        {

        }

        // основной метод
        public void DoAlg(Router startRouter, double Q)
        {
            // сброс топологии
            Reset();

            // этап 1
            // получение минимального остова
            AlgPrim algPrim = new AlgPrim(network);
            algPrim.DoAlg(startRouter, false);
            startRouter.Mark = Marks.Segmentation;

            // этап 2
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

            // этап 3
            // распределение узлов, не имеющих сегментов

            // получаем список нераспределенных узлов
            List<Router> viewingRouters = (from r in network.Routers
                                           where r.Segment.Number == 0
                                           select r).ToList();

            // пока в сети есть нераспределенные узлы
            // проводим распределение
            while (viewingRouters.Count > 0)
            {
                // распределение узлов связи
                RoutersDistribution(viewingRouters);

                // обновление списканераспределенных узлов связи
                viewingRouters = (from r in network.Routers
                                  where r.Segment.Number == 0
                                  select r).ToList();
            }


            // этап 4
            // раасчет Q для сегментов
            foreach (Segment segment in network.Segments)
            {
                // расчет структурных показателей сегмента,
                // в том числе и Q
                segment.UpdateStructure();
            }

            // этап 5
            // объединение сегментов с неоптимальным Q

            // получение списка сегментов с неоптимальным Q
            List<Segment> viewingSegments = (from s in network.Segments
                                             where s.Q < Q && s.Number > 0
                                             select s).ToList();

            while (viewingSegments.Count > 0)
            {
                // проведение необходимых объединений сегментов
                SegmentsDistribution(viewingSegments, Q);

                // обновление списка сегментов с неоптимальным Q
                viewingSegments = (from s in network.Segments
                                   where s.Q < Q && s.Number > 0
                                   select s).ToList();
            }

            // распределение каналов связи по сформированным сегментам
            WiresDistribution();

            // редактирование магистрального сегмента
            network.Segments[0].Routers.Clear();
            network.Segments[0].Wires.Clear();
        }

        // распределение узлов по сегментам
        private void RoutersDistribution(List<Router> viewingRouters)
        {
            // список пар узел-сегмент
            List<Router_Connect_Segment> rcsList = new List<Router_Connect_Segment>();

            foreach (Router router in viewingRouters)
            {
                // список сегментов, смежных с рассматриваемым узлом
                List<Segment> viewingSegments = new List<Segment>();

                // поиск сегментов, с которыми узел имеет связь по
                // минимальному остову
                foreach (Port port in router.TPorts)
                {
                    Segment segment = port.Router.Segment;
                    // если сегмент не магистральный и еще не добавлен в список рассматриваемых сегментов
                    if ((segment.Number > 0) && (viewingSegments.Contains(port.Router.Segment) == false))
                    {
                        // добавить сегмент в список рассматриваемых сегментов
                        viewingSegments.Add(segment);
                    }
                }

                // если у узла есть соседние сегменты ...
                if (viewingSegments.Count > 0)
                {
                    // потенциально присоединяемый сегмент
                    Segment connectedSegment = null;
                    // список сегментов с одинаковым максимальным числом связей к узлу
                    List<Segment> maxSegments = new List<Segment>();
                    int trigger = 0;
                    int max = 0;
                    // нахождение сегмента с наибольшим числом связей к узлу
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
                            // триггер срабатывает, если найдены два и более сегмента с 
                            // одинаковым максимальным числом связей к узлу
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

                    // добавление узла к сегменту по максимальному числу связей
                    if (trigger == 0)
                    {
                        rcsList.Add(new Router_Connect_Segment(router, connectedSegment.MinConnectivity(router), connectedSegment));
                    }
                    else // добавление узла к сегменту по минимальному параметру канала связи
                    {
                        int minConn = Const.INF;
                        Segment minSegment = null;

                        // поиск сегмента с минимальной связью к рассматриваемому узлу
                        foreach (Segment seg in maxSegments)
                        {
                            int count = seg.MinConnectivity(router);
                            if (count < minConn)
                            {
                                minConn = count;
                                minSegment = seg;
                            }
                        }
                        rcsList.Add(new Router_Connect_Segment(router, minConn, minSegment));
                    }
                }
            }

            // поиск пары узел-сегмент с минимальной связностью между собой
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

            // присоединение узла к сегменту
            minRcs.Router.Segment = minRcs.Segment;
            minRcs.Segment.Routers.Add(minRcs.Router);
        }

        // объединение сегментов
        private void SegmentsDistribution(List<Segment> viewingSegments, double Q)
        {
            // список пар сегмент-сегмент
            List<Segment_Connect_Segment> scsList = new List<Segment_Connect_Segment>();

            foreach (Segment segment in viewingSegments)
            {
                // список сегментов, смежных с рассматриваемым сегментом
                List<Segment> adjacentSegments = new List<Segment>();

                // поиск сегментов, с которыми рассматриваемый сегмент 
                // имеет связь по минимальному остову
                foreach (Port port in segment.TGateways)
                {
                    Segment adjSeg = port.Router.Segment;
                    // если сегмент еще не добавлен в список рассматриваемых сегментов
                    if ((segment != adjSeg) && (adjacentSegments.Contains(port.Router.Segment) == false))
                    {
                        // добавить сегмент в список рассматриваемых сегментов
                        adjacentSegments.Add(adjSeg);
                    }
                }

                // если у рассматриваемого сегмента есть соседние сегменты ...
                if (adjacentSegments.Count > 0)
                {
                    // потенциально присоединяемый сегмент
                    Segment connectedSegment = null;
                    // список сегментов с минимальным параметром канала связи между ними
                    List<Segment> minConnectivitySegments = new List<Segment>();
                    int trigger = 0;
                    int minSumConnectivity = adjacentSegments[0].GetInternalConnectivity();

                    foreach (Segment adjSeg in adjacentSegments)
                    {
                        // поиск сегмента с минимальной внутренней связностью 
                        // среди сегментов, смежных с рассматриваемым
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
                                // триггер срабатывает, если найдены два и более сегмента с 
                                // одинаковой минимальной внутренней связностью
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

                    // образование пары сегмент-сегмент по минимальной величине внутренней связности
                    if (trigger == 0) 
                    {
                        scsList.Add(new Segment_Connect_Segment(segment, connectedSegment.MinConnectivity(segment), connectedSegment));
                    }
                    else // образование пары сегмент-сегмент по минимальному параметру канала связи
                    {
                        int minConn = Const.INF;
                        Segment minSegment = null;

                        // поиск сегмента с минимальной связью к рассматриваемому сегменту
                        foreach (Segment seg in minConnectivitySegments)
                        {
                            int count = seg.MinConnectivity(segment);
                            if (count < minConn)
                            {
                                minConn = count;
                                minSegment = seg;
                            }
                        }
                        scsList.Add(new Segment_Connect_Segment(segment, minConn, minSegment));
                    }
                }
            }

            // поиск пары сегмент-сегмент с минимальной пармаметром канала связи между ними
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

        // распределение каналов связи по сегментам
        private void WiresDistribution()
        {
            foreach (Wire wire in network.Wires)
            {
                if (wire.StartRouter.Segment == wire.EndRouter.Segment)
                {
                    wire.Segment = wire.StartRouter.Segment;
                    wire.Segment.Wires.Add(wire);
                }
                else
                {
                    wire.Segment = null;
                }
            }
        }
    }
}
