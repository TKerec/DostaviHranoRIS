using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DostaviHrano
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
            this.bunifuTextBox4.UseSystemPasswordChar = true;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e) // prijaviSeCB
        {
            // preveri če je uporabnik vnešen
            if (bunifuTextBox3.Text == "")
            {
                MessageBox.Show("Vnesite uporabniško ime");
            }
            else if (bunifuTextBox4.Text == "")
            {
                MessageBox.Show("Vnesite geslo");
            }
            else
            {
                KNarociHrano.Prijava(bunifuTextBox3.Text, bunifuTextBox4.Text);
                this.Close();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
