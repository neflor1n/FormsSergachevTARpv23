using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class esimeneGame : Form
    {
        TableLayoutPanel tableLayoutPanel;
        Button[] buttons;
        Random random = new Random();
        System.Drawing.Image[] images;
        Button firstClicked = null;
        Button secondClicked = null;
        int matchedPairs = 0; // Счетчик угаданных пар
        MenuStrip ms;
        System.Windows.Forms.Timer timer;
        Label timerLabel;
        int remainingTime = 20; // Отсчет
        bool gameStarted = false; // Отслеживание начала игры

        public esimeneGame(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Matching Game";
            this.ClientSize = new Size(400, 450); // Увеличиваем высоту формы

            images = new Image[]
            {
            Image.FromFile(@"..\..\..\img\code.png"),
            Image.FromFile(@"..\..\..\img\JavaScript.png"),
            Image.FromFile(@"..\..\..\img\css3.png"),
            Image.FromFile(@"..\..\..\img\java.png"),
            Image.FromFile(@"..\..\..\img\php.png"),
            Image.FromFile(@"..\..\..\img\typescript.png"),
            Image.FromFile(@"..\..\..\img\python.png"),
            Image.FromFile(@"..\..\..\img\swift.png")
            };

            Array.Resize(ref images, 16);
            Array.Copy(images, 0, images, 8, 8);

            ShuffleImages();

            // Основная вертикальная панель для всей формы
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(mainPanel);

            // Панель для таймера с фиксированной высотой
            Panel timerPanel = new Panel();
            timerPanel.Dock = DockStyle.Top;
            timerPanel.Height = 20; // Высота панели под таймер
            timerPanel.BackColor = Color.LightGray;
            mainPanel.Controls.Add(timerPanel);

            // Инициализация метки таймера
            timerLabel = new Label();
            timerLabel.Dock = DockStyle.Fill;
            timerLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            timerLabel.TextAlign = ContentAlignment.MiddleCenter;
            timerLabel.Text = $"Time: {remainingTime}s"; // Начало с 20 секунд
            timerPanel.Controls.Add(timerLabel);

            // Панель с кнопками
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.Dock = DockStyle.Fill;

            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            buttons = new Button[16];
            for (int i = 0; i < 16; i++)
            {
                buttons[i] = new Button();
                buttons[i].Dock = DockStyle.Fill;
                buttons[i].BackColor = Color.LightBlue;
                buttons[i].Tag = images[i];
                buttons[i].Click += Button_Click;
                tableLayoutPanel.Controls.Add(buttons[i]);
            }

            mainPanel.Controls.Add(tableLayoutPanel);

            // Инициализация таймера
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Таймер срабатывает каждую секунду
            timer.Tick += Timer_Tick1;

            // Инициализация меню
            ms = new MenuStrip();
            ToolStripMenuItem windowsMenu = new ToolStripMenuItem("Window");
            ToolStripMenuItem windowColorMenu = new ToolStripMenuItem("Change window color", null, new EventHandler(windowColorMenuClick));
            ToolStripMenuItem windowAkenSuurus = new ToolStripMenuItem("Change window permission", null, new EventHandler(windowPermissionChange));
            windowsMenu.DropDownItems.Add(windowAkenSuurus);
            windowsMenu.DropDownItems.Add(windowColorMenu);
            ms.Items.Add(windowsMenu);
            ms.Dock = DockStyle.Top;
            MainMenuStrip = ms;
            this.Controls.Add(ms);

            
        }

        private void Timer_Tick1(object? sender, EventArgs e)
        {
            remainingTime--; // Уменьшаем время
            timerLabel.Text = $"Time: {remainingTime}s";

            if (remainingTime <= 0)
            {
                timer.Stop(); // Остановка таймера, если время закончилось
                MessageBox.Show("Время вышло! Игра окончена.", "Конец игры");
                this.Close(); // Закрываем окно
            }
        }

        // Остальной код остаётся без изменений...

        private void windowPermissionChange(object sender, EventArgs e)
        {
            int w = this.Width;
            int h = this.Height;
            var agree = MessageBox.Show("Kas olete kindel, et soovite ekraani suurust muuta?", "Suurus", MessageBoxButtons.YesNo);
            if (agree == DialogResult.Yes)
            {
                string he = Interaction.InputBox("Sisesta kõrgus");
                if (string.IsNullOrEmpty(he))
                {
                    MessageBox.Show("Palun sisesta kõrgus");
                    return;
                }

                string wi = Interaction.InputBox("Sisesta laius");
                if (string.IsNullOrEmpty(wi))
                {
                    MessageBox.Show("Palun sisesta kõrgus");
                    return;
                }

                if (!int.TryParse(wi, out int width))
                {
                    MessageBox.Show("Laius peab olema number");
                    return;
                }

                if (!int.TryParse(he, out int height))
                {
                    MessageBox.Show("Kõrgus peab olema number");
                    return;
                }
                this.Width = width;
                this.Height = height;
                NeljasVorm neljas = new NeljasVorm(w, h);
                neljas.Show();
            }
        }

        private void windowColorMenuClick(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cd.Color;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {

            if (!gameStarted)
            {
                timer.Start();
                gameStarted = true;
            }

            if (firstClicked != null && secondClicked != null)
                return;

            Button clickedButton = sender as Button;

            if (clickedButton == null || clickedButton.BackgroundImage != null)
                return;

            clickedButton.BackgroundImage = clickedButton.Tag as Image;
            clickedButton.BackgroundImageLayout = ImageLayout.Stretch;

            if (firstClicked == null)
            {
                firstClicked = clickedButton;
                return;
            }

            secondClicked = clickedButton;

            if (firstClicked.Tag == secondClicked.Tag)
            {
                firstClicked = null;
                secondClicked = null;

                matchedPairs++;

                if (matchedPairs == 8)
                {
                    timer.Stop(); // Остановка таймера
                    var aken = MessageBox.Show("Palju õnne! Sa arvasid kõik paarid ära!", "Mäng on läbi! Kas soovite jätkata?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (aken == DialogResult.Yes)
                    {
                        int w = 700;
                        int h = 600;

                        NeljasVorm newForm = new NeljasVorm(w, h);
                        newForm.Show();

                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 300;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            timer.Stop();

            firstClicked.BackgroundImage = null;
            secondClicked.BackgroundImage = null;

            firstClicked = null;
            secondClicked = null;
        }

        private void ShuffleImages()
        {
            for (int i = 0; i < images.Length; i++)
            {
                int j = random.Next(i, images.Length);
                var temp = images[i];
                images[i] = images[j];
                images[j] = temp;
            }
        }
    }
}
