namespace Routing_Application.Forms
{
    partial class RouterProperties
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblSegment = new System.Windows.Forms.Label();
            this.cbSegment = new System.Windows.Forms.ComboBox();
            this.gbSignature = new System.Windows.Forms.GroupBox();
            this.txtSegment = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbEditSegment = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblNewSegment = new System.Windows.Forms.Label();
            this.gbSignature.SuspendLayout();
            this.gbEditSegment.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(12, 20);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "Number";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(12, 36);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(60, 20);
            this.txtNumber.TabIndex = 3;
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.Location = new System.Drawing.Point(12, 64);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(49, 13);
            this.lblSegment.TabIndex = 0;
            this.lblSegment.Text = "Segment";
            // 
            // cbSegment
            // 
            this.cbSegment.FormattingEnabled = true;
            this.cbSegment.Location = new System.Drawing.Point(12, 36);
            this.cbSegment.Name = "cbSegment";
            this.cbSegment.Size = new System.Drawing.Size(104, 21);
            this.cbSegment.Sorted = true;
            this.cbSegment.TabIndex = 1;
            // 
            // gbSignature
            // 
            this.gbSignature.Controls.Add(this.txtSegment);
            this.gbSignature.Controls.Add(this.txtNumber);
            this.gbSignature.Controls.Add(this.lblNumber);
            this.gbSignature.Controls.Add(this.lblSegment);
            this.gbSignature.Location = new System.Drawing.Point(8, 8);
            this.gbSignature.Name = "gbSignature";
            this.gbSignature.Size = new System.Drawing.Size(84, 116);
            this.gbSignature.TabIndex = 1;
            this.gbSignature.TabStop = false;
            this.gbSignature.Text = "Signature";
            // 
            // txtSegment
            // 
            this.txtSegment.Location = new System.Drawing.Point(12, 80);
            this.txtSegment.Name = "txtSegment";
            this.txtSegment.ReadOnly = true;
            this.txtSegment.Size = new System.Drawing.Size(60, 20);
            this.txtSegment.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 112);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbEditSegment
            // 
            this.gbEditSegment.Controls.Add(this.btnApply);
            this.gbEditSegment.Controls.Add(this.lblNewSegment);
            this.gbEditSegment.Controls.Add(this.cbSegment);
            this.gbEditSegment.Location = new System.Drawing.Point(108, 8);
            this.gbEditSegment.Name = "gbEditSegment";
            this.gbEditSegment.Size = new System.Drawing.Size(128, 96);
            this.gbEditSegment.TabIndex = 6;
            this.gbEditSegment.TabStop = false;
            this.gbEditSegment.Text = "Change Segment";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(40, 64);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "Connect";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblNewSegment
            // 
            this.lblNewSegment.AutoSize = true;
            this.lblNewSegment.Location = new System.Drawing.Point(12, 20);
            this.lblNewSegment.Name = "lblNewSegment";
            this.lblNewSegment.Size = new System.Drawing.Size(104, 13);
            this.lblNewSegment.TabIndex = 5;
            this.lblNewSegment.Text = "Connect to Segment";
            // 
            // RouterProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(244, 143);
            this.Controls.Add(this.gbEditSegment);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbSignature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RouterProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Router Properties";
            this.Load += new System.EventHandler(this.RouterProperties_Load);
            this.gbSignature.ResumeLayout(false);
            this.gbSignature.PerformLayout();
            this.gbEditSegment.ResumeLayout(false);
            this.gbEditSegment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblSegment;
        private System.Windows.Forms.ComboBox cbSegment;
        private System.Windows.Forms.GroupBox gbSignature;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtSegment;
        private System.Windows.Forms.GroupBox gbEditSegment;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblNewSegment;
    }
}