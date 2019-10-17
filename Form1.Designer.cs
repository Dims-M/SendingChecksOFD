namespace SendingChecksOFD
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonExitApp = new System.Windows.Forms.Button();
            this.buttonTesrtSatarEOU = new System.Windows.Forms.Button();
            this.buttonStartEoU = new System.Windows.Forms.Button();
            this.buttonSaveSetings = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.Location = new System.Drawing.Point(445, 269);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(97, 66);
            this.buttonExitApp.TabIndex = 0;
            this.buttonExitApp.Text = "Выход";
            this.buttonExitApp.UseVisualStyleBackColor = true;
            this.buttonExitApp.Click += new System.EventHandler(this.ButtonExitApp_Click);
            // 
            // buttonTesrtSatarEOU
            // 
            this.buttonTesrtSatarEOU.Location = new System.Drawing.Point(22, 269);
            this.buttonTesrtSatarEOU.Name = "buttonTesrtSatarEOU";
            this.buttonTesrtSatarEOU.Size = new System.Drawing.Size(162, 66);
            this.buttonTesrtSatarEOU.TabIndex = 1;
            this.buttonTesrtSatarEOU.Text = "Скачать или проверить обновление службы  EoU";
            this.buttonTesrtSatarEOU.UseVisualStyleBackColor = true;
            this.buttonTesrtSatarEOU.Click += new System.EventHandler(this.ButtonTesrtSatarEOU_Click);
            // 
            // buttonStartEoU
            // 
            this.buttonStartEoU.Location = new System.Drawing.Point(177, 134);
            this.buttonStartEoU.Name = "buttonStartEoU";
            this.buttonStartEoU.Size = new System.Drawing.Size(230, 75);
            this.buttonStartEoU.TabIndex = 2;
            this.buttonStartEoU.Text = "Запустить службу отправки чеков EoU";
            this.buttonStartEoU.UseVisualStyleBackColor = true;
            this.buttonStartEoU.Click += new System.EventHandler(this.Button3_Click);
            // 
            // buttonSaveSetings
            // 
            this.buttonSaveSetings.Location = new System.Drawing.Point(245, 269);
            this.buttonSaveSetings.Name = "buttonSaveSetings";
            this.buttonSaveSetings.Size = new System.Drawing.Size(133, 66);
            this.buttonSaveSetings.TabIndex = 3;
            this.buttonSaveSetings.Text = "Сохранить настройки";
            this.buttonSaveSetings.UseVisualStyleBackColor = true;
            this.buttonSaveSetings.Click += new System.EventHandler(this.ButtonSaveSetings_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(19, 19);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(11, 17);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "l";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(177, 215);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(223, 21);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Запускать к скрытом режиме";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(177, 242);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(202, 21);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Атозапуск при включении";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Отправка чеков в ОФД";
            this.notifyIcon1.BalloonTipTitle = "Отправка чеков в ОФД 1";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Отправка чеков в ОФД";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 359);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonSaveSetings);
            this.Controls.Add(this.buttonStartEoU);
            this.Controls.Add(this.buttonTesrtSatarEOU);
            this.Controls.Add(this.buttonExitApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(581, 406);
            this.MinimumSize = new System.Drawing.Size(581, 406);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Служба отправки чеков Атол EoU";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExitApp;
        private System.Windows.Forms.Button buttonTesrtSatarEOU;
        private System.Windows.Forms.Button buttonStartEoU;
        private System.Windows.Forms.Button buttonSaveSetings;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

