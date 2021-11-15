using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Routing_Application.Domain;
using Routing_Application.Enums;
using System.Drawing;
using System.Linq;
namespace Routing_Application.Forms
{
    public partial class Chart_1 : Form
    {
        private List<double> Counts;
        public List<Color> mausac = new List<Color> { Color.Green, Color.Red, Color.Blue, Color.Yellow, Color.Orange, Color.Violet };
        public Chart_1(List<double> Counts)
        {
            InitializeComponent();
            this.Counts = Counts;
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Counts.Count; i++)
            {
                int j = i + 1;
                ctlChart.Series["Load"].Points.AddXY("Path " +j, Counts[i]);
                ctlChart.Series["Load"].Points[i].Color = mausac[i];
            }

            if (Counts.Count > 70)
            {
                ctlChart.ChartAreas[0].Area3DStyle.PointDepth = 120;
            }
            else
            {
                ctlChart.ChartAreas[0].Area3DStyle.PointDepth = 60;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "Chart.jpg";
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            switch (saveFileDialog.FilterIndex)
            {
                case 1:
                    ctlChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                    break;
                case 2:
                    ctlChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Tiff);
                    break;
                case 3:
                    ctlChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    break;
            }
        }
    }
}
