using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace Routing_Application.View
{
    public static class Drawing
    {
        public static Dictionary<int, Bitmap> Bitmaps;
        public static Dictionary<int, Color> WireColors;
        public static int xOffset = Properties.Resources.router0.Size.Width / 2;
        public static int yOffset = Properties.Resources.router0.Height / 2;
        public static Size screenSize = Screen.PrimaryScreen.Bounds.Size;

        static Drawing()
        {
            Bitmaps = new Dictionary<int, Bitmap>();
            Bitmaps.Add(0, Properties.Resources.router0);
            Bitmaps.Add(1, Properties.Resources.router1);
            Bitmaps.Add(2, Properties.Resources.router2);
            Bitmaps.Add(3, Properties.Resources.router3);
            Bitmaps.Add(4, Properties.Resources.router4);
            Bitmaps.Add(5, Properties.Resources.router5);
            Bitmaps.Add(6, Properties.Resources.router6);
            Bitmaps.Add(7, Properties.Resources.router7);
            Bitmaps.Add(8, Properties.Resources.router8);
            Bitmaps.Add(9, Properties.Resources.router9);
            Bitmaps.Add(10, Properties.Resources.router10);
            Bitmaps.Add(11, Properties.Resources.router11);
            Bitmaps.Add(12, Properties.Resources.router12);
            Bitmaps.Add(13, Properties.Resources.router13);
            Bitmaps.Add(14, Properties.Resources.router14);
            Bitmaps.Add(15, Properties.Resources.router15);
            Bitmaps.Add(16, Properties.Resources.router16);
            Bitmaps.Add(17, Properties.Resources.router17);
            Bitmaps.Add(18, Properties.Resources.router18);
            Bitmaps.Add(19, Properties.Resources.router19);
            Bitmaps.Add(20, Properties.Resources.Router_mark);
            WireColors = new Dictionary<int, Color>();
            WireColors.Add(0, Color.Red);
            WireColors.Add(1, Color.Blue);
            WireColors.Add(2, Color.DeepPink);
            WireColors.Add(3, Color.Brown);
            WireColors.Add(4, Color.Chartreuse);
            WireColors.Add(5, Color.Chocolate);
            WireColors.Add(6, Color.Crimson);
            WireColors.Add(7, Color.DarkCyan);
            WireColors.Add(8, Color.DarkViolet);
            WireColors.Add(9, Color.BlueViolet);
            WireColors.Add(10, Color.Maroon);
            WireColors.Add(11, Color.SaddleBrown);
            WireColors.Add(12, Color.Teal);
            WireColors.Add(13, Color.Aqua);
        }

        public static void DrawRouter(Router router, PaintEventArgs e)
        {
            e.Graphics.DrawImage(router.Image, new Point(router.Location.X - xOffset,
                                                         router.Location.Y - yOffset));

            Rectangle rectangle = new Rectangle(new Point(router.Location.X - router.TextSize.Width / 2,
                                                                              router.Location.Y - yOffset - 18),
                                                                              router.TextSize);
            e.Graphics.FillRectangle(Brushes.White, rectangle);

            switch (router.Mark)
            {
                case Marks.Dejkstra:
                    e.Graphics.DrawRectangle(new Pen(router.Segment.WireColor, 2), rectangle);
                    break;

                case Marks.Prim:
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 2), rectangle);
                    break;

                case Marks.Segmentation:
                    e.Graphics.DrawRectangle(new Pen(Color.Blue, 2), rectangle);
                    break;

                case Marks.Rout:
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 2), rectangle);
                    break;
            }


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(router.Text, new Font("Arial", 12), Brushes.Black, new Point(router.Location.X,
                                                                                               router.Location.Y - yOffset - 18),
                                                                                               stringFormat);
        }

        public static void DrawTextLabel(TextLabel textLabel, Brush brush, PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(new Point(textLabel.Location.X - textLabel.TextSize.Width / 2,
                                                          textLabel.Location.Y - textLabel.TextSize.Height / 2),
                                                          textLabel.TextSize);

            e.Graphics.FillRectangle(brush, rectangle);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(textLabel.Text, new Font("Arial", 10), Brushes.Black, new Point(textLabel.Location.X,
                                                                                                 textLabel.Location.Y - textLabel.TextSize.Height / 2),
                                                                                                 stringFormat);
        }

        public static void DrawWire(Wire wire, PaintEventArgs e)
        {
            Font font = new Font("Arial", 13);

            Size size = wire.TextSize;
            int width = size.Width+10;
            int height = size.Height+10;
            int halfWidth = width / 2;
            int halfHeight = height / 2;

            e.Graphics.DrawCurve(wire.Pen, new Point[] { wire.StartRouter.Location, 
                                                         wire.FloatingCenter});

            e.Graphics.DrawCurve(wire.Pen, new Point[] { wire.FloatingCenter,
                                                         wire.EndRouter.Location });

            e.Graphics.FillEllipse(Brushes.White, new Rectangle(wire.FloatingCenter.X - halfWidth,
                                                                wire.FloatingCenter.Y - halfHeight,
                                                                width, height));

            e.Graphics.DrawString(wire.Text, font, Brushes.Black, wire.FloatingCenter.X - halfWidth + 3,
                                                                  wire.FloatingCenter.Y - halfHeight);
        }

        public static void DrawRouterFrame(Router router, PaintEventArgs e)
        {                                                                
            int width = xOffset * 2 + 8;
            int height = yOffset * 2 + 8;
            int x = router.Location.X - xOffset - 4;
            int y = router.Location.Y - yOffset - 4;
            int piece = 16;

            Pen pen = new Pen(Brushes.Blue, 3);
            e.Graphics.SmoothingMode = SmoothingMode.Default;

            e.Graphics.DrawLines(pen, new Point[] {
                                                    new Point(x + piece, y + height),
                                                    new Point(x, y + height), 
                                                    new Point(x, y),
                                                    new Point(x + piece, y)
                                                    });

            e.Graphics.DrawLines(pen, new Point[] {
                                                   new Point(x + width - piece, y + height),
                                                   new Point(x + width, y + height), 
                                                   new Point(x + width, y),
                                                   new Point(x + width - piece, y)
                                                   });
        }
    }
}
