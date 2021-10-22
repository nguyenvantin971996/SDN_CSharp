namespace Routing_Application.Forms
{
    partial class EditText
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
            this.txtText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtText.Location = new System.Drawing.Point(0, 0);
            this.txtText.Margin = new System.Windows.Forms.Padding(0);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(56, 15);
            this.txtText.TabIndex = 0;
            this.txtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyDown);
            // 
            // EditText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(56, 15);
            this.Controls.Add(this.txtText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(56, 15);
            this.MinimumSize = new System.Drawing.Size(56, 15);
            this.Name = "EditText";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtText;
    }
}