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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.Location = new System.Drawing.Point(334, 219);
            this.buttonExitApp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(73, 54);
            this.buttonExitApp.TabIndex = 0;
            this.buttonExitApp.Text = "Выход";
            this.buttonExitApp.UseVisualStyleBackColor = true;
            this.buttonExitApp.Click += new System.EventHandler(this.ButtonExitApp_Click);
            // 
            // buttonTesrtSatarEOU
            // 
            this.buttonTesrtSatarEOU.Location = new System.Drawing.Point(16, 219);
            this.buttonTesrtSatarEOU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTesrtSatarEOU.Name = "buttonTesrtSatarEOU";
            this.buttonTesrtSatarEOU.Size = new System.Drawing.Size(122, 54);
            this.buttonTesrtSatarEOU.TabIndex = 1;
            this.buttonTesrtSatarEOU.Text = "Скачать или проверить обновление службы  EoU";
            this.buttonTesrtSatarEOU.UseVisualStyleBackColor = true;
            this.buttonTesrtSatarEOU.Click += new System.EventHandler(this.ButtonTesrtSatarEOU_Click);
            // 
            // buttonStartEoU
            // 
            this.buttonStartEoU.Location = new System.Drawing.Point(133, 109);
            this.buttonStartEoU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStartEoU.Name = "buttonStartEoU";
            this.buttonStartEoU.Size = new System.Drawing.Size(172, 61);
            this.buttonStartEoU.TabIndex = 2;
            this.buttonStartEoU.Text = "Запустить службу отправки чеков EoU";
            this.buttonStartEoU.UseVisualStyleBackColor = true;
            this.buttonStartEoU.Click += new System.EventHandler(this.Button3_Click);
            // 
            // buttonSaveSetings
            // 
            this.buttonSaveSetings.Location = new System.Drawing.Point(184, 219);
            this.buttonSaveSetings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSaveSetings.Name = "buttonSaveSetings";
            this.buttonSaveSetings.Size = new System.Drawing.Size(100, 54);
            this.buttonSaveSetings.TabIndex = 3;
            this.buttonSaveSetings.Text = "Сохранить настройки";
            this.buttonSaveSetings.UseVisualStyleBackColor = true;
            this.buttonSaveSetings.Click += new System.EventHandler(this.ButtonSaveSetings_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(14, 15);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(9, 13);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "l";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(133, 175);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Запускать к скрытом режиме";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(133, 197);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(158, 17);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Порт";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 131);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 298);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonSaveSetings);
            this.Controls.Add(this.buttonStartEoU);
            this.Controls.Add(this.buttonTesrtSatarEOU);
            this.Controls.Add(this.buttonExitApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 337);
            this.MinimumSize = new System.Drawing.Size(440, 337);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Служба отправки чеков Атол EoU";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

