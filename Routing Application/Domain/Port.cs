using Routing_Application.DAL;
using System;
using System.Collections.Generic;

namespace Routing_Application.Domain
{
    /// <summary>
    /// класс Порт роутера
    /// </summary>
    [Serializable()]
    public class Port
    {
        private Wire wire;      // ссылка на канал порта
        private Router router;  // ссылка на роутер, к которому ведет канал
        private Router owner;
        private Port oppositePort;
        private int distance;
        private List<Port> tracks;
       // private int number ;

        // открытые свойства
        #region Properties

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public List<Port> Tracks
        {
            get { return tracks; }
            set { tracks = value; }
        }

        public Port OppositePort
        {
            get { return oppositePort; }
            set { oppositePort = value; }
        }

        public Wire Wire
        {
            get { return wire; }
            set { wire = value; }
        }

        public Router Router
        {
            get { return router; }
            set { router = value; }
        }

        public Router Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        
        #endregion

        // конструктор порта
        public Port(Wire wire, Router router, Router owner)
        {
            this.wire = wire;
            this.router = router;
            this.owner = owner;
            this.distance = Const.INF;
            this.tracks = new List<Port>();
        }
    }
}
