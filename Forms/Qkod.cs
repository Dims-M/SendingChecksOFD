using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendingChecksOFD.Forms
{
    public partial class Qkod : Form
    {
        public Qkod()
        {
            InitializeComponent();
        }

        //кнопка при нажатии Barcoder
        private void BtnBarcode_Click(object sender, EventArgs e)
        {
            //Обьект для работы с Barcode
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = barcode.Draw(txtBarcode.Text, 50); 
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
           // Application.Exit();
        }

        //Кнопка при нажатие QRcoda
        private void BtnQRCode_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = barcode.Draw(txtQRCode.Text, 50);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            txtQRCode.Text = "";
            txtBarcode.Text = "";

        }

        //Кнопка тест
        private void Button3_Click(object sender, EventArgs e)
        {
            
            BL bL = new BL();
            bL.SaveBarcodet(pictureBox);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //PrintDocument pd = new PrintDocument();
            //pd.PrintPage += PrintPage;
            //pd.Print();

            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_PrintPage);

            PrintDialog printDlg = new PrintDialog();

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrinterSettings = printDlg.PrinterSettings;
                printDocument.Print();
               
            }
        }

        void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //   Paint(e.Graphics);// Выводит на екран линии и текст (по сути мой рисунок)
            e.Graphics.DrawImage(pictureBox.Image, 0, 0);
        }
        //private void PrintPage(object o, PrintPageEventArgs e)
        //{
        //    System.Drawing.Image img = System.Drawing.Image.FromFile(pictureBox.Image.);
        //    Point loc = new Point(100, 100);
        //    e.Graphics.DrawImage(img, loc);
        //}

    }
}
