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
using Common;
using System.Configuration;


namespace UnosTeksta
{
    public class Program
    {
        public static ProslediTekst pt = new ProslediTekst();
        public static PrimljeniTekst ptt = new PrimljeniTekst();
        public static ProveraFajla pf = new ProveraFajla();
        public static UnesiteTekst utt = new UnesiteTekst();
        public static IUnesiteTekst ut=utt;
        public static UpisUFajl uf = new UpisUFajl();
        public static string UnetiFajl = "";
        public static string connectionString;

        static void Main(string[] args)
        {
            connectionString = ConfigurationManager.ConnectionStrings["UnosTeksta.Properties.Settings.BazaConnectionString"].ConnectionString;
            do
            {
            
                String s = ut.Unos();
                //pt.UnetiTekst = ut.Unos();//saljemo tekst ili fajl u klasu prosledi tekst.
                uf.PrimljeniTekst = s;

                pf.PrimljenFajl = s;//saljemo ekstenziju fajla parseru da proveri tekst da li je ispravna!

                if (!ut.FileOrText)//Nakon izbora(tekst ili file), ako smo izabrali tekst da unesemo necemo napraviti string "UnetiFajl" jer je on namenjen za proveru fajla da bi izdvojili naziv fajla.
                {
                    try
                    {

                        UnetiFajl = s.Split(' ')[1];//Ovde uzimamo naziv fajla.
                    }
                    catch
                    {
                        //pf.fajl = "jgjfjh";
                        Console.WriteLine("Greska!\n");
                    }
                }


                pf.fajl = UnetiFajl;//Ovde saljemo naziv fajla parserfajlu koji smo uneli radi provere da li postoji!

                if (s == "izadji")//Ako smo uneli izadji, prekidamo rad programa!
                {
                    break;
                }


                ptt.PrimljenaPoruka = s;//saljemo tekst na proveru!

                string ss = "";
                ss = ptt.SaljiKlijentu();//primamo proveru od parsera.

                if (ut.FileOrText)
                {
                    Console.WriteLine("*****PROVEREN TEKST*****\n" + ss);
                    uf.UpisiUFajl(s,connectionString);

                }
                else
                {
                    pf.Odgovorparserfile();
                }

            } while (pt.UnetiTekst != "izadji");
        }
    }
}
