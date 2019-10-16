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
        public Form1()
        {
            InitializeComponent();

            bl = new BL();
            bl.InitDirAndFile();
        }

        //Установка службы eUF
        private void Button3_Click(object sender, EventArgs e)
        {

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

        }

        //Тестовый запуск консоли еуф
        private void ButtonTesrtSatarEOU_Click(object sender, EventArgs e)
        {

        }

        //При запуске формы
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void InitForm()
        {

        }
    }
}
