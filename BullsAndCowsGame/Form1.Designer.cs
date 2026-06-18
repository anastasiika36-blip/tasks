namespace BullsAndCows
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDigits;
        private System.Windows.Forms.NumericUpDown numericUpDownDigits;
        private System.Windows.Forms.Label labelGuess;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Label labelBulls;
        private System.Windows.Forms.Label labelCows;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripAttempts;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDigits = new System.Windows.Forms.Label();
            this.numericUpDownDigits = new System.Windows.Forms.NumericUpDown();
            this.labelGuess = new System.Windows.Forms.Label();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.labelBulls = new System.Windows.Forms.Label();
            this.labelCows = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripAttempts = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDigits)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(242, 17);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Угадайте задуманное компьютером число.";

            // labelDigits
            this.labelDigits.AutoSize = true;
            this.labelDigits.Location = new System.Drawing.Point(20, 60);
            this.labelDigits.Name = "labelDigits";
            this.labelDigits.Size = new System.Drawing.Size(82, 13);
            this.labelDigits.TabIndex = 1;
            this.labelDigits.Text = "Число знаков:";

            // numericUpDownDigits
            this.numericUpDownDigits.Location = new System.Drawing.Point(120, 58);
            this.numericUpDownDigits.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            this.numericUpDownDigits.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            this.numericUpDownDigits.Name = "numericUpDownDigits";
            this.numericUpDownDigits.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownDigits.TabIndex = 2;
            this.numericUpDownDigits.Value = new decimal(new int[] { 4, 0, 0, 0 });

            // labelGuess
            this.labelGuess.AutoSize = true;
            this.labelGuess.Location = new System.Drawing.Point(20, 100);
            this.labelGuess.Name = "labelGuess";
            this.labelGuess.Size = new System.Drawing.Size(40, 13);
            this.labelGuess.TabIndex = 3;
            this.labelGuess.Text = "Число:";

            // textBoxGuess
            this.textBoxGuess.Location = new System.Drawing.Point(120, 98);
            this.textBoxGuess.MaxLength = 6;
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(100, 20);
            this.textBoxGuess.TabIndex = 4;

            // labelBulls
            this.labelBulls.AutoSize = true;
            this.labelBulls.Location = new System.Drawing.Point(20, 140);
            this.labelBulls.Name = "labelBulls";
            this.labelBulls.Size = new System.Drawing.Size(96, 13);
            this.labelBulls.TabIndex = 5;
            this.labelBulls.Text = "Угадано цифр: 0";

            // labelCows
            this.labelCows.AutoSize = true;
            this.labelCows.Location = new System.Drawing.Point(20, 170);
            this.labelCows.Name = "labelCows";
            this.labelCows.Size = new System.Drawing.Size(133, 13);
            this.labelCows.TabIndex = 6;
            this.labelCows.Text = "Из них на своих местах: 0";

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(20, 210);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;

            // btnStop
            this.btnStop.Location = new System.Drawing.Point(120, 210);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Завершить";
            this.btnStop.UseVisualStyleBackColor = true;

            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripAttempts,
                this.toolStripTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 248);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(340, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";

            // toolStripAttempts
            this.toolStripAttempts.Name = "toolStripAttempts";
            this.toolStripAttempts.Size = new System.Drawing.Size(74, 17);
            this.toolStripAttempts.Text = "Попыток: 0";

            // toolStripTime
            this.toolStripTime.Name = "toolStripTime";
            this.toolStripTime.Size = new System.Drawing.Size(113, 17);
            this.toolStripTime.Text = "Затрачено времени: 0 сек.";

            // Form1
            this.ClientSize = new System.Drawing.Size(340, 270);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labelCows);
            this.Controls.Add(this.labelBulls);
            this.Controls.Add(this.textBoxGuess);
            this.Controls.Add(this.labelGuess);
            this.Controls.Add(this.numericUpDownDigits);
            this.Controls.Add(this.labelDigits);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDigits)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}