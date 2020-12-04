using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Praktinis
{
    public partial class Ivertinti : Form
    {
        string pazymys;
        string vardas;
        string pavarde;
        string dalykas;
        public Ivertinti(string vardas,string pavarde,string pazymys,string dalykas)
        {
            InitializeComponent();
            textBox1.Text = pazymys;
            this.pazymys = pazymys;
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.dalykas = dalykas;
        }
        MySql MS = new MySql();
        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, "[0-9]"))
            {
                int sk = Int32.Parse(textBox1.Text);
                if (sk>=0 && sk<11)
                {
                    MS.KeistiPazymi(pavarde, vardas, dalykas, sk);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Galima įvesti tik 0-10");
                }
            }
            else
            {
                MessageBox.Show("Galima įvesti tik 0-10");
            }
        }
    }
}
