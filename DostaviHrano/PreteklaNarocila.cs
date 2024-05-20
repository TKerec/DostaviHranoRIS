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
    public partial class PreteklaNarocila : Form
    {
        public PreteklaNarocila()
        {
            InitializeComponent();
            this.Load += new EventHandler(PreteklaNarocila_Load);
        }
        private void PreteklaNarocila_Load(object sender, EventArgs e)
        {
            foreach (Uporabnik temp in KNarociHrano.uporabniki)
            {
                if (temp.Equals(KNarociHrano.trenutniUporabnik))
                {
                    if (!(temp.narocilaUporabnika[0] == null))
                    {
                        narocilo1.Visible = true;
                        narocilo1.Text = temp.narocilaUporabnika[0].ToString();

                    }
                    if (!(temp.narocilaUporabnika[1] == null))
                    {
                        narocilo2.Visible = true;
                        narocilo2.Text = temp.narocilaUporabnika[1].ToString();
                    }
                    if (!(temp.narocilaUporabnika[2] == null))
                    {
                        narocilo3.Visible = true;
                        narocilo3.Text = temp.narocilaUporabnika[2].ToString();
                    }

                }
            }
        }

        private void narocilo2_Click(object sender, EventArgs e)
        {

        }
    }
}
