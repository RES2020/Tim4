using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosTeksta;
using ProsledjivanjeTeksta;
using Parser;
using ParserFajl;

namespace UnosTeksta
{
   public class Program
    {
        public static ProslediTekst pt = new ProslediTekst();
        public static PrimljeniTekst ptt = new PrimljeniTekst();
        public static ProveraFajla pf = new ProveraFajla();
        public static UpisUFajl uf = new UpisUFajl();
        private static string povrataPoruka;

        public string PovratnaPoruka
        {
            get { return povrataPoruka; }
            set { povrataPoruka = value; }
        }

        public static string povratna()
        {
            if (povrataPoruka != null)
            {
                return "Uspesno ste uneli poruku!";

            }
            else
            {
                return "Pogresno ste uneli poruku, unesite ponovo!";
            }
        }


        static void Main(string[] args)
        {
            do
            {
                UnesiteTekst ut = new UnesiteTekst();
                pt.UnetiTekst = ut.Unos();
                pf.PrimljenFajl = ut.Unos();
                uf.PrimljeniTekst = ut.Unos();
                if (pt.UnetiTekst == "izadji")
                {
                    break;
                }
                ptt.PrimljenaPoruka = ut.Unos();
                string s = "";
                s = ptt.SaljiKlijentu();
                Console.WriteLine("*****ODGOVOR OD PARSERA *****\n\n" + s);
               // bool b = uf.ProverenTekst();
               // if (b)
               // {
               //     Console.WriteLine("Tekst je ispravan");
               // }
               // else
               // {
               //     Console.WriteLine("Nije");
               // }
            } while (pt.UnetiTekst != "izadji");
        }
    }
}
