using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication19
{
    public partial class Form1 : Form
    {
        public int set;
        public int nrintrebare;
        public int p;
        public int x;
        public int ok = 0;
        public int ok2 = 0;
        public int ok3 = 0;
        public int ok4 = 0;
        public int ok5 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void intrebareBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.intrebareBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.atestattDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'atestattDataSet.test' table. You can move, or remove it, as needed.
            this.testTableAdapter.Fill(this.atestattDataSet.test);
            // TODO: This line of code loads data into the 'atestattDataSet.set' table. You can move, or remove it, as needed.
            this.setTableAdapter.Fill(this.atestattDataSet.set);
            // TODO: This line of code loads data into the 'atestattDataSet.jucator' table. You can move, or remove it, as needed.
            this.jucatorTableAdapter.Fill(this.atestattDataSet.jucator);
            // TODO: This line of code loads data into the 'atestattDataSet.joc' table. You can move, or remove it, as needed.
            this.jocTableAdapter.Fill(this.atestattDataSet.joc);
            // TODO: This line of code loads data into the 'atestattDataSet.intrebare' table. You can move, or remove it, as needed.
            this.intrebareTableAdapter.Fill(this.atestattDataSet.intrebare);


            tabControl1.SelectedTab = tabPage1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = atestattDataSet.jucator;
            p = 0;
            x = dt.Rows.Count + 1;
            

            Random r = new Random();
            int s = r.Next(7);
            DataTable dt1 = atestattDataSet.set;
            while (dt1.Rows[s]["domeniu"].ToString().Trim() != comboBox1.SelectedItem.ToString().Trim())
            {
                s = r.Next(7);

            }




            tabControl1.SelectedTab = tabPage2;
            set = s + 1;
            nrintrebare = 0;

            testTableAdapter.intrebaridinset(atestattDataSet.test, set);
            DataTable dt2 = atestattDataSet.test;

            richTextBox1.Text = dt2.Rows[0]["enunt"].ToString();
            radioButton1.Text = dt2.Rows[0]["var1"].ToString();
            radioButton2.Text = dt2.Rows[0]["var2"].ToString();
            radioButton3.Text = dt2.Rows[0]["var3"].ToString();
            radioButton4.Text = dt2.Rows[0]["var4"].ToString();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {

            testTableAdapter.intrebaridinset(atestattDataSet.test, set);
            DataTable dt2 = atestattDataSet.test;
            if (nrintrebare < 10)
            {
                if (radioButton1.Checked == true)
                {
                    if (radioButton1.Text == dt2.Rows[nrintrebare]["corect"].ToString())
                    {
                        MessageBox.Show("corect");
                        p = p + 5;
                    }
                    else MessageBox.Show("gresit");
                }
                if (radioButton2.Checked == true)
                {
                    if (radioButton2.Text == dt2.Rows[nrintrebare]["corect"].ToString())
                    {
                        MessageBox.Show("corect");
                        p = p + 5;
                    }
                    else MessageBox.Show("gresit");
                }
                if (radioButton3.Checked == true)
                {
                    if (radioButton3.Text == dt2.Rows[nrintrebare]["corect"].ToString())
                    {
                        MessageBox.Show("corect");
                        p = p + 5;
                    }
                    else MessageBox.Show("gresit");
                }
                if (radioButton4.Checked == true)
                {
                    if (radioButton4.Text == dt2.Rows[nrintrebare]["corect"].ToString())
                    {
                        MessageBox.Show("corect");
                        p = p + 5;
                    }
                    else MessageBox.Show("gresit");
                }
                nrintrebare++;
            }

            if (nrintrebare < 10)
            {
                richTextBox1.Text = dt2.Rows[nrintrebare]["enunt"].ToString();
                radioButton1.Text = dt2.Rows[nrintrebare]["var1"].ToString();
                radioButton2.Text = dt2.Rows[nrintrebare]["var2"].ToString();
                radioButton3.Text = dt2.Rows[nrintrebare]["var3"].ToString();
                radioButton4.Text = dt2.Rows[nrintrebare]["var4"].ToString();
            }
            if (nrintrebare == 10)
            {
                MessageBox.Show("TEST COMPLETAT");
                MessageBox.Show("ai luat " + p.ToString() + " puncte din 50");

                jucatorTableAdapter.inserare(x, textBox1.Text, textBox2.Text);
                jucatorTableAdapter.Update(atestattDataSet);

                this.jucatorTableAdapter.Fill(this.atestattDataSet.jucator);
                jocTableAdapter.inserare2(set, x, p);
                jocTableAdapter.Update(atestattDataSet);
                this.jocTableAdapter.Fill(this.atestattDataSet.joc);
                tabControl1.SelectedTab = tabPage3;

            }
            


        }

        




        private void button3_Click(object sender, EventArgs e)
        {
           
            DataTable dt = atestattDataSet.jucator;
            int maxi = Convert.ToInt32(jocTableAdapter.maxim());
            DataTable d = atestattDataSet.joc;
            DataTable dy = atestattDataSet.set;
            if (ok == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(d.Rows[i]["punctaj"]) == maxi)
                    {
                        int g = Convert.ToInt32(d.Rows[i]["idset"]) - 1 ;
                        richTextBox2.Text += dt.Rows[i]["nume"] + dt.Rows[i]["prenume"].ToString() 
                        + dy.Rows[g]["domeniu"] + '\n';
                    }
                }
                ok = 1;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = atestattDataSet.joc;
            richTextBox3.Text = dt.Rows.Count.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = setTableAdapter.cerinta3().ToString();
            richTextBox4.Text = s;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (ok4 == 0)
            {
                DataTable dt = atestattDataSet.jucator;
                DataTable d = atestattDataSet.joc;
                DataTable dy = atestattDataSet.set;
                for (int i = 0; i < dt.Rows.Count; i++)

                {
                    int g = Convert.ToInt32(d.Rows[i]["idset"]) - 1;
                    richTextBox5.Text += dt.Rows[i]["nume"] + dt.Rows[i]["prenume"].ToString() + d.Rows[i]["punctaj"]  + " " +dy.Rows[g]["domeniu"] + '\n';
                }
                ok4 = 1;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {


            string s = setTableAdapter.cerinta5().ToString();

            richTextBox6.Text = s;



        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ok5 == 0)
            {
                jucatorTableAdapter.cerinta6(atestattDataSet.jucator);
                DataTable dt = atestattDataSet.jucator;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    richTextBox7.Text += dt.Rows[i]["nume"] + dt.Rows[i]["prenume"].ToString() + '\n';

                }
                ok5 = 1;
            }
        }

      

        private void button9_Click(object sender, EventArgs e)
        {
            string s = jucatorTableAdapter.cerinta7(textBox3.Text).ToString();
            richTextBox8.Text = s;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ok3 == 0)
            {
               jucatorTableAdapter.cerinta8(atestattDataSet.jucator,jocTableAdapter.info());
                DataTable dt = atestattDataSet.jucator;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    richTextBox9.Text += dt.Rows[i]["nume"] + dt.Rows[i]["prenume"].ToString() + '\n';

                }
                ok3 = 1;
            }
        }
        private void cerinta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage4;
        }
        private void cerinta2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage5;
        }

       

        private void cerinta3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage6;
        }

        private void cerinta4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage7;
        }

        private void cerinta5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage8;

        }

        private void cerinta6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage9;
        }

        private void cerinta7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage10;
        }

        private void cerinta8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage11;
        }

       

        

       
        }

    
       
    }
