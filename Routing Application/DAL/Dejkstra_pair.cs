using Routing_Application.Domain;
using Routing_Application.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace Routing_Application.DAL
{
    /// <summary>
    /// класс, реализующий алгоритм Дейкстры
    /// </summary>
    public class Dejkstra_pair : Algorithm
    {
        // конструктор
        public Dejkstra_pair(Network network) : base(network)
        {
        }

        // основной метод
        public List<Wire> Parth(Router startRouter, Router endRouter)
        { 
            List<Wire> parth = new List<Wire>();
            Do_Dejkstra_pair(startRouter, endRouter);
            Router rt = endRouter;
            do
            {
                foreach (Port port in rt.Ports)
                {
                    // вычисление добавляемого ребра
                    if (port.Router.DistancePointer == rt.DistancePointer - port.Wire.Criterion)
                    {
                        // помечаем ребро как состоящее в множестве ребер дерева кратчайших путей
                        parth.Add(port.Wire);
                        rt = port.Router;
                        break;
                    }
                }
            }
            while (rt != startRouter);
            return parth;
        }
        public void Do_Dejkstra_pair(Router startRouter, Router endRouter)
        {
            // подготовка сегмента к проведению алгоритма
            Preparation(startRouter.Segment);

            // установки для исходного роутера
            startRouter.DistancePointer = 0;
            startRouter.Mark = Marks.Dejkstra;
            Router router = startRouter;

            for (int i = 0; i < startRouter.Segment.Routers.Count - 1; i++)
            {
                // присоединение очередной вершины к дереву кратчайших путей
                AddRouter(startRouter.Segment, ref router);
            }
            
           
        }

        // подготовительный метод
        private void Preparation(Segment segment)
        {
            foreach (Router router in segment.Routers)
            {
                // сброс статусной метки
                router.Mark = Marks.None;
                // установка пометки в бесконечность
                router.DistancePointer = Const.INF;
                // устаного флага посещения
                router.Used = false;
            }

            Pen pen = new Pen(Color.Gray, 1);
            foreach (Wire wire in segment.Wires)
            {
                // сброс цвета ребра
                wire.Pen = pen;
                wire.BelongTree = false;
            }
        }

        // добавление вершины в дерево кратчайших путей
        private void AddRouter(Segment segment, ref Router router)
        {
            foreach (Port port in router.Ports)
            {
                // обновление меток расстояния соседних с текущей вершин
                if ((port.Router.Segment == router.Segment) && (port.Router.Used == false) &&
                    (port.Router.DistancePointer > (router.DistancePointer + port.Wire.Criterion)))
                {
                    port.Router.DistancePointer = router.DistancePointer + port.Wire.Criterion;
                }
            }

            // пометить вершину как исследованную
            router.Used = true;

            // получить следующую вершину
            router = GetNextRouter(segment);
            // добавить ребро к дереву кратчайших путей
            AddEdge(router, segment.WireColor);
        }

        // получить следующий узел с минимальной пометкой
        private Router GetNextRouter(Segment segment)
        {
            double min = Const.INF;
            Router returnableRouter = null;
            foreach (Router router in segment.Routers)
            {
                // условия: пометка наименьшая, узел не посещен
                if ((router.DistancePointer < min) && (router.Used == false))
                {
                    min = router.DistancePointer;
                    returnableRouter = router;
                }
            }

            return returnableRouter;
        }

        // добавление ребра в дерево кратчайших путей
        private void AddEdge(Router router, Color color)
        {
            foreach (Port port in router.Ports)
            {
                // вычисление добавляемого ребра
                if (port.Router.DistancePointer == router.DistancePointer - port.Wire.Criterion)
                {
                    // помечаем ребро как состоящее в множестве ребер дерева кратчайших путей
                    port.Wire.Pen = new Pen(color, 4);
                    port.Wire.BelongTree = true;
                    break;
                }
            }
        }
    }
}
