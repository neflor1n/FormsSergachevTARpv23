using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class KolmasformNoob : Form
    {
        private IContainer components = null;

        public KolmasformNoob()
        {
            InitializeComponent();
        }

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
            this.components = new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Text = "KolmasformNoob";
        }
    }
}
