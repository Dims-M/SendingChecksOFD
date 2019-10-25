using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

                bl.voidRegAvtoLoad(true);


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
            MessageBox.Show($"Проверка наличия службы Eou{ bl.proverkaDirFikeEou()}\n Скачивание новор версии дистрбутива EoU");
            bl.GetDirecEou(); //Cjplfybt папок
            bl.ZipArhivJob(); // распаковка
            labelInfo.Text += bl.GetSettingPortEou();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bl.KillProssec("EthOverUsb");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           // bl.ProverkaVersion();
           // bl.appShortcutToDesktop("test"); // url ссылка 
            bl.appShortcutToDesktop("еуые");
           // ProverkaVersion();

            //String s = System.Environment.GetEnvironmentVariable("programfiles");
            //String s2 = System.Environment.GetEnvironmentVariable("Startup");

            //bl.MySendMai("От Кого","типо тела письма");


            //  //String s3 = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
            //  String s3 = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            // s3 += "\\";
            //  bl.WrateText("Строка подключения \n"+s3);
            // MessageBox.Show(s3);

            //string a = "~runme.lnk";
            //string b = @"C:\EoU\";
            //string c = s3;
            // File.Copy(b + a, c + a);

            //  File.Copy(@"C:\EoU\~runme", s3);
            // File.Copy(@"C:\EoU\EthOverUsb.exe", $"{s3}~runme.lnk");
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bl.SetSettingPortEou(decimal.ToInt32(numericUpDown1.Value));
            Close();
            Application.Exit();
        }

        private void ЗапуститьПроверкуИСканиваниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bl.GetFailSite();  //загрузка службы еоф
            bl.DounloadFailSite();
        }

        private void СкачатьОтдельноСлужбуEoUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bl.GetFailSite();  //загрузка службы еоф
            
        }

        private void LabelInfo_Click(object sender, EventArgs e)
        {

        }
        //**********РАБОТА С ККЕ*****
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Кнопка Поиск и работа с ККТ Атол
        private void ПоискИПодключениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKKM formKKM = new FormKKM();
            formKKM.Show();
        }

        private void НастроитьЧтоНибутьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СкаатьДрайвераАтол10ХToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://fs.atol.ru/SitePages/%D0%A6%D0%B5%D0%BD%D1%82%D1%80%20%D0%B7%D0%B0%D0%B3%D1%80%D1%83%D0%B7%D0%BA%D0%B8.aspx");
        }

        private void СкаатьДрайвераАтол816ХToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://fs.atol.ru/SitePages/%D0%A6%D0%B5%D0%BD%D1%82%D1%80%20%D0%B7%D0%B0%D0%B3%D1%80%D1%83%D0%B7%D0%BA%D0%B8.aspx");
        }

        private void ПодробноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа для первоночальной загрузки и запуска службы отправки чеков Кассы Атол");
        }

        private void СкачатьДаннуюПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        System.Diagnostics.Process.Start("https://yadi.sk/d/G-9vrLyvB2lwNA");
        }

        private void ДополнительноеПОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://yadi.sk/d/dAtjl1D4yZb8Mw");
        }

        private void НаписатьРазработчикуИлиВТехподтержкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.MessageForm1 messageForm = new Forms.MessageForm1();
            messageForm.Show();
        }
    }


   //дОБАВТЬ ФОРМУ ДЛЯ РАботы с ккм атол
   /// Логирование и отправка сообщений
   ///
}
