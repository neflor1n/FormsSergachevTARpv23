using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class StartNeljasForm: Form
    {
        RadioButton rbtn, rbtn2, rbtn3;
        public StartNeljasForm()
        {
            this.Width = 700;
            this.Height = 600;
            this.Text = "Start game menu";

            rbtn = new RadioButton();
            rbtn2 = new RadioButton();
            rbtn3 = new RadioButton();

            rbtn.Text = "PRO";
            rbtn2.Text = "MIDDLE";
            rbtn3.Text = "NOOB";

            rbtn.Checked = false;
            rbtn2.Checked = false;
            rbtn3.Checked = false;

            rbtn.AutoSize = true;
            rbtn2.AutoSize = true;
            rbtn3.AutoSize = true;

            rbtn.Location = new Point((this.ClientSize.Width - rbtn.Width) / 2, (this.ClientSize.Height - rbtn.Height) / 2);
            rbtn2.Location = new Point((this.ClientSize.Width - rbtn2.Width) / 2, (this.ClientSize.Height - rbtn2.Height) / 2 + 30); // Смещение для второго
            rbtn3.Location = new Point((this.ClientSize.Width - rbtn3.Width) / 2, (this.ClientSize.Height - rbtn3.Height) / 2 + 60); // Смещение для третьего


            rbtn.Click += rbtn_checkedChanged;
            rbtn2.Click += rbtn_checkedChanged;
            rbtn3.Click += rbtn_checkedChanged;

            this.Controls.Add(rbtn);
            this.Controls.Add(rbtn2);
            this.Controls.Add(rbtn3);


            
        }
        private void rbtn_checkedChanged(object sender, EventArgs e)
        {
            if (rbtn.Checked)
            {
                int w = 700;
                int h = 600;

                var aken = MessageBox.Show("Vali akna suurus", "Kas soovite määrata oma akna suuruse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (aken == DialogResult.Yes)
                {
                    string wi = Interaction.InputBox("Sisestage akna laius");
                    if (string.IsNullOrWhiteSpace(wi))
                    {
                        MessageBox.Show("Palun sisestage laius");
                        return;
                    }

                    string he = Interaction.InputBox("Sisestage akna kõrgus");
                    if (string.IsNullOrWhiteSpace(he))
                    {
                        MessageBox.Show("Palun sisestage kõrgus");
                        return;
                    }

                    if (!int.TryParse(wi, out w))
                    {
                        MessageBox.Show("Laius peab olema number.");
                        return;
                    }

                    if (!int.TryParse(he, out h))
                    {
                        MessageBox.Show("Kõrgus peab olema number.");
                        return;
                    }
                }

                esimeneGame esimeneGame = new esimeneGame(w, h);
                esimeneGame.Show();

            }


            else if (rbtn2.Checked)
            {

                int w = 700;
                int h = 600;

                var aken = MessageBox.Show("Vali akna suurus", "Kas sa soovite määrata oma akna suurus?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (aken == DialogResult.Yes)
                {
                    string wi = Interaction.InputBox("Sisestage akna laius");
                    if (string.IsNullOrWhiteSpace(wi))
                    {
                        MessageBox.Show("Palun sisestage laius");
                        return;

                    }
                    string he = Interaction.InputBox("Sisestage akna kõrgus");
                    if (string.IsNullOrWhiteSpace(he))
                    {
                        MessageBox.Show("Palun sisestage kõrgus");
                        return;
                    }

                    if (!int.TryParse(wi, out w))
                    {
                        MessageBox.Show("Laius peab olema number.");
                        return;

                    }
                    if (!int.TryParse(he, out h))
                    {
                        MessageBox.Show("Kõrgus peab olema number.");
                        return;
                    }


                }
                
                teineGame teineGame = new teineGame(w, h);
                teineGame.Show();


            }

            else if (rbtn3.Checked)
            {
                int w = 700;
                int h = 600;


                var aken = MessageBox.Show("Vali akna suurus", "Kas sa soovite määrata oma akna suurus?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (aken == DialogResult.Yes)
                {
                    string wi = Interaction.InputBox("Sisestage akna laius");
                    if (string.IsNullOrWhiteSpace(wi))
                    {
                        MessageBox.Show("Palun sisestage laius");
                        return;

                    }
                    string he = Interaction.InputBox("Sisestage akna kõrgus");
                    if (string.IsNullOrWhiteSpace(he))
                    {
                        MessageBox.Show("Palun sisestage kõrgus");
                        return;
                    }

                    if (!int.TryParse(wi, out w))
                    {
                        MessageBox.Show("Laius peab olema number.");
                        return;

                    }
                    if (!int.TryParse(he, out h))
                    {
                        MessageBox.Show("Kõrgus peab olema number.");
                        return;
                    }

                }
                NeljasVorm kolmasGame = new NeljasVorm(w, h);
                kolmasGame.Show();
            }

            

        }
    }
}
