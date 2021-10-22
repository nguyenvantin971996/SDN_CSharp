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
    public partial class KPaths : Form
    {
        public KPaths()
        {
            InitializeComponent();
        }

        private void KPaths_Load(object sender, EventArgs e)
        {
            k.Text = "4";
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
