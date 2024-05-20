using DostaviHrano.Properties;
using System;
using System.Collections;
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
    //ta class aka ZMStrankaNarociHrano 
    public partial class Form1 : Form 
    {        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //predprijavljen uporabnik
            KNarociHrano.uporabniki.Add(new Uporabnik("Tomaž", "Kerec", "Brilejeva 9", "tomaz.kerec@gmail.com", "+386 40 974 004", "123", "1234-1234-1234-1234", "123"));
            KNarociHrano.Prijava("tomaz.kerec@gmail.com", "123");
            prijavaCB.Text = "    " + KNarociHrano.trenutniUporabnik.Ime + " " + KNarociHrano.trenutniUporabnik.Priimek;
            odjavaCB.Visible = true;
            
            KNarociHrano.seznamJedi.Add(new Jedi("Burger Classic", 5));
            KNarociHrano.seznamJedi.Add(new Jedi("Pizza Margherita", 7));
            KNarociHrano.seznamJedi.Add(new Jedi("Pizza Klasika", 8));
            KNarociHrano.seznamJedi.Add(new Jedi("Mesna Lazanja", 9));
            KNarociHrano.seznamJedi.Add(new Jedi("Dunajski Zrezek", 6));
            KNarociHrano.seznamJedi.Add(new Jedi("Pomfri", 3));
            KNarociHrano.seznamJedi.Add(new Jedi("Suši", 12));
            KNarociHrano.seznamJedi.Add(new Jedi("Špageti Bolognese", 9));
            KNarociHrano.seznamJedi.Add(new Jedi("Zelenjavna Juha", 5));
            KNarociHrano.seznamJedi.Add(new Jedi("Goveja Juha", 5));
            KNarociHrano.seznamJedi.Add(new Jedi("Mešana Solata", 5));
            KNarociHrano.seznamJedi.Add(new Jedi("Čokoladna Torta", 6));

        }

        private void bunifuRating1_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(burgerLAbel.Text, bunifuRating1.Value);
        }

        private void bunifuRating2_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(pizzaMargeritaLabel.Text, bunifuRating2.Value);
        }

        private void bunifuRating3_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(pizzaKlasikaLabel.Text, bunifuRating3.Value);
        }

        private void bunifuRating4_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(mesnaLazanjaLabel.Text, bunifuRating4.Value);
        }

        private void bunifuRating5_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(dunajskiZrezekLabel.Text, bunifuRating5.Value);
        }

        private void bunifuRating6_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(ponfriLabel.Text, bunifuRating6.Value);
        }

        private void bunifuRating7_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(susiLabel.Text, bunifuRating7.Value);
        }

        private void bunifuRating8_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(spagetiBologneseLabel.Text, bunifuRating8.Value);
        }

        private void bunifuRating9_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(zelenjavnaJuhaLabel.Text, bunifuRating9.Value);
        }

        private void bunifuRating10_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(govejaJuhaLabel.Text, bunifuRating10.Value);
        }

        private void bunifuRating11_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(mesanaSolataLabel.Text, bunifuRating11.Value);
        }

        private void bunifuRating12_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            HandleRatingValueChanged(cokoladnaTortaLabel.Text, bunifuRating12.Value);
        }

        private void HandleRatingValueChanged(string jedLabel, int ocenaValue)
        {
            if (KNarociHrano.uporabnikPrijavljen)
            {
                dodajOceno(jedLabel, ocenaValue);
            }
            else
            {
                prijavaShow();
            }
        }
        //metoda za dodajanje ocene uporabniku iz diagrama
        private void dodajOceno(string jedLabel, int ocenaValue)
        {
            Ocena ocena = new Ocena(1, KNarociHrano.trenutniUporabnik.Email, jedLabel, ocenaValue);
            ocena.dodajOceno();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registracija();
        }

        //metoda za registracijo uporabnika iz diagrama
        private void registracija()
        {
            Registracija registracija = new Registracija();

            if (registracija.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e) //prijava
        {
            prijava();
        }
        //metoda za prijavo uporabnika iz diagrama
        private void prijava()
        {
            if (!KNarociHrano.uporabnikPrijavljen)
            {
                Prijava prijava = new Prijava();
                if (prijava.ShowDialog() == DialogResult.OK)
                {

                }
                if (KNarociHrano.uporabnikPrijavljen)
                {
                    prijavaCB.Text = "    " + KNarociHrano.trenutniUporabnik.Ime + " " + KNarociHrano.trenutniUporabnik.Priimek;
                    odjavaCB.Visible = true;
                }
            }
            else
            {
                UporabniskiProfil uporabniskiProfil = new UporabniskiProfil();
                if (uporabniskiProfil.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KNarociHrano. uporabnikPrijavljen)
            {
                Kosarica kosarica = new Kosarica();
                if (kosarica.ShowDialog() == DialogResult.OK)
                {

                }
                if(KNarociHrano.jediInKvantitetaVKosarici.Count == 0)
                {
                    kvantiteta.Text = "(0)";
                    KNarociHrano.stRazlicnihJedi = 0;
                }
            }
            else
            {
                prijavaShow();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (KNarociHrano.uporabnikPrijavljen)
            {
                PreteklaNarocila preteklaNarocila = new PreteklaNarocila();
                if (preteklaNarocila.ShowDialog() == DialogResult.OK)
                {

                }
            }
            else
            {
                prijavaShow();
            }

        }
        private void prijavaShow()
        {
            Prijava prijava = new Prijava();
            if (prijava.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
        //metoda za dodajanje jedi v košarico iz diagrama
        public void dodajVKosarico(String ime, double cena)
        {
            if (KNarociHrano.uporabnikPrijavljen)
            {
                char charAtIndex = (kvantiteta.Text)[1];
                int quantityValue = (int)char.GetNumericValue(charAtIndex);

                if (KNarociHrano.stRazlicnihJedi < 3)
                {
                    quantityValue++;
                    kvantiteta.Text = "(" + quantityValue + ")";
                    KNarociHrano.dodajVKosarico(ime, cena);
                }
                else
                {
                    MessageBox.Show("Presegli ste maksimalno število različnih jedi v košarici");
                }
            }
            else
            {
                prijavaShow();
            }
        }

        private void dodajBurgerClassic_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(burgerLAbel.Text);
        }

        private void dodajPizzaMargherita_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(pizzaMargeritaLabel.Text);
        }

        private void dodajSusi_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(susiLabel.Text);
        }

        private void dodajMesnaLazanja_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(mesnaLazanjaLabel.Text);
        }

        private void dodajDunajskiZrezek_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(dunajskiZrezekLabel.Text);
        }

        private void dodajPomfri_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(ponfriLabel.Text);
        }

        private void dodajPizzaKlasika_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(pizzaKlasikaLabel.Text);
        }

        private void dodajSpagetiBolognese_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(spagetiBologneseLabel.Text);
        }

        private void dodajZelenjavnaJuha_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(zelenjavnaJuhaLabel.Text);
        }

        private void dodajGovejaJuha_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(govejaJuhaLabel.Text);
        }

        private void dodajMesanaSolata_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(mesanaSolataLabel.Text);
        }

        private void dodajCokoladnaTorta_Click(object sender, EventArgs e)
        {
            HandleDodajVKosaricoClick(cokoladnaTortaLabel.Text);
        }
        private void HandleDodajVKosaricoClick(string imeJedi)
        {
            double cena = findPrice(imeJedi);
            dodajVKosarico(imeJedi, cena);
        }

        private void button1_Click_1(object sender, EventArgs e) //odjava
        {
            KNarociHrano.uporabnikPrijavljen = false;
            prijavaCB.Text = "    Prijava";
            odjavaCB.Visible = false;
            MessageBox.Show("Uspešno ste se odjavili");

        }

        private double findPrice(String imeJedi)
        {
            foreach(Jedi jed in KNarociHrano.seznamJedi)
            {
                if(jed.ImeJedi == imeJedi)
                {
                    return jed.CenaJedi;
                }
            }
            return 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {

        }
    }
}
