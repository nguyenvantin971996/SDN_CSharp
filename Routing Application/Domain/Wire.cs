using Routing_Application.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Routing_Application.DAL;
using Routing_Application.Enums;

namespace Routing_Application.Domain
{
    /// <summary>
    /// класс Канал связи
    /// </summary>
    [Serializable()]
    public class Wire
    {
        /*  графическая часть  */
        private Point center;           // центер отрезка между роутерами
        private Point floatingPoint;    // "плавающий" узел - третий узел кривой канала, не привязанный к роутерам

        private int centerOffsetX;      // смещение "плавающего" узла по Х
        private int centerOffsetY;      // смещение "плавающего" узла по Y

        private string text;            // надпись
        private Size textSize;          // размер надписи

        [field: NonSerialized()]
        private Pen pen;                // перо канала

        /*  логическая часть  */
        private Segment segment;        // сегмент

        private int pointT;             // точка вхождения в дерево
        private int pointS;             // точка вхождения во множество замены

        private bool belongTree;        // принадлежность к дереву
        private Port replacement;       // порт замены

        private Router startRouter;     // метка первого конечного роутера
        private Router endRouter;       // метка второго конечного роутера

        private Port startPort;         // порт, частью которых является ребро
        private Port endPort;           // порт, частью которых является ребро

        private int delay = 1;          // задержка канала
        private int load = 1;           // цена канала
        private double capacity = 1;    // пропускная способность канала
        private int metric = 1;         // метрика
        private int numberRepeat = 0;
        private int criterion;          // критерий, используемый при рассчетах
        private double pheromone;
        private double probability;
        // открытые свойства
        #region Properties

        public bool BelongTree
        {
            get { return belongTree; }
            set { belongTree = value; }
        }
        public double Pheromone
        {
            get { return pheromone; }
            set { pheromone = value; }
        }
        public double Probability
        {
            get { return probability; }
            set { probability = value; }
        }
        public Segment Segment
        {
            get { return segment; }
            set { segment = value; }
        }

        public Port Replacement
        {
            get { return replacement; }
            set { replacement = value; }
        }

        public Port EndPort
        {
            get { return endPort; }
            set { endPort = value; }
        }

        public Port StartPort
        {
            get { return startPort; }
            set { startPort = value; }
        }

        public Router StartRouter
        {
            get { return startRouter; }
            set { startRouter = value; }
        }

        public Router EndRouter
        {
            get { return endRouter; }
            set { endRouter = value; }
        }

        public int PointT
        {
            get { return pointT; }
            set { pointT = value; }
        }

        public int PointS
        {
            get { return pointS; }
            set { pointS = value; }
        }

        public Point Center
        {
            get { return center; }
            set { center = value; }
        }

        public Point FloatingCenter
        {
            get { return floatingPoint; }
            set { floatingPoint = value; }
        }

        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        public int Load
        {
            get { return load; }
            set { load = value; }
        }

        public int Metric
        {
            get { return metric; }
            set { metric = value; }
        }
        public int NumberRepeat
        {
            get { return numberRepeat; }
            set { numberRepeat = value; }
        }

        public double Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Criterion
        {
            get { return criterion; }
            set { criterion = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Size TextSize
        {
            get { return textSize; }
            set { textSize = value; }
        }

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }

        #endregion

        /* конструкторы */
        public Wire()
        {
        }
 
        public Wire(Router startRouter, Router endRouter)
        {
            this.startRouter = startRouter;
            startRouter.Wires.Add(this);
            startPort = new Port(this, endRouter, startRouter);
            startRouter.Ports.Add(startPort);

            this.endRouter = endRouter;
            endRouter.Wires.Add(this);
            endPort = new Port(this, startRouter, endRouter);
            endRouter.Ports.Add(endPort);

            startPort.OppositePort = endPort;
            endPort.OppositePort = startPort;

            if (startRouter.Segment.Number == endRouter.Segment.Number)
            {
                segment = startRouter.Segment;
                segment.Wires.Add(this);
            }

            UpdateCenter();             
            floatingPoint = center;      
            criterion = metric;
            this.pen = new Pen(Color.Gray, 1);
        }

        // основные методы
        #region MainMethods

        // пересчитать центер
        public void UpdateCenter()
        {
            int x1 = startRouter.Location.X;    
            int x2 = endRouter.Location.X;
            int y1 = startRouter.Location.Y;
            int y2 = endRouter.Location.Y;

            center = new Point((x2 + x1) / 2, (y2 + y1) / 2);
            floatingPoint = new Point(center.X - centerOffsetX, center.Y - centerOffsetY);
        }

        // not used now !!!
        public void Straighten()
        {
            floatingPoint = center;
        }

        // пересчитать смещения "плавающего" узла относительно центра
        public void UpdateOffsets()
        {
            centerOffsetX = center.X - floatingPoint.X;
            centerOffsetY = center.Y - floatingPoint.Y;
        }

        // обновить надпись
        public void UpdateInfo(Criterias currentCriterion)
        {
            Font font = new Font("Arial", 10);

            switch (currentCriterion)
            {
                case Criterias.Delay:
                    text = String.Format("{0}ms", delay);
                    criterion = delay;
                    break;

                case Criterias.Load:
                    if (load == 0)
                    {
                        text = String.Format("{0}", load);
                        criterion = load;
                        break;
                    }
                    else
                    {
                        text = String.Format("{0}Mb", load);
                        criterion = load;
                        break;
                    }

                case Criterias.Capacity:
                    text = String.Format("{0}Mbit/s", capacity);
                    criterion = (int)((1 / capacity) * 100000);
                    break;

                case Criterias.Metric:
                    text = String.Format("{0}", metric);
                    criterion = metric;
                    break;
            }

            textSize = TextRenderer.MeasureText(text, font);
        }

        public void UpdateCriterion(Criterias currentCriterion, int count)
        {
            switch (currentCriterion)
            {
                case Criterias.Delay:
                    criterion = delay = count;
                    break;

                case Criterias.Load:
                    criterion = load = count;
                    break;

                case Criterias.Capacity:
                    capacity = count;
                    criterion = (int)((1 / capacity) * 100000);
                    break;

                case Criterias.Metric:
                    criterion = metric = count;
                    break;
            }
        }
        #endregion

        // вспомогательные методы
        #region AuxiliaryMethods


        #endregion
    }
}
