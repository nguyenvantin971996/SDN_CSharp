namespace Routing_Application.Forms
{
    partial class Statistic
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistic));
            this.ctlTable = new System.Windows.Forms.ListView();
            this.ctlNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlRouters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlWires = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlSegments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlDmin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlDmax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlNmin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlNmax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlMmin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlMmax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlMout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlMout_min = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlMout_max = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnToTxt = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlTable
            // 
            this.ctlTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ctlNumber,
            this.ctlRouters,
            this.ctlWires,
            this.ctlSegments,
            this.ctlD,
            this.ctlDmin,
            this.ctlDmax,
            this.ctlNmin,
            this.ctlNmax,
            this.ctlMmin,
            this.ctlMmax,
            this.ctlMout,
            this.ctlMout_min,
            this.ctlMout_max,
            this.ctlQ,
            this.ctlFile});
            this.ctlTable.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctlTable.ForeColor = System.Drawing.Color.Black;
            this.ctlTable.FullRowSelect = true;
            this.ctlTable.GridLines = true;
            this.ctlTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ctlTable.Location = new System.Drawing.Point(0, 0);
            this.ctlTable.Name = "ctlTable";
            this.ctlTable.Size = new System.Drawing.Size(874, 308);
            this.ctlTable.TabIndex = 0;
            this.ctlTable.UseCompatibleStateImageBehavior = false;
            this.ctlTable.View = System.Windows.Forms.View.Details;
            // 
            // ctlNumber
            // 
            this.ctlNumber.Text = "№";
            this.ctlNumber.Width = 28;
            // 
            // ctlRouters
            // 
            this.ctlRouters.Text = "N";
            this.ctlRouters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlRouters.Width = 40;
            // 
            // ctlWires
            // 
            this.ctlWires.Text = "M";
            this.ctlWires.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlWires.Width = 40;
            // 
            // ctlSegments
            // 
            this.ctlSegments.Text = "R";
            this.ctlSegments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlSegments.Width = 40;
            // 
            // ctlD
            // 
            this.ctlD.Text = "D";
            this.ctlD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlD.Width = 40;
            // 
            // ctlDmin
            // 
            this.ctlDmin.Text = "Dmin";
            this.ctlDmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlDmin.Width = 50;
            // 
            // ctlDmax
            // 
            this.ctlDmax.Text = "Dmax";
            this.ctlDmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlDmax.Width = 50;
            // 
            // ctlNmin
            // 
            this.ctlNmin.Text = "Nmin";
            this.ctlNmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlNmin.Width = 50;
            // 
            // ctlNmax
            // 
            this.ctlNmax.Text = "Nmax";
            this.ctlNmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlNmax.Width = 50;
            // 
            // ctlMmin
            // 
            this.ctlMmin.Text = "Mmin";
            this.ctlMmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlMmin.Width = 50;
            // 
            // ctlMmax
            // 
            this.ctlMmax.Text = "Mmax";
            this.ctlMmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlMmax.Width = 50;
            // 
            // ctlMout
            // 
            this.ctlMout.Text = "Mout";
            this.ctlMout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlMout.Width = 50;
            // 
            // ctlMout_min
            // 
            this.ctlMout_min.Text = "Mout_min";
            this.ctlMout_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlMout_min.Width = 70;
            // 
            // ctlMout_max
            // 
            this.ctlMout_max.Text = "Mout_max";
            this.ctlMout_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlMout_max.Width = 72;
            // 
            // ctlQ
            // 
            this.ctlQ.Text = "Q";
            this.ctlQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlQ.Width = 40;
            // 
            // ctlFile
            // 
            this.ctlFile.Text = "File ";
            this.ctlFile.Width = 149;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(553, 320);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 26);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(777, 320);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 26);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "OK";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(253, 320);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 26);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnToTxt
            // 
            this.btnToTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToTxt.Location = new System.Drawing.Point(681, 320);
            this.btnToTxt.Name = "btnToTxt";
            this.btnToTxt.Size = new System.Drawing.Size(90, 26);
            this.btnToTxt.TabIndex = 5;
            this.btnToTxt.Text = "Save...";
            this.btnToTxt.UseVisualStyleBackColor = true;
            this.btnToTxt.Click += new System.EventHandler(this.btnToTxt_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(453, 320);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(90, 26);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(353, 320);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(90, 26);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Network";
            this.saveFileDialog.Filter = "Text Files (*.txt) | *.txt";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 352);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ctlTable);
            this.Controls.Add(this.btnToTxt);
            this.Controls.Add(this.btnRemove);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(890, 390);
            this.Name = "Statistic";
            this.Text = "Statistic Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Statistic_FormClosing);
            this.Load += new System.EventHandler(this.Statistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ctlTable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ColumnHeader ctlNumber;
        private System.Windows.Forms.ColumnHeader ctlFile;
        private System.Windows.Forms.ColumnHeader ctlRouters;
        private System.Windows.Forms.ColumnHeader ctlWires;
        private System.Windows.Forms.ColumnHeader ctlSegments;
        private System.Windows.Forms.ColumnHeader ctlNmin;
        private System.Windows.Forms.ColumnHeader ctlNmax;
        private System.Windows.Forms.ColumnHeader ctlMmin;
        private System.Windows.Forms.ColumnHeader ctlMmax;
        private System.Windows.Forms.ColumnHeader ctlMout;
        private System.Windows.Forms.ColumnHeader ctlQ;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnToTxt;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ColumnHeader ctlMout_min;
        private System.Windows.Forms.ColumnHeader ctlD;
        private System.Windows.Forms.ColumnHeader ctlDmin;
        private System.Windows.Forms.ColumnHeader ctlDmax;
        private System.Windows.Forms.ColumnHeader ctlMout_max;
    }
}