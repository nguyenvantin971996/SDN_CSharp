namespace Routing_Application.Forms
{
    partial class NewFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFile));
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.lblHight = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkAutoFilling = new System.Windows.Forms.CheckBox();
            this.gbSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(8, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "File Name";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(186, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(122, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.lblHight);
            this.gbSize.Controls.Add(this.txtHeight);
            this.gbSize.Controls.Add(this.lblWidth);
            this.gbSize.Controls.Add(this.txtWidth);
            this.gbSize.Location = new System.Drawing.Point(8, 60);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(212, 68);
            this.gbSize.TabIndex = 1;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Field Size ( px )";
            // 
            // lblHight
            // 
            this.lblHight.AutoSize = true;
            this.lblHight.Location = new System.Drawing.Point(112, 24);
            this.lblHight.Name = "lblHight";
            this.lblHight.Size = new System.Drawing.Size(32, 13);
            this.lblHight.TabIndex = 3;
            this.lblHight.Text = "Hight";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(112, 40);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(70, 20);
            this.txtHeight.TabIndex = 1;
            this.txtHeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtHeight_Validating);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(12, 24);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Width";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(12, 40);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(70, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.Validating += new System.ComponentModel.CancelEventHandler(this.txtWidth_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // chkAutoFilling
            // 
            this.chkAutoFilling.AutoSize = true;
            this.chkAutoFilling.Location = new System.Drawing.Point(12, 140);
            this.chkAutoFilling.Name = "chkAutoFilling";
            this.chkAutoFilling.Size = new System.Drawing.Size(77, 17);
            this.chkAutoFilling.TabIndex = 5;
            this.chkAutoFilling.Text = "Auto Filling";
            this.chkAutoFilling.UseVisualStyleBackColor = true;
            // 
            // NewFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(249, 199);
            this.Controls.Add(this.chkAutoFilling);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New File";
            this.Load += new System.EventHandler(this.NewFileForm_Load);
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.Label lblHight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox chkAutoFilling;
    }
}