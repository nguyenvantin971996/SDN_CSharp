namespace Routing_Application.Forms
{
    partial class ParametersGenerate
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
            this.label_population = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_population
            // 
            this.label_population.AutoSize = true;
            this.label_population.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_population.Location = new System.Drawing.Point(11, 26);
            this.label_population.Name = "label_population";
            this.label_population.Size = new System.Drawing.Size(206, 18);
            this.label_population.TabIndex = 3;
            this.label_population.Text = "Численность популяции N =";
            // 
            // population
            // 
            this.population.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.population.Location = new System.Drawing.Point(234, 22);
            this.population.Multiline = true;
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(112, 25);
            this.population.TabIndex = 2;
            this.population.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.Info;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(105, 62);
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
            this.button_ok.Location = new System.Drawing.Point(234, 62);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 48;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // ParametersGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 120);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_population);
            this.Controls.Add(this.population);
            this.Name = "ParametersGenerate";
            this.Text = "ParametersGenerate";
            this.Load += new System.EventHandler(this.ParametersGenerate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_population;
        public System.Windows.Forms.TextBox population;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_ok;
    }
}