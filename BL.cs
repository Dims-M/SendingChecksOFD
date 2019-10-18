using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
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
     
        readonly string pathDirTemp = @"C:\EoUTemp\";
        string pathFileZip = @"C:\Program Files\Eou\1.rar";

        string pathEoU = @"C:\EoU\EthOverUsb.exe";
        string pathEoUSettings = @"C:\EoU\C:\EoU\settings.ini";
        string[] port = new string[10];


      static  bool metHide = false;
      static  bool avtoLoad = true;

        //автозапуск приложения через реестр
        // http://www.cyberforum.ru/csharp-beginners/thread282803.html
        //скрытие формы

        //Количество файлов в папке
        // http://www.cyberforum.ru/csharp-beginners/thread939527.html

            //работа с архивами
        //http://www.codernotes.ru/articles/c-c/rabota-s-zip-arhivami-v-net-framework-3-5-na-c.html



        /// <summary>
        /// включение, отключение скрытого режима
        /// </summary>
        /// <param name="hide"></param>
        public void inetMetHide( bool hide)
        {
            metHide = hide;
        }

        /// <summary>
        /// Запуск в скрытом режиме
        /// </summary>
        /// <param name="hide"></param>
        public void inetAvtoLoad(bool AvtoLoad)
        {
            metHide = AvtoLoad;
        }

        /// <summary>
        /// Запись в автозагрузку
        /// </summary>
        /// <param name="swixh"></param>
        public void voidRegAvtoLoad( bool swixh)
        {
            if (swixh)
            {
                var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                key.SetValue("Отправка чеков в ОФД", Application.ExecutablePath);
            }
             

            else 
            {
                var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                key.DeleteValue("Отправка чеков в ОФД");
            }
        }

        //закрыть нужны процесс по имени.
        public void KillProssec(string nameProssec)
        {
            System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill();
        }

        //Распаковка архива в нужный каталог
        public void ZipArhivJob()
        {
            string zipPath = @"C:\EoUTemp\EoU.zip";
            string extractPath = @"C:\";

            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n"+ ex);
            }
            

        }

        /// <summary>
        /// Считываем порт из настроек EoU
        /// </summary>
        /// <returns></returns>
        public string GetSettingPortEou()
        {
           port = File.ReadAllText(@"C:\EoU\settings.ini").Split('=');
           return port[1];
        }


        public  void SetSettingPortEou( int myPort)
        {

           // File.OpenWrite( ).Seek(-2, SeekOrigin.End);
           string text =$"[com]\nnumber={myPort}";
           
            // запись в файл
            using (FileStream fstream = new FileStream(@"C:\EoU\settings.ini", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // асинхронная запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
               // Console.WriteLine("Текст записан в файл");
            }
        }


        /// <summary>
        /// Создание директории, временной папки
        /// </summary>
        public void InitDirAndFile( string myPachDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(myPachDir);
           // FileInfo fileInfo = new FileInfo(pathFileZip);
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
        /// Проверка количества файлов папка с файлами EoU
        /// </summary>
        public int GetDirecEou()
        {
            string pathDirEoU = @"C:\EoU\";
            int fileCount = 0;
            string[] filePaths;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(pathDir);

                if (dirInfo.Exists) //Если папки нет зоздаем корневую папку EoU
                {
                    InitDirAndFile(pathDirTemp);
                    InitDirAndFile(pathDirEoU);
                    GetFailSite(); // загружаем файл с сайта
                }

               if (dirInfo.Exists)
                {
                    filePaths = Directory.GetFiles(pathDirEoU);
                    fileCount = filePaths.Length;
                }

                if (fileCount < 12)
                {
                    WrateText("Ошибка. Количество файлом не соотвестыует нужному количеству");
                }

            }
            catch (Exception ex)
            {
                WrateText("произошла ошибка при проверке существования папки EoU");
            }
            return fileCount;
        }

        /// <summary>
        /// Получение файла ссайта 000webhostapp.com
        /// </summary>
        public void GetFailSite()
        {
            string errorLog = $"{DateTime.Now.ToString()}\t\n";
            string pathFile = @"C:\EoUTemp\EoU.zip";
            string serFtp = @"https://testkkm.000webhostapp.com/Dhh134567800gfdfh/EoU.zip";

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
            string errorLog = $"t\n";
            try
            {
                Process iStartProcess = new Process(); // новый процесс
                iStartProcess.StartInfo.FileName = pathEoU; // путь к запускаемому файлу
                iStartProcess.StartInfo.Arguments = " -e";

                if (metHide)
                {
                   // iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                }

                await Task.Run(() => iStartProcess.Start()); // запуск программы лечения
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
