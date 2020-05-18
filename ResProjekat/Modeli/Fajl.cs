using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class Fajl
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private string ekstenzija;

        public string Ekstenzija
        {
            get { return ekstenzija; }
            set { ekstenzija = value; }
        }

        public Fajl(int id, string naziv, string ekstenzija)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id mora biti pozitivan broj veci od 0!");
            }
            this.id = id;
            this.naziv = naziv;
            this.ekstenzija = ekstenzija;
        }

        public Fajl()
        {
        }
    }
}
