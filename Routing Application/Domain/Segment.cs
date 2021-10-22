using Routing_Application.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Routing_Application.Domain
{
    /// <summary>
    /// класс Сегмент сети
    /// </summary>
    [Serializable()]
    public class Segment
    {
        private List<Router> routers;       // список роутеров в сегменте
        private List<Port> gateways;        // шлюзы
        private List<Port> tGateways;       // шлюзы минимального остова
        private int distancePointer;        // числовая метка
        private bool used;                  // логическая метка
        private int number;                 // уникальный номер сегмента
        private Color color;                // цвет канала для дерева кратчайших путей
        private double q;                   // величина связанности сегмента
        private double m_in = 0;            // количество внутренних каналов
        private double m_out = 0;           // количество внешних связей
        private List<Wire> wires;

        private List<string> pairSwitches;
        private List<int> chartInfo;

        private int connectAmount = 0;
         
        // открытые свойства
        #region Properties

        public List<int> ChartInfo
        {
            get { return chartInfo; }
            set { chartInfo = value; }
        }

        public List<Wire> Wires
        {
            get { return wires; }
            set { wires = value; }
        }

        public List<string> PairSwitches
        {
            get { return pairSwitches; }
            set { pairSwitches = value; }
        }  

        public List<Router> Routers
        {
            get { return routers; }
            set { routers = value; }
        }

        public List<Port> Gateways
        {
            get { return gateways; }
        }

        public List<Port> TGateways
        {
            get { return tGateways; }
        }

        public bool Used
        {
            get { return used; }
            set { used = value; }
        }

        public int DistancePointer
        {
            get { return distancePointer; }
            set { distancePointer = value; }
        }

        public int ConnectAmount
        {
            get { return connectAmount; }
            set { connectAmount = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public Color WireColor
        {
            get { return color; }
            set { color = value; }
        }

        public double Q
        {
            get { return q; }
        }

        public double M_in
        {
            get { return m_in; }
        }

        public double M_out
        {
            get { return m_out; }
        }

        #endregion

        /* конструкторы сегмента */
        public Segment()   
        {
            routers = new List<Router>();
            gateways = new List<Port>();
            tGateways = new List<Port>();
            wires = new List<Wire>();
            pairSwitches = new List<string>();
            chartInfo = new List<int>();
            number = 0;
            color = Color.Red;
        }

        public Segment(Router router, int num)  
        {
            routers = new List<Router>();
            gateways = new List<Port>();
            tGateways = new List<Port>();
            wires = new List<Wire>();
            pairSwitches = new List<string>();
            chartInfo = new List<int>();
            routers.Add(router);
            number = num;
            color = Color.Red;
        }

        public Segment(Router router1, Router router2, int num)   
        {
            routers = new List<Router>();
            gateways = new List<Port>();
            tGateways = new List<Port>();
            wires = new List<Wire>();
            pairSwitches = new List<string>();
            chartInfo = new List<int>();
            routers.Add(router1);
            routers.Add(router2);
            number = num;
            color = Color.Red;
        }

        // собственные методы
        #region MainMethods

        // перепреоделение конвертации в строку
        public override string ToString()
        {
            return String.Format("Segment: {0}", number);
        }

        // возвращает количество связей роутера и текущего сегмента
        public int GetConnectedWiresCount(Router router)
        {
            int count = 0;
            foreach (Port port in router.Ports)
            {
                if (port.Router.Segment.number == number)
                {
                    count += 1;
                }
            }
            return count;
        }

        public int GetInternalConnectivity()
        {
            List<Wire> wires = new List<Wire>();
            foreach (Router router in routers)
            {
                foreach (Wire wire in router.Wires)
                {
                    if ((wire.StartRouter.Segment.Number == wire.EndRouter.Segment.Number) 
                     && (wires.Contains(wire) == false))
                    {
                        wires.Add(wire);
                    }
                }
            }

            int sumConnectivity = 0;
            foreach (Wire wire in wires)
            {
                sumConnectivity += wire.Criterion;
            }

            return sumConnectivity;
        }

        // возвращает минимальный вес дуги, связывающей текущий
        // сегмент с роутером <router>
        public int MinConnectivity(Router router)
        {
            int min = Const.INF;
            foreach (Port port in router.TPorts)
            {
                if ((port.Router.Segment.Number == Number) && (port.Wire.Criterion < min))
                {
                    min = port.Wire.Criterion;
                }
            }

            return min;
        }

        // возвращает минимальный вес дуги, связывающей текущий
        // сегмент с сегментом segment
        public int MinConnectivity(Segment segment)
        {
            int min = Const.INF;
            foreach (Port port in segment.TGateways)
            {
                if ((port.Router.Segment.Number == Number) && (port.Wire.Criterion < min))
                {
                    min = port.Wire.Criterion;
                }
            }

            return min;
        }

        // обновление величины связанности
        public void UpdateStructure()
        {
            m_in = 0;
            m_out = 0;
            List<Wire> wires = new List<Wire>();

            foreach (Router router in routers)
            {
                foreach (Port port in router.Ports)
                {
                    if (port.Router.Segment.Number == this.number)
                    {
                        if (wires.Contains(port.Wire) == false)
                        {
                            wires.Add(port.Wire);
                            m_in += 1;
                        }
                    }
                    else
                    {
                        gateways.Add(port);
                        if (router.TPorts.Contains(port) == true)
                        {
                            tGateways.Add(port);
                        }
                        m_out += 1;
                    }
                }
            }
            q = m_in / m_out;
        }

        // окрашивание роутеров сегмента в один цвет
        public void Repaint(Bitmap color)
        {
            foreach (Router router in Routers)
            {
                router.Image = color;
            }
        }

        #endregion
    }
}
