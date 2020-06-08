using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string s = "";
            if (OtvarajuciTagovi() && ZatvarajuciTagovi())
            {
                
                s = "OK";
            }
            else
            {
                s = "NOT OK";
            }
            return s;
        }

        public bool OtvarajuciTagovi()
        {
            bool b = true;
            Regex regex = new Regex(@"\s*(?<word>\w+)\s+");

            try
            {
                string[] otvarajuci = primljenaPoruka.Split(' ');
                if (otvarajuci[0] != "<html>")
                {
                    b = false;
                }
                else if (otvarajuci[1] != "<head>")
                {
                    b = false;
                }
                else if (otvarajuci[2] != "<title>")
                {
                    b = false;
                }
                else if (otvarajuci[6] != "<body>")
                {
                    b = false;
                }
                return b;
            }
            catch
            {
                b = false;
                return b;
            }
        }


        public bool ZatvarajuciTagovi()
        {
            bool b = true;
            try
            {
                string[] zatvarajuci = primljenaPoruka.Split(' ');
                if (zatvarajuci[4] != "</title>")
                {
                    b = false;

                }
                else if (zatvarajuci[5] != "</head>")
                {
                    b = false;
                }
                else if (zatvarajuci[8] != "</body>")
                {
                    b = false;
                }
                else if (zatvarajuci[9] != "</html>")
                {
                    b = false;
                }
                return b;
            }
          catch
            {
                b = false;
                return b;
            }
        }

       /* public bool ProveraBodyDela()
        {
            bool b = true;

        }*/

        public bool IspravnostTeksta()
        {
            bool b = false;

            if(OtvarajuciTagovi()&&ZatvarajuciTagovi())
            {
                b = true;
            }
                return b;
            
        }
    }
}
