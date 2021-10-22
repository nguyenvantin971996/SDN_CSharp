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
    /// <summary>
    /// Класс, реализующий алгоритм поиска
    /// оптимального маршрута между узлами связи
    /// </summary>
    public class AlgOptimalRout : Algorithm
    {
        // конструктор
        public AlgOptimalRout(Network network) : base(network)
        {
        }

        // основной метод
        public int DoAlg(Router startRouter, Router endRouter)
        {
            // подготовка сети к вычислениям
            Preparation();

            /* присвоить узлу-источнику и узлу-получателю статусные метки */
            startRouter.Mark = Marks.Rout;
            endRouter.Mark = Marks.Rout;

            // если узел-источник и узел-получатель находятся в одном сегменте
            if (startRouter.Segment == endRouter.Segment)
            {
                // проложить маршрут в сегменте
                GetSegmentRout(startRouter, endRouter);
                // вернуть трудоемкость
                return (startRouter.Segment.Routers.Count * endRouter.Segment.Routers.Count);
            }

            // если узел-источник и узел-получатель находятся в разных сегментах
            // проложить межсегментный маршрут
            List<Router> shortRout = GetIntersegmentalRout(startRouter.Segment, endRouter.Segment);

            // добавить узел-получатель в маршрут
            if (shortRout.Contains(endRouter) == false)
            {
                shortRout.Insert(0, endRouter);
            }

            // добавить узел-источник в маршрут
            if (shortRout.Contains(startRouter) == false)
            {
                shortRout.Add(startRouter);
            }

            // рассчитать трудоемкость
            // и построить маршруты внутри сегментов
            return GetLaboriousness(shortRout);
        }


        // построение маршрута внутри сегмента
        private void GetSegmentRout(Router startRouter, Router endRouter)
        {
            // первичная настройка узлов
            PreparationRouters(startRouter.Segment.Routers);

            // исходные установки для начального узла
            startRouter.DistancePointer = 0;
            Router router = startRouter;

            // пока не рассчитан маршрут до заданного узла ...
            while (router != endRouter)
            {
                // добавить новый узел в дерево кратчайших путей
                AddRouter(ref router, startRouter.Segment.Routers);
            }

            // прокладка пути между узлами
            Router currentRouter = endRouter;
            Pen pen = new Pen(Color.Red, 4);

            // пока не построен маршрут в сегменте ...
            while (currentRouter != startRouter)
            {
                // добавить ребро в маршрут
                AddEdge(ref currentRouter, startRouter.Segment, pen);
            }
        }

        #region GetSegmentRoutAuxiliary

        // исходные установки для узлов
        private void PreparationRouters(List<Router> routers)
        {
            foreach (Router router in routers)
            {
                // установка исходных данных 
                router.DistancePointer = Const.INF;
                router.Used = false;
            }
        }

        // получить следующий узел для исследования
        private Router GetNextRouter(List<Router> routers)
        {
            double min = Const.INF;
            Router returnableRouter = null;

            foreach (Router router in routers)
            {
                // условия выбора следующего узла:
                // узел имеет минимальную пометку и неисследован
                if ((router.DistancePointer < min) && (router.Used == false))
                {
                    min = router.DistancePointer;
                    returnableRouter = router;
                }
            }

            return returnableRouter;
        }

        // добавление узла в маршрут
        private void AddRouter(ref Router router, List<Router> routers)
        {
            foreach (Port port in router.Ports)
            {
                // обновление меток расстояния узлов
                if ((port.Router.DistancePointer > (router.DistancePointer + port.Wire.Criterion)) &&
                    (port.Router.Used == false) && (port.Router.Segment == router.Segment))
                {
                    port.Router.DistancePointer = router.DistancePointer + port.Wire.Criterion;
                }
            }

            router.Used = true;
            // получить следующий узел для исследования
            router = GetNextRouter(routers);
        }

        // добавление ребра в дерево кратчайших путей
        private void AddEdge(ref Router router, Segment segment, Pen pen)
        {
            foreach (Port port in router.Ports)
            {                
                // обновление меток расстояния соседних с текущей вершин
                if ((port.Router.DistancePointer == (router.DistancePointer - port.Wire.Criterion)) &&
                    (port.Router.Segment == segment))
                {
                    router = port.Router;
                    port.Wire.Pen = pen;
                    break;
                }
            }
        }

        #endregion

        // получение списка вершин, составляющих путь между двумя исходными вершинами
        private List<Router> GetIntersegmentalRout(Segment startSegment, Segment endSegment)
        {
            // исходные установки для сегментов
            PreparationSegments();

            // исходные установки для сегмента-источника
            startSegment.DistancePointer = 0;
            Segment segment = startSegment;

            // пока не постороен маршрут до сегмента-получателя
            while (segment != endSegment)
            {
                // добавить в маршрут новый сегмент
                AddSegment(ref segment);
            }

            // формирование маршрута между сегментами
            List<Router> shortPath = new List<Router>();
            Segment currentSegment = endSegment;
            Pen pen = new Pen(Color.Red, 4);

            // пока не пройден межсегментный маршрут ...
            while (currentSegment != startSegment)
            {
                // присоединить пограничные узелы к оптимальному маршруту
                AddGateways(ref currentSegment, ref shortPath, pen);
            }
            return shortPath;
        }

        // вспомогательные методы для GetIntersegmentalRout
        #region GetIntersegmentalRoutAuxiliary

        // исходные установки для сегментов
        private void PreparationSegments()
        {
            foreach (Segment seg in network.Segments)
            {
                // обновить информацию о сегменте
                seg.UpdateStructure();
                // установить пометку 'бесконечность'
                seg.DistancePointer = Const.INF;
                // пометить сегмент как не исследуемый
                seg.Used = false;
            }
        }

        // получить следующий сегмент для исследования
        private Segment GetNextSegment()
        {
            double min = Const.INF;
            Segment returnableSegment = null;
            foreach (Segment segment in network.Segments)
            {
                // условия поиска сегмента:
                // минимальная метка и неисследован
                if ((segment.DistancePointer < min) && (segment.Used == false))
                {
                    min = segment.DistancePointer;
                    returnableSegment = segment;
                }
            }

            return returnableSegment;
        }

        // присоединить сегмент к дереву кратчайших путей между сегментами
        private void AddSegment(ref Segment segment)
        {
            foreach (Port port in segment.Gateways)
            {
                // обновление меток соседних сегментов
                if ((port.Router.Segment.DistancePointer > (segment.DistancePointer + port.Wire.Criterion)) &&
                    (port.Router.Segment.Used == false))
                {
                    port.Router.Segment.DistancePointer = segment.DistancePointer + port.Wire.Criterion;
                }
            }

            // пометить сегмент как исследованный
            segment.Used = true;
            segment = GetNextSegment();
        }

        // присоединить пограничные узелы к оптимальному маршруту
        private void AddGateways(ref Segment segment, ref List<Router> shortPath, Pen pen)
        {
            foreach (Port port in segment.Gateways)
            {
                // если сегмент является частью маршрута, идущего от сегмента-получателя ...
                if (port.Router.Segment.DistancePointer == segment.DistancePointer - port.Wire.Criterion)
                {
                    // добавление к оптимальному маршруту узлов
                    // инцидентных межсегментному ребру
                    if (port.Router == port.Wire.StartRouter)
                    {
                        shortPath.Add(port.Wire.EndRouter);
                        shortPath.Add(port.Wire.StartRouter);
                    }
                    else
                    {
                        shortPath.Add(port.Wire.StartRouter);
                        shortPath.Add(port.Wire.EndRouter);
                    }

                    // присвоить рассматриваемому сегменту вновь присоединенный
                    segment = port.Router.Segment;
                    // пометить ребро как часть маршрута
                    port.Wire.Pen = pen;
                    break;
                }
            }
        }

        #endregion

        // подготовка сети к вычислениям
        private void Preparation()
        {
            Pen pen = new Pen(Color.Gray, 1);
            // сброс цветов каналов
            foreach (Wire wire in network.Wires)
            {
                wire.Pen = pen;
            }

            // сброс статусных меток узлов
            foreach (Router router in network.Routers)
            {
                router.Mark = Marks.None;
            }
        }

        // расчет трудоемкости алгоритма и достроение оптимального маршрута 
        // внутри сегментов
        private int GetLaboriousness(List<Router> shortRout)
        {
            int laboriousness = 0;
            for (int i = 0; i < shortRout.Count - 1; i++)
            {
                // если пограничные узлы находятся в одном сегменте ...
                if (shortRout[i].Segment == shortRout[i + 1].Segment)
                {
                    // построить оптимальный маршрут между ними
                    GetSegmentRout(shortRout[i], shortRout[i + 1]);
                    // обновить хначение трудоемкости
                    laboriousness += (shortRout[i].Segment.Routers.Count * shortRout[i].Segment.Routers.Count);
                }
            }

            // вернуть значение трудоемкости с учетом рассчета межсегментных маршрутов
            return (laboriousness + ((network.Segments.Count - 1) * (network.Segments.Count - 1)));
        }

    }


}
