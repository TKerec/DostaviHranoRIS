using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DostaviHrano
{
    public class Ocena
    {
        public int ratingId;
        public String user;
        public String dish;
        public int rating;

        public Ocena(int ratingId, String user, String dish, int rating)
        {
            this.ratingId = ratingId;
            this.user = user;
            this.dish = dish;
            this.rating = rating;
        }
        //metoda za dodajanje ocene uporabniku iz diagrama
        public void dodajOceno()
        {   
            foreach(Uporabnik uporabnik in KNarociHrano.uporabniki)
            {
                if(uporabnik.Email == KNarociHrano.trenutniUporabnik.Email)
                {
                    uporabnik.seznamOcenUporabnika.Add(this);
                    MessageBox.Show("Ocena dodana");
                }
            }
        } 
    }
}
