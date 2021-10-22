using System;
using System.Windows.Forms;
using System.Drawing;

using Routing_Application.Domain;
using Routing_Application.Controls;
using Routing_Application.DAL;

namespace Routing_Application.Forms
{
    /// <summary>
    /// класс формы Свойства канала связи
    /// </summary>
    public partial class WireProperties : Form
    {
        private Wire wire;      // ссылка на канал связи

        public WireProperties() { }

        // конструктор
        public WireProperties(Wire newWire)
        {
            InitializeComponent();
            this.wire = newWire;
        }

        // загрузка формы
        private void LineProperties_Load(object sender, EventArgs e)
        {
            txtDelay.Text = wire.Delay.ToString();
            txtLoad.Text = wire.Load.ToString();
            txtCapacity.Text = wire.Capacity.ToString();
            txtMetric.Text = wire.Metric.ToString();
            txtPointT.Text = wire.PointT.ToString();

            if (wire.PointS >= Const.INF)
            {
                txtPointS.Text = "INF";
            }
            else
            {
                txtPointS.Text = wire.PointS.ToString();
            }

            if (wire.Replacement != null)
            {
                txtReplacement.Text = string.Format("R{0}:R{1}", wire.Replacement.Owner.Number, wire.Replacement.Router.Number);
            }
            else
            {
                txtReplacement.Text = "NONE";
            }
        }

        // события
        #region Events

        // кнопка ОК
        private void btnOK_Click(object sender, EventArgs e)
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

        #region Validation

        private void txtAmount1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validation(txtDelay, e);
        }

        private void txtAmount1_Validated(object sender, EventArgs e)
        {
            wire.Delay = Int32.Parse(txtDelay.Text.Trim());
        }

        private void txtAmount2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validation(txtLoad, e);
        }

        private void txtAmount2_Validated(object sender, EventArgs e)
        {
            wire.Load = Int32.Parse(txtLoad.Text.Trim());
        }

        private void txtAmount3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validation(txtCapacity, e);
        }

        private void txtAmount3_Validated(object sender, EventArgs e)
        {
            wire.Capacity = Int32.Parse(txtCapacity.Text.Trim());
        }

        private void txtMetric_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validation(txtMetric, e);
        }

        private void txtMetric_Validated(object sender, EventArgs e)
        {
            wire.Metric = Int32.Parse(txtMetric.Text.Trim());
        }

        #endregion

        #endregion

        // методы
        #region Methods

        private void Validation(TextBox txtBox, System.ComponentModel.CancelEventArgs e)
        {
            string input = txtBox.Text.Trim();
            int amount;
            if (Int32.TryParse(input, out amount) == true)
            {
                if ((amount >= 0) && (amount <= 100))
                {
                    errorProvider.SetError(txtBox, String.Empty);
                    return;
                }
            }
            e.Cancel = true;
            string error = "Value must be less than 1000 and more than 1";
            errorProvider.SetError(txtBox, error);
        }


        #endregion

        private void checkBox1_Click(object sender, EventArgs e)
        {
            wire.Pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        }
    }
}
