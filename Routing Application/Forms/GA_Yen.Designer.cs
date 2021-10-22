namespace Routing_Application.Forms
{
    partial class GA_Yen
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
            this.label_iteration = new System.Windows.Forms.Label();
            this.iteration = new System.Windows.Forms.TextBox();
            this.mutation = new System.Windows.Forms.Label();
            this.mitation = new System.Windows.Forms.TextBox();
            this.label_crosser = new System.Windows.Forms.Label();
            this.crosser = new System.Windows.Forms.TextBox();
            this.label_population = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.TextBox();
            this.label_path = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(242, 263);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 17;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click_1);
            // 
            // label_iteration
            // 
            this.label_iteration.AutoSize = true;
            this.label_iteration.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iteration.Location = new System.Drawing.Point(84, 164);
            this.label_iteration.Name = "label_iteration";
            this.label_iteration.Size = new System.Drawing.Size(122, 18);
            this.label_iteration.TabIndex = 16;
            this.label_iteration.Text = "Число итераций";
            // 
            // iteration
            // 
            this.iteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration.Location = new System.Drawing.Point(242, 164);
            this.iteration.Multiline = true;
            this.iteration.Name = "iteration";
            this.iteration.Size = new System.Drawing.Size(112, 25);
            this.iteration.TabIndex = 15;
            this.iteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mutation
            // 
            this.mutation.AutoSize = true;
            this.mutation.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mutation.Location = new System.Drawing.Point(40, 123);
            this.mutation.Name = "mutation";
            this.mutation.Size = new System.Drawing.Size(166, 18);
            this.mutation.TabIndex = 14;
            this.mutation.Text = "Вероятность мутации";
            // 
            // mitation
            // 
            this.mitation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mitation.Location = new System.Drawing.Point(242, 119);
            this.mitation.Multiline = true;
            this.mitation.Name = "mitation";
            this.mitation.Size = new System.Drawing.Size(112, 25);
            this.mitation.TabIndex = 13;
            this.mitation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_crosser
            // 
            this.label_crosser.AutoSize = true;
            this.label_crosser.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_crosser.Location = new System.Drawing.Point(4, 78);
            this.label_crosser.Name = "label_crosser";
            this.label_crosser.Size = new System.Drawing.Size(202, 18);
            this.label_crosser.TabIndex = 12;
            this.label_crosser.Text = "Вероятность скрещивания";
            // 
            // crosser
            // 
            this.crosser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crosser.Location = new System.Drawing.Point(242, 74);
            this.crosser.Multiline = true;
            this.crosser.Name = "crosser";
            this.crosser.Size = new System.Drawing.Size(112, 25);
            this.crosser.TabIndex = 11;
            this.crosser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_population
            // 
            this.label_population.AutoSize = true;
            this.label_population.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_population.Location = new System.Drawing.Point(28, 36);
            this.label_population.Name = "label_population";
            this.label_population.Size = new System.Drawing.Size(178, 18);
            this.label_population.TabIndex = 10;
            this.label_population.Text = "Численность популяции";
            // 
            // population
            // 
            this.population.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.population.Location = new System.Drawing.Point(242, 29);
            this.population.Multiline = true;
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(112, 25);
            this.population.TabIndex = 9;
            this.population.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_path.Location = new System.Drawing.Point(112, 209);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(94, 18);
            this.label_path.TabIndex = 19;
            this.label_path.Text = "Число путей";
            // 
            // path
            // 
            this.path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.path.Location = new System.Drawing.Point(242, 209);
            this.path.Multiline = true;
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(112, 25);
            this.path.TabIndex = 18;
            this.path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GA_Yen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(442, 321);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.path);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_iteration);
            this.Controls.Add(this.iteration);
            this.Controls.Add(this.mutation);
            this.Controls.Add(this.mitation);
            this.Controls.Add(this.label_crosser);
            this.Controls.Add(this.crosser);
            this.Controls.Add(this.label_population);
            this.Controls.Add(this.population);
            this.Name = "GA_Yen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Balancer_FormClosing);
            this.Load += new System.EventHandler(this.Balancer_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_iteration;
        public System.Windows.Forms.TextBox iteration;
        private System.Windows.Forms.Label mutation;
        public System.Windows.Forms.TextBox mitation;
        private System.Windows.Forms.Label label_crosser;
        public System.Windows.Forms.TextBox crosser;
        private System.Windows.Forms.Label label_population;
        public System.Windows.Forms.TextBox population;
        private System.Windows.Forms.Label label_path;
        public System.Windows.Forms.TextBox path;
    }
}