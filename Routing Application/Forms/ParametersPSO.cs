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
    public partial class ParametersPSO : Form
    {
        public ParametersPSO()
        {
            InitializeComponent();
        }

        private void ParametersPSO_Load(object sender, EventArgs e)
        {
            inertia_weight.Text = "0,9";
            acceleration_factor_c1.Text = "2";
            acceleration_factor_c2.Text = "2";
            iterations.Text = "100";
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
