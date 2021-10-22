using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Routing_Application.DAL;
using Routing_Application.Structures;

namespace Routing_Application.Domain
{ 
    /// <summary>
    /// класс Роутер
    /// </summary>
    [Serializable()] 
    public class Router
    {
        /*  графическая часть  */
        private Bitmap image;                      // изображение 
        private Marks mark = Marks.None;           // метка роутера ( является ли точкой отсчета для алгоритма )
        private Point location;                    // координаты

        private List<Wire> wires;                  // инцидентные каналы
        
        private string text;                       // надпись
        private Size textSize;                     // размер надписи

        private int xOffset;                       // смещение "выбранный узел - мышь" по Х
        private int yOffset;                       // смещение "выбранный узел - мышь" по Y

        /*  логическая часть  */
        private int number;                                 // уникальный номер роутера 

        private bool used;                                  // метка посещения ( для алгоритмов )
        private double distancePointer = Const.INF;         // расстояние до исходного роутера ( для алгоритма Дейкстры )

        private Segment segment;                            // ссылка на сегмент, в котором находится узел

        private List<Port> ports;                           // порты
        private List<Port> tPorts;                          // порты остова

        private List<Port> shortTrack;
        private double prio;

        // открытые свойства
        #region Properties
        public double Prio
        {
            get { return prio; }
            set { prio = value; }
        }
        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        public List<Port> ShortTrack
        {
            get { return shortTrack; }
            set { shortTrack = value; }
        }

        public Segment Segment
        {
            get { return segment; }
            set { segment = value; }
        }

        public double DistancePointer
        {
            get { return distancePointer; }
            set { distancePointer = value; }
        }

        public int XOffset
        {
            get { return xOffset; }
            set { xOffset = value; }
        }

        public int YOffset
        {
            get { return yOffset; }
            set { yOffset = value; }
        }

        public Marks Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        public List<Wire> Wires
        {
            get { return wires; }
            set { wires = value; }
        }

        public List<Port> Ports
        {
            get { return ports; }
            set { ports = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public List<Port> TPorts
        {
            get { return tPorts; }
            set { tPorts = value; }
        }

        public bool Used
        {
            get { return used; }
            set { used = value; }
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


        #endregion

        /* конструкторы роутера */
        public Router() { }

        public Router(Point location, int number, Segment segment)
        {
            this.number = number;
            this.used = false;

            this.image = Properties.Resources.router0;
            this.location = location;

            this.wires = new List<Wire>();
            this.ports = new List<Port>();
            this.tPorts = new List<Port>();
            this.shortTrack = new List<Port>();

            this.segment = segment;
            segment.Routers.Add(this);

            this.UpdateText();
        }

        // методы роутера
        #region MainMethods

        // обновление надписи
        public void UpdateText()
        {
            Font font = new Font("Arial", 12);
            text = String.Format("R{0}", number);
            textSize = TextRenderer.MeasureText(text, font);
        }

        #endregion
    }
}
