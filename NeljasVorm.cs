using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class NeljasVorm : Form
    {
        TableLayoutPanel tableLayoutPanel;
        Button[] buttons;
        Random random = new Random();
        System.Drawing.Image[] images;
        Button firstClicked = null;
        Button secondClicked = null;
        int matchedPairs = 0; // Счетчик угаданных пар
        MenuStrip ms;
        public NeljasVorm(int w, int h)
        {
            this.Text = "Matching Game";
            this.ClientSize = new Size(400, 400);

            images = new System.Drawing.Image[]
            {
                System.Drawing.Image.FromFile(@"..\..\..\img\code.png"),
                System.Drawing.Image.FromFile(@"..\..\..\img\JavaScript.png"),
                System.Drawing.Image.FromFile(@"..\..\..\img\css3.png"),
                System.Drawing.Image.FromFile(@"..\..\..\img\java.png"),
                System.Drawing.Image.FromFile(@"..\..\..\img\php.png"),
                System.Drawing.Image.FromFile(@"..\..\..\img\typescript.png"),
                System.Drawing.Image.FromFile(@"..\..\..\img\python.png"),
                System.Drawing.Image.FromFile(@"..\..\..\img\swift.png")
            };

            // Увеличиваем массив до 16 элементов и дублируем изображения для пар
            Array.Resize(ref images, 16);
            Array.Copy(images, 0, images, 8, 8);

            ShuffleImages();

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

            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem windowsMenu = new ToolStripMenuItem("Window");
            ToolStripMenuItem windowColorMenu = new ToolStripMenuItem("Change window color", null, new EventHandler(windowColorMenuClick));
            ToolStripMenuItem windowAkenSuurus = new ToolStripMenuItem("Change window permission", null, new EventHandler(windowPermissionChange));
            windowsMenu.DropDownItems.Add(windowAkenSuurus);
            windowsMenu.DropDownItems.Add(windowColorMenu);
            ms.Items.Add(windowsMenu);
            ms.Dock = DockStyle.Top;
            MainMenuStrip = ms;
            Controls.Add(ms);

            this.Controls.Add(tableLayoutPanel);
        }

        private void windowPermissionChange(object sender, EventArgs e) {
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

            if(cd.ShowDialog() == DialogResult.OK) {
                this.BackColor = cd.Color;}
        }

        // Обработчик события клика на кнопку
        private void Button_Click(object sender, EventArgs e)
        {
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

            // Если изображения совпадают
            if (firstClicked.Tag == secondClicked.Tag)
            {
                firstClicked = null;
                secondClicked = null;

                matchedPairs++; // Увеличиваем счетчик угаданных пар

                // Если угаданы все пары
                if (matchedPairs == 8) // У нас 8 пар
                {
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
                        Application.Exit();
                    }
                }
            }
            else
            {
                // Если изображения не совпадают, скрываем их через 1 секунду
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        // Таймер для скрытия изображений
        private void Timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            timer.Stop();

            firstClicked.BackgroundImage = null;
            secondClicked.BackgroundImage = null;

            firstClicked = null;
            secondClicked = null;
        }

        // Перемешивание изображений
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
