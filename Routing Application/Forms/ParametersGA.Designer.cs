namespace Routing_Application.Forms
{
    partial class ParametersGA
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
            this.population = new System.Windows.Forms.TextBox();
            this.label_population = new System.Windows.Forms.Label();
            this.label_crosser = new System.Windows.Forms.Label();
            this.crosser = new System.Windows.Forms.TextBox();
            this.mutation = new System.Windows.Forms.Label();
            this.mitation = new System.Windows.Forms.TextBox();
            this.label_iteration = new System.Windows.Forms.Label();
            this.iteration = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.label_k = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // population
            // 
            this.population.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.population.Location = new System.Drawing.Point(263, 38);
            this.population.Multiline = true;
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(112, 25);
            this.population.TabIndex = 0;
            this.population.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_population
            // 
            this.label_population.AutoSize = true;
            this.label_population.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_population.Location = new System.Drawing.Point(40, 42);
            this.label_population.Name = "label_population";
            this.label_population.Size = new System.Drawing.Size(206, 18);
            this.label_population.TabIndex = 1;
            this.label_population.Text = "Численность популяции N =";
            // 
            // label_crosser
            // 
            this.label_crosser.AutoSize = true;
            this.label_crosser.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_crosser.Location = new System.Drawing.Point(8, 179);
            this.label_crosser.Name = "label_crosser";
            this.label_crosser.Size = new System.Drawing.Size(238, 18);
            this.label_crosser.TabIndex = 3;
            this.label_crosser.Text = "Вероятность скрещивания Pc =";
            // 
            // crosser
            // 
            this.crosser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crosser.Location = new System.Drawing.Point(263, 175);
            this.crosser.Multiline = true;
            this.crosser.Name = "crosser";
            this.crosser.Size = new System.Drawing.Size(112, 25);
            this.crosser.TabIndex = 2;
            this.crosser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mutation
            // 
            this.mutation.AutoSize = true;
            this.mutation.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mutation.Location = new System.Drawing.Point(39, 223);
            this.mutation.Name = "mutation";
            this.mutation.Size = new System.Drawing.Size(207, 18);
            this.mutation.TabIndex = 5;
            this.mutation.Text = "Вероятность мутации Pm =";
            // 
            // mitation
            // 
            this.mitation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mitation.Location = new System.Drawing.Point(263, 219);
            this.mitation.Multiline = true;
            this.mitation.Name = "mitation";
            this.mitation.Size = new System.Drawing.Size(112, 25);
            this.mitation.TabIndex = 4;
            this.mitation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_iteration
            // 
            this.label_iteration.AutoSize = true;
            this.label_iteration.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iteration.Location = new System.Drawing.Point(78, 86);
            this.label_iteration.Name = "label_iteration";
            this.label_iteration.Size = new System.Drawing.Size(168, 18);
            this.label_iteration.TabIndex = 7;
            this.label_iteration.Text = "Число итераций Max =";
            // 
            // iteration
            // 
            this.iteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration.Location = new System.Drawing.Point(263, 82);
            this.iteration.Multiline = true;
            this.iteration.Name = "iteration";
            this.iteration.Size = new System.Drawing.Size(112, 25);
            this.iteration.TabIndex = 6;
            this.iteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(263, 266);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 8;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_k
            // 
            this.label_k.AutoSize = true;
            this.label_k.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_k.Location = new System.Drawing.Point(124, 132);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(122, 18);
            this.label_k.TabIndex = 21;
            this.label_k.Text = "Число путей K =";
            // 
            // k
            // 
            this.k.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k.Location = new System.Drawing.Point(263, 128);
            this.k.Multiline = true;
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(112, 25);
            this.k.TabIndex = 20;
            this.k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.Info;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(421, 266);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(112, 36);
            this.button_close.TabIndex = 47;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // ParametersGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(607, 330);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label_k);
            this.Controls.Add(this.k);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_iteration);
            this.Controls.Add(this.iteration);
            this.Controls.Add(this.mutation);
            this.Controls.Add(this.mitation);
            this.Controls.Add(this.label_crosser);
            this.Controls.Add(this.crosser);
            this.Controls.Add(this.label_population);
            this.Controls.Add(this.population);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ParametersGA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParametersGA";
            this.Load += new System.EventHandler(this.GA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_population;
        private System.Windows.Forms.Label label_crosser;
        private System.Windows.Forms.Label mutation;
        private System.Windows.Forms.Label label_iteration;
        public System.Windows.Forms.TextBox population;
        public System.Windows.Forms.TextBox crosser;
        public System.Windows.Forms.TextBox mitation;
        public System.Windows.Forms.TextBox iteration;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_k;
        public System.Windows.Forms.TextBox k;
        private System.Windows.Forms.Button button_close;
    }
}