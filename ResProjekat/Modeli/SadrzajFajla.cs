using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeli
{
    public class SadrzajFajla
    {

        private int idfajla;

        public int Idfajla
        {
            get { return idfajla; }
            set { idfajla = value; }
        }

        private string Idsadrzaja;

        public string IdSadrzaja
        {
            get { return Idsadrzaja; }
            set { Idsadrzaja = value; }
        }

        private string sadrzaj;

        public string Sadrzaj
        {
            get { return sadrzaj; }
            set { sadrzaj = value; }
        }

        public SadrzajFajla()
        {
        }

        public SadrzajFajla(int idfajla, string idsadrzaja, string sadrzaj)
        {
            if(idfajla < 0)
            {
                throw new ArgumentException("Id mora biti pozitivan broj veci od 0!");
            }

            this.idfajla = idfajla;
            Idsadrzaja = idsadrzaja;
            this.sadrzaj = sadrzaj;
        }
    }
}
