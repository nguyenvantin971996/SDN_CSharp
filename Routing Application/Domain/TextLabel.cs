using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Routing_Application.DAL;
using Routing_Application.Structures;
using Routing_Application.Enums;
using System.Drawing;
using System.Windows.Forms;

namespace Routing_Application.Domain
{
    [Serializable()]
    public class TextLabel
    {
        private Point location;                    // координаты

        private string text;                       // надпись
        private Size textSize;                     // размер надписи

        public TextLabel(string text, Point location)
        {
            Text = text;
            Location = location;

            UpdateText(text);
        }

        #region Properties

        public string Text
        {
            get { return text; }
            set
            {
                if ((value != null) && (value != string.Empty))
                {
                    text = value;
                }
                else
                {
                    text = "NONE";
                }
            }
        }

        public Point Location
        {
            get { return location; }
            set
            {
                if (value.X > 0 && value.Y > 0)
                {
                    location = value;
                }
                else
                {
                    location = new Point(0, 0);
                }
            }
        }

        public Size TextSize
        {
            get { return textSize; }
            set { textSize = value; }
        }

        #endregion

        #region EventHandlers

        #endregion

        #region MainMethods

        public void UpdateText(string text)
        {
            Font font = new Font("Arial", 10);
            Text = text;
            TextSize = TextRenderer.MeasureText(Text, font);
        }

        #endregion

        #region AuxiliaryMethods

        #endregion

    }
}
