using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DostaviHrano
{
    public class Uporabnik
    {
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Naslov { get; set; }
        public string Email { get; set; }
        public string TelefonskaStevilka { get; set; }
        public string Geslo { get; set; }
        public string kreditnaKartica { get; set; }
        public string ccv { get; set; }

        public String[] narocilaUporabnika = new String[3];

        public List<Ocena> seznamOcenUporabnika = new List<Ocena>();

        public Uporabnik() { }
        public Uporabnik(string ime, string priimek, string naslov, string email, string telefonskaStevilka, string geslo, string kreditnaKartica, string ccv)
        {
            Ime = ime;
            Priimek = priimek;
            Naslov = naslov;
            Email = email;
            TelefonskaStevilka = telefonskaStevilka;
            Geslo = geslo;
            this.kreditnaKartica = kreditnaKartica;
            this.ccv = ccv;
        }
        public override bool Equals(object obj)
        {
            if (obj is Uporabnik other)
            {
                return Ime == other.Ime &&
                       Priimek == other.Priimek &&
                       Naslov == other.Naslov &&
                       Email == other.Email &&
                       TelefonskaStevilka == other.TelefonskaStevilka &&
                       Geslo == other.Geslo &&
                       kreditnaKartica == other.kreditnaKartica &&
                       ccv == other.ccv;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ime, Priimek, Naslov, Email, TelefonskaStevilka, Geslo, kreditnaKartica, ccv);
        }
    }
}
