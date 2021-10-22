using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Routing_Application.Domain;
using Routing_Application.Controls;
using System.IO;
using Routing_Application.DAL;

namespace Routing_Application.Forms
{
    /// <summary>
    /// класс формы Статистика
    /// содержит статистическую таблицу и методы управления ей
    /// </summary>
    public partial class Statistic : Form
    {
        private Main mainForm;                // ссылка на главную форму
        private bool file = false;         // вспомогательный флаг

        // конструктор
        public Statistic(Main main)
        {
            InitializeComponent();
            DoubleBuffered = true;
            mainForm = main;
        }


        private void Statistic_Load(object sender, EventArgs e)
        {
        }
        // обработчики нажатия кнопок
        #region ButtonHandlers

        // кнопка Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        // кнопка Calculate/Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mainForm.CurrentField.Network.Routers.Count > 0)
            {
                Calculate();
            }
        }

        // кнопка Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection delList = ctlTable.SelectedItems;
            if (delList.Count > 0)
            {
                foreach (ListViewItem delEl in delList)
                {
                    ctlTable.Items.Remove(delEl);
                }
                UpdateTable();
            }
        }

        // кнопка Down
        private void btnDown_Click(object sender, EventArgs e)
        {
            if ((ctlTable.SelectedItems.Count == 1) && (ctlTable.SelectedIndices[0] < ctlTable.Items.Count - 1))
            {
                ListViewItem item = ctlTable.SelectedItems[0];
                int index = ctlTable.SelectedIndices[0];

                ctlTable.Items.Remove(item);
                ctlTable.Items.Insert(index + 1, item);

                UpdateTable();
            }
            ctlTable.Focus();
        }

        // кнопка UP
        private void btnUp_Click(object sender, EventArgs e)
        {
            if ((ctlTable.SelectedItems.Count == 1) && (ctlTable.SelectedIndices[0] > 0))
            {
                ListViewItem item = ctlTable.SelectedItems[0];
                int index = ctlTable.SelectedIndices[0];

                ctlTable.Items.Remove(item);
                ctlTable.Items.Insert(index - 1, item);

                UpdateTable();
            }
            ctlTable.Focus();
        }

        // кнопка Save As
        private void btnToTxt_Click(object sender, EventArgs e)
        {
            if (file == false)
            {
                file = true;
                saveFileDialog.ShowDialog();
                file = false;
            }
        }

        #endregion

        // методы
        #region MainMethods

        // обновление номеров пунктов таблицы
        private void UpdateTable()
        {
            foreach (ListViewItem lvi in ctlTable.Items)
            {
                lvi.Text = (lvi.Index + 1).ToString();
            }
        }

        // вычисление параметров таблицы
        private void Calculate()
        {
            // предварительный пересчет параметров сегментов
            foreach (Segment segment in mainForm.CurrentField.Network.Segments)
            {
                segment.UpdateStructure();
            }

            int routersCount = mainForm.CurrentField.Network.Routers.Count;          // N
            int wiresCount = mainForm.CurrentField.Network.Wires.Count;              // M
            int segmentsCount = mainForm.CurrentField.Network.Segments.Count - 1;    // R

            int Nmin = Const.INF;                          // Nmin
            foreach (Segment segment in mainForm.CurrentField.Network.Segments)
            {
                int count = segment.Routers.Count;
                if ((count < Nmin) && (count > 0))
                {
                    Nmin = count;
                }
            }
            if (Nmin == Const.INF)
            {
                Nmin = 0;
            }                     

            int Nmax = 0;                                      // Nmax
            foreach (Segment segment in mainForm.CurrentField.Network.Segments)
            {
                int count = segment.Routers.Count;
                if (count > Nmax)
                {
                    Nmax = count;
                }
            }

            double Mmin = Const.INF;                     // Mmin
            foreach (Segment segment in mainForm.CurrentField.Network.Segments)
            {
                double count = segment.M_in;
                if ((count < Mmin) && (count > 0))
                {
                    Mmin = count;
                }
            }
            if (Mmin == Const.INF)
            {
                Mmin = 0;
            }

            double Mmax = 0;                                    // Mmax
            foreach (Segment segment in mainForm.CurrentField.Network.Segments)
            {
                double count = segment.M_in;
                if (count > Mmax)
                {
                    Mmax = count;
                }
            }           

            int Mout = 0;                                       // Mout
            foreach (Wire wire in mainForm.CurrentField.Network.Wires)
            {
                if (wire.StartRouter.Segment.Number != wire.EndRouter.Segment.Number)
                {
                    Mout += 1;
                }
            }

            int Mout_min = Const.INF;                       // Mout_min
            foreach (Segment segment in mainForm.CurrentField.Network.Segments)
            {
                if (segment.Number > 0)
                {
                    if ((segment.M_out < Mout_min) && (segment.Number > 0))
                    {
                        Mout_min = (int)segment.M_out;
                    }
                }
            }
            if (Mout_min == Const.INF)
            {
                Mout_min = 0;
            }

            int Mout_max = 0;                                     // Mout_max
            foreach (Segment segment in mainForm.CurrentField.Network.Segments)
            {
                if (segment.Number > 0)
                {
                    if ((segment.M_out > Mout_max) && (segment.Number > 0))
                    {
                        Mout_max = (int)segment.M_out;
                    }
                }
            }

            AlgDiameterCalculator alg = new AlgDiameterCalculator(mainForm.CurrentField.Network);
            int D = alg.DoAlg(mainForm.CurrentField.Network.Routers);               // D
            int Dmin = D;
            int Dmax = D;

            if (mainForm.CurrentField.Network.Segments.Count > 1)
            {
                Dmin = Const.INF;                               // Dmin 
                foreach (Segment segment in mainForm.CurrentField.Network.Segments)
                {
                    if (segment.Number > 0)
                    {
                        int intermediateResult = alg.GetDiameter(segment.Routers);
                        if (intermediateResult < Dmin)
                        {
                            Dmin = intermediateResult;
                        }
                    }
                }
                if (Dmin == Const.INF)
                {
                    Dmin = 0;
                }

                Dmax = 0;                                          // Dmax
                foreach (Segment segment in mainForm.CurrentField.Network.Segments)
                {
                    if (segment.Number > 0)
                    {
                        int intermediateResult = alg.GetDiameter(segment.Routers);
                        if (intermediateResult > Dmax)
                        {
                            Dmax = intermediateResult;
                        }
                    }
                }
            }
            
            ListViewItem lvi = new ListViewItem();

            lvi.Text = (ctlTable.Items.Count + 1).ToString();   
            lvi.SubItems.Add(routersCount.ToString());          
            lvi.SubItems.Add(wiresCount.ToString());            
            lvi.SubItems.Add(segmentsCount.ToString());         
            lvi.SubItems.Add(D.ToString());
            lvi.SubItems.Add(Dmin.ToString());
            lvi.SubItems.Add(Dmax.ToString());
            lvi.SubItems.Add(Nmin.ToString());                  
            lvi.SubItems.Add(Nmax.ToString());
            lvi.SubItems.Add(Mmin.ToString());
            lvi.SubItems.Add(Mmax.ToString());
            lvi.SubItems.Add(Mout.ToString());
            lvi.SubItems.Add(Mout_min.ToString());
            lvi.SubItems.Add(Mout_max.ToString());
            lvi.SubItems.Add(mainForm.Q.ToString());
            lvi.SubItems.Add(mainForm.ctlTabControl.SelectedTab.Text);

            ctlTable.Items.Add(lvi);
        }

        #endregion

        // обработчики событий
        #region Events

        // сохранение файла
        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
            {
                foreach (ColumnHeader header in ctlTable.Columns)
                {
                    writer.Write(header.Text + "\t");
                }
                writer.WriteLine();
                foreach (ListViewItem lvi in ctlTable.Items)
                {
                    foreach (ListViewItem.ListViewSubItem sub in lvi.SubItems)
                    {
                        writer.Write(sub.Text + "\t");
                    }
                    writer.WriteLine();
                }
            }
        }

        // обработка закрытия формы
        private void Statistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        #endregion

    }
}
