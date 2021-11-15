using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

using Routing_Application.DAL;
using Routing_Application.Domain;
using Routing_Application.Controls;
using Routing_Application.Enums;
using Routing_Application.View;
using System.Collections.Generic;

namespace Routing_Application.Forms
{
    public partial class Main : Form
    {
        // окно управления парными переходами и парными перестановками
        public WorkField CurrentField { get; set; }   // ссылка на текущее Рабочее Поле
        public Instruments Instrument { get; set; }   // текущий инструмент
        public Criterias Criterion { get; set; }      // текущий критерий ребра
        public bool PairSwitchAlg { get; set; }       // DEL
        public bool AutoWeight { get; set; }          // автоинициализация критериев ребра ( вкл / откл )
        public int FileNumber { get; set; }           // переменная, хранящая номер файла
        public bool FullMesh { get; set; }            // флаг полносвязного формирования сети
        public double Q { get; set; }                 // величина связности

        private bool fileOperation = false;           // флаг загрузки файла
        private Statistic statisticTable;             // окно статистики
        private List<int> tt = new List<int>() ;
        private List<int> ttt = new List<int>();
        private List<double> load_1 = new List<double>();
        private List<int> crt = new List<int>();
        private List<Individual> trs = new List<Individual>();
        private List<Individual> trss = new List<Individual>();
        private string algorithm;
        public Random ran = new Random();
        //khoi tao population ban dau
        List<Individual> population_starting = new List<Individual>();
        List<Individual> population_noRepeat = new List<Individual>();
        // конструктор основной формы
        public Main()
        {
            InitializeComponent();
            statisticTable = new Statistic(this);
            Instrument = Instruments.Edit;
            Criterion = Criterias.Metric;
            AutoWeight = true;
            Q = 0.3;
        }

        // загрузка основной формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            // создать первый файл
            CreateFile(Screen.PrimaryScreen.Bounds.Size, false, "New 0");
            SizeInfoRefresh(Screen.PrimaryScreen.Bounds.Size);
            FileNumber += 1;
        }

        // управление вкладками Файл
        #region MenuFile

        // событие: развертывание меню Файл
        private void menuFile_DropDownOpening(object sender, EventArgs e)
        {

        }

        // событие: пункт Новый Файл выбран
        private void MenuFileNew_Click(object sender, EventArgs e)
        {
            // создать новый файл
            NewFile();
        }

        // событие: пункт Открыть Файл выбран
        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            // открыть файл
            OpenFile();
        }

        // событие: пункт Сохранить Файл Как выбран
        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            // сохранить файл под другим именем
            SaveAs();
        }

        // событие: пункт Сохранить Файл выбран
        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            // сохранить файл
            Save();
        }

        // событие: пункт Выход выбран
        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            // завершить работу приложения
            Close();
        }

        // событие: пункт Закрыть Файл выбран
        private void MenuFileClose_Click(object sender, EventArgs e)
        {
            // закрыть файл
            CloseFile();
        }

        #endregion

        // управление вкладками Инструменты
        #region MenuTools

        // событие: пункт Вертикальное Выравнивание выбран
        private void menuToolsVertAlignment_Click(object sender, EventArgs e)
        {
            VerticalAlignment();
        }

        // событие: пункт Горизонтальное Выравнивание выбран
        private void menuToolsHorAlignment_Click(object sender, EventArgs e)
        {
            HorizontalAlignment();
        }

        // событие: пункт Удвлить Все выбран
        private void menuToolsDeleteAll_Click(object sender, EventArgs e)
        {
            if (CurrentField.Network.Routers.Count > 5)
            {
                if (MessageBox.Show("Are you sure?", "### Info ###", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    return;
                }
            }

            CurrentField.DeleteAll();
        }

        // событие: пункт Текстовая Метка выбран
        private void menuToolsCreateText_Click(object sender, EventArgs e)
        {
            InsertTextLabel();
        }

        // событие: пункт Редактирование выбран
        private void menuToolsEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // событие: пункт Узел Связи выбран
        private void menuToolsInsertRouter_Click(object sender, EventArgs e)
        {
            InsertRouter();
        }

        // событие: пункт Канал Связи выбран
        private void menuToolsInsertWire_Click(object sender, EventArgs e)
        {
            InsertWire();
        }

        // событие: пункт Сброс выбран
        private void menuToolsReset_Click(object sender, EventArgs e)
        {
            Recalculate();
        }

        #endregion

        // управление вкладками Алгоритмы
        #region MenuAlgorithms

        private void menuAlgorithmsYen_Click(object sender, EventArgs e)
        {

        }

        private void menuAlgorithmsYenCross_Click(object sender, EventArgs e)
        {

        }

        private void menuAlgorithmsPairShift_Click(object sender, EventArgs e)
        {
            PairSwitchAlg = false;

            AlgPairShift alg = new AlgPairShift(CurrentField.Network);

            // проверки целостности графа
            int result = alg.Check(CurrentField.Network.Routers);
            if (result == 1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Router is not selected!",
                                      "### Warning! ###",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                return;
            }
            else if (result == -1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                      "### Warning! ###",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                return;
            }

            // подготовка графа к обработки парных переходов
            foreach (Segment segment in CurrentField.Network.Segments)
            {
                if (segment.Routers.Count > 0)
                {
                    Router workingRouter = segment.Routers[0];
                    foreach (Router router in segment.Routers)
                    {
                        if (CurrentField.SelectedRouters.Contains(router) == true)
                        {
                            workingRouter = router;
                            break;
                        }
                    }

                    alg.Dejkstra(workingRouter);
                    alg.DoAlg(segment);
                }
            }

            CurrentField.ToolKit.UpdateField();

            // вызов меню парных переходов
        }

        public void Dejkstra(object sender, EventArgs e)
        {
            Algorithm alg = new Algorithm(CurrentField.Network);

            int result = alg.Check(CurrentField.SelectedRouters);
            if (result == 1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Router is not selected!",
                                      "### Warning! ###",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                return;
            }
            else if (result == -1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                      "### Warning! ###",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                return;
            }

            AlgDejkstra algD = new AlgDejkstra(CurrentField.Network);
            CurrentField.Network.WiresRecolor();
            algD.DoAlg(CurrentField.SelectedRouters[0]);

            int rCount = CurrentField.SelectedRouters[0].Segment.Routers.Count;
            string output = String.Format("Successful!\nO(n^2) = {0}", rCount * rCount);

            CurrentField.ToolKit.UpdateField();
            MessageBox.Show(this, output, "### Info ###", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Prim(object sender, EventArgs e)
        {
            AlgPrim algPrim = new AlgPrim(CurrentField.Network);

            int result = algPrim.Check(CurrentField.SelectedRouters);
            if (result == 1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Router is not selected!", "### Warning! ###", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (result == -1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!", "### Warning! ###", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            algPrim.DoAlg(CurrentField.SelectedRouters[0], true);

            CurrentField.ToolKit.UpdateField();
            MessageBox.Show(this, "Successful!", "### Info ###", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Segmentation(object sender, EventArgs e)
        {
            AlgSegmentation alg = new AlgSegmentation(CurrentField.Network);

            int result = alg.Check(CurrentField.SelectedRouters);
            if (result == 1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Router is not selected!", "### Warning! ###", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (result == -1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!", "### Warning! ###", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            alg.Segmentation(CurrentField.SelectedRouters[0], Q);

            CurrentField.Network.RoutersRepaint();
            CurrentField.ToolKit.UpdateField();
            MessageBox.Show(this, "Successful!", "### Info ###", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OptimalRout(object sender, EventArgs e)
        {
            Algorithm alg = new Algorithm(CurrentField.Network);

            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }

                AlgOptimalRout algSP = new AlgOptimalRout(CurrentField.Network);
                int laboriousness = algSP.DoAlg(CurrentField.SelectedRouters[0],
                                                  CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1]);
                int rCount = CurrentField.SelectedRouters[0].Segment.Routers.Count;
                string output = String.Format("Successful!\nL_common: {0}", laboriousness);

                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, output, "### Info ###", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Please select two routers!", "### Warning! ###",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void PairSwitch(object sender, EventArgs e)
        {
            PairSwitchAlg = true;

            AlgPairSwitch alg = new AlgPairSwitch(CurrentField.Network);

            // проверки целостности графа
            int result = alg.Check(CurrentField.Network.Routers);
            if (result == 1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Router is not selected!",
                                      "### Warning! ###",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                return;
            }
            else if (result == -1)
            {
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                      "### Warning! ###",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                return;
            }

            // подготовка графа к обработки парных переходов
            foreach (Segment segment in CurrentField.Network.Segments)
            {
                if (segment.Routers.Count > 0)
                {
                    Router workingRouter = segment.Routers[0];
                    foreach (Router router in segment.Routers)
                    {
                        if (CurrentField.SelectedRouters.Contains(router) == true)
                        {
                            workingRouter = router;
                            break;
                        }
                    }

                    alg.Dejkstra(workingRouter);
                    alg.Preparation(segment);
                }
            }

            CurrentField.ToolKit.UpdateField();
        }

        #endregion

        // управление вкладками Сеть
        #region MenuNetwork

        // событие: пункт Статистическая Таблица выбран
        private void menuNetworkStatTable_Click(object sender, EventArgs e)
        {
            // показать статистическую таблицу
            statisticTable.Show();
        }

        #endregion

        // управление вкладками Настройки
        #region MenuOptions

        // событие: пункт Случайный Вес выбран
        private void menuOptionsAutoWeight_Click(object sender, EventArgs e)
        {
            if (menuOptionsAutoWeight.Checked == false)
            {
                AutoWeight = false;
            }
            else
            {
                AutoWeight = true;
            }
        }

        // событие: пункт Панель Инструментов выбран
        private void MenuOptionsToolBar_Click(object sender, EventArgs e)
        {
            if (menuOptionsToolBar.Checked == false)
            {
                // убрать Панель инструментов
                ctlToolBar.Hide();
                ctlToolBar.Enabled = false;
                ctlTabControl.Location = new Point(0, 24);
                ctlTabControl.Size = new Size(ctlTabControl.Size.Width, ctlTabControl.Size.Height + 44);
            }
            else
            {
                // показать Панель инструментов
                ctlTabControl.Location = new Point(0, 68);
                ctlTabControl.Size = new Size(ctlTabControl.Size.Width, ctlTabControl.Size.Height - 44);
                ctlToolBar.Enabled = true;
                ctlToolBar.Show();
            }
        }

        // событие: пункт Величиа Связности выбран
        private void menuOptionsConnectivity_Click(object sender, EventArgs e)
        {
            Connectivity connectivityForm = new Connectivity(Q);

            if (connectivityForm.ShowDialog(this) == DialogResult.OK)
            {
                // получить новое значение величины связности
                Q = connectivityForm.GetQ;
                // вывести статус величины связности
            }
        }

        // событие: пункт Полносвязность выбран
        private void menuOptionsFullMesh_Click(object sender, EventArgs e)
        {
            if (menuOptionsFullMesh.Checked == false)
            {
                // включить полносвязный режим
                FullMesh = false;
            }
            else
            {
                // выключить полносвязный режим
                FullMesh = true;
            }
        }

        // событие: пункт Пропускная Способность выбран
        private void menuOptionsCriteriasCapacity_Click(object sender, EventArgs e)
        {
            // выбрать критерий ребер Пропускная способость
            CapacityOn();
        }

        // событие: пункт Цена выбран
        private void menuOptionsCriteriasLoad_Click(object sender, EventArgs e)
        {
            foreach (Wire wire in CurrentField.Network.Wires)
            {
                wire.UpdateCriterion(Criterias.Load,(1+ran.Next(15))*wire.NumberRepeat);
                wire.UpdateInfo(Criterias.Load);
            }
            // выбрать критерий ребер Цена
            LoadOn();
        }

        // событие: пункт Задержка выбран
        private void menuOptionsCriteriasDelay_Click(object sender, EventArgs e)
        {
            // выбрать критерий ребер Задержка
            DelayOn();
        }

        // событие: пункт Метрика выбран
        private void menuOptionsCriteriasMetric_Click(object sender, EventArgs e)
        {
            // выбрать критерий ребер Метрика
            MetricOn();
        }

        #endregion

        // управление вкладками Файл
        #region ToolBar

        // событие: кнопка Пересчитать нажата
        private void btnToolRecalculate_Click(object sender, EventArgs e)
        {
            // обработка динамических изменений в сети
            Recalculate();
        }

        // событие: кнопка Сброс нажата
        private void btnToolReset_Click(object sender, EventArgs e)
        {
            // очистьить сеть от результатов работы алгоритмов
            Reset();
        }

        // событие: кнопка Текстовая Метка нажата
        private void btnToolTextLabel_Click(object sender, EventArgs e)
        {
            // выбрать инструмент Текстовая Метка
            InsertTextLabel();
        }

        // событие: кнопка Редактировать нажата
        private void btnToolEdit_Click(object sender, EventArgs e)
        {
            // выбрать инструмент Редактировать
            Edit();
        }

        // событие: кнопка Канал Связи нажата
        private void btnToolWire_Click(object sender, EventArgs e)
        {
            // выбрать инструмент Канал Связи
            InsertWire();
        }

        // событие: кнопка Узел Связи нажата
        private void btnToolRouter_Click(object sender, EventArgs e)
        {
            // выбрать инструмент Узел Связи
            InsertRouter();
        }

        // событие: кнопка Удалить Все нажата
        private void btnToolDeleteAll_Click(object sender, EventArgs e)
        {
            // удалить все объекты с текущего Рабочего Поля
            CurrentField.DeleteAll();
        }

        // событие: кнопка Новый Файл нажата
        private void btnToolNew_Click(object sender, EventArgs e)
        {
            // создать новый файл
            NewFile();
        }

        // событие: кнопка Открыть Файл нажата
        private void btnToolOpen_Click(object sender, EventArgs e)
        {
            // проверить, производится ли работа с файлом
            if (fileOperation == false)
            {
                fileOperation = true;
                // открыть файл
                OpenFile();
                fileOperation = false;
            }
        }

        // событие: кнопка Сохранить Файл нажата
        private void btnToolSave_Click(object sender, EventArgs e)
        {
            // проверить, производится ли работа с файлом
            if (fileOperation == false)
            {
                fileOperation = true;
                // пересохранить файл
                Save();
                fileOperation = false;
            }
        }

        // событие: кнопка Сохранить Как нажата
        private void btnToolSaveAs_Click(object sender, EventArgs e)
        {
            // проверить, производится ли работа с файлом
            if (fileOperation == false)
            {
                fileOperation = true;
                // сохранить файл
                SaveAs();
                fileOperation = false;
            }
        }

        // событие: кнопка Горизонтальное Выравнивание нажата
        private void btnToolHorAlignment_Click(object sender, EventArgs e)
        {
            // выполнить горизонтальное выравнивание
            HorizontalAlignment();
        }

        // событие: кнопка Вертикальное Выравнивание нажата
        private void btnToolVertAlignment_Click(object sender, EventArgs e)
        {
            // выполнить вертикальное выравнивание
            VerticalAlignment();
        }

        #endregion

        // управление контекстными меню
        #region ContextMenu

        // событие: закрыть вкладку
        private void ContextClose_Click(object sender, EventArgs e)
        {
            // закрыть файл
            CloseFile();
        }

        // событие: развертывание контекстного меню
        private void ctlContextMenu_Opening(object sender, CancelEventArgs e)
        {
            // если открыта не одна вкладка
            if (ctlTabControl.TabCount > 1)
            {
                // разрешить закрытие вкладки
                contextClose.Enabled = true;
            }
            else // иначе 
            {
                // запретить закрытие вкладки
                contextClose.Enabled = false;
            }
        }

        #endregion

        // управление диалоговыми окнами
        #region Dialogs

        // событие: принять изменения диалога сохранения файла
        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            // сохранить файл
            SaveFile(saveFileDialog.FileName);
        }

        // событие: принять изменения диалога открытие файла
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            // получить путь к файлу
            string filePath = openFileDialog.FileName.Trim();

            // создать вкладку
            TabPage page = new TabPage(FileNameParse(filePath));
            page.Controls.Add(CurrentField = GetWorkFieldFromDisk(filePath));

            // добавить вкладку в контейнер вкладок
            ctlTabControl.TabPages.Add(page);
            ctlTabControl.SelectedTab = page;
        }

        #endregion

        // обработчики событий
        #region EventHandlers

        // событие: изменение текущей вкладки
        private void ctlTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentField.CtrlIsCliced = false;
            // обновить указатель на текущее поле 
            CurrentField = ctlTabControl.SelectedTab.Controls[0] as WorkField;

            // вывести статус открытой вкладки
            SizeInfoRefresh(CurrentField.FieldSize);
            RoutersRefresh(CurrentField.Network.Routers.Count);
            WiresRefresh(CurrentField.Network.Wires.Count);

            // DEL
            // если включен режим парных переходов или парных перестановок ...

        }

        // событие: двойной клик на форме
        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // если клик произведен левой кнопкой мыши ...
            if (e.Button == MouseButtons.Left)
            {
                // создать новый файл
                NewFile();
            }
        }

        // событие: клавиша нажата
        private void ctlTabControl_KeyDown(object sender, KeyEventArgs e)
        {
            // если нажата клавиша Ctrl 
            if (e.Control == true)
            {
                // установить флаг множественного выбора
                CurrentField.CtrlIsCliced = true;
                return;
            }

            // обработка 'горячих' клавиш
            switch (e.KeyCode)
            {
                case Keys.E:
                    // выбрать инструмент Редактирование
                    Edit();
                    break;

                case Keys.W:
                    // выбрать инструмент Канал Связи
                    InsertWire();
                    break;

                case Keys.R:
                    // выбрать инструмент Узел Связи
                    InsertRouter();
                    break;

                case Keys.P:
                    // очистить рабочее поле
                    CurrentField.DeleteAll();
                    break;

                case Keys.Delete:
                    // удалить выбранный элемент с рабочего поля
                    CurrentField.DeleteSelectedElement();
                    break;
            }
        }

        // событие: клавиша отпущена
        private void ctlTabControl_KeyUp(object sender, KeyEventArgs e)
        {
            // если отпущена клавиша Ctrl 
            if (e.Control == false)
            {
                // снять флаг множественного выбора
                CurrentField.CtrlIsCliced = false;
            }
        }

        #endregion

        // управление панелью статуса
        #region StatusBar

        // вывод координат мыши
        public void CoordsRefresh(int x, int y)
        {
            lblGreed.Text = String.Format("Greed: {0}, {1}", x, y);
        }

        // вывод числа узлов связи
        public void RoutersRefresh(int count)
        {
            lblRouters.Text = String.Format("   Routers: {0}", count);
        }

        // вывод числа сегментов

        // вывод числа каналов связи
        public void WiresRefresh(int count)
        {
            lblWires.Text = String.Format("   Wires: {0}", count);
        }

        // вывод названия используемого инструмента
        public void InstrumentRefresh(string instr)
        {
            lblInstrument.Text = instr;
        }

        // вывод размерности рабочего поля
        private void SizeInfoRefresh(Size size)
        {
            string info = String.Format("Field Size: {0} x {1}", size.Width, size.Height);
            lblFieldSize.Text = info;
        }

        #endregion

        // основные методы
        #region MainMethods

        // создание нового файла
        private void NewFile()
        {
            // создание формы, запрашивающей начальную информацию о файле
            NewFile newFile = new NewFile();

            // если поля формы заполнены правильно ...
            if (newFile.ShowDialog(this) == DialogResult.OK)
            {
                // создать новый файл
                CreateFile(newFile.FileSize, newFile.AutoFilling, newFile.FileName);
            }
        }

        // закрытие файла
        private void CloseFile()
        {
            if (ctlTabControl.Controls.Count > 1)
            {
                CloseSelectedPage();
            }
        }

        // сохранение файла
        private void Save()
        {
            // если файл уже на диске ...
            if ((CurrentField.FilePath != null) && (File.Exists(CurrentField.FilePath)))
            {
                // произвести выстрое сохранение
                SaveFile(CurrentField.FilePath);
                MessageBox.Show("Saved!", "### Info ###", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // иначе ...
            {
                // записать файл на диск
                saveFileDialog.FileName = ctlTabControl.SelectedTab.Text;
                saveFileDialog.ShowDialog();
            }
        }

        // сохранение файла под другим именем
        private void SaveAs()
        {
            saveFileDialog.FileName = ctlTabControl.SelectedTab.Text;
            saveFileDialog.ShowDialog();
        }

        // открытие файла
        private void OpenFile()
        {
            openFileDialog.ShowDialog();
        }

        // извлечение имени файла из пути к нему
        private string FileNameParse(string path)
        {
            string[] tmp = path.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
            int lenght = tmp.Length;

            Regex regex = new Regex(@"(?<name>.+).rsv", RegexOptions.Compiled);
            if (regex.IsMatch(tmp[lenght - 1]) == true)
            {
                Match match = regex.Match(tmp[lenght - 1]);
                return match.Groups["name"].Value;
            }

            return String.Format("New {0}", FileNumber++); ;
        }

        // считывание файла с диска
        private WorkField GetWorkFieldFromDisk(string fileName)
        {
            Data data = null;

            using (Stream stream = File.OpenRead(fileName))
            {
                BinaryFormatter deserializer = new BinaryFormatter();

                try
                {
                    data = deserializer.Deserialize(stream) as Data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "### Warning ###", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }

            // создание Рабочего Поля на основе считанной информации
            WorkField field = new WorkField(this,
                                            CheckSize(data.FieldSize.Width, Screen.PrimaryScreen.Bounds.Size.Width,
                                                      data.FieldSize.Height, Screen.PrimaryScreen.Bounds.Size.Height),
                                            fileName,
                                            data.Network,
                                            CurrentField.PicBoxCursor);
            return field;
        }

        // обработка динамических изменений в сети
        private void Recalculate()
        {
            if (PairSwitchAlg == true)
            {
                AlgPairSwitch alg = new AlgPairSwitch(CurrentField.Network);

                foreach (Segment segment in CurrentField.Network.Segments)
                {
                    if (segment.Routers.Count > 0)
                    {
                        CurrentField.ToolKit.UpdateField();
                        segment.PairSwitches = alg.DoAlg(segment);
                    }
                }
            }
            else
            {
                AlgPairShift alg = new AlgPairShift(CurrentField.Network);

                foreach (Segment segment in CurrentField.Network.Segments)
                {
                    if (segment.Routers.Count > 0)
                    {
                        CurrentField.ToolKit.UpdateField();
                        segment.PairSwitches = alg.DoAlg(segment);
                    }
                }
            }
        }

        // выбрать инструмент Узел Связи
        private void InsertRouter()
        {
            // обновить переменную Инструмент
            Instrument = Instruments.Insert_Router;

            // обновить панели меню
            btnToolEdit.Checked = false;
            btnToolRouter.Checked = true;
            btnToolWire.Checked = false;
            btnToolTextLabel.Checked = false;

            // применить изменения ко всем вкладкам
            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;

                field.PicBoxCursor = Cursors.Cross;
                field.PicBoxContextMenuSwitch(false);
                field.SelectedWire = null;
                field.SelectedRouters.Clear();
            }

            // обновить статус Инструмента
            InstrumentRefresh(Instrument.ToString());
        }

        // выбрать инструмент Канал Связи
        private void InsertWire()
        {
            // обновить переменную Инструмент
            Instrument = Instruments.Insert_Wire;

            // обновить панели меню
            btnToolEdit.Checked = false;
            btnToolRouter.Checked = false;
            btnToolWire.Checked = true;
            btnToolTextLabel.Checked = false;

            // применить изменения ко всем вкладкам
            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;

                field.PicBoxCursor = Cursors.Cross;
                field.PicBoxContextMenuSwitch(false);
                field.SelectedWire = null;
                field.SelectedRouters.Clear();
            }

            // обновить статус Инструмента
            InstrumentRefresh(Instrument.ToString());
        }

        // выбрать инструмент Редактирование
        private void Edit()
        {
            // обновить переменную Инструмент
            Instrument = Instruments.Edit;

            // обновить панели меню
            btnToolEdit.Checked = true;
            btnToolRouter.Checked = false;
            btnToolWire.Checked = false;
            btnToolTextLabel.Checked = false;

            // применить изменения ко всем вкладкам
            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;

                field.PicBoxCursor = Cursors.Arrow;
                field.PicBoxContextMenuSwitch(true);
            }

            // обновить статус Инструмента
            InstrumentRefresh(Instrument.ToString());
        }

        // выбрать инструмент Текстовая метка
        private void InsertTextLabel()
        {
            // обновить переменную Инструмент
            Instrument = Instruments.Create_Text;

            // обновить панели меню
            btnToolEdit.Checked = false;
            btnToolRouter.Checked = false;
            btnToolWire.Checked = false;
            btnToolTextLabel.Checked = true;

            // применить изменения ко всем вкладкам
            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;

                field.PicBoxCursor = Cursors.Arrow;
                field.PicBoxContextMenuSwitch(false);
                field.SelectedWire = null;
                field.SelectedRouters.Clear();
            }

            // обновить статус Инструмента
            InstrumentRefresh(Instrument.ToString());
        }

        // выбрать критерий ребер Метрика
        private void MetricOn()
        {
            Criterion = Criterias.Metric;

            menuOptionsCriteriasDelay.Checked = false;
            menuOptionsCriteriasLoad.Checked = false;
            menuOptionsCriteriasCapacity.Checked = false;
            menuOptionsCriteriasMetric.Checked = true;

            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;
                foreach (Wire wire in field.Network.Wires)
                {
                    wire.UpdateInfo(Criterion);
                }
            }

            CurrentField.ToolKit.UpdateField();
        }

        // выбрать критерий ребер Задержка
        private void DelayOn()
        {
            Criterion = Criterias.Delay;

            menuOptionsCriteriasDelay.Checked = true;
            menuOptionsCriteriasLoad.Checked = false;
            menuOptionsCriteriasCapacity.Checked = false;
            menuOptionsCriteriasMetric.Checked = false;

            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;
                foreach (Wire wire in field.Network.Wires)
                {
                    wire.UpdateInfo(Criterion);
                }
            }

            CurrentField.ToolKit.UpdateField();
        }

        // выбрать критерий ребер Цена
        private void LoadOn()
        {
            Criterion = Criterias.Load;

            menuOptionsCriteriasDelay.Checked = false;
            menuOptionsCriteriasLoad.Checked = true;
            menuOptionsCriteriasCapacity.Checked = false;
            menuOptionsCriteriasMetric.Checked = false;

            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;
                foreach (Wire wire in field.Network.Wires)
                {
                    wire.UpdateInfo(Criterion);
                }
            }

            CurrentField.ToolKit.UpdateField();
        }

        // выбрать критерий ребер Пропускная Способность
        private void CapacityOn()
        {
            Criterion = Criterias.Capacity;

            menuOptionsCriteriasDelay.Checked = false;
            menuOptionsCriteriasLoad.Checked = false;
            menuOptionsCriteriasCapacity.Checked = true;
            menuOptionsCriteriasMetric.Checked = false;

            foreach (TabPage page in ctlTabControl.TabPages)
            {
                WorkField field = page.Controls[0] as WorkField;
                foreach (Wire wire in field.Network.Wires)
                {
                    wire.UpdateInfo(Criterion);
                }
            }

            CurrentField.ToolKit.UpdateField();
        }

        // очистьить сеть от результатов работы алгоритмов
        private void Reset()
        {
            // если требуется, то ...
            if (CurrentField.Network.Routers.Count > 0)
            {
                Algorithm alg = new Algorithm(CurrentField.Network);
                // произвести чистку
                alg.Reset();
                // обновить количество сегментов
                // перерисовать Рабочее Поле
                CurrentField.ToolKit.UpdateField();
            }
            if (crt.Count != 0)
            {
                for (int i = 0; i < CurrentField.Network.Wires.Count; i++)
                {
                    CurrentField.Network.Wires[i].UpdateCriterion(Criterias.Metric, crt[i]);
                    CurrentField.Network.Wires[i].UpdateInfo(Criterias.Metric);
                }
            }
            crt.Clear();
            trs.Clear();
            trss.Clear();
            tt.Clear();
            ttt.Clear();
            load_1.Clear();
        }

        // выравнивание узлов по горизонтали
        private void HorizontalAlignment()
        {
            // если требуется выравнивание, то ...
            if (CurrentField.SelectedRouters.Count > 0)
            {
                // сохранить ординату позиционной точки первого узла их выбранных
                int y = CurrentField.SelectedRouters[0].Location.Y;

                // присвоить сохраненную ординату всем выбранным узлам
                foreach (Router router in CurrentField.SelectedRouters)
                {
                    router.Location = new Point(router.Location.X, y);
                    // обновить положение инцедентных узлу ребер
                    foreach (Wire wire in router.Wires)
                    {
                        wire.UpdateCenter();
                    }
                }
                // перерисовать Рабочее Поле
                CurrentField.ToolKit.UpdateField();
            }
        }

        // выравнивание узлов по вертикали
        private void VerticalAlignment()
        {
            // если требуется выравнивание, то ...
            if (CurrentField.SelectedRouters.Count > 0)
            {
                // сохранить абсциссу позиционной точки первого узла их выбранных
                int x = CurrentField.SelectedRouters[0].Location.X;

                // присвоить сохраненную абсциссу всем выбранным узлам
                foreach (Router router in CurrentField.SelectedRouters)
                {
                    router.Location = new Point(x, router.Location.Y);
                    // обновить положение инцедентных узлу ребер
                    foreach (Wire wire in router.Wires)
                    {
                        wire.UpdateCenter();
                    }
                }
                // перерисовать Рабочее Поле
                CurrentField.ToolKit.UpdateField();
            }
        }

        #endregion

        // вспомогательные методы
        #region AuxiliaryMethods

        // создание файла
        private void CreateFile(Size size, bool autoFilling, string name)
        {
            CreateTab(CreateField(size, autoFilling), name);
        }

        // создание Рабочего Поля
        private WorkField CreateField(Size size, bool autoFilling)
        {
            WorkField field = new WorkField(this, size);

            // сделать новое Рабочее Поле текущим
            CurrentField = field;

            // если включена автоматическая генерация ...
            if (autoFilling == true)
            {
                // автоматически создать сеть
                field.CreateNetwork(size.Width, size.Height);
            }

            return field;
        }

        // создание вкладки
        private void CreateTab(WorkField field, string name)
        {
            // создание вкладки с именем
            TabPage page = new TabPage(name);
            // присоединение Рабочего поля ко вкладке
            page.Controls.Add(field);

            // добавление вкладки в контейнер вкладок
            ctlTabControl.TabPages.Add(page);
            // сделать вкладку выбранной
            ctlTabControl.SelectedTab = page;
        }

        // закрытие выбранной вкладки
        private void CloseSelectedPage()
        {
            // получение выбранной вкладки
            TabPage removedPage = ctlTabControl.SelectedTab;
            // удаление выбранной вкладки из контейнера вкладок
            ctlTabControl.TabPages.Remove(removedPage);
            // перезапись текущего Поля
            CurrentField = ctlTabControl.SelectedTab.Controls[0] as WorkField;
        }

        // запись файла на диск
        private void SaveFile(string fileName)
        {
            using (Stream stream = File.Create(fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                CurrentField.FilePath = fileName;

                // создание контейнера информации для сохранения файла
                Data data = new Data();
                // запись размера Рабочего Поля
                data.FieldSize = CurrentField.FieldSize;
                // запись пути к файлу
                data.FilePath = CurrentField.FilePath;
                // запись сети
                data.Network = CurrentField.Network;

                try
                {
                    serializer.Serialize(stream, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nFile is not saved!", "### Warning ###", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // обновить название вкладки
                ctlTabControl.SelectedTab.Text = FileNameParse(fileName);
            }
        }

        // проверка размерности рабочего поля
        private Size CheckSize(int width1, int width2, int height1, int height2)
        {
            return new Size(Math.Max(width1, width2), Math.Max(height1, height2));
        }

        #endregion

        private void menuAlgorithmFloyd_Click(object sender, EventArgs e)
        {

            Algorithm alg = new Algorithm(CurrentField.Network);

            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }

                AlgFloyd floyd = new AlgFloyd(CurrentField.Network);
                floyd.Do(CurrentField.SelectedRouters[0],
                                  CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1]);
                string output = String.Format("Successful!");
                CurrentField.ToolKit.UpdateField();
                MessageBox.Show(this, output, "### Info ###", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Please select two routers!", "### Warning! ###",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuToolYen_Click(object sender, EventArgs e)
        {

        }

        private void Ga_Click(object sender, EventArgs e)
        {

        }
        private void menuToolGa_Dejkstra_Click(object sender, EventArgs e)
        {

        }

        private void Dejkstra_pair_Click(object sender, EventArgs e)
        {

        }

        private void Yen_2_Click(object sender, EventArgs e)
        {

        }

        private void Ga_click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Ga_Yen_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Ga_Dejkstra_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Ga_Balancer_Click(object sender, EventArgs e)
        {

        }

        private void ctlMainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void toolStripButton_GA_Click(object sender, EventArgs e)
        {
            Reset();
            Algorithm alg = new Algorithm(CurrentField.Network);
            foreach (Wire wre in CurrentField.Network.Wires)
            {
                crt.Add(wre.Criterion);
            }
            int N = population_starting.Count;
            double Pc = 0.0;
            double Pm = 0.0;
            int Max = 0;
            int K_paths = 0;
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                if (population_starting.Count == 0)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Population is not generated!!!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                ParametersGA fom2 = new ParametersGA();
                fom2.population.Text = Convert.ToString(N);
                fom2.ShowDialog();
                if (fom2.DialogResult == DialogResult.Cancel)
                {
                    fom2.Close();
                }
                else if (fom2.DialogResult == DialogResult.OK)
                {
                    Pc = Convert.ToDouble(fom2.crosser.Text);
                    Pm = Convert.ToDouble(fom2.mitation.Text);
                    Max = Convert.ToInt32(fom2.iteration.Text);
                    K_paths = Convert.ToInt32(fom2.k.Text);
                    GA ga = new GA(CurrentField.Network);

                    trss = ga.Paths_GA(CurrentField.SelectedRouters[0],
                                      CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1],population_starting,
                                      N, Pc, Pm, Max, K_paths);
                    population_noRepeat.Clear();
                    for (int i = 0; i < trss.Count; i++)
                    {
                        population_noRepeat.Add(trss[i].DeepCopy());
                    }
                    algorithm = " (GA)";
                    string population_size = Convert.ToString(trss.Count);
                    MessageBox.Show(this, population_size,
                                          "MAXIMUM PATHS",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    CurrentField.ToolKit.UpdateField();
                }
            }
        }
        private void toolStripButton_ACO_Click(object sender, EventArgs e)
        {
            Reset();
            Algorithm alg = new Algorithm(CurrentField.Network);
            foreach (Wire wre in CurrentField.Network.Wires)
            {
                crt.Add(wre.Criterion);
            }
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                double p;
                double a;
                double b;
                int Max;
                int N;
                double p0;
                int Q;
                int K_paths = 0;
                ParametersACO fom3 = new ParametersACO();
                fom3.ShowDialog();
                if (fom3.DialogResult == DialogResult.Cancel)
                {
                    fom3.Close();
                }
                else if (fom3.DialogResult == DialogResult.OK)
                {
                    p = Convert.ToDouble(fom3.evaporation.Text);
                    a = Convert.ToDouble(fom3.alpha.Text);
                    b = Convert.ToDouble(fom3.beta.Text);
                    Max = Convert.ToInt32(fom3.iterations.Text);
                    N = Convert.ToInt32(fom3.NumberAnts.Text);
                    p0 = Convert.ToDouble(fom3.probability.Text);
                    Q = Convert.ToInt32(fom3.constant.Text);
                    K_paths = Convert.ToInt32(fom3.k.Text);
                    ACO aco = new ACO(CurrentField.Network);

                    trss = aco.Paths_ACO(CurrentField.SelectedRouters[0],
                                      CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1], p, a, b, Max, N, p0, Q, K_paths);
                    population_noRepeat.Clear();
                    for (int i = 0; i < trss.Count; i++)
                    {
                        population_noRepeat.Add(trss[i].DeepCopy());
                    }
                    algorithm = " (ACO)";
                    string population_size = Convert.ToString(trss.Count);
                    MessageBox.Show(this, population_size,
                                          "MAXIMUM PATHS",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    CurrentField.ToolKit.UpdateField();
                }
            }
        }

        private void toolStripButton_PSO_Click(object sender, EventArgs e)
        {
            Reset();
            Algorithm alg = new Algorithm(CurrentField.Network);
            foreach (Wire wre in CurrentField.Network.Wires)
            {
                crt.Add(wre.Criterion);
            }
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                if (population_starting.Count == 0)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Population is not generated!!!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                int N=population_starting.Count;
                double w;
                double c1,c2;
                int Max;
                int K_paths = 0;
                ParametersPSO fom4 = new ParametersPSO();
                fom4.population_size.Text = Convert.ToString(N);
                fom4.ShowDialog();
                if (fom4.DialogResult == DialogResult.Cancel)
                {
                    fom4.Close();
                }
                else if (fom4.DialogResult == DialogResult.OK)
                {
                    w = Convert.ToDouble(fom4.inertia_weight.Text);
                    c1 = Convert.ToDouble(fom4.acceleration_factor_c1.Text);
                    c2 = Convert.ToDouble(fom4.acceleration_factor_c2.Text);
                    Max = Convert.ToInt32(fom4.iterations.Text);
                    K_paths = Convert.ToInt32(fom4.k.Text);
                    PSO pso = new PSO(CurrentField.Network);

                    trss = pso.Paths_PSO(CurrentField.SelectedRouters[0],
                                      CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1],population_starting,
                                      N, w, c1, c2, Max, K_paths);
                    population_noRepeat.Clear();
                    for (int i = 0; i < trss.Count; i++)
                    {
                        population_noRepeat.Add(trss[i].DeepCopy());
                    }
                    algorithm = " (PSO)";
                    string population_size = Convert.ToString(trss.Count);
                    MessageBox.Show(this, population_size,
                                          "MAXIMUM PATHS",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    CurrentField.ToolKit.UpdateField();
                }
            }
        }

        private void toolStripButton_ABC_Click(object sender, EventArgs e)
        {
            Reset();
            Algorithm alg = new Algorithm(CurrentField.Network);
            foreach (Wire wre in CurrentField.Network.Wires)
            {
                crt.Add(wre.Criterion);
            }
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                if (population_starting.Count == 0)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Population is not generated!!!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                int N = population_starting.Count;
                int Max;
                int K_paths = 0;
                ParametersABC fom5 = new ParametersABC();
                fom5.population_size.Text = Convert.ToString(N);
                fom5.ShowDialog();
                if (fom5.DialogResult == DialogResult.Cancel) 
                {
                    fom5.Close();
                }
                else if(fom5.DialogResult == DialogResult.OK)
                {
                    Max = Convert.ToInt32(fom5.iterations.Text);
                    K_paths = Convert.ToInt32(fom5.k.Text);
                    ABC abc = new ABC(CurrentField.Network);

                    trss = abc.Paths_ABC(CurrentField.SelectedRouters[0],
                                        CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1],population_starting,
                                        N, Max, K_paths);
                    population_noRepeat.Clear();
                    for (int i = 0; i < trss.Count; i++)
                    {
                        population_noRepeat.Add(trss[i].DeepCopy());
                    }
                    algorithm = " (ABC)";
                    string population_size = Convert.ToString(trss.Count);
                    MessageBox.Show(this, population_size,
                                          "MAXIMUM PATHS",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    CurrentField.ToolKit.UpdateField();
                }
                
            }
        }

        private void toolStripButton_FA_Click(object sender, EventArgs e)
        {
            Reset();
            Algorithm alg = new Algorithm(CurrentField.Network);
            foreach (Wire wre in CurrentField.Network.Wires)
            {
                crt.Add(wre.Criterion);
            }
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                if (population_starting.Count == 0)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Population is not generated!!!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                double y;
                double a;
                double b;
                int Max;
                int N = population_starting.Count;
                int K_paths = 0;
                ParametersFA fom6 = new ParametersFA();
                fom6.number_firefly.Text = Convert.ToString(N);
                fom6.ShowDialog();
                if (fom6.DialogResult == DialogResult.Cancel)
                {
                    fom6.Close();
                }
                else if (fom6.DialogResult == DialogResult.OK)
                {
                    y = Convert.ToDouble(fom6.gamma.Text);
                    a = Convert.ToDouble(fom6.alpha.Text);
                    b = Convert.ToDouble(fom6.beta.Text);
                    Max = Convert.ToInt32(fom6.iterations.Text);
                    K_paths = Convert.ToInt32(fom6.k.Text);
                    FA fa = new FA(CurrentField.Network);

                    trss = fa.Paths_FA(CurrentField.SelectedRouters[0],
                                      CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1],population_starting, N, y, b, a, Max, K_paths);
                    population_noRepeat.Clear();
                    for (int i = 0; i < trss.Count; i++)
                    {
                        population_noRepeat.Add(trss[i].DeepCopy());
                    }
                    algorithm = " (FA)";
                    string population_size = Convert.ToString(trss.Count);
                    MessageBox.Show(this, population_size,
                                          "MAXIMUM PATHS",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    CurrentField.ToolKit.UpdateField();
                }
            }
        }

        private void toolStripButton_load_balancer_Click(object sender, EventArgs e)
        {
            Algorithm alg = new Algorithm(CurrentField.Network);
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                LOAD_BALANCER lb = new LOAD_BALANCER(CurrentField.Network);
                if (trss.Count != 0)
                {
                    trs = lb.Do(trss);
                    CurrentField.ToolKit.UpdateField();
                }
            }
        }
        private void toolStripButton_chart_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < trs.Count; i++)
            {
                tt.Add(trs[i].tc);
            }
            for (int i = 0; i < trs.Count; i++)
            {
                ttt.Add(trs[i].ts);
            }
            Chart chartForm = new Chart(tt, ttt);
            chartForm.ShowDialog(this);
        }

        private void generate_population_Click(object sender, EventArgs e)
        {
            Reset();
            Algorithm alg = new Algorithm(CurrentField.Network);
            foreach (Wire wre in CurrentField.Network.Wires)
            {
                crt.Add(wre.Criterion);
            }
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                population_starting.Clear();
                int N;
                ParametersGenerate fom7 = new ParametersGenerate();
                fom7.ShowDialog();
                if (fom7.DialogResult == DialogResult.Cancel)
                {
                    fom7.Close();
                }
                else if (fom7.DialogResult == DialogResult.OK)
                {
                    N = Convert.ToInt32(fom7.population.Text);
                    Generate generate = new Generate(CurrentField.Network);
                    population_starting = generate.GeneratePopulation(CurrentField.SelectedRouters[0],
                                              CurrentField.SelectedRouters[CurrentField.SelectedRouters.Count - 1], N);
                    MessageBox.Show(this, "Generate population successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CurrentField.ToolKit.UpdateField();
                }
            }
        }

        private void remove_population_Click(object sender, EventArgs e)
        {
            Reset();
            population_starting.Clear();
        }

        private void create_paths_Click(object sender, EventArgs e)
        {
            Reset();
            Algorithm alg = new Algorithm(CurrentField.Network);
            foreach (Wire wre in CurrentField.Network.Wires)
            {
                crt.Add(wre.Criterion);
            }
            if (CurrentField.SelectedRouters.Count >= 2)
            {
                int result = alg.Check(CurrentField.SelectedRouters);

                if (result == -1)
                {
                    CurrentField.ToolKit.UpdateField();
                    MessageBox.Show(this, "Graph is not closed!\nPlease check the topology!",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    return;
                }
                int K = 0;
                KPaths fom8 = new KPaths();
                int MaxKPath = population_noRepeat.Count;
                string MaxK = Convert.ToString(MaxKPath);
                string M = string.Concat( "<= ",MaxK,algorithm); 
                fom8.MaxK.Text = M;
                fom8.ShowDialog();
                if (fom8.DialogResult == DialogResult.Cancel)
                {
                    fom8.Close();
                }
                else if (fom8.DialogResult == DialogResult.OK)
                {
                    K= Convert.ToInt32(fom8.k.Text);
                    if (K > MaxKPath)
                    {
                        MessageBox.Show(this, "Check the value of K",
                                          "### Warning! ###",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    }
                    else
                    {
                        CreateKPaths create = new CreateKPaths(CurrentField.Network);
                        load_1 = create.Create(population_noRepeat, K);
                        CurrentField.ToolKit.UpdateField();
                    }
                }
            }
        }

        private void char_paper_eng_1(object sender, EventArgs e)
        {
            Chart_1 chartForm = new Chart_1(load_1);
            chartForm.ShowDialog(this);
        }
    }
}
