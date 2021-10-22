using Routing_Application.Domain;
using Routing_Application.Enums;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace Routing_Application.DAL
{
    public class AlgYen : Algorithm
    {
        private List<List<Wire>> YenW;
        private double minDist;
        Random randColor;

        /* Конструктор */
        public AlgYen(Network network) : base(network)
        {
            this.YenW = new List<List<Wire>>();
            this.minDist = 0;
            this.randColor = new Random();
        }

        // алгоритм Йена
        public void Do(Router startRouter, Router endRouter)
        {
            Pen pen = new Pen(Color.Gray, 1);
            // сброс цветов каналов
            foreach (Wire wire in network.Wires)
            {
                wire.Pen = pen;
            }
            if (endRouter.Ports.Count < startRouter.Ports.Count)
            {
                Router temp = endRouter;
                endRouter = startRouter;
                startRouter = temp;
            }
            for (int i = 0; i < endRouter.Ports.Count; i++)
            {
                ShortP(startRouter, endRouter);

                if (i == 0)
                {
                    minDist = Math.Max(YenW[i][YenW[i].Count - 1].StartRouter.DistancePointer, YenW[i][YenW[i].Count - 1].EndRouter.DistancePointer);
                }
            }

            for (int j = 0; j < YenW.Count; j++)
            {
                Pen pathPen = new Pen(CreateRandomColor(), 4);
                foreach (Wire wire in YenW[j])
                {
                    wire.Pen = pathPen;
                }
            }

        }

        #region Yen: Main
        // алгоритм вычисления кратчайшего пути между двумя вершинами
        private int ShortP(Router startRouter, Router endRouter)
        {
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

        #region Yen: Aux
        // прокладка пути между двумя вершинами: алгоритм вычисления кратчайшего пути
        private void GetPath(Router startRouter, Router endRouter)
        {
            foreach (Router rout in startRouter.Segment.Routers)
            {
                // установка исходных данных 
                rout.DistancePointer = Const.INF;
                rout.Used = false;
            }
            startRouter.DistancePointer = 0;
            Router router = startRouter;
            bool exist;
            while (router != endRouter)
            {
                foreach (Port port in router.Ports)
                {
                    exist = false;
                    if (YenW.Count > 0)
                        foreach (List<Wire> y in YenW)
                            foreach (Wire w in y)
                                if (port.Wire == w)
                                {
                                    exist = true;
                                    break;
                                }
                    if (exist == false)
                    {
                        // обновление меток расстояния роутеров
                        if ((port.Router.DistancePointer > (router.DistancePointer + port.Wire.Criterion)) &&
                            (port.Router.Used == false) && (port.Router.Segment.Number == router.Segment.Number))
                        {
                            port.Router.DistancePointer = router.DistancePointer + port.Wire.Criterion;
                        }
                    }
                }

                router.Used = true;
                Router routerCurrent = router;
                double min = Const.INF;
                foreach (Router r in router.Segment.Routers)
                {
                    if ((r.DistancePointer < min) && (r.Used == false))
                    {
                        min = r.DistancePointer;
                        router = r;
                    }
                }
                if (routerCurrent == router)
                {
                    minDist = -1;
                    break;
                }
            }

            // прокладка пути между роутерами
            if (minDist > 0 && minDist != endRouter.DistancePointer || minDist == -1) return;
            List<Wire> shortW = new List<Wire>();
            Router pathRouter = endRouter;
            while (pathRouter != startRouter)
            {
                foreach (Port port in pathRouter.Ports)
                {
                    exist = false;
                    if (YenW.Count == 0)
                    {
                        if ((port.Router.DistancePointer == (pathRouter.DistancePointer - port.Wire.Criterion)) &&
                            (port.Router.Segment.Number == startRouter.Segment.Number))
                        {
                            shortW.Add(port.Wire);
                            pathRouter = port.Router;
                            break;
                        }
                    }
                    else
                    {
                        if (YenW.Count > 0)
                            foreach (List<Wire> y in YenW)
                                foreach (Wire w in y)
                                    if (port.Wire == w) { exist = true; break; }
                        if ((exist == false) && (port.Router.DistancePointer == (pathRouter.DistancePointer - port.Wire.Criterion)) &&
                            (port.Router.Segment.Number == startRouter.Segment.Number))
                        {
                            shortW.Add(port.Wire);
                            pathRouter = port.Router;
                            break;
                        }

                    }
                }
            }
            shortW.Sort(delegate(Wire x, Wire y)
                {
                    return Math.Max(x.StartRouter.DistancePointer, x.EndRouter.DistancePointer)
                      .CompareTo(Math.Max(y.StartRouter.DistancePointer, y.EndRouter.DistancePointer));
                });
            YenW.Add(shortW);
        }

        private Color CreateRandomColor()
        {
            Color randomColor = Color.FromArgb(randColor.Next(255), randColor.Next(255), randColor.Next(255));
            foreach (Wire w in network.Wires)
            {
                if (w.Pen.Color == randomColor)
                    CreateRandomColor();
            }
            return randomColor;
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
