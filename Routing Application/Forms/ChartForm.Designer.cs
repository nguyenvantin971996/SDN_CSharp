namespace Routing_Application.Forms
{
    partial class Chart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chart));
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblMean = new System.Windows.Forms.Label();
            this.lblVariance = new System.Windows.Forms.Label();
            this.ctlChart_1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ctlChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ctlChart_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.SystemColors.Info;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(878, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save As ...";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG (*.jpg) | *.jpg |TIFF (*.tif) | *.tif|PNG (*.png) | *.png";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // lblMean
            // 
            this.lblMean.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMean.AutoSize = true;
            this.lblMean.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblMean.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMean.Location = new System.Drawing.Point(380, 455);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(0, 23);
            this.lblMean.TabIndex = 2;
            // 
            // lblVariance
            // 
            this.lblVariance.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVariance.AutoSize = true;
            this.lblVariance.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblVariance.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVariance.Location = new System.Drawing.Point(536, 455);
            this.lblVariance.Name = "lblVariance";
            this.lblVariance.Size = new System.Drawing.Size(0, 23);
            this.lblVariance.TabIndex = 3;
            // 
            // ctlChart_1
            // 
            this.ctlChart_1.BackColor = System.Drawing.Color.Turquoise;
            this.ctlChart_1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "ChartArea1";
            this.ctlChart_1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ctlChart_1.Legends.Add(legend1);
            this.ctlChart_1.Location = new System.Drawing.Point(511, 12);
            this.ctlChart_1.Name = "ctlChart_1";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.Orange;
            series1.Legend = "Legend1";
            series1.Name = "Load";
            this.ctlChart_1.Series.Add(series1);
            this.ctlChart_1.Size = new System.Drawing.Size(461, 429);
            this.ctlChart_1.TabIndex = 4;
            this.ctlChart_1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "After balancing";
            this.ctlChart_1.Titles.Add(title1);
            // 
            // ctlChart
            // 
            this.ctlChart.BackColor = System.Drawing.Color.Turquoise;
            this.ctlChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Name = "ChartArea1";
            this.ctlChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ctlChart.Legends.Add(legend2);
            this.ctlChart.Location = new System.Drawing.Point(26, 12);
            this.ctlChart.Name = "ctlChart";
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series2.IsValueShownAsLabel = true;
            series2.LabelBackColor = System.Drawing.Color.Orange;
            series2.Legend = "Legend1";
            series2.Name = "Load";
            this.ctlChart.Series.Add(series2);
            this.ctlChart.Size = new System.Drawing.Size(461, 429);
            this.ctlChart.TabIndex = 5;
            this.ctlChart.Text = "chart1";
            title2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Title1";
            title2.Text = "Before balancing";
            this.ctlChart.Titles.Add(title2);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(999, 480);
            this.Controls.Add(this.ctlChart);
            this.Controls.Add(this.ctlChart_1);
            this.Controls.Add(this.lblVariance);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlChart_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Label lblVariance;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctlChart_1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctlChart;
    }
}