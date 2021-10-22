namespace Routing_Application.Forms
{
    partial class Connectivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connectivity));
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctlValueOfConBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlValueOfConBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(36, 12);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(82, 13);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "Connectivity (Q)";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(120, 8);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(40, 20);
            this.txtValue.TabIndex = 1;
            this.txtValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
            this.txtValue.Validated += new System.EventHandler(this.txtValue_Validated);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(112, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // ctlValueOfConBar
            // 
            this.ctlValueOfConBar.AutoSize = false;
            this.ctlValueOfConBar.LargeChange = 1;
            this.ctlValueOfConBar.Location = new System.Drawing.Point(12, 32);
            this.ctlValueOfConBar.Maximum = 9;
            this.ctlValueOfConBar.Name = "ctlValueOfConBar";
            this.ctlValueOfConBar.Size = new System.Drawing.Size(176, 32);
            this.ctlValueOfConBar.TabIndex = 3;
            this.ctlValueOfConBar.Value = 2;
            this.ctlValueOfConBar.Scroll += new System.EventHandler(this.ctlValueOfConBar_Scroll);
            // 
            // Connectivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(196, 97);
            this.Controls.Add(this.ctlValueOfConBar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Connectivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connectivity";
            this.Load += new System.EventHandler(this.InitialDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlValueOfConBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TrackBar ctlValueOfConBar;
    }
}