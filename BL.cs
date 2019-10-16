using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendingChecksOFD
{
  public  class BL
    {
        private string logErrors ="Журнал событий.txt";
      // readonly string pathDir = @"C:\Program Files\Eou\";
        readonly string pathDir = @"C:\Eou1\";
        string pathFileZip = @"C:\Program Files\Eou\1.rar";





        /// <summary>
        /// закрыть процесс по имени
        /// </summary>
        /// <param name="nameProssec"></param>
        public void KillProssec(string nameProssec)
        {
            System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill();
        }


        public bool InitDirAndFile()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathDir);
            FileInfo fileInfo = new FileInfo(pathFileZip);
            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();  // cоздаем временный католог
                    WrateText("Создался католог \n");
                    return true;
                }
            }
            catch (Exception ex)
            {
                WrateText("Произошла ошибка при создании главной директории!!! \n" + ex+"\n");
            }
          
            return true;
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


    }






}
