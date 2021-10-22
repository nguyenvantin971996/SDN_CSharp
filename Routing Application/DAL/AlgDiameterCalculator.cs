using Routing_Application.Domain;
using System.Collections.Generic;

namespace Routing_Application.DAL
{
    /// <summary>
    /// класс, реализующий алгоритм вычисления диаметра графа
    /// </summary>
    public class AlgDiameterCalculator : Algorithm
    {
        // конструктор
        public AlgDiameterCalculator(Network network) : base(network)
        {
        }

        // алгоритм вычисления диаметра графа
        public int DoAlg(List<Router> routers)
        {
            int[] diameters = new int[routers.Count];
            int iteration = 0;

            foreach (Router startRouter in routers)
            {
                FindDiameter(routers, startRouter, ref iteration, diameters);
            }

            // вернуть максимальный диаметр
            return GetMaxDiametr(diameters);
        }

        // вычисление диаметра графа по начальной вершине
        private void FindDiameter(List<Router> routers, Router startRouter, ref int iteration, int[] diameters)
        {
            // подготовка вершин графа
            Preparation(routers);
            // установки для исходного узла
            startRouter.DistancePointer = 0;
            Router router = startRouter;

            for (int i = 0; i < routers.Count; i++)
            {
                // обновить метки соседних узлов
                UpdateMarks(router);
                // пометить узел как исследованный
                router.Used = true;
                // получить следующий узел
                router = GetNextRouter(routers);
            }

            // добавить элемент в массив максимальных диаметров 
            diameters[iteration] = GetMaxMark(routers);
            iteration += 1;
        }

        // поиск максимального диаметра
        private int GetMaxDiametr(int[] diametres)
        {
            int maxDiametr = 0;
            for (int i = 0; i < diametres.Length; i++)
            {
                if (diametres[i] > maxDiametr)
                {
                    maxDiametr = diametres[i];
                }
            }

            return maxDiametr;
        }

        // подготовка узлов связи
        private void Preparation(List<Router> routers)
        {
            foreach (Router r in routers)
            {
                // установка исходных данных 
                r.DistancePointer = Const.INF;
                r.Used = false;
            }
        }

        // получить следующий узел 
        private Router GetNextRouter(List<Router> routers)
        {
            double min = Const.INF;
            Router returnableRouter = null;

            foreach (Router router in routers)
            {
                // поиск следующего роутера 
                if ((router.DistancePointer < min) && (router.Used == false))
                {
                    min = router.DistancePointer;
                    returnableRouter = router;
                }
            }

            return returnableRouter;
        }

        // обновление пометок соседнихх узлов
        private void UpdateMarks(Router router)
        {
            foreach (Port port in router.Ports)
            {
                // обновление меток расстояния узлов
                if ((port.Router.Used == false) &&
                    (port.Router.DistancePointer > (router.DistancePointer + 1)))
                {
                    port.Router.DistancePointer = router.DistancePointer + 1;
                }
            }
        }

        // получить максимальную пометку
        private int GetMaxMark(List<Router> routers)
        {
            int maxMark = 0;
            foreach (Router r in routers)
            {
                if (r.DistancePointer > maxMark)
                {
                    maxMark = (int)r.DistancePointer;
                }
            }

            return maxMark;
        }
    }
}
