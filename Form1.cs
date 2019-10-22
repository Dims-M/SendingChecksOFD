using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendingChecksOFD
{
    public partial class Form1 : Form
    {
        BL bl;
        bool hhhide = false;
        private string _temp_info;
        public Form1()
        {
            InitializeComponent();

            bl = new BL();
           // bl.GetDirecEou();
           // bl.ZipArhivJob(); // распаковка 
            

            this.ShowInTaskbar = true;
            notifyIcon1.Click += notifyIcon1_Click;

        }



        //Запуск службы eUF
        private void Button3_Click(object sender, EventArgs e)
        {
            bl.KillProssec("EthOverUsb");
            bl.StatrProgramm();


        }

        //Кнопка выход
        private void ButtonExitApp_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
        //Сохранить настройки
        private void ButtonSaveSetings_Click(object sender, EventArgs e)
        {
            labelInfo.Text += bl.GetSettingPortEou();
            bl.SetSettingPortEou(decimal.ToInt32(numericUpDown1.Value));
            labelInfo.Text = bl.GetSettingPortEou();
           // bl.GetSetingStarMode();
        }

        //Тестовый запуск Проверки обновления
        private void ButtonTesrtSatarEOU_Click(object sender, EventArgs e)
        {
            bl.GetFailSite();  //загрузка службы еоф
            MessageBox.Show("Проверка обновления новой версии. ", "Служба отправки чеков Атол EoU 1.0.0.2", MessageBoxButtons.YesNoCancel);
           
            // bl.GetFailSite();  //загрузка службы еоф
           // label2.Text += bl.GetUbtateApp(); ; // проверка и загрузка обнолвнеия программы
           // bl.DounloadFailSite(); //загрузка и распаковка обновления

            if (DialogResult.OK == buttonTesrtSatarEOU.DialogResult)
            {   
                label2.Text += bl.GetUbtateApp(); ; // проверка и загрузка обнолвнеия программы
                bl.DounloadFailSite(); //загрузка и распаковка обновления
                MessageBox.Show("Проверка обновления новой версии Загруженно посмотрите во временной папки.", "Служба отправки чеков Атол EoU 1.0.0.2");
            }
           
        }

        //При запуске формы
        private void Form1_Load(object sender, EventArgs e)
        {
          
            // bl.GetDirecEou();
            if (hhhide)
            {
                this.WindowState = FormWindowState.Minimized;
            }

          // labelInfo.Text = "Rjkbx{bl.GetDirecEou().ToString()}";
           // labelInfo.Text += bl.GetSettingPortEou();
        }

        private void InitForm()
        {

        }

        //Событие чек бокса. Работа в скрытом меню.
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox

            if (checkBox.Checked == true)
            {
                MessageBox.Show("Запуск в скрытом режиме включен!");
                bl.inetMetHide(true);
                bl.GetSetingStarMode(1);
            }
            else
            {
                MessageBox.Show("Запуск в скрытом режиме Отключен!");
                bl.GetSetingStarMode(0);
                bl.voidRegAvtoLoad(true);
            }
        }

        //Событие автозапуска при включении системы
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                MessageBox.Show("Запуск при загрузке включен!");
               

                 

            }
            else
            {
                MessageBox.Show("Запуск при загрузке Отключен. !");
               // bl.GetSetingStarMode(0);
                bl.voidRegAvtoLoad(false);
            }
        }


        private void HideForms ()
        {
            this.WindowState = FormWindowState.Minimized;
           // this.Hide();
        }
     
        //при загрузки иконки трея
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
     
        //Событие клика 
        void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }


        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        //Событие при вервом отображении формы
        private void Form1_Shown(object sender, EventArgs e)
        {
            MessageBox.Show($"Проверка наличия службы Eou{ bl.proverkaDirFikeEou()}");
            bl.GetDirecEou(); //Cjplfybt папок
            bl.ZipArhivJob(); // распаковка
            labelInfo.Text += bl.GetSettingPortEou();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bl.KillProssec("EthOverUsb");
        }
    }
}
