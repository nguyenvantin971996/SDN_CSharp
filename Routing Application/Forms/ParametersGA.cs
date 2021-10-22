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
    public partial class ParametersGA : Form
    {
        public ParametersGA()
        {
            InitializeComponent();
        }

       private void GA_Load(object sender, EventArgs e)
        {
            crosser.Text = "0,8";
            mitation.Text = "0,1";
            iteration.Text = "100";
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
