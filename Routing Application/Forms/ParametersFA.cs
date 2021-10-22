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
    public partial class ParametersFA : Form
    {
        public ParametersFA()
        {
            InitializeComponent();
        }

        private void ParametersFA_Load(object sender, EventArgs e)
        {
            alpha.Text = "0,2";
            beta.Text = "2";
            iterations.Text = "100";
            gamma.Text = "1";
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
