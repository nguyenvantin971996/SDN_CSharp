using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Routing_Application.Domain;

namespace Routing_Application.Forms
{
    /// <summary>
    /// класс формы Свойства роутера
    /// </summary>
    public partial class RouterProperties : Form
    {
        private Network network;
        private Router router;

        // открытые свойства
        #region Properties

        public Network Graph
        {
            get { return network; }
            set { network = value; }
        }

        public Router Router
        {
            get { return router; }
            set { router = value; }
        }

        #endregion 

        // конструктор
        public RouterProperties(Router router, Network graph)
        {
            InitializeComponent();
            this.network = graph;
            this.router = router;
        }

        // загрузка формы
        private void RouterProperties_Load(object sender, EventArgs e)
        {
            string output = String.Format("R{0}", this.router.Number);
            txtNumber.Text = output;
            txtSegment.Text = this.router.Segment.Number.ToString();

            FindSegments();
        }

        // обработчики кнопок
        #region ButtonHandlers

        // кнопка ОК
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        // кнопка Connect
        private void btnConnect_Click(object sender, EventArgs e)
        {
            switch (cbSegment.SelectedItem.ToString())
            {
                case "Not segmented":
                    router.Segment.Routers.Remove(router);
                    network.Segments[0].Routers.Add(router);
                    router.Segment = network.Segments[0];
                    router.Image = Properties.Resources.router0;
                    break;

                case "Create new":
                    router.Segment.Routers.Remove(router);
                    Segment seg = new Segment(this.router, MaxSegmentNum());
                    router.Segment = seg;
                    network.Segments.Add(seg);
                    break;

                default:
                    Segment connectedSegment = cbSegment.SelectedItem as Segment;
                    router.Segment.Routers.Remove(router);
                    connectedSegment.Routers.Add(router);
                    router.Segment = connectedSegment;
                    break;
            }
            this.SegmentsRefresh();
            this.DialogResult = DialogResult.OK;
        }

        #endregion

        // методы
        #region Methods

        // поиск окружающих сегментов
        private void FindSegments()
        {
            foreach (Port port in this.router.Ports)
            {
                if ((cbSegment.Items.Contains(port.Router.Segment) == false) && (port.Router.Segment.Number > 0) &&
                    (port.Router.Segment.Number != router.Segment.Number))
                {
                    cbSegment.Items.Add(port.Router.Segment);
                }
            }
            cbSegment.Items.Add("Not segmented");
            cbSegment.Items.Add("Create new");
            cbSegment.SelectedIndex = 0;
        }

        // вычисление номера нового сегмента
        private int MaxSegmentNum()
        {
            int max = 0;
            foreach (Segment segment in network.Segments)
            {
                if (segment.Number > max)
                {
                    max = segment.Number;
                }
            }

            return ++max;
        }

        // удаление сегмента без роутеров
        private void SegmentsRefresh()
        {
            Segment deletedSegment = null;
            foreach (Segment segment in network.Segments)
            {
                if ((segment.Routers.Count == 0) && (segment.Number > 0))
                {
                    deletedSegment = segment;
                    break;
                }
            }

            if (deletedSegment != null)
            {
                network.Segments.Remove(deletedSegment);
            }
        }

        #endregion

    }
}
