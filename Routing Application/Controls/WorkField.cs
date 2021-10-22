using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Drawing.Drawing2D;

using Routing_Application.DAL;
using Routing_Application.Domain;
using Routing_Application.View;

using Routing_Application.Enums;
using Routing_Application.Structures;
using Routing_Application.Forms;

namespace Routing_Application.Controls
{
    public partial class WorkField : UserControl
    {
        private Main mainForm;                              // ссылка на главную форму

        private bool mouseIsCliced;                         // состояние левой кнопки мыши ( нажата / не нажата )
        private bool multiSelect;                           // флаг множественного выбора
        private List<Router> drawingRouters;                // список узлов в области видимости пользователя
        private List<Wire> drawingWires;                    // список каналов связи в области видимости пользователя
        private List<TextLabel> drawingTextLabels;          // список текстовых меток в области видимости пользователя
        private Point mouseLocation;                        // текущие координаты мыши 
        private Point rectPoint;                            // точка прямоугольника выделения
        private Rectangle selectedRect;                     // ссылка на прямоугольник выделения
        private Router startRouter;                         // метка начального узла канала
        private Router endRouter;                           // метка конечного узла канала
        private TextLabel selectedTextLabel;                // ссылка на выбранную текстовую метку
        private FieldToolKit toolKit;                       // набор делегатов, инкапсулирующих методы
                                                            // управления Рабочим Полем

        public List<Router> SelectedRouters { get; set; }   // список выделенных узлов
        public Wire SelectedWire { get; set; }              // ссылка навыбранный канал
        public bool CtrlIsCliced { get; set; }              // состояние Control ( нажат / не нажат )
        public string FilePath { get; set; }                // путь к файлу
        public Network Network { get; set; }                // топология

        // свойства
        #region Properties

        public Cursor PicBoxCursor
        {
            get { return ctlPicBox.Cursor; }
            set { ctlPicBox.Cursor = value; }
        }

        public FieldToolKit ToolKit
        {
            get { return toolKit; }
        }

        public Size FieldSize
        {
            get { return ctlPicBox.Size; }
            set { ctlPicBox.Size = value; }
        }

        public Main MainForm
        {
            get { return mainForm; }
        }

        #endregion

        // конструктор
        public WorkField(Main main, Size size, string filePath = null, Network net = null, Cursor cursor = null)
        {
            mainForm = main;
            InitializeComponent();
            Dock = DockStyle.Fill;
            FieldSize = size;       
            FilePath = filePath;       

            if (net == null)
            {
                Network = new Network();
            }
            else
            {
                Network = net;
            }

            if (cursor == null)
            {
                PicBoxCursor = Cursors.Arrow;
            }
            else
            {
                PicBoxCursor = cursor;
            }

            drawingTextLabels = new List<TextLabel>();
            SelectedRouters = new List<Router>();
            drawingRouters = new List<Router>();
            drawingWires = new List<Wire>();
            selectedRect = new Rectangle();
            toolKit = new FieldToolKit(ctlPicBox.Invalidate);
        }

        // загрузка формы
        private void WorkField_Load(object sender, EventArgs e)
        {
            // создать магистральный сегмент
            Network.Segments.Clear();
            Network.Segments.Add(new Segment());

            // настройка атрибутов Рабочего Поля
            if (mainForm.Instrument == Instruments.Edit)
            {
                ctlPicBox.Cursor = Cursors.Arrow;
                ctlPicBox.ContextMenuStrip = ctlPicBoxContextMenu;
            }
            else
            {
                ctlPicBox.Cursor = Cursors.Cross;
                ctlPicBox.ContextMenuStrip = null;
            }

            // исходные установки узлов связи
            foreach (Router router in Network.Routers)
            {
                Network.Segments[0].Routers.Add(router);
                router.Segment = Network.Segments[0];
                router.Mark = Marks.None;
            }

            // исходные установки каналов связи
            Pen pen = new Pen(Color.Gray, 1);
            foreach (Wire wire in Network.Wires)
            {
                wire.Pen = pen;
                wire.Segment = Network.Segments[0];
                Network.Segments[0].Wires.Add(wire);
                wire.UpdateInfo(mainForm.Criterion);
            }

            UpdateScreen();
            toolKit.UpdateField();
        }

        // обработчики событий мыши 
        #region Mouse Events

        // событие: двойной клик мыши
        private void ctlPicBox_DoubleClick(object sender, EventArgs e)
        {
            switch (mainForm.Instrument)
            {
                case Instruments.Edit:
                    // открыть контекстное меню
                    OpenContextMenu();
                    break;

                case Instruments.Insert_Router:
                    break;

                case Instruments.Insert_Wire:
                    break;

                case Instruments.Create_Text:
                    break;

            }
        }

        // событие: мышь передвинута
        private void ctlPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            mainForm.CoordsRefresh(e.Location.X, e.Location.Y);    // вывод положения мыши на форму
            mouseLocation = e.Location;                            // обновление положения мыши

            // обработка события
            if (e.Button == MouseButtons.Left)
            {
                switch (mainForm.Instrument)
                {
                    case Instruments.Edit:
                        if (mouseIsCliced == true)
                        {
                            if (selectedTextLabel != null)
                            {
                                selectedTextLabel.Location = new Point(e.X, e.Y);
                            }

                            if (SelectedRouters.Count != 0)
                            {
                                foreach (Router router in SelectedRouters)
                                {
                                    router.Location = new Point(e.X - router.XOffset, e.Y - router.YOffset);
                                    foreach (Wire wire in router.Wires)
                                    {
                                        wire.UpdateCenter();
                                    }
                                }
                                ctlPicBox.Invalidate();
                                break;
                            }

                            if (SelectedWire != null)
                            {
                                SelectedWire.FloatingCenter = e.Location;
                                SelectedWire.UpdateOffsets();
                            }
                        }

                        if (multiSelect == true)
                        {
                            UpdateRect(rectPoint, e.Location);
                        }
                        ctlPicBox.Invalidate();
                        break;

                    case Instruments.Insert_Router:
                        break;

                    case Instruments.Insert_Wire:
                        ctlPicBox.Invalidate();
                        break;

                    case Instruments.Create_Text:
                        break;
                }
            }
        }

        // событие: клавиша мыши отпущена
        private void ctlPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            // обработка события
            if (e.Button == MouseButtons.Left)
            {
                switch (mainForm.Instrument)
                {
                    case Instruments.Edit:
                        if (SelectedRouters.Count > 0)
                        {
                            foreach (Router router in SelectedRouters)
                            {
                                CheckRouterPosition(router);
                                foreach (Wire wire in router.Wires)
                                {
                                    wire.UpdateCenter();
                                }
                            }
                        }

                        if (multiSelect == true)
                        {
                            foreach (Router router in drawingRouters)
                            {
                                if (InArea(router, selectedRect) == true)
                                {
                                    SelectedRouters.Add(router);
                                }
                            }
                            multiSelect = false;
                        }
                        break;

                    case Instruments.Insert_Router:
                        break;

                    case Instruments.Insert_Wire:
                        if (mouseIsCliced == true)
                        {
                            endRouter = FindRouter(e.Location);

                            if ((endRouter != null) && (startRouter != null) && (endRouter.Equals(startRouter) == false))
                            {
                                Wire wire = new Wire(startRouter, endRouter);

                                Network.Wires.Add(wire);   // можно убрать в граф ?
                                drawingWires.Add(wire);
                                Network.Segments[0].Wires.Add(wire);
                                mouseIsCliced = false;

                                if (mainForm.AutoWeight == false)
                                {
                                    WireProperties properties = new WireProperties(wire);
                                    properties.ShowDialog(this);
                                }
                                else
                                {
                                    Random random = new Random();
                                    wire.Delay = 1 + random.Next(15);
                                    wire.Load = 0 ;
                                    wire.Capacity = 1 + random.Next(15);
                                    wire.Metric = (1 + random.Next(10))*10;
                                }
                                wire.UpdateInfo(mainForm.Criterion);
                                mainForm.WiresRefresh(Network.Wires.Count);
                            }
                        }
                        break;

                    case Instruments.Create_Text:
                        break;
                }

                selectedRect = new Rectangle();
                startRouter = null;
                endRouter = null;
                ctlPicBox.Invalidate();
            }
        }

        // событие: клавиша мыши нажата
        private void ctlPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            // обработка события
            if (e.Button == MouseButtons.Left)
            {
                switch (mainForm.Instrument)
                {
                    case Instruments.Edit:

                        selectedTextLabel = FindTextLabel(e.Location);
                        if (selectedTextLabel != null)
                        {
                        }
                        else
                        {
                            Router selectedRouter = null;

                            // работа с выбранным каналом
                            if ((selectedRouter = FindRouter(e.Location)) == null)
                            {
                                if ((SelectedWire = FindWire(e.Location)) == null)
                                {
                                    multiSelect = true;
                                }

                                SelectedRouters.Clear();
                            }
                            // работа с роутерами
                            else
                            {
                                // не один роутер не выбран
                                if (SelectedRouters.Count == 0)
                                {
                                    SelectedRouters.Add(selectedRouter);
                                }
                                // выбран один роутер
                                else if (SelectedRouters.Count == 1)
                                {
                                    if (CtrlIsCliced == true)
                                    {
                                        if (selectedRouter != SelectedRouters[0])
                                        {
                                            SelectedRouters.Add(selectedRouter);
                                        }
                                        else
                                        {
                                            SelectedRouters.Clear();
                                        }
                                    }
                                    else
                                    {
                                        SelectedRouters[0] = selectedRouter;
                                    }
                                }
                                // выбрано больше одного роутера
                                else
                                {
                                    if (CtrlIsCliced == true)
                                    {
                                        if (SelectedRouters.Contains(selectedRouter) == false)
                                        {
                                            SelectedRouters.Add(selectedRouter);
                                        }
                                        else
                                        {
                                            SelectedRouters.Remove(selectedRouter);
                                        }
                                    }
                                    else
                                    {
                                        if (SelectedRouters.Contains(selectedRouter) == false)
                                        {
                                            SelectedRouters.Clear();
                                            SelectedRouters.Add(selectedRouter);
                                        }
                                    }
                                }

                                foreach (Router r in SelectedRouters)
                                {
                                    r.XOffset = e.X - r.Location.X;
                                    r.YOffset = e.Y - r.Location.Y;
                                }
                                SelectedWire = null;
                            }

                            rectPoint = e.Location;
                        }

                        mouseIsCliced = true;
                        break;

                    case Instruments.Insert_Router:
                        Router router = new Router(e.Location, Network.RouterMaxNumber + 1, Network.Segments[0]);
                        Network.Routers.Add(router);   // можно занести в граф  ?
                        drawingRouters.Add(router);

                        if (mainForm.FullMesh == true)
                        {
                            Random random = new Random();
                            foreach (Router r in Network.Routers)
                            {
                                if (router != r)
                                {
                                    Wire wire = new Wire(router, r);

                                    Network.Wires.Add(wire);
                                    drawingWires.Add(wire);

                                    wire.Delay = 1 + random.Next(15);
                                    wire.Load = 0;
                                    wire.Capacity = 1 + random.Next(15);
                                    wire.Metric = (1 + random.Next(10)) * 10;

                                    wire.UpdateInfo(mainForm.Criterion);
                                    mainForm.WiresRefresh(Network.Wires.Count);
                                }
                            }
                        }

                        mainForm.RoutersRefresh(Network.Routers.Count);
                        break;

                    case Instruments.Insert_Wire:
                        startRouter = FindRouter(e.Location);
                        mouseIsCliced = true;
                        break;

                    case Instruments.Create_Text:
                        TextLabel textLabel = new TextLabel(null, e.Location);
                        Network.TextLabels.Add(textLabel);
                        drawingTextLabels.Add(textLabel);

                        EditText editTextForm = new EditText(textLabel);
                        editTextForm.SetLocation(ctlPicBox.PointToScreen(textLabel.Location));
                        editTextForm.ShowDialog();
                        break;
                }

                toolKit.UpdateField();
            }
        }

        // событие: ползунок окна передвинут
        private void ctlPanel_Scroll(object sender, ScrollEventArgs e)
        {
            // обновить списки элементов, 
            // которые видит пользователь
            UpdateScreen();
        }

        #endregion

        // основные методы
        #region Methods

        // активировать/деактивировать контекстное меню Рабочего Поля 
        public void PicBoxContextMenuSwitch(bool state)
        {
            if (state == true)
            {
                ctlPicBox.ContextMenuStrip = ctlPicBoxContextMenu;
            }
            else
            {
                ctlPicBox.ContextMenuStrip = null;
            }
        }

        // очистить Рабочее Поле
        public void DeleteAll()
        {
            drawingRouters.Clear();
            drawingWires.Clear();
            drawingTextLabels.Clear();
            Network.Routers.Clear();
            Network.Wires.Clear();
            Network.TextLabels.Clear();
            mainForm.WiresRefresh(Network.Wires.Count);
            mainForm.RoutersRefresh(Network.Routers.Count);
            SelectedRouters.Clear();
            SelectedWire = null;
            toolKit.UpdateField();
        }

        // удалить выбранный элемент
        public void DeleteSelectedElement()
        {
            // удалить текстовую метку
            if (selectedTextLabel != null)
            {
                Network.TextLabels.Remove(selectedTextLabel);
                drawingTextLabels.Remove(selectedTextLabel);
                selectedTextLabel = null;
                toolKit.UpdateField();
            }

            // удалить выбранные узлы связи
            if (SelectedRouters.Count > 0)
            {
                foreach (Router router in SelectedRouters)
                {
                    RemoveRouter(router);
                }
                SelectedRouters.Clear();
            }

            // удалить выбраный канал связи 
            if (SelectedWire != null)
            {
                RemoveWire(SelectedWire);
            }
        }

        // обновить список видимых элементов Рабочего Поля
        private void UpdateScreen()
        {
            drawingRouters.Clear();
            drawingWires.Clear();
            drawingTextLabels.Clear();

            foreach (Router router in Network.Routers)
            {
                if (InArea(router.Location, ctlPicBox.PointToClient(ctlPanel.Location), Drawing.screenSize.Width, Drawing.screenSize.Height) == true)
                {
                    drawingRouters.Add(router);
                    foreach (Wire wire in router.Wires)
                    {
                        if (drawingWires.Contains(wire) == false)
                        {
                            drawingWires.Add(wire);
                        }
                    }
                }
            }

            foreach (TextLabel textLabel in Network.TextLabels)
            {
                if (InArea(textLabel.Location, ctlPicBox.PointToClient(ctlPanel.Location), Drawing.screenSize.Width, Drawing.screenSize.Height) == true)
                {
                    drawingTextLabels.Add(textLabel);
                }
            }
        }

        // поиск роутера около указанной точки
        private Router FindRouter(Point location)
        {
            List<Router> findRouters = new List<Router>();
            foreach (Router router in drawingRouters)
            {
                if (InArea(router.Location, location, Drawing.xOffset, Drawing.yOffset) == true)
                {
                    findRouters.Add(router);
                }
            }

            if (findRouters.Count > 0)
            {
                return findRouters[findRouters.Count - 1];
            }
            else
            {
                return null;
            }
        }

        // поиск канала около указанной точки
        private Wire FindWire(Point location)
        {
            List<Wire> findWires = new List<Wire>();
            foreach (Wire wire in drawingWires)
            {
                if (InArea(wire.FloatingCenter, location, 20, 10) == true)
                {
                    findWires.Add(wire);
                }
            }

            if (findWires.Count > 0)
            {
                return findWires[findWires.Count - 1];
            }
            else
            {
                return null;
            }
        }

        // поиск текстовой метки
        private TextLabel FindTextLabel(Point location)
        {
            List<TextLabel> findingTextLabels = new List<TextLabel>();
            foreach (TextLabel textLabel in drawingTextLabels)
            {
                if (InArea(textLabel.Location, location, textLabel.TextSize.Width / 2, textLabel.TextSize.Height / 2) == true)
                {
                    findingTextLabels.Add(textLabel);
                }
            }

            if (findingTextLabels.Count > 0)
            {
                return findingTextLabels[findingTextLabels.Count - 1];
            }
            else
            {
                return null;
            }
        }

        // удаление канала связи
        private void RemoveWire(Wire wire)
        {
            if (wire == SelectedWire)
            {
                SelectedWire = null;
            }

            wire.StartRouter.Ports.Remove(wire.StartPort);
            wire.EndRouter.Ports.Remove(wire.EndPort);

            wire.StartRouter.Wires.Remove(wire);
            wire.EndRouter.Wires.Remove(wire);

            wire.Segment.Wires.Remove(wire);
            drawingWires.Remove(wire);
            Network.Wires.Remove(wire);
            mainForm.WiresRefresh(Network.Wires.Count);
            toolKit.UpdateField();
        }

        // удаление узла связи
        private void RemoveRouter(Router router)
        {
            while (router.Wires.Count > 0)
            {
                RemoveWire(router.Wires[0]);
            }

            drawingRouters.Remove(router);
            router.Segment.Routers.Remove(router);
            Network.Routers.Remove(router);
            mainForm.RoutersRefresh(Network.Routers.Count);
            mainForm.WiresRefresh(Network.Wires.Count);
            ctlPicBox.Invalidate();
        }

        // !!! доработать !!! ... когда-нибудь
        public void CreateNetwork(int width, int height)
        {
            int offset = 150;
            double countX = width / (Drawing.xOffset + offset);
            countX = Math.Floor(countX);

            double countY = height / (Drawing.yOffset + offset);
            countY = Math.Floor(countY);

            Router[,] mass = new Router[(int)countX, (int)countY];
            int constx = Drawing.xOffset + offset;
            int consty = Drawing.yOffset + offset;

            int x = 70;
            int y = 70;
            int routerNumber = 0;

            Network.Segments.Add(new Segment());

            for (int i = 0; i < countX; i++)
            {
                for (int j = 0; j < countY; j++)
                {
                    Router router = new Router(new Point(x, y), routerNumber, Network.Segments[0]);
                    mass[i, j] = router;
                    Network.Routers.Add(router);
                    routerNumber += 1;
                    y += consty;
                }
                x += constx;
                y = 70;
            }

            Random random = new Random();

            if (mainForm.FullMesh == false)
            {
                for (int i = 0; i < countX; i++)
                {
                    for (int j = 0; j < countY; j++)
                    {
                        if (j < countY - 1)
                        {
                            Wire wire = new Wire(mass[i, j], mass[i, j + 1]);

                            Network.Wires.Add(wire);

                            wire.Delay = 1 + random.Next(15);
                            wire.Load = 0;
                            wire.Capacity = 1 + random.Next(15);
                            wire.Metric = (1 + random.Next(10)) * 10;

                            wire.UpdateInfo(mainForm.Criterion);
                        }

                        if (i > 0)
                        {
                            Wire wire = new Wire(mass[i, j], mass[i - 1, j]);

                            Network.Wires.Add(wire);

                            wire.Delay = 1 + random.Next(15);
                            wire.Load = 0;
                            wire.Capacity = 1 + random.Next(15);
                            wire.Metric = (1 + random.Next(10)) * 10;

                            wire.UpdateInfo(mainForm.Criterion);
                        }
                    }
                }
            }
            else
            {
                foreach (Router router in Network.Routers)
                {
                    foreach (Router r in Network.Routers)
                    {
                        if (router != r)
                        {
                            Wire wire = new Wire(router, r);

                            Network.Wires.Add(wire);
                            drawingWires.Add(wire);

                            wire.Delay = 1 + random.Next(15);
                            wire.Load = 0;
                            wire.Capacity = 1 + random.Next(15);
                            wire.Metric = (1 + random.Next(10)) * 10;

                            wire.UpdateInfo(mainForm.Criterion);
                        }
                    }
                }
            }
            mainForm.WiresRefresh(Network.Wires.Count);
        }

        #endregion

        // вспомогательные методы
        #region AuxiliaryMethods

        private void OpenContextMenu()
        {
            // выбрана текстовая метка
            if ((selectedTextLabel = FindTextLabel(mouseLocation)) != null)
            {
                EditText textForm = new EditText(selectedTextLabel);
                textForm.SetLocation(ctlPicBox.PointToScreen(selectedTextLabel.Location));
                textForm.ShowDialog();
            }

            Router selectedRouter = null;
            
            // выбран узел связи
            if ((selectedRouter = FindRouter(mouseLocation)) != null)
            {
                SelectedRouters.Clear();
                SelectedRouters.Add(selectedRouter);
                toolKit.UpdateField();

                RouterProperties properties = new RouterProperties(selectedRouter, Network);
                if (properties.ShowDialog(this) == DialogResult.OK)
                {
                    Network.RoutersRepaint();
                    toolKit.UpdateField();
                }
                selectedRouter = null;
                return;
            }

            // выбран канал связи
            if (SelectedWire != null)
            {
                WireProperties properties = new WireProperties(SelectedWire);
                if (properties.ShowDialog(this) == DialogResult.OK)
                {
                    SelectedWire.UpdateInfo(mainForm.Criterion);
                    ctlPicBox.Invalidate();
                }

                SelectedWire = null;
            }
        }

        // проверка: находится ли точка 'p' в окресности точки 'center' 
        private bool InArea(Point center, Point p, int xOffset, int yOffset)
        {
            if ((p.X <= center.X + xOffset) && (p.X >= center.X - xOffset) &&
                (p.Y <= center.Y + yOffset) && (p.Y >= center.Y - yOffset))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // проверка: находится ли узел связи впределах прямоугольника
        private bool InArea(Router router, Rectangle rect)
        {
            if ((router.Location.X <= rect.X + rect.Width) && (router.Location.X >= rect.X) &&
                (router.Location.Y >= rect.Y) && (router.Location.Y <= rect.Y + rect.Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // корректировка позиции узла связи
        private void CheckRouterPosition(Router router)
        {
            int i_x;
            int i_y;
            int x = i_x = router.Location.X;
            int y = i_y = router.Location.Y;

            if (i_x > ctlPicBox.Width)
            {
                x = ctlPicBox.Width - Drawing.xOffset;
            }
            else if (i_x < 0)
            {
                x = Drawing.xOffset;
            }

            if (i_y > ctlPicBox.Height)
            {
                y = ctlPicBox.Height - Drawing.yOffset;
            }
            else if (i_y < 0)
            {
                y = Drawing.yOffset;
            }

            router.Location = new Point(x, y);
        }

        // перерисовка рамки выделения
        private void UpdateRect(Point p1, Point p2)
        {
            if (p1.X > p2.X)
            {
                if (p1.Y < p2.Y)
                {
                    selectedRect = new Rectangle(p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
                }
                else
                {
                    selectedRect = new Rectangle(p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
                }
            }
            else
            {
                if (p1.Y < p2.Y)
                {
                    selectedRect = new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                }
                else
                {
                    selectedRect = new Rectangle(p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
                }
            }
            
        }

        #endregion

        // обработчики событий
        #region EventHandlers

        // отрисовка Рабочего Поля
        private void WorkFieldPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // отрисовка фантома канала
            if ((mouseIsCliced == true) && (mainForm.Instrument == Instruments.Insert_Wire) && (startRouter != null))
            {
                e.Graphics.DrawLine(new Pen(Color.Gray, 1), startRouter.Location, mouseLocation);
            }

            // отрисовка каналов
            foreach (Wire wire in drawingWires)
            {
                if (wire != SelectedWire)
                {
                    Drawing.DrawWire(wire, e);
                }
            }

            // отрисовка выбранного канала ( поверх остальных )
            if ((SelectedWire != null) && (SelectedRouters.Count == 0))
            {
                Pen pen = SelectedWire.Pen;
                SelectedWire.Pen = new Pen(Brushes.Blue, 2);
                Drawing.DrawWire(SelectedWire, e);
                SelectedWire.Pen = pen;
            }

            e.Graphics.SmoothingMode = SmoothingMode.Default;

            // отрисовка роутеров
            foreach (Router router in drawingRouters)
            {
                Drawing.DrawRouter(router, e);
            }

            // отрисовка выбранного роутера ( поверх остальных )
            foreach (Router router in SelectedRouters)
            {
                Drawing.DrawRouter(router, e);
                Drawing.DrawRouterFrame(router, e);
            }

            foreach (TextLabel textLabel in drawingTextLabels)
            {
                Drawing.DrawTextLabel(textLabel, Brushes.White, e);
            }

            if (selectedTextLabel != null)
            {
                Drawing.DrawTextLabel(selectedTextLabel, Brushes.Blue, e);
            }

            if (multiSelect == true)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), selectedRect);
            }

        }

        // отключение контекстного меню главной формы на Рабочем Поле
        private void ctlPicBox_MouseEnter(object sender, EventArgs e)
        {
            mainForm.ctlTabControl.ContextMenuStrip = null;
        }

        // подключение контекстного меню главной формы
        private void ctlPicBox_MouseLeave(object sender, EventArgs e)
        {
            mainForm.ctlTabControl.ContextMenuStrip = mainForm.ctlContextMenu;
        }

        #endregion

        // группа методов управления контекстными меню
        #region ContextMenu

        // событие: раскрытие контекстного меню Рабочего Поля
        private void ctlPicBoxContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // заполнить меню узла связи
            Router selectedRouter = FindRouter(mouseLocation);
            if (selectedRouter != null)
            {
                SelectedRouters.Clear();
                SelectedRouters.Add(selectedRouter);
                SelectedWire = null;
                ctlPicBoxContextMenu.Items.Clear();

                ctlRemove.Image = Properties.Resources.ToolRouterRemove;
                ctlPicBoxContextMenu.Items.Add(ctlRemove);
                ctlPicBoxContextMenu.Items.Add(contextSeparator1);
                ctlPicBoxContextMenu.Items.Add(ctlDejkstra);
                ctlPicBoxContextMenu.Items.Add(ctlOptimalRout);
                ctlPicBoxContextMenu.Items.Add(ctlPrim);
                ctlPicBoxContextMenu.Items.Add(ctlSegmentation);
                ctlPicBoxContextMenu.Items.Add(ctlPairSwitch);
                ctlPicBoxContextMenu.Items.Add(contextSeparator2);
                ctlPicBoxContextMenu.Items.Add(ctlProperties);

                ctlRemove.Text = "Remove Router";
                ctlPicBox.Invalidate();
                return;
            }

            // заполнить меню канала связи
            SelectedWire = FindWire(mouseLocation);
            if (SelectedWire != null)
            {
                SelectedRouters.Clear();
                ctlPicBoxContextMenu.Items.Clear();

                ctlRemove.Image = Properties.Resources.ToolLineRemove;
                ctlPicBoxContextMenu.Items.Add(ctlRemove);
                ctlPicBoxContextMenu.Items.Add(contextSeparator1);
                ctlPicBoxContextMenu.Items.Add(ctlProperties);

                ctlRemove.Text = "Remove Wire";
                ctlPicBox.Invalidate();
                return;
            }

            // заполнить меню Рабочего Поля
            ctlPicBoxContextMenu.Items.Clear();

            ctlPicBoxContextMenu.Items.Add(ctlDeleteAll);
            ctlPicBoxContextMenu.Items.Add(contextSeparator1);
            ctlPicBoxContextMenu.Items.Add(ctlProperties);
            toolKit.UpdateField();
        }

        // событие: рвскрытие контекстного меню
        private void ctlProperties_Click(object sender, EventArgs e)
        {
            // открыть контекстное меню
            OpenContextMenu();
        }

        // вызов метода удаления узла/канала связи
        private void RemoveElement(object sender, EventArgs e)
        {
            // удаление выделенного узла связи
            Router selectedRouter = FindRouter(mouseLocation);
            if (selectedRouter != null)
            {
                RemoveRouter(selectedRouter);
                selectedRouter = null;
                return;
            }

            // удаление выделенного канала связи
            if (SelectedWire != null)
            {
                RemoveWire(SelectedWire);
                SelectedWire = null;
            }
        }

        #endregion   
    }
}
