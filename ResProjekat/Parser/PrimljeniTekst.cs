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
            string[] niz=primljenaPoruka.Split(' ');

            if (niz[0] != "<html>")

            {
                return "Niste dobro uneli text u html foematu!";
            }
            else
            {
                return "Dobro ste uneli poruku!";
            }
        }
    }
}
