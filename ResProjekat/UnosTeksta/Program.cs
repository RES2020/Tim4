using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosTeksta;
using ProsledjivanjeTeksta;
using Parser;
<<<<<<< HEAD
using ParserFajl;
=======
using ParserFile;
>>>>>>> 1adaeacb5100e3092581839f5a4a4577e7307e37

namespace UnosTeksta
{
   public class Program
    {
        public static ProveraFajla pf = new ProveraFajla();
        public static ProslediTekst pt = new ProslediTekst();
        public static PrimljeniTekst ptt = new PrimljeniTekst();
<<<<<<< HEAD
        public static ProveraFajla pf = new ProveraFajla();
        public static UpisUFajl uf = new UpisUFajl();
=======
       // public static UpisUFajl uf = new UpisUFajl();
>>>>>>> 1adaeacb5100e3092581839f5a4a4577e7307e37
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
<<<<<<< HEAD
                pf.PrimljenFajl = ut.Unos();
                uf.PrimljeniTekst = ut.Unos();
=======
               // pf.PrimljenFajl = ut.Unos();
>>>>>>> 1adaeacb5100e3092581839f5a4a4577e7307e37
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
