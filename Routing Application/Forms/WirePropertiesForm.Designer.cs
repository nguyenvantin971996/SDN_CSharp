namespace Routing_Application.Forms
{
    partial class WireProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WireProperties));
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbCriterions = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblMetric = new System.Windows.Forms.Label();
            this.txtMetric = new System.Windows.Forms.TextBox();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.lblReplacement = new System.Windows.Forms.Label();
            this.txtReplacement = new System.Windows.Forms.TextBox();
            this.lblPointS = new System.Windows.Forms.Label();
            this.txtPointS = new System.Windows.Forms.TextBox();
            this.lblPointT = new System.Windows.Forms.Label();
            this.txtPointT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbCriterions.SuspendLayout();
            this.gbParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(100, 40);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(44, 20);
            this.txtDelay.TabIndex = 1;
            this.txtDelay.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount1_Validating);
            this.txtDelay.Validated += new System.EventHandler(this.txtAmount1_Validated);
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(40, 44);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(56, 13);
            this.lblDelay.TabIndex = 5;
            this.lblDelay.Text = "Delay (ms)";
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(23, 67);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(73, 13);
            this.lblLoad.TabIndex = 6;
            this.lblLoad.Text = "Load (packet)";
            // 
            // txtLoad
            // 
            this.txtLoad.Location = new System.Drawing.Point(100, 64);
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.Size = new System.Drawing.Size(44, 20);
            this.txtLoad.TabIndex = 2;
            this.txtLoad.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount2_Validating);
            this.txtLoad.Validated += new System.EventHandler(this.txtAmount2_Validated);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(8, 92);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(87, 13);
            this.lblCapacity.TabIndex = 7;
            this.lblCapacity.Text = "Capacity (Mbit/s)";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(100, 88);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(44, 20);
            this.txtCapacity.TabIndex = 3;
            this.txtCapacity.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount3_Validating);
            this.txtCapacity.Validated += new System.EventHandler(this.txtAmount3_Validated);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(220, 228);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // gbCriterions
            // 
            this.gbCriterions.Controls.Add(this.checkBox1);
            this.gbCriterions.Controls.Add(this.lblMetric);
            this.gbCriterions.Controls.Add(this.txtMetric);
            this.gbCriterions.Controls.Add(this.txtDelay);
            this.gbCriterions.Controls.Add(this.lblDelay);
            this.gbCriterions.Controls.Add(this.txtLoad);
            this.gbCriterions.Controls.Add(this.lblCapacity);
            this.gbCriterions.Controls.Add(this.txtCapacity);
            this.gbCriterions.Controls.Add(this.lblLoad);
            this.gbCriterions.Location = new System.Drawing.Point(8, 8);
            this.gbCriterions.Name = "gbCriterions";
            this.gbCriterions.Size = new System.Drawing.Size(164, 158);
            this.gbCriterions.TabIndex = 0;
            this.gbCriterions.TabStop = false;
            this.gbCriterions.Text = "Criterias";
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox1.Location = new System.Drawing.Point(29, 111);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Arrow";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // lblMetric
            // 
            this.lblMetric.AutoSize = true;
            this.lblMetric.Location = new System.Drawing.Point(60, 20);
            this.lblMetric.Name = "lblMetric";
            this.lblMetric.Size = new System.Drawing.Size(36, 13);
            this.lblMetric.TabIndex = 4;
            this.lblMetric.Text = "Metric";
            // 
            // txtMetric
            // 
            this.txtMetric.Location = new System.Drawing.Point(100, 16);
            this.txtMetric.Name = "txtMetric";
            this.txtMetric.Size = new System.Drawing.Size(44, 20);
            this.txtMetric.TabIndex = 0;
            this.txtMetric.Validating += new System.ComponentModel.CancelEventHandler(this.txtMetric_Validating);
            this.txtMetric.Validated += new System.EventHandler(this.txtMetric_Validated);
            // 
            // gbParameters
            // 
            this.gbParameters.Controls.Add(this.lblReplacement);
            this.gbParameters.Controls.Add(this.txtReplacement);
            this.gbParameters.Controls.Add(this.lblPointS);
            this.gbParameters.Controls.Add(this.txtPointS);
            this.gbParameters.Controls.Add(this.lblPointT);
            this.gbParameters.Controls.Add(this.txtPointT);
            this.gbParameters.Location = new System.Drawing.Point(180, 8);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(112, 116);
            this.gbParameters.TabIndex = 2;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parameters";
            // 
            // lblReplacement
            // 
            this.lblReplacement.AutoSize = true;
            this.lblReplacement.Location = new System.Drawing.Point(8, 80);
            this.lblReplacement.Name = "lblReplacement";
            this.lblReplacement.Size = new System.Drawing.Size(32, 13);
            this.lblReplacement.TabIndex = 9;
            this.lblReplacement.Text = "Repl.";
            // 
            // txtReplacement
            // 
            this.txtReplacement.Location = new System.Drawing.Point(52, 76);
            this.txtReplacement.Name = "txtReplacement";
            this.txtReplacement.ReadOnly = true;
            this.txtReplacement.Size = new System.Drawing.Size(52, 20);
            this.txtReplacement.TabIndex = 8;
            // 
            // lblPointS
            // 
            this.lblPointS.AutoSize = true;
            this.lblPointS.Location = new System.Drawing.Point(8, 52);
            this.lblPointS.Name = "lblPointS";
            this.lblPointS.Size = new System.Drawing.Size(41, 13);
            this.lblPointS.TabIndex = 7;
            this.lblPointS.Text = "Point S";
            // 
            // txtPointS
            // 
            this.txtPointS.Location = new System.Drawing.Point(52, 48);
            this.txtPointS.Name = "txtPointS";
            this.txtPointS.ReadOnly = true;
            this.txtPointS.Size = new System.Drawing.Size(52, 20);
            this.txtPointS.TabIndex = 6;
            // 
            // lblPointT
            // 
            this.lblPointT.AutoSize = true;
            this.lblPointT.Location = new System.Drawing.Point(8, 24);
            this.lblPointT.Name = "lblPointT";
            this.lblPointT.Size = new System.Drawing.Size(41, 13);
            this.lblPointT.TabIndex = 5;
            this.lblPointT.Text = "Point T";
            // 
            // txtPointT
            // 
            this.txtPointT.Location = new System.Drawing.Point(52, 20);
            this.txtPointT.Name = "txtPointT";
            this.txtPointT.ReadOnly = true;
            this.txtPointT.Size = new System.Drawing.Size(52, 20);
            this.txtPointT.TabIndex = 1;
            // 
            // WireProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(301, 256);
            this.Controls.Add(this.gbParameters);
            this.Controls.Add(this.gbCriterions);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WireProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wire Properties";
            this.Load += new System.EventHandler(this.LineProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbCriterions.ResumeLayout(false);
            this.gbCriterions.PerformLayout();
            this.gbParameters.ResumeLayout(false);
            this.gbParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.TextBox txtLoad;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox gbCriterions;
        private System.Windows.Forms.Label lblMetric;
        private System.Windows.Forms.TextBox txtMetric;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.Label lblPointS;
        private System.Windows.Forms.TextBox txtPointS;
        private System.Windows.Forms.Label lblPointT;
        private System.Windows.Forms.TextBox txtPointT;
        private System.Windows.Forms.Label lblReplacement;
        private System.Windows.Forms.TextBox txtReplacement;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}