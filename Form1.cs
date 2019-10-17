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
        public Form1()
        {
            InitializeComponent();

            bl = new BL();
            bl.InitDirAndFile();

           this.ShowInTaskbar = false;
            notifyIcon1.Click += notifyIcon1_Click;

        }

        //Установка службы eUF
        private void Button3_Click(object sender, EventArgs e)
        {
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
            HideForms();
        }

        //Тестовый запуск консоли еуф
        private void ButtonTesrtSatarEOU_Click(object sender, EventArgs e)
        {

        }

        //При запуске формы
        private void Form1_Load(object sender, EventArgs e)
        {
            if (hhhide)
            {
                this.WindowState = FormWindowState.Minimized;
            }
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
            }
            else
            {
                MessageBox.Show("Запуск в скрытом режиме Отключен!");
                bl.inetMetHide(false);
            }
        }

        //Событие автозапуска при включении системы
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                MessageBox.Show("Запуск при загрузке включен!");
                bl.voidRegAvtoLoad(true);
                

            }
            else
            {
                MessageBox.Show("Запуск при загрузке Отключен. !");
                bl.inetMetHide(false);
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
    }
}
