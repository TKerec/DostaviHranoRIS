using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DostaviHrano
{
    public class SIMDostavljalec
    {
        public int dostavljalecId;
        public String ime { get; set; }
        public String priimek { get; set; }
        public String telefon { get; set; }
        public String lokacija { get; set; }

        public SIMDostavljalec(int dostavljalecId, String ime, String priimek, String telefon, String lokacija)
        {
            this.dostavljalecId = dostavljalecId;
            this.ime = ime;
            this.priimek = priimek;
            this.telefon = telefon;
            this.lokacija = lokacija;
        }

        public void pridobiLokacijo()
        {
            KNarociHrano.SIMpridobljenaLokacija = true;
        }

    }
}
