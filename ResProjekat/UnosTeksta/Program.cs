using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosTeksta;
using ProsledjivanjeTeksta;
using Parser;
using ParserFile;
using System.IO;

namespace UnosTeksta
{
    public class Program
    {
        public static ProslediTekst pt = new ProslediTekst();
        public static PrimljeniTekst ptt = new PrimljeniTekst();
        public static ProveraFajla pf = new ProveraFajla();
        public static UnesiteTekst ut = new UnesiteTekst();
        public static string UnetiFajl = "";

        static void Main(string[] args)
        {
            do
            {
                pt.UnetiTekst = ut.Unos();//saljemo tekst ili fajl u klasu prosledi tekst.
                pf.PrimljenFajl = pt.UnetiTekst;//saljemo fajl parseru da proveri tekst da li je ispravan!
                if (!ut.FileOrText)//Nakon izbora(tekst ili file), ako smo izabrali tekst da unesemo necemo napraviti string "UnetiFajl" jer je on namenjen za proveru fajla da bi izdvojili naziv fajla.
                {
                    UnetiFajl = pt.UnetiTekst.Split(' ')[1];//Ovde uzimamo naziv fajla.
                }
                pf.fajl = UnetiFajl;//Ovde saljemo naziv fajla parserfajlu koji smo uneli radi provere da li postoji!
                if (pt.UnetiTekst == "izadji")//Ako smo uneli izadji, prekidamo rad programa!
                {
                    break;
                }
                ptt.PrimljenaPoruka = pt.UnetiTekst;//saljemo tekst na proveru!
                string s = "";
                s = ptt.SaljiKlijentu();//primamo proveru od parsera.
                if (ut.FileOrText)
                {
                    Console.WriteLine("*****PROVEREN TEKST*****\n" + s);
                }
                else
                {
                    pf.Odgovorparserfile();
                }
            } while (pt.UnetiTekst != "izadji");
        }
    }
}
