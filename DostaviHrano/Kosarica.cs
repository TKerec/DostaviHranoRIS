using Bunifu.UI.WinForms;
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
    public partial class Kosarica : Form
    {
        public double skupnaKvantiteta{ get; set;}
        private int stNarocila = 1;
        string dateStr = DateTime.Now.ToString("dd.MM.yyyy");
        string timeStr = DateTime.Now.ToString("HH:mm");
        double cenaJedi1, cenaJedi2, cenaJedi3;

        public Kosarica()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Kosarica_Load);
        }

        private void Kosarica_Load(object sender, EventArgs e)
        {
            izberiNacinPlacila.Items.Add("Gotovina po povzetju");
            izberiNacinPlacila.Items.Add("Kreditna Kartica");
            int ctr = 0;

            foreach (Jedi key in KNarociHrano.jediInKvantitetaVKosarici.Keys)
            {
                int kvantiteta = KNarociHrano.jediInKvantitetaVKosarici[key];
                dodajVKosarico(key, kvantiteta, ctr);
                ctr++;
            }

            skupnaCenaLabel.Text = skupnaKvantiteta.ToString() + " €";
        }

        private void dodajVKosarico(Jedi jed, int kvantiteta, int ctr)
        {
            izracunSkupneCene(jed.CenaJedi, kvantiteta);

            switch (ctr)
            {
                case 0:
                    imeJedi1.Text = jed.ImeJedi;
                    cenaJed1.Text = (jed.CenaJedi * kvantiteta).ToString() + " €";
                    cenaJedi1 = jed.CenaJedi;
                    jedKvantiteta1.Text = kvantiteta.ToString();
                    itemPanel1.Visible = true;
                    break;
                case 1:
                    imeJedi2.Text = jed.ImeJedi;
                    cenaJed2.Text = (jed.CenaJedi * kvantiteta).ToString() + " €";
                    cenaJedi2 = jed.CenaJedi;
                    jedKvantiteta2.Text = kvantiteta.ToString();
                    itemPanel2.Visible = true;
                    break;
                case 2:
                    imeJedi3.Text = jed.ImeJedi;
                    cenaJed3.Text = (jed.CenaJedi * kvantiteta).ToString() + " €";
                    cenaJedi3 = jed.CenaJedi;
                    jedKvantiteta3.Text = kvantiteta.ToString();
                    itemPanel3.Visible = true;
                    break;
            }
        }

        private void izracunSkupneCene(double cenaJedi, int kvantiteta)
        {
            skupnaKvantiteta += (cenaJedi * kvantiteta);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e) //pocist vse
        {
            pocistiVse();
        }
        private void pocistiVse()
        {
            itemPanel1.Visible = false;
            itemPanel2.Visible = false;
            itemPanel3.Visible = false;

            imeJedi1.Text = "";
            cenaJed1.Text = "";
            jedKvantiteta1.Text = "";

            imeJedi2.Text = "";
            cenaJed2.Text = "";
            jedKvantiteta2.Text = "";

            imeJedi3.Text = "";
            cenaJed3.Text = "";
            jedKvantiteta3.Text = "";

            skupnaCenaLabel.Text = "0 €";
            KNarociHrano.jediInKvantitetaVKosarici.Clear();
            this.Close();
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            UpdateKvantiteta(jedKvantiteta1, cenaJed1, cenaJedi1, 1);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            UpdateKvantiteta(jedKvantiteta2, cenaJed2, cenaJedi2, 1);
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            UpdateKvantiteta(jedKvantiteta3, cenaJed3, cenaJedi3, 1);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e) // znižaj kvantiteto
        {
            UpdateKvantiteta(jedKvantiteta1, cenaJed1, cenaJedi1, -1);
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            UpdateKvantiteta(jedKvantiteta2, cenaJed2, cenaJedi2, -1);
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            UpdateKvantiteta(jedKvantiteta3, cenaJed3, cenaJedi3, -1);
        }

        private void UpdateKvantiteta(BunifuTextBox kvantitetaTextBox, Label cenaLabel, double cenaJedi, int increment)
        {
            int staraKvantiteta = kvantitetaTextBox.Text == "" ? 0 : int.Parse(kvantitetaTextBox.Text);
            if (staraKvantiteta == 0 && increment < 0)
                return;

            int novaKvantiteta = staraKvantiteta + increment;
            kvantitetaTextBox.Text = novaKvantiteta.ToString();

            int staraCena = int.Parse(cenaLabel.Text.Split(' ')[0]);
            cenaLabel.Text = (cenaJedi * novaKvantiteta).ToString() + " €";

            int staraSkupnaCena = int.Parse(skupnaCenaLabel.Text.Split(' ')[0]);
            double novaSkupnaCena = staraSkupnaCena - staraCena + (cenaJedi * novaKvantiteta);
            skupnaKvantiteta += increment;
            skupnaCenaLabel.Text = novaSkupnaCena.ToString() + " €";
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e) // oddaj narocilo
        {
            oddajNarocilo();
        }

        public void oddajNarocilo()
        {
            if (skupnaKvantiteta == 0)
            {
                MessageBox.Show("Kosarica je prazna");
                return;
            }

            pridobiElementeKosarice();
            SIMProcesiranjePlacil.izvediPlacilo();
            KNarociHrano.trenutniDostavljalec.pridobiLokacijo();
            KNarociHrano.trenutnaRestavracija.potrdiNarocilo();

        }

        public void pridobiElementeKosarice()
        {
            string jed1 = !imeJedi1.Text.Equals("") ? imeJedi1.Text : "";
            string jed2 = !imeJedi2.Text.Equals("") ? imeJedi2.Text : "";
            string jed3 = !imeJedi3.Text.Equals("") ? imeJedi3.Text : "";

            string quantity1 = !jedKvantiteta1.Text.Equals("") ? jedKvantiteta1.Text : "";
            string quantity2 = !jedKvantiteta2.Text.Equals("") ? jedKvantiteta2.Text : "";
            string quantity3 = !jedKvantiteta3.Text.Equals("") ? jedKvantiteta3.Text : "";

            string cena1 = !cenaJed1.Text.Equals("") ? cenaJed1.Text : "";
            string cena2 = !cenaJed2.Text.Equals("") ? cenaJed2.Text : "";
            string cena3 = !cenaJed3.Text.Equals("") ? cenaJed3.Text : "";

            if (izberiNacinPlacila.SelectedItem == null)
            {
                MessageBox.Show("Izberite nacin placila");
                return;
            }

            string paymentMethod = izberiNacinPlacila.SelectedItem.ToString();
            ProcesirajNarocilo(jed1, quantity1, cena1, jed2, quantity2, cena2, jed3, quantity3, cena3, paymentMethod);
        }

        private void ProcesirajNarocilo(string jed1, string quantity1, string cena1, string jed2, string quantity2, string cena2, string jed3, string quantity3, string cena3, string paymentMethod)
        {
            string orderDetails = $@"
            Naročilo:

            {jed1}({quantity1}x) - {cena1:C}
            {jed2}({quantity2}x) - {cena2:C}
            {jed3}({quantity3}x) - {cena3:C}

            Datum in ura: {dateStr} {timeStr}
            Skupaj: {skupnaCenaLabel.Text:C}
            --------------------------------------------------------------------------------------------------------------";

            foreach (Uporabnik uporabnik in KNarociHrano.uporabniki)
            {
                if (uporabnik.Equals(KNarociHrano.trenutniUporabnik))
                {
                    for (int i = 0; i < uporabnik.narocilaUporabnika.Length; i++)
                    {
                        if (uporabnik.narocilaUporabnika[i] == null)
                        {
                            uporabnik.narocilaUporabnika[i] = orderDetails;
                            break;
                        }
                    }
                }
            }

            pocistiVse();
            stNarocila++;
            MessageBox.Show("Naročilo oddano");
        }

        private void Kosarica_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }
    }
}
