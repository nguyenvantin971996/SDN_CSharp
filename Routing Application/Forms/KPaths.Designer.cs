namespace Routing_Application.Forms
{
    partial class KPaths
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
            this.label_k = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.MaxK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_k
            // 
            this.label_k.AutoSize = true;
            this.label_k.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_k.Location = new System.Drawing.Point(33, 32);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(122, 18);
            this.label_k.TabIndex = 23;
            this.label_k.Text = "Число путей K =";
            // 
            // k
            // 
            this.k.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k.Location = new System.Drawing.Point(172, 28);
            this.k.Multiline = true;
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(112, 25);
            this.k.TabIndex = 22;
            this.k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.Info;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(318, 80);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(112, 36);
            this.button_close.TabIndex = 49;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(172, 80);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 48;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // MaxK
            // 
            this.MaxK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaxK.Location = new System.Drawing.Point(318, 28);
            this.MaxK.Multiline = true;
            this.MaxK.Name = "MaxK";
            this.MaxK.Size = new System.Drawing.Size(112, 25);
            this.MaxK.TabIndex = 50;
            this.MaxK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 137);
            this.Controls.Add(this.MaxK);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_k);
            this.Controls.Add(this.k);
            this.Name = "KPaths";
            this.Text = "KPaths";
            this.Load += new System.EventHandler(this.KPaths_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_k;
        public System.Windows.Forms.TextBox k;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_ok;
        public System.Windows.Forms.TextBox MaxK;
    }
}