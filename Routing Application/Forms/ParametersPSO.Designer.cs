namespace Routing_Application.Forms
{
    partial class ParametersPSO
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
            this.label_acceleration_factor = new System.Windows.Forms.Label();
            this.acceleration_factor_c1 = new System.Windows.Forms.TextBox();
            this.label_population_size = new System.Windows.Forms.Label();
            this.population_size = new System.Windows.Forms.TextBox();
            this.label_inertia_weight = new System.Windows.Forms.Label();
            this.inertia_weight = new System.Windows.Forms.TextBox();
            this.acceleration_factor_c2 = new System.Windows.Forms.TextBox();
            this.label_k = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(300, 250);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 32;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_iterations
            // 
            this.label_iterations.AutoSize = true;
            this.label_iterations.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iterations.Location = new System.Drawing.Point(109, 69);
            this.label_iterations.Name = "label_iterations";
            this.label_iterations.Size = new System.Drawing.Size(168, 18);
            this.label_iterations.TabIndex = 31;
            this.label_iterations.Text = "Число итераций Max =";
            // 
            // iterations
            // 
            this.iterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iterations.Location = new System.Drawing.Point(300, 65);
            this.iterations.Multiline = true;
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(112, 25);
            this.iterations.TabIndex = 30;
            this.iterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_acceleration_factor
            // 
            this.label_acceleration_factor.AutoSize = true;
            this.label_acceleration_factor.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_acceleration_factor.Location = new System.Drawing.Point(20, 194);
            this.label_acceleration_factor.Name = "label_acceleration_factor";
            this.label_acceleration_factor.Size = new System.Drawing.Size(257, 18);
            this.label_acceleration_factor.TabIndex = 29;
            this.label_acceleration_factor.Text = "Коэффициенты ускорений c1, c2 =";
            // 
            // acceleration_factor_c1
            // 
            this.acceleration_factor_c1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceleration_factor_c1.Location = new System.Drawing.Point(300, 190);
            this.acceleration_factor_c1.Multiline = true;
            this.acceleration_factor_c1.Name = "acceleration_factor_c1";
            this.acceleration_factor_c1.Size = new System.Drawing.Size(112, 25);
            this.acceleration_factor_c1.TabIndex = 28;
            this.acceleration_factor_c1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_population_size
            // 
            this.label_population_size.AutoSize = true;
            this.label_population_size.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_population_size.Location = new System.Drawing.Point(108, 26);
            this.label_population_size.Name = "label_population_size";
            this.label_population_size.Size = new System.Drawing.Size(169, 18);
            this.label_population_size.TabIndex = 27;
            this.label_population_size.Text = "Размер популяции N =";
            // 
            // population_size
            // 
            this.population_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.population_size.Location = new System.Drawing.Point(300, 22);
            this.population_size.Multiline = true;
            this.population_size.Name = "population_size";
            this.population_size.Size = new System.Drawing.Size(112, 25);
            this.population_size.TabIndex = 26;
            this.population_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_inertia_weight
            // 
            this.label_inertia_weight.AutoSize = true;
            this.label_inertia_weight.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_inertia_weight.Location = new System.Drawing.Point(111, 152);
            this.label_inertia_weight.Name = "label_inertia_weight";
            this.label_inertia_weight.Size = new System.Drawing.Size(166, 18);
            this.label_inertia_weight.TabIndex = 25;
            this.label_inertia_weight.Text = "Инерционный вес w =";
            // 
            // inertia_weight
            // 
            this.inertia_weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inertia_weight.Location = new System.Drawing.Point(300, 148);
            this.inertia_weight.Multiline = true;
            this.inertia_weight.Name = "inertia_weight";
            this.inertia_weight.Size = new System.Drawing.Size(112, 25);
            this.inertia_weight.TabIndex = 24;
            this.inertia_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // acceleration_factor_c2
            // 
            this.acceleration_factor_c2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceleration_factor_c2.Location = new System.Drawing.Point(454, 190);
            this.acceleration_factor_c2.Multiline = true;
            this.acceleration_factor_c2.Name = "acceleration_factor_c2";
            this.acceleration_factor_c2.Size = new System.Drawing.Size(112, 25);
            this.acceleration_factor_c2.TabIndex = 33;
            this.acceleration_factor_c2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_k
            // 
            this.label_k.AutoSize = true;
            this.label_k.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_k.Location = new System.Drawing.Point(155, 111);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(122, 18);
            this.label_k.TabIndex = 35;
            this.label_k.Text = "Число путей K =";
            // 
            // k
            // 
            this.k.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k.Location = new System.Drawing.Point(300, 107);
            this.k.Multiline = true;
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(112, 25);
            this.k.TabIndex = 34;
            this.k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.Info;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(454, 250);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(112, 36);
            this.button_close.TabIndex = 47;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // ParametersPSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 312);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label_k);
            this.Controls.Add(this.k);
            this.Controls.Add(this.acceleration_factor_c2);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_iterations);
            this.Controls.Add(this.iterations);
            this.Controls.Add(this.label_acceleration_factor);
            this.Controls.Add(this.acceleration_factor_c1);
            this.Controls.Add(this.label_population_size);
            this.Controls.Add(this.population_size);
            this.Controls.Add(this.label_inertia_weight);
            this.Controls.Add(this.inertia_weight);
            this.Name = "ParametersPSO";
            this.Text = "ParametersPSO";
            this.Load += new System.EventHandler(this.ParametersPSO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_iterations;
        public System.Windows.Forms.TextBox iterations;
        private System.Windows.Forms.Label label_acceleration_factor;
        public System.Windows.Forms.TextBox acceleration_factor_c1;
        private System.Windows.Forms.Label label_population_size;
        public System.Windows.Forms.TextBox population_size;
        private System.Windows.Forms.Label label_inertia_weight;
        public System.Windows.Forms.TextBox inertia_weight;
        public System.Windows.Forms.TextBox acceleration_factor_c2;
        private System.Windows.Forms.Label label_k;
        public System.Windows.Forms.TextBox k;
        private System.Windows.Forms.Button button_close;
    }
}