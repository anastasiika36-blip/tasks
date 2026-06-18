using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BullsAndCows
{
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();
        private int[] secretNumber;
        private int digitsCount = 4;
        private int attempts = 0;
        private Timer timer;
        private int seconds = 0;
        private bool isGameActive = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            numericUpDownDigits.ValueChanged += NumericUpDownDigits_ValueChanged;
            textBoxGuess.KeyPress += TextBoxGuess_KeyPress;
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;

            btnStop.Enabled = false;
            textBoxGuess.Enabled = false;
        }

        private void GenerateSecretNumber()
        {
            digitsCount = (int)numericUpDownDigits.Value;
            secretNumber = new int[digitsCount];

            List<int> digits = Enumerable.Range(0, 10).ToList();
            for (int i = 0; i < digitsCount; i++)
            {
                int index = random.Next(digits.Count);
                if (i == 0 && digits[index] == 0)
                    index = random.Next(1, digits.Count);
                secretNumber[i] = digits[index];
                digits.RemoveAt(index);
            }
        }

        private void TextBoxGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CheckGuess();
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void CheckGuess()
        {
            if (!isGameActive) return;

            string guessText = textBoxGuess.Text.Trim();

            if (guessText.Length != digitsCount)
            {
                MessageBox.Show($"Введите {digitsCount}-значное число.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxGuess.Clear();
                textBoxGuess.Focus();
                return;
            }

            if (guessText.Distinct().Count() != digitsCount)
            {
                MessageBox.Show("Цифры не должны повторяться.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxGuess.Clear();
                textBoxGuess.Focus();
                return;
            }

            int[] guessDigits = guessText.Select(c => int.Parse(c.ToString())).ToArray();

            int bulls = 0, cows = 0;
            for (int i = 0; i < digitsCount; i++)
            {
                if (guessDigits[i] == secretNumber[i])
                    bulls++;
                else if (secretNumber.Contains(guessDigits[i]))
                    cows++;
            }

            attempts++;
            UpdateStatus();

            labelBulls.Text = $"Угадано цифр: {cows + bulls}";
            labelCows.Text = $"Из них на своих местах: {bulls}";

            if (bulls == digitsCount)
            {
                timer.Stop();
                isGameActive = false;
                btnStart.Text = "Новая игра";
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                textBoxGuess.Enabled = false;
                numericUpDownDigits.Enabled = true;

                MessageBox.Show($"Поздравляем! Вы угадали число {guessText}!\n" +
                    $"Попыток: {attempts}\nВремя: {seconds} сек.",
                    "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBoxGuess.Clear();
            textBoxGuess.Focus();
        }

        private void UpdateStatus()
        {
            toolStripAttempts.Text = $"Попыток: {attempts}";
            toolStripTime.Text = $"Затрачено времени: {seconds} сек.";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            toolStripTime.Text = $"Затрачено времени: {seconds} сек.";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            attempts = 0;
            seconds = 0;
            isGameActive = true;

            GenerateSecretNumber();

            labelBulls.Text = "Угадано цифр: 0";
            labelCows.Text = "Из них на своих местах: 0";
            textBoxGuess.Clear();
            textBoxGuess.Enabled = true;
            textBoxGuess.Focus();
            btnStart.Text = "Стоп";
            btnStop.Enabled = true;
            numericUpDownDigits.Enabled = false;
            UpdateStatus();

            timer.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (isGameActive)
            {
                timer.Stop();
                isGameActive = false;

                string secret = string.Join("", secretNumber);
                MessageBox.Show($"Загаданное число: {secret}\n" +
                    $"Попыток: {attempts}\nВремя: {seconds} сек.",
                    "Игра остановлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnStart.Text = "Новая игра";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            textBoxGuess.Enabled = false;
            numericUpDownDigits.Enabled = true;
        }

        private void NumericUpDownDigits_ValueChanged(object sender, EventArgs e)
        {
            if (!isGameActive)
            {
                textBoxGuess.MaxLength = (int)numericUpDownDigits.Value;
                textBoxGuess.Clear();
                digitsCount = (int)numericUpDownDigits.Value;
            }
        }
    }
}