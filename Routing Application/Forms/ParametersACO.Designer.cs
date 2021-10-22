namespace Routing_Application.Forms
{
    partial class ParametersACO
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
            this.label_beta = new System.Windows.Forms.Label();
            this.beta = new System.Windows.Forms.TextBox();
            this.label_alpha = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.TextBox();
            this.label_evaporation = new System.Windows.Forms.Label();
            this.evaporation = new System.Windows.Forms.TextBox();
            this.label_probability = new System.Windows.Forms.Label();
            this.probability = new System.Windows.Forms.TextBox();
            this.label_NumberAnts = new System.Windows.Forms.Label();
            this.NumberAnts = new System.Windows.Forms.TextBox();
            this.label_constant = new System.Windows.Forms.Label();
            this.constant = new System.Windows.Forms.TextBox();
            this.label_k = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(362, 381);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 17;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_iterations
            // 
            this.label_iterations.AutoSize = true;
            this.label_iterations.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iterations.Location = new System.Drawing.Point(169, 75);
            this.label_iterations.Name = "label_iterations";
            this.label_iterations.Size = new System.Drawing.Size(168, 18);
            this.label_iterations.TabIndex = 16;
            this.label_iterations.Text = "Число итераций Max =";
            // 
            // iterations
            // 
            this.iterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iterations.Location = new System.Drawing.Point(362, 71);
            this.iterations.Multiline = true;
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(112, 25);
            this.iterations.TabIndex = 15;
            this.iterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_beta
            // 
            this.label_beta.AutoSize = true;
            this.label_beta.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_beta.Location = new System.Drawing.Point(268, 255);
            this.label_beta.Name = "label_beta";
            this.label_beta.Size = new System.Drawing.Size(69, 18);
            this.label_beta.TabIndex = 14;
            this.label_beta.Text = "Бета b =";
            // 
            // beta
            // 
            this.beta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beta.Location = new System.Drawing.Point(362, 251);
            this.beta.Multiline = true;
            this.beta.Name = "beta";
            this.beta.Size = new System.Drawing.Size(112, 25);
            this.beta.TabIndex = 13;
            this.beta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_alpha
            // 
            this.label_alpha.AutoSize = true;
            this.label_alpha.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_alpha.Location = new System.Drawing.Point(249, 210);
            this.label_alpha.Name = "label_alpha";
            this.label_alpha.Size = new System.Drawing.Size(88, 18);
            this.label_alpha.TabIndex = 12;
            this.label_alpha.Text = "Альфа  a =";
            // 
            // alpha
            // 
            this.alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.alpha.Location = new System.Drawing.Point(362, 206);
            this.alpha.Multiline = true;
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(112, 25);
            this.alpha.TabIndex = 11;
            this.alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_evaporation
            // 
            this.label_evaporation.AutoSize = true;
            this.label_evaporation.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_evaporation.Location = new System.Drawing.Point(41, 164);
            this.label_evaporation.Name = "label_evaporation";
            this.label_evaporation.Size = new System.Drawing.Size(296, 18);
            this.label_evaporation.TabIndex = 10;
            this.label_evaporation.Text = "Коэффициент испарения феромона p =";
            // 
            // evaporation
            // 
            this.evaporation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.evaporation.Location = new System.Drawing.Point(362, 160);
            this.evaporation.Multiline = true;
            this.evaporation.Name = "evaporation";
            this.evaporation.Size = new System.Drawing.Size(112, 25);
            this.evaporation.TabIndex = 9;
            this.evaporation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_probability
            // 
            this.label_probability.AutoSize = true;
            this.label_probability.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_probability.Location = new System.Drawing.Point(138, 299);
            this.label_probability.Name = "label_probability";
            this.label_probability.Size = new System.Drawing.Size(199, 18);
            this.label_probability.TabIndex = 21;
            this.label_probability.Text = "Вероятность выбора p0 =";
            // 
            // probability
            // 
            this.probability.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.probability.Location = new System.Drawing.Point(362, 295);
            this.probability.Multiline = true;
            this.probability.Name = "probability";
            this.probability.Size = new System.Drawing.Size(112, 25);
            this.probability.TabIndex = 20;
            this.probability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_NumberAnts
            // 
            this.label_NumberAnts.AutoSize = true;
            this.label_NumberAnts.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_NumberAnts.Location = new System.Drawing.Point(141, 31);
            this.label_NumberAnts.Name = "label_NumberAnts";
            this.label_NumberAnts.Size = new System.Drawing.Size(196, 18);
            this.label_NumberAnts.TabIndex = 19;
            this.label_NumberAnts.Text = "Количество муравьев N =";
            // 
            // NumberAnts
            // 
            this.NumberAnts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberAnts.Location = new System.Drawing.Point(362, 27);
            this.NumberAnts.Multiline = true;
            this.NumberAnts.Name = "NumberAnts";
            this.NumberAnts.Size = new System.Drawing.Size(112, 25);
            this.NumberAnts.TabIndex = 18;
            this.NumberAnts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_constant
            // 
            this.label_constant.AutoSize = true;
            this.label_constant.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_constant.Location = new System.Drawing.Point(235, 343);
            this.label_constant.Name = "label_constant";
            this.label_constant.Size = new System.Drawing.Size(102, 18);
            this.label_constant.TabIndex = 23;
            this.label_constant.Text = "Констант Q =";
            // 
            // constant
            // 
            this.constant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.constant.Location = new System.Drawing.Point(362, 339);
            this.constant.Multiline = true;
            this.constant.Name = "constant";
            this.constant.Size = new System.Drawing.Size(112, 25);
            this.constant.TabIndex = 22;
            this.constant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_k
            // 
            this.label_k.AutoSize = true;
            this.label_k.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_k.Location = new System.Drawing.Point(215, 120);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(122, 18);
            this.label_k.TabIndex = 46;
            this.label_k.Text = "Число путей K =";
            // 
            // k
            // 
            this.k.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k.Location = new System.Drawing.Point(362, 116);
            this.k.Multiline = true;
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(112, 25);
            this.k.TabIndex = 45;
            this.k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.Info;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(516, 381);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(112, 36);
            this.button_close.TabIndex = 47;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // ParametersACO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 442);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label_k);
            this.Controls.Add(this.k);
            this.Controls.Add(this.label_constant);
            this.Controls.Add(this.constant);
            this.Controls.Add(this.label_probability);
            this.Controls.Add(this.probability);
            this.Controls.Add(this.label_NumberAnts);
            this.Controls.Add(this.NumberAnts);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_iterations);
            this.Controls.Add(this.iterations);
            this.Controls.Add(this.label_beta);
            this.Controls.Add(this.beta);
            this.Controls.Add(this.label_alpha);
            this.Controls.Add(this.alpha);
            this.Controls.Add(this.label_evaporation);
            this.Controls.Add(this.evaporation);
            this.Name = "ParametersACO";
            this.Text = "ParametersACO";
            this.Load += new System.EventHandler(this.ParametersACO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_iterations;
        public System.Windows.Forms.TextBox iterations;
        private System.Windows.Forms.Label label_beta;
        public System.Windows.Forms.TextBox beta;
        private System.Windows.Forms.Label label_alpha;
        public System.Windows.Forms.TextBox alpha;
        private System.Windows.Forms.Label label_evaporation;
        public System.Windows.Forms.TextBox evaporation;
        private System.Windows.Forms.Label label_probability;
        public System.Windows.Forms.TextBox probability;
        private System.Windows.Forms.Label label_NumberAnts;
        public System.Windows.Forms.TextBox NumberAnts;
        private System.Windows.Forms.Label label_constant;
        public System.Windows.Forms.TextBox constant;
        private System.Windows.Forms.Label label_k;
        public System.Windows.Forms.TextBox k;
        private System.Windows.Forms.Button button_close;
    }
}