using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendingChecksOFD.Forms
{
    public partial class MessageForm1 : Form
    {
        private string _nameSenntMessage;
        private string _senntMessage;

        public string SenntMessage { get; set; }
        public string NameSenntMessage { get; set; }

        public MessageForm1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageForm1.ActiveForm.Close();
        }

        

        //кнопка отправки сообщения
        private  async void Button2_Click(object sender, EventArgs e)
        {
            BL bl = new BL();
            _nameSenntMessage = NameSendtextBox.Text;
            _senntMessage = MessagetextBox.Text;

            await Task.Run(() => bl.MySendMai(_nameSenntMessage, _senntMessage));
            MessageBox.Show("Ваше сообщение отправлено!!");
            NameSendtextBox.Text = "";
            MessagetextBox.Text = "";
        }
    }
}
