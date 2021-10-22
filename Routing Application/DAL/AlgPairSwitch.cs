using Routing_Application.Domain;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Routing_Application.DAL
{
    public class AlgPairSwitch : Algorithm
    {
        // список, хранящий информацию о произошедших парных переходах
        private List<string> pairSwitchesSet;

        /* конструктор */
        public AlgPairSwitch(Network network) : base(network) 
        {
            pairSwitchesSet = new List<string>();
        }

        // основной метод
        public List<string> DoAlg(Segment segment)
        {
            pairSwitchesSet.Clear();
            // обновление статической информации 
            while (UpdateStaticInfo(segment.Routers) == 1) 
            { 
            }
            // сортировка узлов по удалению от корня дерева кратчайших путей
            segment.Routers = segment.Routers.OrderBy(r => r.DistancePointer).ToList();
            // пересчет параметров ребер
            UpdateWires(segment);
            // закрашивание маршрутов
            Painting(segment);

            return pairSwitchesSet;
        }

        // обновление параметров ребра
        private void UpdateWires(Segment segment)
        {
            Pen wirePen = new Pen(Color.Gray, 1);
            foreach (Wire wire in segment.Wires)
            {
                wire.Pen = wirePen;
                // перерасчет точек вхождения
                UpdatePoint(wire);
            }
        }

        // закрашивание маршрутов
        private void Painting(Segment segment)
        {
            Pen pen = new Pen(segment.WireColor, 4);
            foreach (Router router in segment.Routers)
            {
                foreach (Port port in router.Ports)
                {
                    // выбор добавляемого в дерево ребра
                    if ((router.DistancePointer == port.Router.DistancePointer + port.Wire.Criterion) && 
                        (port.Router.Segment.Number == router.Segment.Number))
                    {
                        port.Wire.Pen = pen;
                        break;
                    }
                }
            }
        }

        // обновление статической информации
        private int UpdateStaticInfo(List<Router> routers)
        {
            // проход по узлам связи 
            foreach (Router router in routers)        
            {
                // проход по соседям текущего узла
                foreach (Port port in router.Ports)   
                {
                    // условие: соседний узел не исходный и он распологается в том же сегменте, что и текущий
                    if ((port.Router.DistancePointer > 0) && (port.Router.Segment.Number == router.Segment.Number))
                    {
                        int result = 0;

                        // условие: в соседний узел можно попасть из текущего
                        if ((int)router.DistancePointer - port.Wire.Criterion == port.Router.DistancePointer)
                        {
                            if (router.Ports.Count > 1)
                            {
                                // обновить расстояние от текущего узла до рассматриваемого соседа
                                result = UpdateTrack(port, (int)router.Ports[1].Distance + port.Wire.Criterion);
                            }
                        }
                        else
                        {
                            // обновить расстояние от текущего узла до рассматриваемого соседа
                            result = UpdateTrack(port, (int)router.DistancePointer + port.Wire.Criterion);
                        }

                        // если произошел парный переход
                        if (result == 1)
                        {
                            // передать информацию о том, что произошел парный переход
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }

        // осуществление парного перехода
        private void PairSwitch(Port port, Port replacement)
        {
            // если инцидентный переключаемому каналу 
            if (replacement.Router.DistancePointer > 0)
            {
                int index = replacement.Router.Ports.IndexOf(replacement.OppositePort);
                // переключить канал связи
                replacement.Router.Ports[index].Distance = (int)port.Router.DistancePointer + replacement.Wire.Criterion;
            }

            // вернуть информацию о произошедшем парном переходе
            pairSwitchesSet.Add(string.Format("Edge R{0}-R{1} switch R{2}-R{3}",
                                               replacement.Owner.Number,
                                               replacement.Router.Number,
                                               port.Wire.StartRouter.Number,
                                               port.Wire.EndRouter.Number)); 
        }

        // обновление расстояния до узла 
        private int UpdateTrack(Port port, int portDistance)
        {
            int oldIndex = port.Router.Ports.IndexOf(port.OppositePort);

            /* обновление информации о метрике маршрута */
            port.Router.Ports[oldIndex].Distance = portDistance;

            port.Router.Ports = port.Router.Ports.OrderBy(p => p.Distance).ToList();
            port.Router.DistancePointer = port.Router.Ports[0].Distance;

            int curIndex = port.Router.Ports.IndexOf(port.OppositePort);

            if ((port.Router.Ports.Count >= 2) && (port.Router.Ports[0].Distance != port.Router.Ports[1].Distance))
            {
                // если ребро перешло из множества замены во множество ребер дерева
                if ((curIndex == 0) && oldIndex > 0)
                {
                    // обработать парный переход
                    PairSwitch(port, port.Router.Ports[1]);
                    return 1;
                }

                // если ребро перешло из множества ребер дерева во множество ребер замены
                if ((curIndex > 0) && oldIndex == 0)
                {
                    // обработать парный переход
                    PairSwitch(port, port.Router.Ports[0]);
                    return 1;
                }
            }

            return 0;
        }

        // выбор узла, инцидентного выбранному ребру
        private Router GetWorkingRouter(Wire wire)
        {
            // в качестве рассматриваемого узла, инцидентного текущему ребру,
            // выбрать узел с наименьшей пометкой
            if (wire.StartRouter.DistancePointer > wire.EndRouter.DistancePointer)
            {
                return wire.StartRouter;
            }
            else
            {
                return wire.EndRouter;
            }
        }

        // пересчет точек вхождения для ребра
        private void UpdatePoint(Wire wire)
        {
            if (wire.StartRouter.Segment.Number == wire.EndRouter.Segment.Number)
            {
                // выбор узла, инцидентного выбранному ребру
                Router workingRouter = GetWorkingRouter(wire);

                int d0 = 0;
                int d1 = 0;
                int d2 = 0;

                // узел имеет три или более инцедентных ребер
                if (workingRouter.Ports.Count >= 3)
                {
                    if (wire == workingRouter.Ports[0].Wire)
                    {
                        wire.Replacement = workingRouter.Ports[1];

                        d0 = workingRouter.Ports[0].Distance;
                        d1 = workingRouter.Ports[1].Distance;
                        d2 = workingRouter.Ports[2].Distance;
                    }
                    else if (wire == workingRouter.Ports[1].Wire)
                    {
                        wire.Replacement = workingRouter.Ports[0];

                        d1 = workingRouter.Ports[0].Distance;
                        d0 = workingRouter.Ports[1].Distance;
                        d2 = workingRouter.Ports[2].Distance;
                    }
                    else
                    {
                        wire.Replacement = workingRouter.Ports[0];

                        d1 = workingRouter.Ports[0].Distance;
                        d2 = workingRouter.Ports[1].Distance;
                        d0 = workingRouter.Ports[2].Distance;
                    }
                    
                    wire.PointT = wire.Criterion + (d1 - d0);   // расчет точки вхождения в дерево
                    wire.PointS = wire.Criterion + (d2 - d0);   // расчет точки вхождения во множество замены
                }
                else if (workingRouter.Ports.Count == 2)        //  узел имеет два инцидентных ребра
                {
                    if (wire == workingRouter.Ports[0].Wire)
                    {
                        wire.Replacement = workingRouter.Ports[1];

                        d0 = workingRouter.Ports[0].Distance;
                        d1 = workingRouter.Ports[1].Distance;
                    }
                    else if (wire == workingRouter.Ports[1].Wire)
                    {
                        wire.Replacement = workingRouter.Ports[0];

                        d1 = workingRouter.Ports[0].Distance;
                        d0 = workingRouter.Ports[1].Distance;
                    }

                    wire.PointT = wire.Criterion + (d1 - d0);
                    wire.PointS = 0;
                }
                else // узел имеет одно инцидентное ребро
                {
                    wire.Replacement = null;
                    wire.PointT = 0;
                    wire.PointS = 0;
                }
            }
        }

        // обновление путей к узлу
        private void GetPrimaryTracks(Router router)
        {
            if (router.Used == false)
            {
                foreach (Port port in router.Ports)
                {
                    if (port.Router.Segment == router.Segment)
                    {
                        if ((port.Router.DistancePointer + port.Wire.Criterion == router.DistancePointer) &&
                            (port.Wire.BelongTree == true))
                        {
                            // исключаем ребро, по которому получили кратчайший маршрут
                            port.Distance = (int)router.DistancePointer;
                        }
                        else
                        {
                            // не пренадлежит дереву
                            if ((router.DistancePointer + port.Wire.Criterion == port.Router.DistancePointer) && (port.Wire.BelongTree == true))
                            {
                                if (port.Router.Ports.Count > 1)
                                {
                                    // не записан альтернативный путь
                                    if (port.Router.Ports[1].Distance == Const.INF)
                                    {
                                        GetPrimaryTracks(port.Router);
                                    }
                                    // записываем
                                    port.Distance = port.Router.Ports[1].Distance + port.Wire.Criterion;
                                }
                            }
                            else
                            {
                                port.Distance = (int)port.Router.DistancePointer + port.Wire.Criterion;
                            }
                        }

                        router.Ports = router.Ports.OrderBy(p => p.Distance).ToList();
                        router.Used = true;
                    }
                }
            }
        }

        // подготовительный этап
        public void Preparation(Segment segment)
        {
            foreach (Router router in segment.Routers)
            {
                if (router.DistancePointer > 0)
                {
                    // исходный список кратчайших путей 
                    foreach (Port port in router.Ports)
                    {
                        port.Distance = Const.INF;
                    }
                    router.Used = false;
                }
                else
                {
                    router.Used = true;
                }
            }

            foreach (Router router in segment.Routers)
            {
                if (router.DistancePointer > 0)
                {
                    // обновление путей к узлу
                    GetPrimaryTracks(router);
                }
            }

            // пересчет параметров ребер
            UpdateWires(segment);
            // закрашивание маршрутов
            Painting(segment);
        }
    }
}
