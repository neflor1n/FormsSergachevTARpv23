using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class TeineVorm : Form
    {
        PictureBox picBox;
        Button showPictureButton, setBackgroundColorButton, clearPictureButton, closeButton;
        CheckBox stretchCheckBox;

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

        private void InitializeComponent()
        {
        }
    }
}
