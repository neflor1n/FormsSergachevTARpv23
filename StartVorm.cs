using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace FormsSergachevTARpv23
{
    public partial class StartVorm : Form
    {   
        List<string> elemendid = new List<string>
        {
            "Nupp", "Silt", "Pilt", "Märkeruut", "Raadionupp", "Tekstkast", "Loetelu", "Tabel", "DialogiAknad", 
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
        ListBox lb;
        DataSet ds;
        DataGridView dg;
        MenuStrip ms;
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
            pic.Size = new Size(140, 140);
            pic.Location = new Point(150, btn.Height+lbl.Height + 10);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Image = Image.FromFile(@"..\..\..\tower.jpg");
            pic.DoubleClick += Pic_DoubleClick;


            MenuStrip ms = new MenuStrip(); 
            ToolStripMenuItem windowsMenu = new ToolStripMenuItem("Window");
            ToolStripMenuItem windowColorMenu = new ToolStripMenuItem("Change window color", null, new EventHandler(windowColorMenu_Click)); 
            ToolStripMenuItem windowCloseMenu = new ToolStripMenuItem("Close", null, new EventHandler(windowCloseMenu_Click));
            windowsMenu.DropDownItems.Add(windowColorMenu);
            windowsMenu.DropDownItems.Add(windowCloseMenu);
            ms.Items.Add(windowsMenu);
            ms.Dock = DockStyle.Top;
            MainMenuStrip = ms;
            Controls.Add(ms);

            rbtn1 = new RadioButton() { Text = "Valik 1", Location = new Point(150, 330) };
            rbtn2 = new RadioButton() { Text = "Valik 2", Location = new Point(150, 330) };
            rbtn3 = new RadioButton() { Text = "Valik 3", Location = new Point(150, 360) };




        }

        private void windowCloseMenu_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void windowColorMenu_Click(object? sender, EventArgs e)
        { 
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cd.Color;
            }

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
                chk4.Location = new Point(450, btn.Height + lbl.Height + pic.Height + 50);
                rbtn1.Location = new Point(300, btn.Height + lbl.Height + pic.Height + 15);
                rbtn1.Checked = false;
                rbtn1.Text = "Picture viewer";
                rbtn2.Text = "Matemaatika viktoriin";
                rbtn2.Checked = false;
                rbtn3.Checked = false;
                rbtn3.Text = "Game";

                rbtn2.Location = new Point(300, btn.Height + lbl.Height + pic.Height + 40);
                rbtn3.Location = new Point(300, btn.Height + lbl.Height + pic.Height + 65);

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
            else if (e.Node.Text == "Loetelu" )
            {
                lb = new ListBox();
                foreach(string item in rbtn_list)
                {
                    lb.Items.Add(item);
                }
                lb.Location = new Point(160 + btn.Width + txt.Width, btn.Height + 20);
                lb.SelectedIndexChanged += Lb_SelectedIndexChanged;
                Controls.Add(lb);
            }
            else if (e.Node.Text == "Tabel")
            {
                ds = new DataSet("XML fail");
                ds.ReadXml (@"..\..\..\Menu.xml");
                dg = new DataGridView();
                dg.Location = new Point(150 + pic.Width + lb.Width, rbtn3.Height + 300);
                dg.DataSource = ds;
                dg.DataMember = "item";
                dg.RowHeaderMouseClick += Dg_DataMemberChanged;
                Controls.Add(dg);
            }
            else if (e.Node.Text == "DialogiAknad")
            {
                var vastus = MessageBox.Show("Sisestame andmed", "Kas tahad sisestada uut elementi XML faili?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (vastus == DialogResult.Yes)
                {
                    string name = Interaction.InputBox("Sisesta toote nimi", "Toote Nimi");
                    string description = Interaction.InputBox("Sisesta toote kirjeldus", "Toote kirjeldus");
                    string priceInput = Interaction.InputBox("Sisesta toote hind", "Toote hind");
                    decimal price;

                    if (!decimal.TryParse(priceInput, out price))
                    {
                        MessageBox.Show("Vale hind. Palun sisesta numbriline väärtus!");
                        return;

                    }
                    AddItemToXml(name, description, price);

                    LoadMenuData();
                }

            }
        }

        private void AddItemToXml(string name, string description, decimal price)
        {
            XDocument menuXml = XDocument.Load(@"..\..\..\Menu.xml");

            var category = menuXml.Descendants("category").First(c => c.Attribute("name").Value == "Appetizers");
            if (category != null)
            {
                // Создаю новый объект 
                XElement newItem = new XElement("item",
                    new XElement("name", name),
                    new XElement("description", description),
                    new XElement("price", price, new XAttribute("currency", "USD"))
                );

                // Добавляю объект в категорию
                category.Add(newItem);

                // Сохраняю в xml файл
                menuXml.Save(@"..\..\..\Menu.xml");
            }
            else
            {
                MessageBox.Show("Kategooriat ei leitud!");
            }
        }
            
        private void LoadMenuData ()
        {
            ds.Clear();
            ds.ReadXml(@"..\..\..\Menu.xml");
            dg.DataSource = ds;
            dg.DataMember = "item";
        }

        private void Dg_DataMemberChanged(object? sender, DataGridViewCellMouseEventArgs e)
        {
            txt.Text = dg.Rows[e.RowIndex].Cells[0].Value.ToString() + " hind " + dg.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Lb_SelectedIndexChanged(object? sender, EventArgs e)
        {
            switch (lb.SelectedIndex)
            {
                case 0:
                    tree.BackColor = Color.Brown; break;
                case 1:
                    tree.BackColor= Color.Green; break;
                case 2:
                    tree.BackColor = Color.Magenta; break;

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
                TeineVorm teineVorm = new TeineVorm(w, h);
                teineVorm.Show();
            }
            else if (rbtn2.Checked)
            {
                lbl.Text = "Valik 2 on valitud";
                
                StartKolmasForm StartKolmasForm = new StartKolmasForm();
                StartKolmasForm.Show();

            }
            else if (rbtn3.Checked)
            {
                lbl.Text = "Valik 3 on valitud";
                
                StartNeljasForm neljasVorm = new StartNeljasForm();
                neljasVorm.Show();
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
