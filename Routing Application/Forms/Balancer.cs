using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routing_Application.Forms
{
    public partial class Balancer : Form
    {
        public Balancer()
        {
            InitializeComponent();
        }

        private void Balancer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult condim = MessageBox.Show("     Get value ?", "      ##### Confirm !!! #####", MessageBoxButtons.YesNo);
            if (condim == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Balancer_Load(object sender, EventArgs e)
        {
            population.Text = "100";
            crosser.Text = "0,6";
            mitation.Text = "0,05";
            iteration.Text = "20";
            path.Text = "5";

            population_1.Text = "100";
            crosser_1.Text = "0,6";
            mitation_1.Text = "0,05";
            iteration_1.Text = "20";

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
