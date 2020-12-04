using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Praktinis
{
    public partial class Administratorius : Form
    {
        MySql MS = new MySql();

        public Administratorius(Naudotojas nd)
        {
            InitializeComponent();
            Lenteles();
        }

        void Lenteles()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            PildytiGrupiuLentele();
            PildytiPaskaituLentele();
            PildytiDestytojuLentele();
            PildytiStudentuLentele();
            PildytiDestytojuDalykuLentele();
            PDDL();
            PildytiStudentus();
            List<string> dalykas = new List<string>();
            dalykas = MS.GautPaskaita();
            //Paskaitos
            foreach (var item in dalykas)
            {
                comboBox2.Items.Add(item);
                comboBox4.Items.Add(item);
            }
            dalykas = new List<string>();
            dalykas = MS.GautiGrupe();
            //Grupes
            foreach (var item in dalykas)
            {
                comboBox1.Items.Add(item);
                comboBox3.Items.Add(item);
            }
            pildytiGrupes();
        }

        private void pildytiGrupes()
        {
            try
            {
                listView8.Items.Clear();
                MS.temp1 = new List<string>();
                MS.temp2 = new List<string>();
                MS.GautGrupes();

                for (int i = 0; i < MS.temp1.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem(MS.temp1[i]);
                    lvi.SubItems.Add(MS.temp2[i]);
                    listView8.Items.Add(lvi);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MS.PridetiGrupe(textBox1.Text);
                Lenteles();
            }
        }

        void PildytiGrupiuLentele()
        {
            listView1.Items.Clear();
            List<string> grupe = MS.GautiGrupe();

            foreach (var item in grupe)
            {
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {

                    MS.IstrintiGrupe(listView1.SelectedItems[0].SubItems[0].Text);
                    Lenteles();
                }
            }
            catch
            {

            }
        }

        void PildytiPaskaituLentele()
        {
            listView2.Items.Clear();
            List<string> grupe = MS.GautPaskaita();

            foreach (var item in grupe)
            {
                listView2.Items.Add(item);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                MS.PridetDalyka(textBox2.Text);
                Lenteles();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    MS.IstrintiDalyka(listView2.SelectedItems[0].SubItems[0].Text);
                    Lenteles();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        void PildytiDestytojuLentele()
        {
            listView3.Items.Clear();
            MS.temp1 = new List<string>();
            MS.temp3 = new List<string>();
            MS.temp2 = new List<string>();
            MS.GautDestytojus();

            for (int i = 0; i < MS.temp1.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(MS.temp1[i]);
                lvi.SubItems.Add(MS.temp2[i]);
                lvi.SubItems.Add(MS.temp3[i]);
                listView3.Items.Add(lvi);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (DVardastxt.Text != "" && DPavardetxt.Text!="")
                {
                MS.PridetiDestytoja(DVardastxt.Text, DPavardetxt.Text);
                Lenteles();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView3.SelectedItems.Count > 0)
                {

                    MS.SalintiDestytoja(listView3.SelectedItems[0].SubItems[2].Text);
                    Lenteles();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void PildytiStudentuLentele()
        {
            listView4.Items.Clear();
            MS.temp1 = new List<string>();
            MS.temp3 = new List<string>();
            MS.temp2 = new List<string>();
            MS.GautStudentus();

            for (int i = 0; i < MS.temp1.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(MS.temp1[i]);
                lvi.SubItems.Add(MS.temp2[i]);
                lvi.SubItems.Add(MS.temp3[i]);
                listView4.Items.Add(lvi);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (SVardasTxt.Text != ""&& SPavTxt.Text!="")
                {

                MS.PridetiStudenta(SVardasTxt.Text, SPavTxt.Text);
                Lenteles();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView4.SelectedItems.Count > 0)
                {
                    MS.SalintiStudenta(listView4.SelectedItems[0].SubItems[2].Text);
                    Lenteles();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void PildytiDestytojuDalykuLentele()
        {
            listView5.Items.Clear();
            MS.temp1 = new List<string>();
            MS.temp3 = new List<string>();
            MS.temp2 = new List<string>();
            MS.GautDestytojus();

            for (int i = 0; i < MS.temp1.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(MS.temp1[i]);
                lvi.SubItems.Add(MS.temp2[i]);
                lvi.SubItems.Add(MS.temp3[i]);
                listView5.Items.Add(lvi);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView5.SelectedItems.Count > 0 && comboBox2.Text!="")
                {
                    MS.PaskirtiPaskaitas(listView5.SelectedItems[0].SubItems[2].Text, comboBox2.Text);
                    Lenteles();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void PDDL()
        {
            listView6.Items.Clear();
            MS.temp1 = new List<string>();
            MS.temp3 = new List<string>();
            MS.temp2 = new List<string>();
            MS.PildytiDestytojuDalykuLentele();
            for (int i = 0; i < MS.temp1.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(MS.temp1[i]);
                lvi.SubItems.Add(MS.temp2[i]);
                lvi.SubItems.Add(MS.temp3[i]);
                listView6.Items.Add(lvi);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView6.SelectedItems.Count > 0)
                {
                    MS.AtleistiDestytoja(listView6.SelectedItems[0].SubItems[1].Text, listView6.SelectedItems[0].SubItems[2].Text);
                    Lenteles();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        void PildytiStudentus()
        {
            listView7.Items.Clear();
            MS.temp1 = new List<string>();
            MS.temp2 = new List<string>();
            MS.temp4 = new List<string>();
            MS.PildytiStudentus();
            for (int i = 0; i < MS.temp1.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(MS.temp1[i]);
                lvi.SubItems.Add(MS.temp2[i]);
                lvi.SubItems.Add(MS.temp4[i]);
                listView7.Items.Add(lvi);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && listView7.SelectedItems.Count > 0)
                {
                    MS.PaskirtiGrupe(comboBox1.Text, listView7.SelectedItems[0].SubItems[2].Text);
                    Lenteles();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView7.SelectedItems.Count > 0)
                {
                    MS.PasalintiGrupe(listView7.SelectedItems[0].SubItems[2].Text);
                    Lenteles();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text !=""&&comboBox4.Text!="")
                {

                MS.DuotiGrupeiPaskaitas(comboBox3.Text, comboBox4.Text);
                Lenteles();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listView8.SelectedItems.Count > 0)
                {

                MS.SalintiGrupesPaskaitas(listView8.SelectedItems[0].SubItems[0].Text, listView8.SelectedItems[0].SubItems[1].Text);
                Lenteles();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
