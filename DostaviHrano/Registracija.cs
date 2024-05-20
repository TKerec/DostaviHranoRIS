using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DostaviHrano
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
            imeWarning.Visible = false;
            priimekWarning.Visible = false;
            epostaWarning.Visible = false;
            telefonWarning.Visible = false;
            naslovWarning.Visible = false;
            karticaWarning.Visible = false;
            ccvWarning.Visible = false;
            this.bunifuTextBox8.UseSystemPasswordChar = true;
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged(sender, @"[a-zA-Z]+$", imeWarning);
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged(sender, @"[a-zA-Z]+$", priimekWarning);
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged(sender, @"[A-ž]+ [0-9]{1,3}", naslovWarning);
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged(sender, @"^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$", epostaWarning);
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged(sender, @"[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}", karticaWarning);
        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged(sender, @"\+[0-9]{1,3} [0-9]{2}[ -][0-9]{3}[ -][0-9]{3}", telefonWarning);
        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged(sender, @"[0-9]{3}", ccvWarning);
        }

        private void HandleTextChanged(object sender, string pattern, Label warningLabel)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {
                if (Regex.IsMatch(textBox.Text, pattern))
                {
                    textBox.BorderColorIdle = Color.Green;
                    warningLabel.Visible = false;
                }
                else
                {
                    textBox.BorderColorIdle = Color.Red;
                    warningLabel.Visible = true;
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e) // gumb za registracijo
        {
            if(imeWarning.Visible || priimekWarning.Visible || epostaWarning.Visible || telefonWarning.Visible || naslovWarning.Visible || karticaWarning.Visible || ccvWarning.Visible || bunifuTextBox8.Text.Equals("") || bunifuTextBox1.Text.Equals("") || bunifuTextBox2.Text.Equals("") || bunifuTextBox3.Text.Equals("") || bunifuTextBox4.Text.Equals("") || bunifuTextBox5.Text.Equals("") || bunifuTextBox6.Text.Equals("") || bunifuTextBox7.Text.Equals("") || bunifuTextBox7.Text.Equals(""))
            {
                MessageBox.Show("Nekateri podatki niso pravilno izpolnjeni ali pa prazni!");
                return;
            }

            Uporabnik uporabnik = new Uporabnik(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox4.Text, bunifuTextBox6.Text, bunifuTextBox8.Text, bunifuTextBox5.Text, bunifuTextBox7.Text);
            KNarociHrano.DodajUporabnika(uporabnik);
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void epostaWarning_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void priimekWarning_Click(object sender, EventArgs e)
        {

        }

        private void imeWarning_Click(object sender, EventArgs e)
        {

        }

        private void naslovWarning_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Ime_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void ccvWarning_Click(object sender, EventArgs e)
        {

        }

        private void karticaWarning_Click(object sender, EventArgs e)
        {

        }

        private void telefonWarning_Click(object sender, EventArgs e)
        {

        }
    }
}
