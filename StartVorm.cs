using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSergachevTARpv23
{
    public partial class StartVorm : Form
    {   
        List<string> elemendid = new List<string>
        {
            "Nupp", "Silt", "Pilt", "Märkeruut", "Raadionupp", "Tekstkast"
        };
        List<string> rbtn_list = new List<string> { "Üks", "Kaks", "Kolm" };
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pic, pic2;
        CheckBox chk1, chk2;
        RadioButton rbtn1, rbtn2, rbtn3;
        CheckBox chk4;
        RadioButton rbtn;
        TextBox txt;
        public StartVorm()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect; ;
            TreeNode tn = new TreeNode("Elemendid: ");
            foreach (var s in elemendid)
            {
                tn.Nodes.Add(new TreeNode(s));
            }
            



            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            // Nupp
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Height = 50;
            btn.Width = 70;
            btn.Location = new Point(150,70);
            btn.Click += Btn_Click;
            // Silt - label
            
            DateTime currentTime = DateTime.Now;
            lbl = new Label();
            lbl.Text = $"{currentTime}";
            lbl.Font = new Font("Arial", 24, FontStyle.Underline);
            lbl.Size = new Size(400, 50);
            lbl.Location = new Point(310, 20);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;


            pic = new PictureBox();
            pic.Size = new Size(150, 150);
            pic.Location = new Point(150, btn.Height+lbl.Height + 10);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Image = Image.FromFile(@"..\..\..\tower.jpg");
            pic.DoubleClick += Pic_DoubleClick;


            rbtn1 = new RadioButton() { Text = "Valik 1", Location = new Point(150, 330) };
            rbtn2 = new RadioButton() { Text = "Valik 2", Location = new Point(150, 330) };
            rbtn3 = new RadioButton() { Text = "Valik 3", Location = new Point(150, 360) };




        }



        /*
        int tt = 0;
        private void Pic_DoubleClick(object? sender, EventArgs e)
        {
            string[] pildid = { "esimene.jpg,",  "teine.webp" };
            string fail = pildid[tt];
            pic.Image= Image.FromFile(@"..\..\..\" + fail);
            tt++;
            if (tt == 3)
            {
                tt = 0;
            }


        }
        */
        private void Pic_DoubleClick(object? sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://bogdansergachev23.thkit.ee/") { UseShellExecute = true });
        }

        private void Lbl_MouseLeave(object? sender, EventArgs e)
        {
            lbl.Font = new Font("Arial", 24, FontStyle.Underline);
        }

        private void Lbl_MouseHover(object? sender, EventArgs e)
        {
            
            lbl.Font = new Font("Arial", 26, FontStyle.Bold | FontStyle.Underline);
            


        }

        int t = 0;
        private void Btn_Click(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
            t++;
            if (t % 2 == 0)
            {
                btn.BackColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Red;
            }
        }
      
        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt") 
            {
                Controls.Add(lbl);
            } 
            else if (e.Node.Text == "Pilt")
            {
                Controls.Add(pic);
            }
            else if(e.Node.Text == "Märkeruut")
            {
                chk1 = new CheckBox();
                chk1.Checked = false;
                chk1.Text = e.Node.Text;
                chk1.Size = new Size(chk1.Text.Length * 10, chk1.Size.Height);
                chk1.Location = new Point(150, btn.Height + lbl.Height + pic.Height + 15);
                chk1.CheckedChanged += new EventHandler(Chk_CheckedChanged);
                


                chk2 = new CheckBox();
                chk2.Checked = false;
                chk2.Image = Image.FromFile(@"..\..\..\esimene.jpg");
                chk2.AutoSize = true;
                //chk2.BackgroundImage = Image.FromFile(@"..\..\..\esimene.jpg");
                //chk2.BackgroundImageLayout = ImageLayout.Zoom;
                chk2.Location = new Point(150, btn.Height + pic.Height + lbl.Height + chk1.Height + 15);
                chk2.CheckedChanged += new EventHandler(Chk_CheckedChanged);
                
                Controls.Add(chk1);
                Controls.Add(chk2);
            }
            else if (e.Node.Text == "Raadionupp")
            {
                chk4 = new CheckBox();
                chk4.Checked = false;
                chk4.Text = "Remove Raadiobuttons";
                chk4.Size = new Size(chk4.Text.Length * 10, chk4.Size.Height);
                chk4.Location = new Point(280, btn.Height + lbl.Height + pic.Height + 30);
                rbtn1.Location = new Point(150, btn.Height + lbl.Height + pic.Height + 15);
                rbtn1.Checked = false;
                rbtn1.Text = e.Node.Text;
                rbtn2.Text = e.Node.Text;
                rbtn2.Checked = false;
                rbtn3.Checked = false;
                rbtn3.Text = e.Node.Text;

                rbtn2.Location = new Point(150, btn.Height + lbl.Height + pic.Height + 40);
                rbtn3.Location = new Point(150, btn.Height + lbl.Height + pic.Height + 65);

                rbtn1.CheckedChanged += Rbtn_CheckedChanged;
                rbtn3.CheckedChanged += Rbtn_CheckedChanged;
                rbtn2.CheckedChanged += Rbtn_CheckedChanged;
                chk4.CheckedChanged += Chk4_CheckedChanged;
                this.Controls.Add(rbtn1);
                this.Controls.Add(rbtn2);
                this.Controls.Add(rbtn3);
                this.Controls.Add(chk4);

                /*
                int x = 20;
                for (int i = 0; i < rbtn_list.Count; i++)
                {
                    rbtn = new RadioButton();
                    rbtn.Checked = false;
                    rbtn.Text = rbtn_list[i];
                    rbtn.Height = x;
                    x = x + 20;
                    rbtn.Location = new Point(150, btn.Height + lbl.Height + pic.Height + chk1.Height +
                        chk2.Height + rbtn.Height);
                    rbtn.CheckedChanged += new EventHandler(Btn_CheckedChanged);

                    Controls.Add(rbtn); 
                }
                */
            }
            else if (e.Node.Text == "Tekstkast")
            {
                txt = new TextBox();
                txt.Location = new Point(150 + btn.Width + 5, btn.Height + 25);
                txt.Font = new Font("Arial", 24);
                txt.Width = 100;
                txt.TextChanged += Txt_TextChanged;
                Controls.Add(txt);
            }
        }

        private void Txt_TextChanged(object? sender, EventArgs e)
        {
            lbl.Text = txt.Text;
        }

        private void Chk4_CheckedChanged(object? sender, EventArgs e)
        {
            rbtn1.Visible = !chk4.Checked;
            rbtn2.Visible = !chk4.Checked;
            rbtn3.Visible = !chk4.Checked;
            if (chk4.Checked)
            {
               
                DateTime currentTime = DateTime.Now;
                lbl.Text = $"{currentTime}";
            }
        }

        private void Rbtn_CheckedChanged(object? sender, EventArgs e)
        {

            if (rbtn1.Checked)
            {
                lbl.Text = "Valik 1 on valitud";
            }
            else if (rbtn2.Checked)
            {
                lbl.Text = "Valik 2 on valitud";
            }
            else if (rbtn3.Checked)
            {
                lbl.Text = "Valik 3 on valitud";
            }
            
        }
        /*
        private void Btn_CheckedChanged(object? sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lbl.Text = rb.Text;
        }
        */
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked && chk2.Checked)
            {
                
                this.BackColor = Color.BlueViolet;
            }
            else if (chk2.Checked)
            {

                this.BackColor = Color.LightBlue;

            }
            else if (chk1.Checked)
            {
                this.BackColor= Color.LightCyan;
            }
            else
            {
                this.BackColor = Color.White;
            }
        }
        //Fixed3D - Делает 3Д модельки объектов+
        
    }
}
