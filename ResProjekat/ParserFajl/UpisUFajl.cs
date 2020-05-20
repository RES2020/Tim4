using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace ParserFajl
{
    public class UpisUFajl
    {
        private string primljeniTekst;

        public string PrimljeniTekst
        {
            get { return primljeniTekst; }
            set { primljeniTekst = value; }
        }

        public UpisUFajl()
        {
        }
        public static PrimljeniTekst pt = new PrimljeniTekst();

        public bool ProverenTekst()
        {
            bool b = false;
            if (pt.IspravnostTeksta())
            {
                b = true;
            }
            return b;
        }
    }
}
