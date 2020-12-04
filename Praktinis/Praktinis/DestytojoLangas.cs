using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktinis
{
    public partial class DestytojoLangas : Form
    {
        List<string> grupe = new List<string>();
        List<string> dalykas = new List<string>();
        MySql MS = new MySql();
        public DestytojoLangas(Naudotojas nd)
        {
            InitializeComponent();
            grupe = MS.GautiGrupeDestytojo(nd);
            foreach (var item in grupe)
            {
                comboBox1.Items.Add(item);
            }

            dalykas = MS.GautDalyka(nd);
            foreach (var item in dalykas)
            {
                comboBox2.Items.Add(item);
            }

        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Ivertinti i = new Ivertinti(listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text,comboBox2.Text);
            if (i.ShowDialog(this)==DialogResult.OK)
            {
                uzpildytiLentele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uzpildytiLentele();
        }

        void uzpildytiLentele()
        {
            listView1.Items.Clear();
            MS.temp1 = new List<string>();
            MS.temp3 = new List<string>();
            MS.temp2 = new List<string>();
            try
            {
                string grupe = comboBox1.Text;
                string dalykas = comboBox2.Text;

                MS.GautiStudentus(grupe, dalykas);

                for (int i = 0; i < MS.temp1.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem(MS.temp2[i]);
                    lvi.SubItems.Add(MS.temp1[i]);
                    lvi.SubItems.Add(MS.temp3[i]);
                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
