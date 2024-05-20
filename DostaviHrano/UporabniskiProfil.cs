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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DostaviHrano
{
    public partial class UporabniskiProfil : Form
    {
        public UporabniskiProfil()
        {
            InitializeComponent();
        }

        private void UporabniskiProfil_Load(object sender, EventArgs e)
        {
            imePP.Text = KNarociHrano.trenutniUporabnik.Ime;
            priimekPP.Text = KNarociHrano.trenutniUporabnik.Priimek;
            naslovPP.Text = KNarociHrano.trenutniUporabnik.Naslov;
            epostaPP.Text = KNarociHrano.trenutniUporabnik.Email;
            telefonPP.Text = KNarociHrano.trenutniUporabnik.TelefonskaStevilka;
            gesloPP.Text = KNarociHrano.trenutniUporabnik.Geslo;
            karticaPP.Text = KNarociHrano.trenutniUporabnik.kreditnaKartica;
            ccvPP.Text = KNarociHrano.trenutniUporabnik.ccv;
        }

        private void shraniPodatkePP_Click(object sender, EventArgs e)
        {
            if (this.imeWarning.Visible || this.priimekWarning.Visible || this.epostaWarning.Visible || this.telefonWarning.Visible || this.naslovWarning.Visible || this.karticaWarning.Visible || this.ccvWarning.Visible || imePP.Text.Equals("") || priimekPP.Text.Equals("") || naslovPP.Text.Equals("") || epostaPP.Text.Equals("") || gesloPP.Text.Equals("") || telefonPP.Text.Equals("") || karticaPP.Text.Equals("") || ccvPP.Text.Equals(""))
            {
                MessageBox.Show("Nekateri podatki niso pravilno izpolnjeni ali pa prazni!");
                return;
            }
            else
            {
                Uporabnik tempUporabnik = new Uporabnik(imePP.Text, priimekPP.Text, naslovPP.Text, epostaPP.Text, telefonPP.Text, gesloPP.Text, karticaPP.Text, ccvPP.Text);
                if(KNarociHrano.uporabniki.Contains(tempUporabnik))
                {
                    MessageBox.Show("Uporabnik že obstaja!");
                    return;
                }
                else
                {
                    foreach (Uporabnik uporabnik in KNarociHrano. uporabniki)
                    {
                        if (uporabnik.Ime.Equals(imePP.Text) && uporabnik.Priimek.Equals(priimekPP.Text) && uporabnik.Naslov.Equals(naslovPP.Text) && uporabnik.Email.Equals(epostaPP.Text) && uporabnik.TelefonskaStevilka.Equals(telefonPP.Text) && uporabnik.Geslo.Equals(gesloPP.Text) && uporabnik.kreditnaKartica.Equals(karticaPP.Text) && uporabnik.ccv.Equals(ccvPP.Text))
                        {
                            MessageBox.Show("Uporabnik z enakimi podatki že obstaja");
                            return;
                        }
                        else
                        {
                            uporabnik.Ime = imePP.Text;
                            uporabnik.Priimek = priimekPP.Text;
                            uporabnik.Naslov = naslovPP.Text;
                            uporabnik.Email = epostaPP.Text;
                            uporabnik.TelefonskaStevilka = telefonPP.Text;
                            uporabnik.Geslo = gesloPP.Text;
                            uporabnik.kreditnaKartica = karticaPP.Text;
                            uporabnik.ccv = ccvPP.Text;
                            MessageBox.Show("Podatki shranjeni");
                        }
                    }
                }
            }
            
        }

        private void imePP_TextChanged(object sender, EventArgs e)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {

                if (Regex.IsMatch(textBox.Text, @"\d"))
                {
                    textBox.BorderColorIdle = Color.Red;
                    imeWarning.Visible = true;
                }
                else
                {
                    textBox.BorderColorIdle = Color.Green;
                    imeWarning.Visible = false;
                }
            }
        }

        private void priimekPP_TextChanged(object sender, EventArgs e)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {

                if (Regex.IsMatch(textBox.Text, @"\d"))
                {
                    textBox.BorderColorIdle = Color.Red;
                    priimekWarning.Visible = true;
                }
                else
                {
                    textBox.BorderColorIdle = Color.Green;
                    priimekWarning.Visible = false;
                }
            }
        }

        private void naslovPP_TextChanged(object sender, EventArgs e)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {

                if (Regex.IsMatch(textBox.Text, @"[A-ž]+ [0-9]{1,3}"))
                {
                    textBox.BorderColorIdle = Color.Green;
                    naslovWarning.Visible = false;

                }
                else
                {
                    textBox.BorderColorIdle = Color.Red;
                    naslovWarning.Visible = true;
                }
            }
        }

        private void epostaPP_TextChanged(object sender, EventArgs e)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {

                if (Regex.IsMatch(textBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    textBox.BorderColorIdle = Color.Green;
                    epostaWarning.Visible = false;
                }
                else
                {
                    textBox.BorderColorIdle = Color.Red;
                    epostaWarning.Visible = true;
                }
            }
        }

        private void gesloPP_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void telefonPP_TextChanged(object sender, EventArgs e)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {

                if (Regex.IsMatch(textBox.Text, @"\+[0-9]{1,3} [0-9]{2}[ -][0-9]{3}[ -][0-9]{3}"))
                {
                    textBox.BorderColorIdle = Color.Green;
                    telefonWarning.Visible = false;
                }
                else
                {
                    textBox.BorderColorIdle = Color.Red;
                    telefonWarning.Visible = true;
                }
            }
        }

        private void karticaPP_TextChanged(object sender, EventArgs e)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {

                if (Regex.IsMatch(textBox.Text, @"[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}"))
                {
                    textBox.BorderColorIdle = Color.Green;
                    karticaWarning.Visible = false;
                }
                else
                {
                    textBox.BorderColorIdle = Color.Red;
                    karticaWarning.Visible = true;
                }
            }
        }

        private void ccvPP_TextChanged(object sender, EventArgs e)
        {
            BunifuTextBox textBox = sender as BunifuTextBox;

            if (textBox != null && textBox.Text.Length > 0)
            {

                if (Regex.IsMatch(textBox.Text, @"[0-9]{3}"))
                {
                    textBox.BorderColorIdle = Color.Green;
                    ccvWarning.Visible = false;
                }
                else
                {
                    textBox.BorderColorIdle = Color.Red;
                    ccvWarning.Visible = true;
                }
            }
        }

    }
}

