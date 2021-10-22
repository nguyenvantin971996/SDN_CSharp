using Routing_Application.Domain;
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
    public partial class EditText : Form
    {
        private TextLabel textLabel;

        public EditText(TextLabel textLabel)
        {
            InitializeComponent();
            this.textLabel = textLabel;
            txtText.Text = textLabel.Text;
        }

        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textLabel.UpdateText(txtText.Text);
                Close();
            }
        }

        public void SetLocation(Point p)
        {
            this.Location = new Point(p.X - txtText.Size.Width / 2, p.Y - txtText.Size.Height / 2);
        }
    }
}
