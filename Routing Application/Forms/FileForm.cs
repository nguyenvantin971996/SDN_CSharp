using System;
using System.Drawing;
using System.Windows.Forms;

using Routing_Application.DAL;
using Routing_Application.View;

namespace Routing_Application.Forms
{
    /// <summary>
    /// класс формы, задающей параметры нового файла
    /// </summary>
    public partial class NewFile : Form
    {
        private int minWidth;          // минимальная ширина Рабочего Поля
        private int minHeight;         // минимальная высота Рабочего Поля
        private string fileName;       // имя создаваемого файла
        private Size size;             // размер создаваемого Рабочего Поля
        private bool autoFilling;      // флаг автозаполнения
        private Main mainForm;

        // открытые свойства
        #region Properties

        public string FileName
        {
            get { return fileName; }
        }

        public bool AutoFilling
        {
            get { return autoFilling; }
        }

        public Size FileSize
        {
            get { return size; }
        }

        #endregion                    // открытые свойства

        // конструктор
        public NewFile()          
        {
            InitializeComponent();
        }

        // загрузка формы
        private void NewFileForm_Load(object sender, EventArgs e)
        {
            mainForm = this.Owner as Main;

            minWidth = Drawing.screenSize.Width;
            minHeight = Drawing.screenSize.Height;

            txtName.Text = String.Format("New {0}", mainForm.FileNumber);
            txtWidth.Text = minWidth.ToString();
            txtHeight.Text = minHeight.ToString();
        }

        // обработчики нажатия кнопок
        #region ButtonHandlers

        // кнопка отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // кнопка ОК
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() == true)
            {
                Size size = new Size(Int32.Parse(txtWidth.Text), Int32.Parse(txtHeight.Text));

                this.fileName = txtName.Text.Trim();
                this.size = size;

                if (chkAutoFilling.Checked == true)
                {
                    this.autoFilling = true;
                }
                else
                {
                    this.autoFilling = false;
                }

                mainForm.FileNumber += 1;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        #endregion

        // валидация текстовых полей
        #region Validation

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string input = txtName.Text.Trim();
            if (String.IsNullOrEmpty(input) == true)
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, "This field cannot be empty");
            }
            else
            {
                errorProvider.SetError(txtName, String.Empty);
            }
        }

        private void txtWidth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string input = txtWidth.Text.Trim();
            int tWidth;
            if (Int32.TryParse(input, out tWidth) == true)
            {
                if ((tWidth >= minWidth) && (tWidth <= 10000))
                {
                    errorProvider.SetError(txtWidth, String.Empty);
                    return;
                }
            }
            e.Cancel = true;
            string error = String.Format("Value must be less than 10000 and more than {0}", minWidth);
            errorProvider.SetError(txtWidth, error);
        }

        private void txtHeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string input = txtHeight.Text.Trim();
            int tHeight;
            if (Int32.TryParse(input, out tHeight) == true)
            {
                if ((tHeight >= minHeight) && (tHeight <= 10000))
                {
                    errorProvider.SetError(txtHeight, String.Empty);
                    return;
                }
            }
            e.Cancel = true;
            string error = String.Format("Value must be less than 10000 and more than {0}", minHeight);
            errorProvider.SetError(txtHeight, error);
        }

        #endregion
    }
}
