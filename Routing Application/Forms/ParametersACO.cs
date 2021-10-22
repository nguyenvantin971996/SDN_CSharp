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
    public partial class ParametersACO : Form
    {
        public ParametersACO()
        {
            InitializeComponent();
        }

        private void ParametersACO_Load(object sender, EventArgs e)
        {
            evaporation.Text = "0,2";
            alpha.Text = "0,6";
            beta.Text = "0,4";
            iterations.Text = "20";
            NumberAnts.Text = "20";
            probability.Text = "0,3";
            constant.Text = "10";
            k.Text = "4";
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void button_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
