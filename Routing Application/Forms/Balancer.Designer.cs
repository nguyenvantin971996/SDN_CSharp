namespace Routing_Application.Forms
{
    partial class Balancer
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
            this.label_path = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.label_iteration = new System.Windows.Forms.Label();
            this.iteration = new System.Windows.Forms.TextBox();
            this.mutation = new System.Windows.Forms.Label();
            this.mitation = new System.Windows.Forms.TextBox();
            this.label_crosser = new System.Windows.Forms.Label();
            this.crosser = new System.Windows.Forms.TextBox();
            this.label_population = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iteration_1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mitation_1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.crosser_1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.population_1 = new System.Windows.Forms.TextBox();
            this.label_Yen = new System.Windows.Forms.Label();
            this.label_balancer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_path.Location = new System.Drawing.Point(137, 245);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(94, 18);
            this.label_path.TabIndex = 30;
            this.label_path.Text = "Число путей";
            // 
            // path
            // 
            this.path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.path.Location = new System.Drawing.Point(267, 245);
            this.path.Multiline = true;
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(112, 25);
            this.path.TabIndex = 29;
            this.path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(751, 285);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 28;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_iteration
            // 
            this.label_iteration.AutoSize = true;
            this.label_iteration.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iteration.Location = new System.Drawing.Point(109, 200);
            this.label_iteration.Name = "label_iteration";
            this.label_iteration.Size = new System.Drawing.Size(122, 18);
            this.label_iteration.TabIndex = 27;
            this.label_iteration.Text = "Число итераций";
            // 
            // iteration
            // 
            this.iteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration.Location = new System.Drawing.Point(267, 200);
            this.iteration.Multiline = true;
            this.iteration.Name = "iteration";
            this.iteration.Size = new System.Drawing.Size(112, 25);
            this.iteration.TabIndex = 26;
            this.iteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mutation
            // 
            this.mutation.AutoSize = true;
            this.mutation.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mutation.Location = new System.Drawing.Point(65, 159);
            this.mutation.Name = "mutation";
            this.mutation.Size = new System.Drawing.Size(166, 18);
            this.mutation.TabIndex = 25;
            this.mutation.Text = "Вероятность мутации";
            // 
            // mitation
            // 
            this.mitation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mitation.Location = new System.Drawing.Point(267, 155);
            this.mitation.Multiline = true;
            this.mitation.Name = "mitation";
            this.mitation.Size = new System.Drawing.Size(112, 25);
            this.mitation.TabIndex = 24;
            this.mitation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_crosser
            // 
            this.label_crosser.AutoSize = true;
            this.label_crosser.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_crosser.Location = new System.Drawing.Point(29, 114);
            this.label_crosser.Name = "label_crosser";
            this.label_crosser.Size = new System.Drawing.Size(202, 18);
            this.label_crosser.TabIndex = 23;
            this.label_crosser.Text = "Вероятность скрещивания";
            // 
            // crosser
            // 
            this.crosser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crosser.Location = new System.Drawing.Point(267, 110);
            this.crosser.Multiline = true;
            this.crosser.Name = "crosser";
            this.crosser.Size = new System.Drawing.Size(112, 25);
            this.crosser.TabIndex = 22;
            this.crosser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_population
            // 
            this.label_population.AutoSize = true;
            this.label_population.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_population.Location = new System.Drawing.Point(53, 72);
            this.label_population.Name = "label_population";
            this.label_population.Size = new System.Drawing.Size(178, 18);
            this.label_population.TabIndex = 21;
            this.label_population.Text = "Численность популяции";
            // 
            // population
            // 
            this.population.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.population.Location = new System.Drawing.Point(267, 65);
            this.population.Multiline = true;
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(112, 25);
            this.population.TabIndex = 20;
            this.population.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(556, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Число итераций";
            // 
            // iteration_1
            // 
            this.iteration_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration_1.Location = new System.Drawing.Point(714, 200);
            this.iteration_1.Multiline = true;
            this.iteration_1.Name = "iteration_1";
            this.iteration_1.Size = new System.Drawing.Size(112, 25);
            this.iteration_1.TabIndex = 37;
            this.iteration_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(512, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 18);
            this.label2.TabIndex = 36;
            this.label2.Text = "Вероятность мутации";
            // 
            // mitation_1
            // 
            this.mitation_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mitation_1.Location = new System.Drawing.Point(714, 155);
            this.mitation_1.Multiline = true;
            this.mitation_1.Name = "mitation_1";
            this.mitation_1.Size = new System.Drawing.Size(112, 25);
            this.mitation_1.TabIndex = 35;
            this.mitation_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(476, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "Вероятность скрещивания";
            // 
            // crosser_1
            // 
            this.crosser_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crosser_1.Location = new System.Drawing.Point(714, 110);
            this.crosser_1.Multiline = true;
            this.crosser_1.Name = "crosser_1";
            this.crosser_1.Size = new System.Drawing.Size(112, 25);
            this.crosser_1.TabIndex = 33;
            this.crosser_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(500, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Численность популяции";
            // 
            // population_1
            // 
            this.population_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.population_1.Location = new System.Drawing.Point(714, 65);
            this.population_1.Multiline = true;
            this.population_1.Name = "population_1";
            this.population_1.Size = new System.Drawing.Size(112, 25);
            this.population_1.TabIndex = 31;
            this.population_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Yen
            // 
            this.label_Yen.AutoSize = true;
            this.label_Yen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Yen.Location = new System.Drawing.Point(12, 22);
            this.label_Yen.Name = "label_Yen";
            this.label_Yen.Size = new System.Drawing.Size(367, 19);
            this.label_Yen.TabIndex = 39;
            this.label_Yen.Text = "Параметры ГА для поиска кратчайших путей";
            // 
            // label_balancer
            // 
            this.label_balancer.AutoSize = true;
            this.label_balancer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_balancer.Location = new System.Drawing.Point(475, 22);
            this.label_balancer.Name = "label_balancer";
            this.label_balancer.Size = new System.Drawing.Size(351, 19);
            this.label_balancer.TabIndex = 40;
            this.label_balancer.Text = "Параметры ГА для балансировки нагрузки";
            // 
            // Balancer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(875, 333);
            this.Controls.Add(this.label_balancer);
            this.Controls.Add(this.label_Yen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iteration_1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mitation_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.crosser_1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.population_1);
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
            this.Name = "Balancer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balancer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Balancer_FormClosing);
            this.Load += new System.EventHandler(this.Balancer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_path;
        public System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_iteration;
        public System.Windows.Forms.TextBox iteration;
        private System.Windows.Forms.Label mutation;
        public System.Windows.Forms.TextBox mitation;
        private System.Windows.Forms.Label label_crosser;
        public System.Windows.Forms.TextBox crosser;
        private System.Windows.Forms.Label label_population;
        public System.Windows.Forms.TextBox population;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox iteration_1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox mitation_1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox crosser_1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox population_1;
        private System.Windows.Forms.Label label_Yen;
        private System.Windows.Forms.Label label_balancer;
    }
}