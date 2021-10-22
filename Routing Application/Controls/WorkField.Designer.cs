namespace Routing_Application.Controls
{
    partial class WorkField
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctlPicBox = new System.Windows.Forms.PictureBox();
            this.ctlPicBoxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctlProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlPanel = new System.Windows.Forms.Panel();
            this.ctlRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlDejkstra = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlOptimalRout = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlPairSwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlPrim = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlSegmentation = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.ctlPicBox)).BeginInit();
            this.ctlPicBoxContextMenu.SuspendLayout();
            this.ctlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlPicBox
            // 
            this.ctlPicBox.BackColor = System.Drawing.Color.White;
            this.ctlPicBox.ContextMenuStrip = this.ctlPicBoxContextMenu;
            this.ctlPicBox.Location = new System.Drawing.Point(0, 0);
            this.ctlPicBox.Name = "ctlPicBox";
            this.ctlPicBox.Size = new System.Drawing.Size(3000, 1500);
            this.ctlPicBox.TabIndex = 0;
            this.ctlPicBox.TabStop = false;
            this.ctlPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.WorkFieldPaint);
            this.ctlPicBox.DoubleClick += new System.EventHandler(this.ctlPicBox_DoubleClick);
            this.ctlPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctlPicBox_MouseDown);
            this.ctlPicBox.MouseEnter += new System.EventHandler(this.ctlPicBox_MouseEnter);
            this.ctlPicBox.MouseLeave += new System.EventHandler(this.ctlPicBox_MouseLeave);
            this.ctlPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctlPicBox_MouseMove);
            this.ctlPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctlPicBox_MouseUp);
            // 
            // ctlPicBoxContextMenu
            // 
            this.ctlPicBoxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlProperties});
            this.ctlPicBoxContextMenu.Name = "ctlPicBoxContextMenu";
            this.ctlPicBoxContextMenu.Size = new System.Drawing.Size(128, 26);
            this.ctlPicBoxContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctlPicBoxContextMenu_Opening);
            // 
            // ctlProperties
            // 
            this.ctlProperties.Name = "ctlProperties";
            this.ctlProperties.Size = new System.Drawing.Size(127, 22);
            this.ctlProperties.Text = "Properties";
            this.ctlProperties.Click += new System.EventHandler(this.ctlProperties_Click);
            // 
            // ctlPanel
            // 
            this.ctlPanel.AutoScroll = true;
            this.ctlPanel.Controls.Add(this.ctlPicBox);
            this.ctlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlPanel.Location = new System.Drawing.Point(0, 0);
            this.ctlPanel.Name = "ctlPanel";
            this.ctlPanel.Size = new System.Drawing.Size(664, 353);
            this.ctlPanel.TabIndex = 1;
            this.ctlPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ctlPanel_Scroll);
            // 
            // ctlRemove
            // 
            this.ctlRemove.Name = "ctlRemove";
            this.ctlRemove.Size = new System.Drawing.Size(32, 19);
            this.ctlRemove.Click += new System.EventHandler(this.RemoveElement);
            // 
            // ctlDeleteAll
            // 
            this.ctlDeleteAll.Name = "ctlDeleteAll";
            this.ctlDeleteAll.Image = Properties.Resources.Delete;
            this.ctlDeleteAll.Size = new System.Drawing.Size(32, 19);
            this.ctlDeleteAll.Text = "Delete All";
            // 
            // ctlDejkstra
            // 
            this.ctlDejkstra.Name = "ctlDejkstra";
            this.ctlDejkstra.Image = Properties.Resources.MenuRun;
            this.ctlDejkstra.Size = new System.Drawing.Size(32, 19);
            this.ctlDejkstra.Text = "Dejkstra";
            this.ctlDejkstra.Click += new System.EventHandler(this.mainForm.Dejkstra);
            // 
            // ctlOptimalRout
            // 
            this.ctlOptimalRout.Name = "ctlOptimalRout";
            this.ctlOptimalRout.Image = Properties.Resources.MenuRun;
            this.ctlOptimalRout.Size = new System.Drawing.Size(32, 19);
            this.ctlOptimalRout.Text = "OptimalRout";
            this.ctlOptimalRout.Click += new System.EventHandler(this.mainForm.OptimalRout);
            // 
            // ctlPairSwitch
            // 
            this.ctlPairSwitch.Name = "ctlPairSwitch";
            this.ctlPairSwitch.Image = Properties.Resources.MenuRun;
            this.ctlPairSwitch.Size = new System.Drawing.Size(32, 19);
            this.ctlPairSwitch.Text = "PairSwitch";
            this.ctlPairSwitch.Click += new System.EventHandler(this.mainForm.PairSwitch);
            // 
            // ctlPrim
            // 
            this.ctlPrim.Name = "ctlPrim";
            this.ctlPrim.Image = Properties.Resources.MenuRun;
            this.ctlPrim.Size = new System.Drawing.Size(32, 19);
            this.ctlPrim.Text = "Prim";
            this.ctlPrim.Click += new System.EventHandler(this.mainForm.Prim);
            // 
            // ctlSegmentation
            // 
            this.ctlSegmentation.Name = "ctlSegmentation";
            this.ctlSegmentation.Image = Properties.Resources.MenuRun;
            this.ctlSegmentation.Size = new System.Drawing.Size(32, 19);
            this.ctlSegmentation.Text = "Segmentation";
            this.ctlSegmentation.Click += new System.EventHandler(this.mainForm.Segmentation);
            // 
            // contextSeparator1
            // 
            this.contextSeparator1.Name = "contextSeparator1";
            this.contextSeparator1.Size = new System.Drawing.Size(32, 6);
            // 
            // contextSeparator2
            // 
            this.contextSeparator2.Name = "contextSeparator2";
            this.contextSeparator2.Size = new System.Drawing.Size(32, 6);
            // 
            // WorkField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlPanel);
            this.Name = "WorkField";
            this.Size = new System.Drawing.Size(664, 353);
            this.Load += new System.EventHandler(this.WorkField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlPicBox)).EndInit();
            this.ctlPicBoxContextMenu.ResumeLayout(false);
            this.ctlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel ctlPanel;
        private System.Windows.Forms.PictureBox ctlPicBox;
        private System.Windows.Forms.ContextMenuStrip ctlPicBoxContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ctlRemove;
        private System.Windows.Forms.ToolStripMenuItem ctlDeleteAll;
        private System.Windows.Forms.ToolStripSeparator contextSeparator1;
        private System.Windows.Forms.ToolStripSeparator contextSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctlProperties;
        private System.Windows.Forms.ToolStripMenuItem ctlDejkstra;
        private System.Windows.Forms.ToolStripMenuItem ctlPrim;
        private System.Windows.Forms.ToolStripMenuItem ctlSegmentation;
        private System.Windows.Forms.ToolStripMenuItem ctlOptimalRout;
        private System.Windows.Forms.ToolStripMenuItem ctlPairSwitch;
    }
}
