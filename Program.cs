using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendingChecksOFD
{
    internal sealed class StartPatams
    {
        public static string[] args;
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool oneonly;
            Mutex m = new Mutex(true, "SendingChecksOFD", out oneonly);
            if (oneonly)
            {

             Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("234234234");
            }
        }
    }
}
