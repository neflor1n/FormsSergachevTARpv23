using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Reflection.Metadata.Ecma335;

namespace FormsSergachevTARpv23
{
    public partial class KolmasVorm : Form
    {
        Label lb, plusLeftLb, plusRightLb;
        TextBox tx;
        Timer tmr;
        int timeLeft;
        
        public KolmasVorm(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Math Quiz";
            

            lb = new Label();
            lb.Location = new Point(150, 0);
            lb.Text = "Time Left:";
            lb.Font = new Font("Arial", 28, FontStyle.Bold);
            lb.Size = new Size(250, 75);
            this.Controls.Add(lb);

            tx = new TextBox();
            tx.Location = new Point(440, 15);
            tx.AutoSize = false;
            tx.TextAlign = HorizontalAlignment.Center;
            tx.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(tx);

            /*
            Timer tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick
            */

        }
    }
}
