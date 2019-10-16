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
            this.buttonExitApp = new System.Windows.Forms.Button();
            this.buttonTesrtSatarEOU = new System.Windows.Forms.Button();
            this.buttonStartEoU = new System.Windows.Forms.Button();
            this.buttonSaveSetings = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.Location = new System.Drawing.Point(445, 292);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(97, 43);
            this.buttonExitApp.TabIndex = 0;
            this.buttonExitApp.Text = "Выход";
            this.buttonExitApp.UseVisualStyleBackColor = true;
            this.buttonExitApp.Click += new System.EventHandler(this.ButtonExitApp_Click);
            // 
            // buttonTesrtSatarEOU
            // 
            this.buttonTesrtSatarEOU.Location = new System.Drawing.Point(22, 292);
            this.buttonTesrtSatarEOU.Name = "buttonTesrtSatarEOU";
            this.buttonTesrtSatarEOU.Size = new System.Drawing.Size(162, 43);
            this.buttonTesrtSatarEOU.TabIndex = 1;
            this.buttonTesrtSatarEOU.Text = "Запустить для отправки чеков EoU";
            this.buttonTesrtSatarEOU.UseVisualStyleBackColor = true;
            this.buttonTesrtSatarEOU.Click += new System.EventHandler(this.ButtonTesrtSatarEOU_Click);
            // 
            // buttonStartEoU
            // 
            this.buttonStartEoU.Location = new System.Drawing.Point(177, 158);
            this.buttonStartEoU.Name = "buttonStartEoU";
            this.buttonStartEoU.Size = new System.Drawing.Size(230, 63);
            this.buttonStartEoU.TabIndex = 2;
            this.buttonStartEoU.Text = "Установить службу отправки чеков EoU";
            this.buttonStartEoU.UseVisualStyleBackColor = true;
            this.buttonStartEoU.Click += new System.EventHandler(this.Button3_Click);
            // 
            // buttonSaveSetings
            // 
            this.buttonSaveSetings.Location = new System.Drawing.Point(245, 292);
            this.buttonSaveSetings.Name = "buttonSaveSetings";
            this.buttonSaveSetings.Size = new System.Drawing.Size(133, 43);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 359);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonSaveSetings);
            this.Controls.Add(this.buttonStartEoU);
            this.Controls.Add(this.buttonTesrtSatarEOU);
            this.Controls.Add(this.buttonExitApp);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

