using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class TeineVorm : Form
    {
        PictureBox picBox;
        Button showPictureButton,
            setBackgroundColorButton,
            clearPictureButton,
            closeButton,
            RightButton,
            LeftButton,
            PiksButton,
            modifyPixelButton,
            saveButton,
            resizeButton;
        CheckBox stretchCheckBox;
        NumericUpDown widthUpDown, heightUpDown;

        public TeineVorm(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Picture Viewer";

            picBox = new PictureBox();
            picBox.Dock = DockStyle.Fill;
            picBox.BorderStyle = BorderStyle.Fixed3D;
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picBox);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            
            this.Controls.Add(panel);

            stretchCheckBox = new CheckBox();
            stretchCheckBox.Text = "Stretch";
            stretchCheckBox.Checked = true;
            stretchCheckBox.CheckedChanged += new EventHandler(StretchCheckBox_CheckedChanged);
            panel.Controls.Add(stretchCheckBox);

            showPictureButton = new Button();
            showPictureButton.Height = 25;
            showPictureButton.Width = 100;
            showPictureButton.Text = "Show a picture";
            showPictureButton.Click += new EventHandler(ShowPictureButton_Click);
            panel.Controls.Add(showPictureButton);

            setBackgroundColorButton = new Button();
            setBackgroundColorButton.Text = "Set the background color";
            setBackgroundColorButton.Height = 25;
            setBackgroundColorButton.Width = 200;
            setBackgroundColorButton.Click += new EventHandler(SetBackgroundColorButton_Click);
            panel.Controls.Add(setBackgroundColorButton);

            LeftButton = new Button();
            LeftButton.Text = "Pööramine 90° vasakule";
            LeftButton.Width = 100;
            LeftButton.Height = 25;
            LeftButton.Click += LeftButton_Click;
            panel.Controls.Add(LeftButton);

            RightButton = new Button();
            RightButton.Text = "Pöörake 90° paremale";
            RightButton.Width = 100;
            RightButton.Height = 25;
            RightButton.Click += RightButton_Click;
            panel.Controls.Add(RightButton);

            widthUpDown = new NumericUpDown() { Minimum = 1, Maximum = 5000, Width = 50 };
            heightUpDown = new NumericUpDown() { Minimum = 1, Maximum = 5000, Width = 50 };
            panel.Controls.Add(new Label() { Text = "Width:" });
            panel.Controls.Add(widthUpDown);
            panel.Controls.Add(new Label() { Text = "Height:" });
            panel.Controls.Add(heightUpDown);

            resizeButton = new Button();
            resizeButton.Text = "Resize Image";
            resizeButton.Click += ResizeButton_Click;
            panel.Controls.Add(resizeButton);

            saveButton = new Button();
            saveButton.Text = "Salvesta pilt";
            saveButton.Width = 100;
            saveButton.Height = 25;
            saveButton.Click += SaveButton_Click;
            panel.Controls.Add(saveButton);

            clearPictureButton = new Button();
            clearPictureButton.Text = "Clear the picture";
            clearPictureButton.Width = 100;
            clearPictureButton.Height = 25;
            clearPictureButton.Click += new EventHandler(ClearPictureButton_Click);
            panel.Controls.Add(clearPictureButton);

            closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Height = 25;
            closeButton.Click += new EventHandler(CloseButton_Click);
            panel.Controls.Add(closeButton);

        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {
            if (picBox.Image != null)
            {
                Bitmap originalImage = (Bitmap)picBox.Image; // Работа с пикселями
                int newWidth = (int)widthUpDown.Value;
                int newHeight = (int)heightUpDown.Value;

                Bitmap resizedImage = new Bitmap(originalImage, newWidth, newHeight);
                picBox.Image = resizedImage;
            }
            else
            {
                MessageBox.Show("Palun laadige kõigepealt pilt üles.");
            }
        }



        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (picBox != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Salvesta pilt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileExtention = System.IO.Path.GetExtension(saveFileDialog.FileName);
                    switch (fileExtention.ToLower())
                    {
                        case ".png":
                            picBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case ".jpg":
                        case ".jpeg":
                            picBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            picBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Pildi salvestamiseks puudub");
            }
        }



        private void LeftButton_Click(object? sender, EventArgs e)
        {
            if (picBox != null)
            {
                picBox.Image = RotateImageMinus((Bitmap)picBox.Image);
            }
        }

        private void RightButton_Click(object? sender, EventArgs e)
        {
            if (picBox != null)
            {
                picBox.Image = RotateImagePlus((Bitmap)picBox.Image);
            }
        }

        private Bitmap RotateImagePlus(Bitmap image)
        {
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                g.TranslateTransform(rotatedBmp.Width / 2, rotatedBmp.Height / 2);  // Перемещение точки отсчета в центр нового изображения
                g.RotateTransform(90);
                g.TranslateTransform(-image.Width / 2, -image.Height / 2);  // Возврат точки отсчета в верхний левый угол исходного изображения
                g.DrawImage(image, new Point(0, 0));

            }
            return rotatedBmp;
        }

        private Bitmap RotateImageMinus(Bitmap image)
        {
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                g.TranslateTransform(rotatedBmp.Width / 2, rotatedBmp.Height / 2);
                g.RotateTransform(-90);
                g.TranslateTransform(-image.Width / 2, -image.Height / 2);
                g.DrawImage(image, new Point(0, 0));

            }
            return rotatedBmp;
        }




        private void StretchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stretchCheckBox.Checked)
            {
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picBox.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void ShowPictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image File|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.webp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = new Bitmap(dlg.FileName);
            }
        }

        private void SetBackgroundColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picBox.BackColor = dlg.Color;
            }
        }

        private void ClearPictureButton_Click(object sender, EventArgs e)
        {
            picBox.Image = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
