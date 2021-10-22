using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Routing_Application.Forms
{
    /// <summary>
    /// класс формы Настройки
    /// </summary>
    public partial class Connectivity : Form
    {
        private double q;        // величина связности

        // открытые свойства
        #region Properties

        public double GetQ
        {
            get { return q; }
        }

        #endregion

        // конструктор
        public Connectivity(double q)
        {
            InitializeComponent();
            this.q = q;
        }

        // загрузка формы
        private void InitialDataForm_Load(object sender, EventArgs e)
        {
            txtValue.Text = q.ToString();
            ctlValueOfConBar.Value = (int)(this.q * 10) - 1;
        }

        // обработчики событий
        #region Events

        // кнопка ОК
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() == true)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        // перемещение ползунка  в ScrollBar
        private void ctlValueOfConBar_Scroll(object sender, EventArgs e)
        {
            this.q = (double)ctlValueOfConBar.Value / 10 + 0.1;
            txtValue.Text = this.q.ToString();
        }

        // валидация текстовых полей
        #region Validation

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            double q;
            if (Double.TryParse(txtValue.Text, out q) == true)
            {
                if ((q <= 1) && (q > 0))
                {
                    errorProvider.SetError(txtValue, String.Empty);
                    return;
                }
            }

            e.Cancel = true;
            string error = "This value must be less than 1 and more than 0";
            errorProvider.SetError(txtValue, error);
        }

        private void txtValue_Validated(object sender, EventArgs e)
        {
            this.q = Double.Parse(txtValue.Text);
        }

        #endregion

        #endregion
    }
}
