
namespace Encryption_Vigenera_2lab
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
            this.encryptButton = new MetroFramework.Controls.MetroButton();
            this.cryptButton = new MetroFramework.Controls.MetroButton();
            this.TextBox = new MetroFramework.Controls.MetroTextBox();
            this.keyTextBox = new MetroFramework.Controls.MetroTextBox();
            this.resultTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ExitButton = new MetroFramework.Controls.MetroButton();
            this.hackButton = new MetroFramework.Controls.MetroButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clearButton = new MetroFramework.Controls.MetroButton();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.nowINTLabel = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(507, 63);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(144, 50);
            this.encryptButton.TabIndex = 0;
            this.encryptButton.Text = "Зашифровать";
            this.encryptButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // cryptButton
            // 
            this.cryptButton.Location = new System.Drawing.Point(507, 119);
            this.cryptButton.Name = "cryptButton";
            this.cryptButton.Size = new System.Drawing.Size(144, 50);
            this.cryptButton.TabIndex = 1;
            this.cryptButton.Text = "Расшифровать";
            this.cryptButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cryptButton.Click += new System.EventHandler(this.cryptButton_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(23, 63);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(478, 410);
            this.TextBox.TabIndex = 2;
            this.TextBox.Text = "Здесь нужно писать текст";
            this.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.TextBox.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(23, 479);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(478, 23);
            this.keyTextBox.TabIndex = 3;
            this.keyTextBox.Text = "Здесь нужно писать ключевое слово";
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.keyTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.keyTextBox.Click += new System.EventHandler(this.keyTextBox_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(657, 63);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(478, 439);
            this.resultTextBox.TabIndex = 4;
            this.resultTextBox.Text = "Результат";
            this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.resultTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.resultTextBox.TextChanged += new System.EventHandler(this.resultTextBox_TextChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(507, 452);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(144, 50);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Выход";
            this.ExitButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // hackButton
            // 
            this.hackButton.Location = new System.Drawing.Point(507, 175);
            this.hackButton.Name = "hackButton";
            this.hackButton.Size = new System.Drawing.Size(144, 50);
            this.hackButton.TabIndex = 7;
            this.hackButton.Text = "Взломать";
            this.hackButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.hackButton.Click += new System.EventHandler(this.hackButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listBox1.ForeColor = System.Drawing.Color.Silver;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(507, 231);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 164);
            this.listBox1.TabIndex = 8;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(507, 396);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(144, 50);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Очистить TextBox";
            this.clearButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(248, 34);
            this.metroProgressBar1.Maximum = 6;
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(836, 23);
            this.metroProgressBar1.TabIndex = 11;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(248, 11);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(332, 20);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "Затраченное на взлом время: 0:00:0:00:0:00.0:000";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // nowINTLabel
            // 
            this.nowINTLabel.Location = new System.Drawing.Point(1090, 34);
            this.nowINTLabel.Name = "nowINTLabel";
            this.nowINTLabel.ReadOnly = true;
            this.nowINTLabel.Size = new System.Drawing.Size(45, 23);
            this.nowINTLabel.TabIndex = 15;
            this.nowINTLabel.Text = "0/15";
            this.nowINTLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nowINTLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1157, 525);
            this.ControlBox = false;
            this.Controls.Add(this.nowINTLabel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.hackButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.cryptButton);
            this.Controls.Add(this.encryptButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Шифр Виженера";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton encryptButton;
        private MetroFramework.Controls.MetroButton cryptButton;
        private MetroFramework.Controls.MetroTextBox keyTextBox;
        public MetroFramework.Controls.MetroTextBox TextBox;
        private MetroFramework.Controls.MetroTextBox resultTextBox;
        private MetroFramework.Controls.MetroButton ExitButton;
        private MetroFramework.Controls.MetroButton hackButton;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton clearButton;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox nowINTLabel;
    }
}

