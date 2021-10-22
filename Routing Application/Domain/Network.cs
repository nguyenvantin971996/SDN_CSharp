using Routing_Application.View;
using System;
using System.Collections.Generic;

namespace Routing_Application.Domain
{
    [Serializable()]
    public class Network
    {
        public List<Router> Routers { get; set; }             // список роутеров
        public List<Wire> Wires { get; set; }                 // список каналов
        public List<Segment> Segments { get; set; }         // список сегментов
        public List<TextLabel> TextLabels { get; set; }      // список текстовых меток

        public Network()
        {
            this.Routers = new List<Router>();
            this.Wires = new List<Wire>();
            this.Segments = new List<Segment>();
            this.TextLabels = new List<TextLabel>();
        }

        #region Properties

        public int RouterMaxNumber
        {
            get { return Routers.Count - 1; }
        }

        #endregion

        #region MainMethods

        // закраска роутеров
        public void RoutersRepaint()
        {
            for (int i = 0; i < Segments.Count; i++)
            {
                int index = 0;
                if (i < Drawing.Bitmaps.Count)
                {
                    index = i;
                }
                else
                {
                    index = i % Drawing.Bitmaps.Count;
                }

                Segments[i].Repaint(Drawing.Bitmaps[index]);
            }
        }

        // распределение цветов для отметок дерева кратчайших путей
        public void WiresRecolor()
        {
            for (int i = 0; i < Segments.Count; i++)
            {
                int index = 0;
                if (i < Drawing.WireColors.Count)
                {
                    index = i;
                }
                else
                {
                    index = i % Drawing.WireColors.Count;
                }

                Segments[i].WireColor = Drawing.WireColors[index];
            }
        }

        #endregion
    }
}
