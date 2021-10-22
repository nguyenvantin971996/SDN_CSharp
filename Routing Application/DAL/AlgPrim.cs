using Routing_Application.Domain;
using Routing_Application.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace Routing_Application.DAL
{
    public class AlgPrim : Algorithm
    {
        // конструктор 
        public AlgPrim(Network network) : base(network) 
        { 
        }

        // основной метод
        public void DoAlg(Router startRouter, bool toPaint)
        {
            // подготовка исходного графа
            Preparation(toPaint);

            // установки для исходного узла 
            startRouter.Mark = Marks.Prim;
            startRouter.Used = true;

            // получение минимального остова
            List<Wire> tree = GetTree(startRouter, 
                                      network.Routers.Count - 1, 
                                      new List<Router>() { startRouter });

            // окраска ребер
            if ((tree.Count > 0) && (toPaint == true))
            {
                Paint(tree);
            }
        }

        // получение минимального остова
        private List<Wire> GetTree(Router startRouter, int n, List<Router> viewingRouters)
        {
            // список ребер, которые вошли в минимальный остов
            List<Wire> tree = new List<Wire>();
            // узел и ребро, подсоединяемые к минимальному остову
            Port connectablePort = null;
            // узлы, к которым нельзя присоединить новые компоненты остова
            List<Router> deletedRouters = new List<Router>();

            // проход по всем узлам в списке
            for (int i = 0; i < n; i++)
            {
                // найти вершину для присоединения к минимальному остову
                connectablePort = FindNextPort(ref viewingRouters, ref deletedRouters);

                if (connectablePort != null)
                {
                    // добавить вершину и ребро к минимальному остову
                    ConnectPort(connectablePort, ref viewingRouters, ref tree);
                }

                if (deletedRouters.Count > 0)
                {
                    // исключить из рассмотрения вершины,
                    // к которым нельзя присоединить ни одной соседней
                    RemoveRouters(ref deletedRouters, ref viewingRouters);
                }
            }

            return tree;
        }

        // поиск вершины для присоединения к минимальному остову
        private Port FindNextPort(ref List<Router> viewingRouters, ref List<Router> deletedRouters)
        {
            double min = Const.INF;
            Port connectablePort = null;
            // просмотр ближайших к роуторам из сформированного остова роутеров
            foreach (Router router in viewingRouters)
            {
                bool trig = false;
                foreach (Port port in router.Ports)
                {
                    if (port.Router.Used == false)
                    {
                        trig = true;
                        if (port.Wire.Criterion < min)
                        {
                            min = port.Wire.Criterion;
                            connectablePort = port;
                        }
                    }
                }

                // если существует узел, окруженный уже вошедшими в остов соседями
                // то он помечается и удаляется из списка просматриваемых
                if (trig == false)
                {
                    deletedRouters.Add(router);
                }
            }

            return connectablePort;
        }

        // присоединение вершины и ребра к минимальному остову
        private void ConnectPort(Port connectablePort, ref List<Router> viewingRouters, ref List<Wire> tree)
        {
            // обновление списка просматриваемых узлов
            connectablePort.Router.Used = true;
            viewingRouters.Add(connectablePort.Router);
            CreateTPorts(connectablePort);
            tree.Add(connectablePort.Wire);
        }

        // исключение из рассмотрения вершин,
        // к которым нельзя присоединить ни одной соседней
        private void RemoveRouters(ref List<Router> deletedRouters, ref List<Router> viewingRouters)
        {
            // удаление узлов, к которым нельзя присоединить новые компоненты остова
            foreach (Router router in deletedRouters)
            {
                viewingRouters.Remove(router);
            }

            deletedRouters.Clear();
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
                router.Mark = Marks.None;
                router.Used = false;
                router.TPorts.Clear();
            }
        }
        // окраска ребер
        private void Paint(List<Wire> wiresForPainting)
        {
            Pen pen = new Pen(Color.Black, 4);
            foreach (Wire wire in wiresForPainting)
            {
                wire.Pen = pen;
            }
        }
        // зоздание портов, входящих в минимальный остов
        private void CreateTPorts(Port connectablePort)
        {
            // поиск портов, которые вошли в минимальный остов
            connectablePort.Wire.StartRouter.TPorts.Add(connectablePort.Wire.StartPort);
            connectablePort.Wire.EndRouter.TPorts.Add(connectablePort.Wire.EndPort);
        }
    }
}
