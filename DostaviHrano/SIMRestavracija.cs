using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DostaviHrano
{
    public class SIMRestavracija
    {
        public int restavracijaId;
        public String ime { get; set; }

        public SIMRestavracija(int restavracijaId, String ime)
        {
            this.restavracijaId = restavracijaId;
            this.ime = ime;
        }

        public void potrdiNarocilo()
        {
            if(KNarociHrano.SIMizvedenoPlacilo && KNarociHrano.SIMpridobljenaLokacija)
            {
                KNarociHrano.SIMpotrjenoNarocilo = true;
            }
        }
    }
}
