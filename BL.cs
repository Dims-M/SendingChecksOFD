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
        string pathDirEoU = @"C:\EoU\";
        string pathFileZip = @"C:\Program Files\Eou\1.rar";
        private readonly string patchStartup = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup";

        string pathEoU = @"C:\EoU\EthOverUsb.exe";
        string pathEoUSettings = @"C:\EoU\C:\EoU\settings.ini";
        string[] port = new string[10];

      string tempInfo = "";
      string  tempMessahc = "";

      static  bool metHide = false;
      static  bool avtoLoad = true;

        //автозапуск приложения через реестр
        // http://www.cyberforum.ru/csharp-beginners/thread282803.html
        // http://www.cyberforum.ru/csharp-net/thread104649.html и переменные среды
        //скрытие формы

        //Количество файлов в папке
        // http://www.cyberforum.ru/csharp-beginners/thread939527.html

        //работа с архивами
        //http://www.codernotes.ru/articles/c-c/rabota-s-zip-arhivami-v-net-framework-3-5-na-c.html

        //Пример сохранения данных программы
        //https://www.youtube.com/watch?v=I6Gge6_8Svg&t=0s
        //https://www.youtube.com/watch?v=CHTd5IMVkPI&t=0s win prov
        // https://www.youtube.com/watch?v=Mb3S2IK3NzI&t=2230s

        //Работа с автозагрузкой в папку   кзагрузкой
        //http://www.cyberforum.ru/csharp-beginners/thread2062011.html

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
            String s3 = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            s3 += "\\";
            //WrateText("Строка подключения \n" + s3);
            // MessageBox.Show(s3);

            string a = "~runme.lnk";
            string b = @"C:\EoU\";
            string c = s3;

            try
            {
            if (swixh)
                {
                    #region НЕ смотреть
                    // var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    // key.SetValue("Отправка чеков в ОФД", Application.ExecutablePath);
                    //  key.SetValue("Отправка чеков в ОФД", @"C:\EoU\EthOverUsb.exe");
                    // String s = System.Environment.GetEnvironmentVariable("programfiles");
                    //  String s2 = System.Environment.GetEnvironmentVariable("Startup");
                    //String s3 = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
                    //  File.Delete(c + a);
                    #endregion

                    File.Copy(b + a, c + a);
                //File.Copy(@"C:\EoU\~runme", patchStartup);
            }
            
            else 
            {
              //  var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                //  key.DeleteValue("Отправка чеков в ОФД",true);
                // File.Delete(@"C:\EoU\EthOverUsb.exe");
                File.Delete(c + a);
            }

            }
            catch (Exception ex)
            {
                WrateText("Ошибка при работе с установкой автозагрузки"+ex);
            }
        }

        /// <summary>
        /// Автозапуск службы еов
        /// </summary>
        public void AvtoServeesEoU()
        {

        }


        //закрыть нужны процесс по имени.
        public void KillProssec(string nameProssec)
        {
            try
            {
                System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill();
            }
            catch(Exception ex)
            {
                WrateText(" Ошибка при закрытии процесса"+ex);
            }
             
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

          //  File.Delete(zipPath);
        }

        /// <summary>
        /// Считываем порт из настроек EoU
        /// </summary>
        /// <returns></returns>
        public string GetSettingPortEou()
        {
           port = File.ReadAllText(@"C:\EoU\settings.ini").Split('=');
           return $"Порт дляотправки чеков установлен = {port[1]}";
        }

        /// <summary>
        /// Открытие и созание файла настроек settings.ini
        /// </summary>
        /// <param name="myPort">Указать нужный порт</param>
        public void SetSettingPortEou( int myPort)
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
        /// Установка режима работы. Создание файла настроек
        /// </summary>
        /// <param name="mUMode"></param>
        public void GetSetingStarMode(int mUMode)
        {
            string text = $"Mode ={mUMode}";

            // запись в файл
            using (FileStream fstream = new FileStream(@"C:\EoU\settingsOFD.ini", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // асинхронная запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                // Console.WriteLine("Текст записан в файл");
            }
        }

        /// <summary>
        /// Загрузка файла настроек. 
        /// </summary>
        /// <returns></returns>
        public int SetSettingMode()
        {
            var mode = File.ReadAllText(@"C:\EoU\settingsOFD.ini").Split('=');
            int temMode =0;
            try
            {
                return temMode = int.Parse(mode[1]);
            }
            catch (Exception ex)
            {
                WrateText("Ошибка при загрузке файла настроек"+ex);
            }
            return  temMode;
        }

        /// <summary>
        /// Создание директории, временной папки
        /// </summary>
        public void InitDirAndFile( string myPachDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(myPachDir);
           // File.Create(@"C:\EoU\settings.ini");

           // FileInfo fileInfo = new FileInfo(pathFileZip);
            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();  // cоздаем временный католог
                    WrateText($"Создался католог {myPachDir}\n");
                   
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
           // string pathDirEoU = @"C:\EoU\";
            int fileCount = 0;
            string[] filePaths;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(pathDir);
              //  Directory.Delete(pathDir);

                //if (!dirInfo.Exists) //Если папки нет зоздаем корневую папку EoU
                //{
                    InitDirAndFile(pathDirTemp);
                    InitDirAndFile(pathDirEoU);
                  //  GetSetingStarMode(0); //запуск 
                    GetFailSite(); // загружаем файл с сайта
                    ZipArhivJob();  //***************
                    tempInfo += "Первоночальная Загрузка и распаковка новой службы EoU";
                    filePaths = Directory.GetFiles(pathDirEoU);
                    fileCount = filePaths.Length;

                //}

               //if (dirInfo.Exists)
               // {
               //     filePaths = Directory.GetFiles(pathDirEoU);
               //     fileCount = filePaths.Length;
               // }

                if (fileCount < 12)
                {
                    WrateText("Ошибка. Количество файлом не соотвестыует нужному количеству");
                }

            }
            catch (Exception ex)
            {
                WrateText("произошла ошибка при проверке существования папки EoU"+ex);
            }

            stopwatch.Stop();
          //  WrateText(stopwatch."");
            return fileCount;
            
        }


        public string proverkaDirFikeEou()
        {

           
            return tempInfo;
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
        public string   GetUbtateApp() //async
        {

            const string pathFile = "ver.txt";
            // const string path = @"C:\SomeDir\";
           // const string path = @"C:\Program Files\SomeDir";
            const string serFtp = @"https://testkkm.000webhostapp.com/hz/Ver.txt";
            //string tempMessahc = "";

            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo("SendingChecksOFD.exe");
            // Строка с версией: myFileVersionInfo.FileVersion;
            string versApp = myFileVersionInfo.FileVersion.ToLower();

            // double versApp2 = Double.Parse(versApp);

            DirectoryInfo dirInfo = new DirectoryInfo(pathDirTemp);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();  // cоздаем временный католог
            }

            //Получение версии на сервере
            using (var web = new WebClient())
            {
               // await Task.Run(() => web.DownloadFile(serFtp, pathDirTemp + "ver.txt"));
                web.DownloadFile(serFtp, pathDirTemp + "ver.txt");
                // аисинхроный запуск
                // скачиваем откуда и куда

            }
            // чтение из файла и проверяем текущую версию файла и нового на сервере
            using (FileStream fstream = File.OpenRead(pathDirTemp + pathFile))
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
                        tempMessahc += $"Требуется обновление программы, текущая версия {versApp} новая {itemMass}";
                        // MessageBox.Show($"Требуется обновление программы, текущая версия {versApp} новая {itemMass}");

                    }

                    else
                    {
                        tempMessahc += "Обновление программы не требуется, текущая версия{versApp} новая {itemMass}";
                        // MessageBox.Show($"Обновление программы не требуется, текущая версия{versApp} новая {itemMass}");
                    }

                }

                File.Delete(pathFile);

            }

            return tempMessahc;
        }


        public void DounloadFailSite()
        {
            string errorLog = $"{DateTime.Now.ToString()}\t\n";
            string pathFile = @"C:\EoUTemp\UpdateSendingChecksOFD.zip";
            string serFtp = @"https://testkkm.000webhostapp.com/Dhh134567800gfdfh/SendingChecksOFD.zip";

            File.Delete(pathFile);
            File.Delete("UpdateSendingChecksOFD.exe");

            //if (File.Exists(pathFile))
            //{
            //    File.Delete(pathFile);
            //    errorLog += $"Данный файл уже существует \t\n{serFtp}\t\n И будет удален.";
            //    WrateText(errorLog);
            //}

            using (var web = new WebClient())
                {

                    // скачиваем откуда и куда
                    web.DownloadFile(serFtp, pathFile);
                }

            //string zipPath = @"C:\EoUTemp\EoU.zip";
            string extractPath = @"C:\EoUTemp\";

            try
            {
                ZipFile.ExtractToDirectory(pathFile, extractPath);
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }


        }

        public string ProverkaVersion()
        {
            GetUbtateApp();
            return tempMessahc;
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
        /// Тестовой запус Службы EoU
        /// </summary>
        public async void StatrProgramm()
        {
            string errorLog = $"t\n";
            int tempMofde = SetSettingMode();

            //Проверка загруженный режима автозагрузки
            if (tempMofde == 1)
            {
                metHide = true;
            }

            if (tempMofde == 0)
            {
                metHide = false;
            }

            try
            {
                Process iStartProcess = new Process(); // новый процесс
                iStartProcess.StartInfo.FileName = pathEoU; // путь к запускаемому файлу
                iStartProcess.StartInfo.Arguments = " -e";

                if (metHide )
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
