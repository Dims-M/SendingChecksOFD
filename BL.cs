using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;



namespace SendingChecksOFD
{
    public class BL
    {
       // private string logErrors = "Журнал событий.txt";
        private string logErrors = Application.StartupPath+ "Журнал событий.txt";
        readonly string pathDir = @"C:\Program Files\Eou\";

        readonly string pathDirTemp = @"C:\EoUServis\";
        string pathDirEoU = @"C:\EoU\";
        string pathFileZip = @"C:\Program Files\Eou\1.rar";
        private readonly string patchStartup = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup";

        string pathEoU = @"C:\EoU\EthOverUsb.exe";
        string pathEoUSettings = @"C:\EoU\C:\EoU\settings.ini";
        string[] port = new string[10];

        string tempInfo = "";
        string tempMessahc = "";

        static bool metHide = false;
        static bool avtoLoad = true;

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

        //Работа с автозагрузкой в папку  
        //http://www.cyberforum.ru/csharp-beginners/thread2062011.html

        //отпрвка емайла
        //https://programming-csharp.ru/2018/01/03/%d1%84%d0%be%d1%80%d0%bc%d0%b0-%d0%be%d0%b1%d1%80%d0%b0%d1%82%d0%bd%d0%be%d0%b9-%d1%81%d0%b2%d1%8f%d0%b7%d0%b8-%d0%bd%d0%b0-c/

        /// <summary>
        /// включение, отключение скрытого режима
        /// </summary>
        /// <param name="hide"></param>
        public void inetMetHide(bool hide)
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
        public void voidRegAvtoLoad(bool swixh)
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

                    System.IO.File.Copy(b + a, c + a);
                    //File.Copy(@"C:\EoU\~runme", patchStartup);
                }

                else
                {
                    //  var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    //  key.DeleteValue("Отправка чеков в ОФД",true);
                    // File.Delete(@"C:\EoU\EthOverUsb.exe");
                    System.IO.File.Delete(c + a);
                }

            }
            catch (Exception ex)
            {
                WrateText("Ошибка при работе с установкой автозагрузки" + ex);
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
            catch (Exception ex)
            {
                WrateText(" Ошибка при закрытии процесса" + ex);
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
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }

            //  File.Delete(zipPath);
        }

        /// <summary>
        /// Разорхивация файлов с указание что и куда орхивировать
        /// </summary>
        /// <param name="MyzipFail">Путь для файла.Откуда и какой архив</param>
        /// <param name="MyExtractPath">Куда распаковыватьы</param>
        public void ZipArhivJobMyPath(string MyzipFail, string MyExtractPath)
        {
            //string zipPath = @"C:\EoUTemp\EoU.zip";
            //string extractPath = @"C:\";
  
            try
            {
                ZipFile.ExtractToDirectory(MyzipFail, MyExtractPath);
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }

            //  File.Delete(zipPath);
        }

        /// <summary>
        /// Считываем порт из настроек EoU
        /// </summary>
        /// <returns></returns>
        public string GetSettingPortEou()
        {
            port = System.IO.File.ReadAllText(@"C:\EoU\settings.ini").Split('=');
            return $"Порт дляотправки чеков установлен = {port[1]}";
        }

        /// <summary>
        /// Открытие и созание файла настроек settings.ini
        /// </summary>
        /// <param name="myPort">Указать нужный порт</param>
        public void SetSettingPortEou(int myPort)
        {

            // File.OpenWrite( ).Seek(-2, SeekOrigin.End);
            string text = $"[com]\nnumber={myPort}";

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
            var mode = System.IO.File.ReadAllText(@"C:\EoU\settingsOFD.ini").Split('=');
            int temMode = 0;
            try
            {
                return temMode = int.Parse(mode[1]);
            }
            catch (Exception ex)
            {
                WrateText("Ошибка при загрузке файла настроек" + ex);
            }
            return temMode;
        }

        /// <summary>
        /// Создание директории, временной папки
        /// </summary>
        public void InitDirAndFile(string myPachDir)
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
                WrateText("Произошла ошибка при создании главной директории!!! \n" + ex + "\n");
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
              // 147
                InitDirAndFile(pathDirTemp); // Папка программы
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
                WrateText("произошла ошибка при проверке существования папки EoU" + ex);
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

            if (System.IO.File.Exists(pathFile))
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
        /// Получение папки с ддл с сайта
        /// </summary>
        public void GetServisEoU()
        {
            string errorLog = $"{DateTime.Now.ToString()}\t\n";
            string pathFile = pathDirTemp + @"SendingChecksOFD.zip";

            string serFtp = @"https://testkkm.000webhostapp.com/Dhh134567800gfdfh/SendingChecksOFD.zip";

            if (System.IO.File.Exists(pathFile))
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
               // ZipArhivJobMyPath(pathFile, pathDirTemp);  //***************
            }
            ZipArhivJobMyPath(pathFile, pathDirTemp);  //распаковка файла

           string tempDeskop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //перенас ярлыка на раб стол
          //  System.IO.File.Move(pathDirTemp+ @"C:\EoUServis\SendingChecksOFDd.lnk", tempDeskop+ "SendingChecksOFDd");
            //  333



            string path = "C:\\EoUServis\\SendingChecksOFD.exe";
            string newPath = tempDeskop + "\\SendingChecksOFD.exe";


           // System.IO.File.Copy(path, newPath,false);

            FileInfo fileInf = new FileInfo(path);

           
            if (fileInf.Exists)
            {

                fileInf.CopyTo(newPath, true);
                //     // альтернатива с помощью класса File
                //     // File.Copy(path, newPath, true);
            }
            //запус новой версии программы из основной папки
            // ProverkaVersion(newPath);
        }



        /// <summary>
        /// Проверка и получение обновление программы НЕ Использовать
        /// </summary>
        public string GetUbtateApp() //async
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
            using (FileStream fstream = System.IO.File.OpenRead(pathDirTemp + pathFile))
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

                System.IO.File.Delete(pathFile);

            }

            return tempMessahc;
        }

        /// <summary>
        /// Скачивание новой версии программы и  распаковка НЕ использовать
        /// </summary>
        public void DounloadFailSite()
        {
            string errorLog = $"{DateTime.Now.ToString()}\t\n";
            string pathFile = @"C:\EoUTemp\UpdateSendingChecksOFD.zip";
            string serFtp = @"https://testkkm.000webhostapp.com/Dhh134567800gfdfh/SendingChecksOFD.zip";

            System.IO.File.Delete(pathFile);
            System.IO.File.Delete("UpdateSendingChecksOFD.exe");

            using (var web = new WebClient())
            {
                // скачиваем откуда и куда
                web.DownloadFile(serFtp, pathFile);
            }

            string extractPath = @"C:\EoUTemp\";

            try
            {
                ZipFile.ExtractToDirectory(pathFile, extractPath);
               // ProverkaVersion();
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }


        }

        /// <summary>
        /// запуск новой версии программы из  основной папки
        /// </summary>
        public void ProverkaVersion(string pathFile)
        {
            //string pathFile = @"C:\EoUServis\SendingChecksOFD.exe";

            System.Diagnostics.Process.Start(pathFile);
            Thread.Sleep(2000);
            Application.Exit();

        }


        //Создание ярлыка программы  Не успользовать
        private void appShortcutToDesktop()
        {
            //  https://stackoverflow.com/questions/234231/creating-application-shortcut-in-a-directory
            string shortcutPathFail = @"C:\EoUTemp\SendingChecksOFD.exe";
            string shortcutPathFail222 = Application.StartupPath+ "\\SendingChecksOFD.exe";
            string koodaPath2 = @"C:\Users\Dim\Desktop\Отправка чеков в ОФД.lnk";

            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                //var lnk = shell.CreateShortcut("sc.lnk");
                var lnk = shell.CreateShortcut(koodaPath2);
                try
                {
                    // lnk.TargetPath = @"C:\something";
                    
                    lnk.TargetPath = shortcutPathFail222;

                    // lnk.IconLocation = "shell32.dll, 1";
                    lnk.IconLocation = $"{shortcutPathFail222}, 0";

                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
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
        /// Отправка сообщение на почту
        /// </summary>
        /// <param name="nameAuthorr"></param>
        /// <param name="bodyMail"></param>
        public void MySendMai(string nameAuthorr, string bodyMail)
        {

            const string passMail = "51215045avto";
            string nameAuthor = nameAuthorr;
            MailAddress from = new MailAddress("o.avto@i-cks.ru", nameAuthor); // Отправка сообщений. Элект ящик
            MailAddress to = new MailAddress("o.avto@i-cks.ru", nameAuthor);
            // MailAddress to = new MailAddress("rabolan@mail.ru", nameAuthor);

            try
            {

                //клиен для отправки письма
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // указываем способ доставки
                smtp.Credentials = new NetworkCredential(from.Address, passMail);
                smtp.EnableSsl = true; // шифровка сообщений
                smtp.Timeout = 20000; //тайаут ожидания

                MailMessage mail = new MailMessage(from, to); // указываем с какого ящика отправлять и куда
                mail.Subject = ",";
                mail.Body = bodyMail + " ";

                smtp.Send(mail); //отправка сообщения

            }
            catch (Exception ex)
            {
                WrateText("Ошибка при отправке письма" + ex);
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


        public void SaveBarcodet(PictureBox pictureBox)
        {
            //вместо pictureBox1 укажите свой pictureBox

            if (pictureBox.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;

                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        pictureBox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void TestObnovlenie()
        {

        }


        public void StartInit()
        {

        }


    }
  


}
