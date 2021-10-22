using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Routing_Application.Forms
{
    public partial class Chart : Form
    {
        private List<int> Counts;
        private List<int> Counts_1;

        public Chart(List<int> Counts, List<int> Counts_1)
        {
            InitializeComponent();
            this.Counts = Counts;
            this.Counts_1 = Counts_1;
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Counts.Count; i++)
            {
                int j = i + 1;
                ctlChart.Series["Load"].Points.AddXY("Path " +j, Counts[i]);
            }

            if (Counts.Count > 70)
            {
                ctlChart.ChartAreas[0].Area3DStyle.PointDepth = 200;
            }
            else
            {
                ctlChart.ChartAreas[0].Area3DStyle.PointDepth = 100;
            }

            for (int i = 0; i < Counts_1.Count; i++)
            {
                int j = i + 1;
                ctlChart_1.Series["Load"].Points.AddXY("Path " + j , Counts_1[i]);
            }

            if (Counts_1.Count > 70)
            {
                ctlChart_1.ChartAreas[0].Area3DStyle.PointDepth = 200;
            }
            else
            {
                ctlChart_1.ChartAreas[0].Area3DStyle.PointDepth = 100;
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
                    ctlChart_1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                    break;
                case 2:
                    ctlChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Tiff);
                    ctlChart_1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Tiff);
                    break;
                case 3:
                    ctlChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    ctlChart_1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    break;
            }
        }
    }
}
