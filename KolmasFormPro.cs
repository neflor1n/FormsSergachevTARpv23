using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class KolmasFormPro : Form
    {
        Random randomizer = new Random();

        Label plusLeftLabel, plusRightLabel, minusLeftLabel, minusRightLabel,
            timesLeftLabel, timesRightLabel, dividedLeftLabel, dividedRightLabel,
            plusSign, minusSign, timesSign, dividedSign, equals1, equals2, equals3, equals4, timeLabel;

        NumericUpDown sum, difference, product, quotient;
        System.Windows.Forms.Timer timer1;
        Button startButton, finishButton;
        int timeLeft;

        int addend1, addend2;  // Addition
        int minuend, subtrahend;  // Subtraction
        int multiplicand, multiplier;  // Multiplication
        int dividend, divisor;  // Division

        int correctAnswers = 0;  // Счетчик правильных ответов
        int incorrectAnswers = 0; // Счетчик неправильных ответов

        Label correctLabel, incorrectLabel;
        public KolmasFormPro(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Math Quiz";

            plusLeftLabel = new Label();
            plusRightLabel = new Label();
            minusLeftLabel = new Label();
            minusRightLabel = new Label();
            timesLeftLabel = new Label();
            timesRightLabel = new Label();
            dividedLeftLabel = new Label();
            dividedRightLabel = new Label();

            sum = new NumericUpDown();
            difference = new NumericUpDown();
            product = new NumericUpDown();
            quotient = new NumericUpDown();
            timeLabel = new Label();

            plusSign = new Label();
            minusSign = new Label();
            timesSign = new Label();
            dividedSign = new Label();
            equals1 = new Label();
            equals2 = new Label();
            equals3 = new Label();
            equals4 = new Label();

            plusSign.Text = "+";
            minusSign.Text = "-";
            timesSign.Text = "×";
            dividedSign.Text = "÷";
            equals1.Text = "=";
            equals2.Text = "=";
            equals3.Text = "=";
            equals4.Text = "=";


            correctLabel = new Label();
            incorrectLabel = new Label();




            plusLeftLabel.Location = new Point(50, 50);
            plusLeftLabel.Font = new Font("Arial", 16);
            plusLeftLabel.Size = new Size(40, 40);

            plusRightLabel.Location = new Point(180, 50);
            plusRightLabel.Font = new Font("Arial", 16);
            plusRightLabel.Size = new Size(40, 40);

            plusSign.Location = new Point(135, 50);
            plusSign.Size = new Size(30, 30);

            equals1.Location = new Point(280, 50);
            equals1.Size = new Size(20, 20);
            sum.Location = new Point(350, 50);







            minusLeftLabel.Location = new Point(50, 90);
            minusLeftLabel.Size = new Size(40, 40);
            minusLeftLabel.Font = new Font("Arial", 16);

            minusRightLabel.Location = new Point(180, 90);
            minusRightLabel.Size = new Size(40, 40);
            minusRightLabel.Font = new Font("Arial", 16);

            minusSign.Location = new Point(135, 90);
            minusSign.Size = new Size(30, 30);

            equals2.Location = new Point(280, 90);
            equals2.Size = new Size(20, 20);
            difference.Location = new Point(350, 90);



            timesLeftLabel.Location = new Point(50, 130);
            timesRightLabel.Location = new Point(180, 130);

            timesRightLabel.Size = new Size(40, 40);
            timesLeftLabel.Size = new Size(40, 40);

            timesLeftLabel.Font = new Font("Arial", 16);
            timesRightLabel.Font = new Font("Arial", 16);

            timesSign.Location = new Point(135, 130);
            timesSign.Size = new Size(30, 30);

            equals3.Location = new Point(280, 130);
            equals3.Size = new Size(20, 20);

            product.Location = new Point(350, 130);


            dividedLeftLabel.Location = new Point(50, 170);
            dividedRightLabel.Location = new Point(180, 170);

            dividedRightLabel.Font = new Font("Arial", 16);
            dividedLeftLabel.Font = new Font("Arial", 16);

            dividedLeftLabel.Size = new Size(40, 40);
            dividedRightLabel.Size = new Size(40, 40);

            dividedSign.Location = new Point(135, 170);
            dividedSign.Size = new Size(40, 40);
            equals4.Location = new Point(280, 170);
            equals4.Size = new Size(20, 20);
            quotient.Location = new Point(350, 170);

            timeLabel.Location = new Point(300, 10);
            timeLabel.Size = new Size(200, 30);
            timeLabel.Font = new Font("Arial", 16);
            timeLabel.Text = "Time Left: ";

            this.Controls.Add(plusLeftLabel);
            this.Controls.Add(plusRightLabel);
            this.Controls.Add(plusSign);
            this.Controls.Add(equals1);
            this.Controls.Add(sum);

            this.Controls.Add(minusLeftLabel);
            this.Controls.Add(minusRightLabel);
            this.Controls.Add(minusSign);
            this.Controls.Add(equals2);
            this.Controls.Add(difference);

            this.Controls.Add(timesLeftLabel);
            this.Controls.Add(timesRightLabel);
            this.Controls.Add(timesSign);
            this.Controls.Add(equals3);
            this.Controls.Add(product);

            this.Controls.Add(dividedLeftLabel);
            this.Controls.Add(dividedRightLabel);
            this.Controls.Add(dividedSign);
            this.Controls.Add(equals4);
            this.Controls.Add(quotient);

            this.Controls.Add(timeLabel);



            correctLabel.Location = new Point(50, 250);
            correctLabel.Size = new Size(200, 30);
            correctLabel.Text = "Õiged vastused: 0";

            incorrectLabel.Location = new Point(50, 290);
            incorrectLabel.Size = new Size(200, 30);
            incorrectLabel.Text = "Valed vastused: 0";

            this.Controls.Add(correctLabel);
            this.Controls.Add(incorrectLabel);

            startButton = new Button();
            startButton.Text = "Alustage viktoriini";
            startButton.Location = new Point(100, 210);
            startButton.Size = new Size(100, 20);
            startButton.Click += new EventHandler(StartButton_Click);
            this.Controls.Add(startButton);

            finishButton = new Button();
            finishButton.Text = "Täitke viktoriini";
            finishButton.Location = new Point(220, 210);
            finishButton.Size = new Size(100, 20);
            finishButton.Click += new EventHandler(FinishButton_Click);
            this.Controls.Add(finishButton);

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
        }

        public void StartTheQuiz()
        {

            correctAnswers = 0;
            incorrectAnswers = 0;
            UpdateAnswerLabels();


            timeLeft = 20;
            timeLabel.Text = "20 seconds";
            timer1.Interval = 1000;
            timer1.Start();

            // Addition
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            // Subtraction
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Multiplication
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Division
            divisor = randomizer.Next(1, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;

            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
        }

        private bool CheckTheAnswer()
        {
            bool allCorrect = true;

            // Проверяем ответы пользователя на правильность и обновляем счетчики
            if (addend1 + addend2 == sum.Value)
                correctAnswers++;
            else
            {
                incorrectAnswers++;
                allCorrect = false;
            }

            if (minuend - subtrahend == difference.Value)
                correctAnswers++;
            else
            {
                incorrectAnswers++;
                allCorrect = false;
            }

            if (multiplicand * multiplier == product.Value)
                correctAnswers++;
            else
            {
                incorrectAnswers++;
                allCorrect = false;
            }

            if (dividend / divisor == quotient.Value)
                correctAnswers++;
            else
            {
                incorrectAnswers++;
                allCorrect = false;
            }

            UpdateAnswerLabels();
            return allCorrect;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " " + "seconds";
            }
            else
            { 
                timer1.Stop();
                timeLabel.Text = "Aeg on läbi!";
                if (CheckTheAnswer())
                {
                    MessageBox.Show("Vastasite kõigile küsimustele õigesti!", "Palju õnne!");
                }
                else
                {
                    MessageBox.Show("On valesid vastuseid.", "Kontrolli oma vastuseid!");
                }
                ShowCorrectAnswers();
                startButton.Enabled = true;
                finishButton.Enabled = false;
                timer1.Stop();
                
            }

        }





        private void UpdateAnswerLabels()
        {
            correctLabel.Text = $"Õiged vastused: {correctAnswers}";
            incorrectLabel.Text = $"Valed vastused: {incorrectAnswers}";
        }




        private void FinishButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (CheckTheAnswer())
            {
                MessageBox.Show("Vastasite kõigile küsimustele õigesti!", "Palju õnne!");
            }
            else
            {
                MessageBox.Show("On valesid vastuseid.", "Kontrolli oma vastuseid!");
                ShowCorrectAnswers();
            }

            startButton.Enabled = true;
            finishButton.Enabled = false;
        }

        private void ShowCorrectAnswers()
        {
            sum.Value = addend1 + addend2;
            difference.Value = minuend - subtrahend;
            product.Value = multiplicand * multiplier;
            quotient.Value = dividend / divisor;
        }
    }
}
