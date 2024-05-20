using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DostaviHrano
{
    public class Jedi
    {
        private string imeJedi;
        private double cenaJedi;

        public Jedi(string imeJedi, double cenaJedi)
        {
            this.imeJedi = imeJedi;
            this.cenaJedi = cenaJedi;
        }

        public string ImeJedi
        {
            get { return imeJedi; }
        }

        public double CenaJedi
        {
            get { return cenaJedi; }
        }
    }
}
