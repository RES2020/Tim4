using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsledjivanjeTeksta;

namespace Parser
{
    public class PrimljeniTekst
    {
        private string primljenaPoruka;

        public string PrimljenaPoruka
        {
            get { return primljenaPoruka; }
            set { primljenaPoruka = value; }
        }


        public PrimljeniTekst()
        {

        }

        public string SaljiKlijentu()
        {
            if (primljenaPoruka != "a")
            {
                return "Niste dobro uneli poruku!";
            }
            else
            {
                return "Dobro ste uneli poruku!";
            }
        }
    }
}
