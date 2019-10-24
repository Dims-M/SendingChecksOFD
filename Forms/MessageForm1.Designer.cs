namespace SendingChecksOFD.Forms
{
    partial class MessageForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NameMessageLabel = new System.Windows.Forms.Label();
            this.sendLabel = new System.Windows.Forms.Label();
            this.NameSendtextBox = new System.Windows.Forms.TextBox();
            this.MessagetextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(374, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отправить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // NameMessageLabel
            // 
            this.NameMessageLabel.AutoSize = true;
            this.NameMessageLabel.Location = new System.Drawing.Point(12, 24);
            this.NameMessageLabel.Name = "NameMessageLabel";
            this.NameMessageLabel.Size = new System.Drawing.Size(35, 17);
            this.NameMessageLabel.TabIndex = 2;
            this.NameMessageLabel.Text = "Имя";
            // 
            // sendLabel
            // 
            this.sendLabel.AutoSize = true;
            this.sendLabel.Location = new System.Drawing.Point(12, 71);
            this.sendLabel.Name = "sendLabel";
            this.sendLabel.Size = new System.Drawing.Size(84, 17);
            this.sendLabel.TabIndex = 3;
            this.sendLabel.Text = "Сообщение";
            // 
            // NameSendtextBox
            // 
            this.NameSendtextBox.Location = new System.Drawing.Point(15, 44);
            this.NameSendtextBox.Name = "NameSendtextBox";
            this.NameSendtextBox.Size = new System.Drawing.Size(371, 22);
            this.NameSendtextBox.TabIndex = 4;
            // 
            // MessagetextBox
            // 
            this.MessagetextBox.Location = new System.Drawing.Point(15, 100);
            this.MessagetextBox.Multiline = true;
            this.MessagetextBox.Name = "MessagetextBox";
            this.MessagetextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessagetextBox.Size = new System.Drawing.Size(371, 93);
            this.MessagetextBox.TabIndex = 5;
            // 
            // MessageForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 406);
            this.Controls.Add(this.MessagetextBox);
            this.Controls.Add(this.NameSendtextBox);
            this.Controls.Add(this.sendLabel);
            this.Controls.Add(this.NameMessageLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MessageForm1";
            this.Text = "MessageForm1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label NameMessageLabel;
        private System.Windows.Forms.Label sendLabel;
        private System.Windows.Forms.TextBox NameSendtextBox;
        private System.Windows.Forms.TextBox MessagetextBox;
    }
}