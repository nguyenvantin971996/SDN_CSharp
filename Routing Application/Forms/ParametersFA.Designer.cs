namespace Routing_Application.Forms
{
    partial class ParametersFA
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
            this.label_gamma = new System.Windows.Forms.Label();
            this.gamma = new System.Windows.Forms.TextBox();
            this.label_beta = new System.Windows.Forms.Label();
            this.beta = new System.Windows.Forms.TextBox();
            this.label_alpha = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.TextBox();
            this.label_Number_firefly = new System.Windows.Forms.Label();
            this.number_firefly = new System.Windows.Forms.TextBox();
            this.label_iterations = new System.Windows.Forms.Label();
            this.iterations = new System.Windows.Forms.TextBox();
            this.label_k = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.Info;
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ok.Location = new System.Drawing.Point(281, 298);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(112, 36);
            this.button_ok.TabIndex = 32;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_gamma
            // 
            this.label_gamma.AutoSize = true;
            this.label_gamma.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_gamma.Location = new System.Drawing.Point(168, 166);
            this.label_gamma.Name = "label_gamma";
            this.label_gamma.Size = new System.Drawing.Size(88, 18);
            this.label_gamma.TabIndex = 31;
            this.label_gamma.Text = "Gamma y =";
            // 
            // gamma
            // 
            this.gamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gamma.Location = new System.Drawing.Point(281, 162);
            this.gamma.Multiline = true;
            this.gamma.Name = "gamma";
            this.gamma.Size = new System.Drawing.Size(112, 25);
            this.gamma.TabIndex = 30;
            this.gamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_beta
            // 
            this.label_beta.AutoSize = true;
            this.label_beta.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_beta.Location = new System.Drawing.Point(187, 211);
            this.label_beta.Name = "label_beta";
            this.label_beta.Size = new System.Drawing.Size(69, 18);
            this.label_beta.TabIndex = 29;
            this.label_beta.Text = "Бета b =";
            // 
            // beta
            // 
            this.beta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beta.Location = new System.Drawing.Point(281, 207);
            this.beta.Multiline = true;
            this.beta.Name = "beta";
            this.beta.Size = new System.Drawing.Size(112, 25);
            this.beta.TabIndex = 28;
            this.beta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_alpha
            // 
            this.label_alpha.AutoSize = true;
            this.label_alpha.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_alpha.Location = new System.Drawing.Point(168, 255);
            this.label_alpha.Name = "label_alpha";
            this.label_alpha.Size = new System.Drawing.Size(88, 18);
            this.label_alpha.TabIndex = 27;
            this.label_alpha.Text = "Альфа  a =";
            // 
            // alpha
            // 
            this.alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.alpha.Location = new System.Drawing.Point(281, 251);
            this.alpha.Multiline = true;
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(112, 25);
            this.alpha.TabIndex = 26;
            this.alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Number_firefly
            // 
            this.label_Number_firefly.AutoSize = true;
            this.label_Number_firefly.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Number_firefly.Location = new System.Drawing.Point(50, 36);
            this.label_Number_firefly.Name = "label_Number_firefly";
            this.label_Number_firefly.Size = new System.Drawing.Size(206, 18);
            this.label_Number_firefly.TabIndex = 25;
            this.label_Number_firefly.Text = "Количество светлячков N =";
            // 
            // number_firefly
            // 
            this.number_firefly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number_firefly.Location = new System.Drawing.Point(281, 32);
            this.number_firefly.Multiline = true;
            this.number_firefly.Name = "number_firefly";
            this.number_firefly.Size = new System.Drawing.Size(112, 25);
            this.number_firefly.TabIndex = 24;
            this.number_firefly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_iterations
            // 
            this.label_iterations.AutoSize = true;
            this.label_iterations.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iterations.Location = new System.Drawing.Point(88, 79);
            this.label_iterations.Name = "label_iterations";
            this.label_iterations.Size = new System.Drawing.Size(168, 18);
            this.label_iterations.TabIndex = 34;
            this.label_iterations.Text = "Число итераций Max =";
            // 
            // iterations
            // 
            this.iterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iterations.Location = new System.Drawing.Point(281, 75);
            this.iterations.Multiline = true;
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(112, 25);
            this.iterations.TabIndex = 33;
            this.iterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_k
            // 
            this.label_k.AutoSize = true;
            this.label_k.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_k.Location = new System.Drawing.Point(134, 123);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(122, 18);
            this.label_k.TabIndex = 36;
            this.label_k.Text = "Число путей K =";
            // 
            // k
            // 
            this.k.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k.Location = new System.Drawing.Point(281, 119);
            this.k.Multiline = true;
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(112, 25);
            this.k.TabIndex = 35;
            this.k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.Info;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(433, 298);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(112, 36);
            this.button_close.TabIndex = 46;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // ParametersFA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 372);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label_k);
            this.Controls.Add(this.k);
            this.Controls.Add(this.label_iterations);
            this.Controls.Add(this.iterations);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_gamma);
            this.Controls.Add(this.gamma);
            this.Controls.Add(this.label_beta);
            this.Controls.Add(this.beta);
            this.Controls.Add(this.label_alpha);
            this.Controls.Add(this.alpha);
            this.Controls.Add(this.label_Number_firefly);
            this.Controls.Add(this.number_firefly);
            this.Name = "ParametersFA";
            this.Text = "ParametersFA";
            this.Load += new System.EventHandler(this.ParametersFA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_gamma;
        public System.Windows.Forms.TextBox gamma;
        private System.Windows.Forms.Label label_beta;
        public System.Windows.Forms.TextBox beta;
        private System.Windows.Forms.Label label_alpha;
        public System.Windows.Forms.TextBox alpha;
        private System.Windows.Forms.Label label_Number_firefly;
        public System.Windows.Forms.TextBox number_firefly;
        private System.Windows.Forms.Label label_iterations;
        public System.Windows.Forms.TextBox iterations;
        private System.Windows.Forms.Label label_k;
        public System.Windows.Forms.TextBox k;
        private System.Windows.Forms.Button button_close;
    }
}