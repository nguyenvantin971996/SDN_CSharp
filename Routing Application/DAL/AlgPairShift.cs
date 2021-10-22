using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Application.DAL
{
    public class AlgPairShift : Algorithm
    {
        // список, хранящий информацию о произошедших парных перестановках
        private List<string> pairShiftesSet;

        // конструктор 
        public AlgPairShift(Network network) : base(network)
        {
            pairShiftesSet = new List<string>();
        }

        // основной метод
        public List<string> DoAlg(Segment segment)
        {
            pairShiftesSet.Clear();
            Preparation(segment);

            while (UpdateStaticInfo(segment.Routers) == 1)
            {
            }

            // сортировка узлов по удалению от корня дерева кратчайших путей
            segment.Routers = segment.Routers.OrderBy(r => r.DistancePointer).ToList();
            // пересчет параметров ребер
            UpdateWires(segment);
            // закрашивание маршрутов
            Painting(segment);

            //pairShiftesSet.Clear();
            // DEL
            //foreach (Router r in segment.Routers)
            //{
            //    pairShiftesSet.Add("Router " + r.Number + " " + r.DistancePointer);
            //    foreach (Port p in r.Ports)
            //    {
            //        pairShiftesSet.Add("port " + p.Wire.Criterion);
            //        foreach (Port track in p.Tracks)
            //        {
            //            pairShiftesSet.Add(track.Wire.Criterion.ToString());
            //        }
            //    }
            //}
            // DEL
            return pairShiftesSet;
        }

        // подключение нового маршрута
        private void ActivateRout(List<Port> rout)
        {
            foreach (Port port in rout)
            {
                //port.OppositePort.Distance = (int)port.Owner.DistancePointer + port.Wire.Criterion;
                port.Router.DistancePointer = (int)port.Owner.DistancePointer + port.Wire.Criterion;
                //port.OppositePort.Tracks.Clear();
                //port.OppositePort.Tracks.AddRange(port.Owner.ShortTrack);
                //port.OppositePort.Tracks.Add(port);

                //port.Router.Ports = port.Router.Ports.OrderBy(p => p.Distance).ToList();
            }
        }

        // обновление расстояния до узла 
        private int UpdateTrack(Port port, int portDistance, List<Port> track)
        {
            int oldIndex = port.Router.Ports.IndexOf(port.OppositePort);

            /* обновление информации о метрике маршрута */
            port.Router.Ports[oldIndex].Distance = portDistance;
            port.Router.Ports[oldIndex].Tracks.Clear();
            port.Router.Ports[oldIndex].Tracks.AddRange(track);
            port.Router.Ports[oldIndex].Tracks.Add(port);

            port.Router.Ports = port.Router.Ports.OrderBy(p => p.Distance).ToList();
            port.Router.DistancePointer = port.Router.Ports[0].Distance;
            port.Router.ShortTrack.Clear();
            port.Router.ShortTrack.AddRange(port.Router.Ports[0].Tracks);

            int curIndex = port.Router.Ports.IndexOf(port.OppositePort);

            if ((port.Router.Ports.Count >= 2) && (port.Router.Ports[0].Distance != port.Router.Ports[1].Distance))
            {
                // если ребро перешло из множества замены во множество ребер дерева
                if ((curIndex == 0) && oldIndex > 0)
                {
                    // обработать парную перестановку маршрутов
                    PairShift(port, port.Router.Ports[1]);
                    return 1;
                }

                // если ребро перешло из множества ребер дерева во множество ребер замены
                if ((curIndex > 0) && oldIndex == 0)
                {
                    // обработать парную перестановку маршрутов
                    PairShift(port, port.Router.Ports[0]);
                    return 1;
                }
            }

            return 0;
        }

        // осуществление парного перехода
        private void PairShift(Port port, Port replacement)
        {
            if (replacement.Router.DistancePointer > 0)
            {
                int index = replacement.Router.Ports.IndexOf(replacement.OppositePort);
                // переключить канал связи
                replacement.Router.Ports[index].Distance = (int)port.Router.DistancePointer + replacement.Wire.Criterion;
                replacement.Router.Ports[index].Tracks.Clear();
                replacement.Router.Ports[index].Tracks.AddRange(port.Router.ShortTrack);
                replacement.Router.Ports[index].Tracks.Add(replacement);

                ActivateRout(port.Router.ShortTrack);
            }

            // вернуть информацию о произошедшей парной перестановке
            pairShiftesSet.Add(string.Format("Edge R{0}-R{1} shift R{2}-R{3}",
                                          replacement.Owner.Number,
                                          replacement.Router.Number,
                                          port.Wire.StartRouter.Number,
                                          port.Wire.EndRouter.Number));
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
                    if ((port.Router.DistancePointer > 0) && (port.Router.Segment == router.Segment))
                    {
                        int result = 0;

                        // условие: в соседний узел можно попасть из текущего
                        if ((int)router.DistancePointer - port.Wire.Criterion == port.Router.DistancePointer)
                        {
                            if (router.Ports.Count > 1)
                            {
                                // обновить расстояние от текущего узла до рассматриваемого соседа
                                result = UpdateTrack(port, (int)router.Ports[1].Distance + port.Wire.Criterion, router.Ports[1].Tracks);
                            }
                        }
                        else
                        {
                            // обновить расстояние от текущего узла до рассматриваемого соседа
                            result = UpdateTrack(port, (int)router.DistancePointer + port.Wire.Criterion, router.ShortTrack);
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

        // обновление маршрутов к узлу
        private void GetPrimaryRouts(Router router)
        {
            // если узел исследован
            if (router.Used == false)
            {
                foreach (Port port in router.Ports)
                {
                    // если узлы находятся в одном сегменте 
                    if (port.Router.Segment == router.Segment)
                    {
                        // если через ребро проходит оптимальный маршрут и трафик входит в узел
                        if ((port.Router.DistancePointer + port.Wire.Criterion == router.DistancePointer) &&
                            (port.Wire.BelongTree == true))
                        {
                            // обновление пометки маршрута
                            port.Distance = (int)router.DistancePointer;
                            // обновление маршрута
                            port.Tracks.AddRange(router.ShortTrack);

                        }
                        else
                        {
                            // если через ребро проходит оптимальный маршрут и трафик выходит из узла
                            if ((router.DistancePointer + port.Wire.Criterion == port.Router.DistancePointer) &&
                                (port.Wire.BelongTree == true))
                            {
                                if (port.Router.Ports.Count > 1)
                                {
                                    // если не записан альтернативный путь
                                    if (port.Router.Ports[1].Distance == Const.INF)
                                    {
                                        // обновить альтернативные пути
                                        GetPrimaryRouts(port.Router);
                                    }
                                    // обновление пометки маршрута
                                    port.Distance = port.Router.Ports[1].Distance + port.Wire.Criterion;

                                    // обновление маршрута
                                    port.Tracks.AddRange(port.Router.Ports[1].Tracks);
                                    port.Tracks.Add(port.OppositePort);
                                }
                            }
                            else // иначе ребро находится во множестве замены
                            {
                                // обновление пометки маршрута
                                port.Distance = (int)port.Router.DistancePointer + port.Wire.Criterion;

                                // обновление маршрута
                                port.Tracks.AddRange(port.Router.ShortTrack);
                                port.Tracks.Add(port.OppositePort);
                            }
                        }

                        // сортировка маршрутов по возрастанию пометок
                        router.Ports = router.Ports.OrderBy(p => p.Distance).ToList();
                        // пометить узел как исследованный
                        router.Used = true;
                    }
                }
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

                    // расчет точки вхождения в дерево
                    wire.PointT = wire.Criterion + (d1 - d0);
                    // расчет точки вхождения во множество замены
                    wire.PointS = wire.Criterion + (d2 - d0);
                }
                //  узел имеет два инцидентных ребра
                else if (workingRouter.Ports.Count == 2)
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
                        port.Tracks.Clear();
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
                    GetPrimaryRouts(router);
                }
            }

            // пересчет параметров ребер
            UpdateWires(segment);
            // закрашивание маршрутов
            Painting(segment);
        }
    }
}
