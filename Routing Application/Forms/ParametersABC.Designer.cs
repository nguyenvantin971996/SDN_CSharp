namespace Routing_Application.Forms
{
    partial class ParametersABC
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
            this.button_ok = new System.Windows.Forms.Button();
            this.label_iterations = new System.Windows.Forms.Label();
            this.iterations = new System.Windows.Forms.TextBox();
            this.label_population_size = new System.Windows.Forms.Label();
            this.population_size = new System.Windows.Forms.TextBox();
            this.label_k = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(249, 184);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 42;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_iterations
            // 
            this.label_iterations.AutoSize = true;
            this.label_iterations.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iterations.Location = new System.Drawing.Point(60, 94);
            this.label_iterations.Name = "label_iterations";
            this.label_iterations.Size = new System.Drawing.Size(168, 18);
            this.label_iterations.TabIndex = 41;
            this.label_iterations.Text = "Число итераций Max =";
            // 
            // iterations
            // 
            this.iterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iterations.Location = new System.Drawing.Point(249, 90);
            this.iterations.Multiline = true;
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(112, 25);
            this.iterations.TabIndex = 40;
            this.iterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_population_size
            // 
            this.label_population_size.AutoSize = true;
            this.label_population_size.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_population_size.Location = new System.Drawing.Point(59, 52);
            this.label_population_size.Name = "label_population_size";
            this.label_population_size.Size = new System.Drawing.Size(169, 18);
            this.label_population_size.TabIndex = 37;
            this.label_population_size.Text = "Размер популяции N =";
            // 
            // population_size
            // 
            this.population_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.population_size.Location = new System.Drawing.Point(249, 45);
            this.population_size.Multiline = true;
            this.population_size.Name = "population_size";
            this.population_size.Size = new System.Drawing.Size(112, 25);
            this.population_size.TabIndex = 36;
            this.population_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_k
            // 
            this.label_k.AutoSize = true;
            this.label_k.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_k.Location = new System.Drawing.Point(106, 139);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(122, 18);
            this.label_k.TabIndex = 44;
            this.label_k.Text = "Число путей K =";
            // 
            // k
            // 
            this.k.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k.Location = new System.Drawing.Point(249, 135);
            this.k.Multiline = true;
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(112, 25);
            this.k.TabIndex = 43;
            this.k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.Info;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(397, 184);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(112, 36);
            this.button_close.TabIndex = 45;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // ParametersABC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 249);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label_k);
            this.Controls.Add(this.k);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_iterations);
            this.Controls.Add(this.iterations);
            this.Controls.Add(this.label_population_size);
            this.Controls.Add(this.population_size);
            this.Name = "ParametersABC";
            this.Text = "ParametersABC";
            this.Load += new System.EventHandler(this.ParametersABC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_iterations;
        public System.Windows.Forms.TextBox iterations;
        private System.Windows.Forms.Label label_population_size;
        public System.Windows.Forms.TextBox population_size;
        private System.Windows.Forms.Label label_k;
        public System.Windows.Forms.TextBox k;
        private System.Windows.Forms.Button button_close;
    }
}