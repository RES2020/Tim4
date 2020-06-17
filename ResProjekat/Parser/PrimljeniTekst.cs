using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            if (OtvarajuciTagovi() && ZatvarajuciTagovi() && ProveraBody(primljenaPoruka))
            {
                
                s = ">>>Tekst je unet u ispravnom html formatu!\n";
            }
            else
            {
                s = ">>>Tekst nije unet u ispravnom html formatu!\n";
            }
                return s;
        }

        public bool ProveraBody(string s)
        {
            bool b = true;
            string d = s.Split(' ')[7];

            if (d.Contains("<b>"))
            {
                if (d.Contains("</b>"))
                {
                    //return b;

                }
                else
                {
                    b = false;
                    //return b;
                }
            }
            if (d.Contains("<br>"))
            {
                // return b;
            }
            if (d.Contains("<ul>"))
            {
                if (d.Contains("<li>"))
                {
                    if (d.Contains("</li>"))
                    {
                        //return b;
                    }
                    else
                    {
                        b = false;
                        //return b;
                    }
                }
                else
                {
                    b = false;
                    //return b;
                }
            }
            if (d.Contains("<p>"))
            {
                if (d.Contains("</p>"))
                {
                    //return b;
                }
                else
                {
                    b = false;
                    //return b;
                }

            }
            if (d.Contains("<a href>"))
            {
                // return b;
            }




            return b;
        }

        public bool OtvarajuciTagovi()
        {
            bool b = true;
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

        public List<string> ListaUnosa()
        {
            List<string> pomocna = new List<string>();
            return pomocna;
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

            if(OtvarajuciTagovi()&&ZatvarajuciTagovi() && ProveraBody(primljenaPoruka))
            {
                b = true;
            }
                return b;
            
        }
    }
}
