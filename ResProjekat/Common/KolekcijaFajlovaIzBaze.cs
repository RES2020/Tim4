using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class KolekcijaFajlovaIzBaze
    {

        public static List<KolekcijaFajlovaIzBaze> Kolekcija = new List<KolekcijaFajlovaIzBaze>();
        private string nazivFajla;

        public string NazivFajla
        {
            get { return nazivFajla; }
            set { nazivFajla = value; }
        }

        private string ekstenzijaFajla;

        public string EkstenzijaFajla
        {
            get { return ekstenzijaFajla; }
            set { ekstenzijaFajla = value; }
        }

        public KolekcijaFajlovaIzBaze(string nazivFajla, string ekstenzijaFajla)
        {
            this.nazivFajla = nazivFajla;
            this.ekstenzijaFajla = ekstenzijaFajla;
        }

        public KolekcijaFajlovaIzBaze()
        {
        }
    }
}
