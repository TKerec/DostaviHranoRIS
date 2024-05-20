using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DostaviHrano
{
    public static class KNarociHrano 
    {
        public static int stRazlicnihJedi = 0;
        public static bool uporabnikPrijavljen = false;
        public static bool SIMizvedenoPlacilo = false, SIMpridobljenaLokacija = false, SIMpotrjenoNarocilo = false;
        public static Uporabnik trenutniUporabnik;
        public static SIMDostavljalec trenutniDostavljalec = new SIMDostavljalec(1, "Janez", "Novak", "031 000 000", "Ljubljana, Stegne");
        public static SIMRestavracija trenutnaRestavracija = new SIMRestavracija(1, "Wolt Fast Food");

        public static List<Ocena> seznamOcen = new List<Ocena>();
        public static List<Uporabnik> uporabniki = new List<Uporabnik>();
        public static Dictionary<Jedi, int> jediInKvantitetaVKosarici = new Dictionary<Jedi, int>();
        public static List<Jedi> seznamJedi = new List<Jedi>();

        public static void Prijava(string ime, string geslo)
        {
            bool nadjen = false;
            foreach (Uporabnik uporabnik in uporabniki)
            {
                if (uporabnik.Email == ime && uporabnik.Geslo == geslo)
                {
                    MessageBox.Show("Prijavljeni ste kot " + uporabnik.Ime + " " + uporabnik.Priimek);
                    nadjen = true;
                    uporabnikPrijavljen = true;
                    trenutniUporabnik = uporabnik;
                    return;
                }

                if(uporabnik.Email == ime)
                {
                    nadjen = true;
                    MessageBox.Show("Napacno uporabnisko ime ali geslo");
                    return;
                }
            }

            if (!nadjen)
                MessageBox.Show("Uporabnik ne obstaja");

            uporabnikPrijavljen = false;
        }

        public static void DodajUporabnika(Uporabnik nov_)
        {
            if(uporabniki.Contains(nov_))
            {
                MessageBox.Show("Uporabnik ze obstaja");           
            }
            else
            {
                uporabniki.Add(nov_);
                MessageBox.Show("Uporabnik dodan");
            }
        }

        //metoda za pridobitev jedi iz diagrama
        public static Jedi pridobiJed (string ime)
        {
            foreach (Jedi jed in seznamJedi)
            {
                if (jed.ImeJedi == ime)
                    return jed;
            }

            return null;
        }

        //metoda za dodajanje jedi v košarico iz diagrama
        public static void dodajVKosarico(String ime, double cena)
        {
            Jedi kljuc = pridobiJed(ime);

            if (jediInKvantitetaVKosarici.ContainsKey(pridobiJed(ime)))
            {
                jediInKvantitetaVKosarici[kljuc]++;
            }
            else
            {
                jediInKvantitetaVKosarici[kljuc] = 1;
                stRazlicnihJedi++;
            }
        }



    }
}
