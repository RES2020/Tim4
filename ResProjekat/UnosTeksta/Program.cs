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
using virtualui;
using UIControler;


namespace UnosTeksta
{
    public class Program
    {
        public static ProslediTekst pt = new ProslediTekst();
        public static PrimljeniTekst ptt = new PrimljeniTekst();
        public static ProveraFajla pf = new ProveraFajla();
        public static UnesiteTekst utt = new UnesiteTekst();
        public static IUnesiteTekst ut=utt;
        public static VirtualUI ui = new VirtualUI();
        public static UpisUFajl uf = new UpisUFajl();
        public static Uicontroller uc = new Uicontroller();

        public static string UnetiFajl = "";
        

        

        static void Main(string[] args)
        {
            UpisUFajl.connectionString = ConfigurationManager.ConnectionStrings["UnosTeksta.Properties.Settings.BazaConnectionString"].ConnectionString;
            VirtualUI.connectionString= ConfigurationManager.ConnectionStrings["UnosTeksta.Properties.Settings.BazaConnectionString"].ConnectionString;
            VirtualUI.PopuniTabeluFajlInicijalno();
            do
            {

                String s = ut.Unos();
                //pt.UnetiTekst = ut.Unos();//saljemo tekst ili fajl u klasu prosledi tekst.
                

                pf.PrimljenFajl = s;//saljemo ekstenziju fajla parseru da proveri tekst da li je ispravna!

                if (!ut.FileOrText)//Nakon izbora(tekst ili file), ako smo izabrali tekst da unesemo necemo napraviti string "UnetiFajl" jer je on namenjen za proveru fajla da bi izdvojili naziv fajla.
                {
                    try
                    {

                        UnetiFajl = s.Split(';')[1];//Ovde uzimamo naziv fajla.
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

                try
                {
                    ptt.PrimljenaPoruka = s.Split(';')[0];//saljemo tekst na proveru!
                }
                catch
                {
                    Console.WriteLine("Greska!");
                }

                try
                {
                    ui.PrimljeniFajl = s.Split(';')[1];
                }
                catch
                {
                    Console.WriteLine("Greska!");

                }

                ptt.PrimljenaPoruka = s.Split(';')[0];//saljemo tekst na proveru!
                ui.Sadrzaj = ptt.PrimljenaPoruka;

                string ss = "";
                ss = ptt.SaljiKlijentu();//primamo proveru od parsera.




                if (ut.FileOrText)
                {
                    Console.WriteLine("*****PROVEREN TEKST*****\n" + ss);
                    try
                    {
                        uf.PrimljeniTekst = s.Split(';')[1].Trim();
                    }
                    catch
                    {
                        Console.WriteLine("Greska!\n");
                    }


                    uf.UpisiUFajl(s.Split(';')[0]);
                    bool b = false;
                    b = ui.DaLiJeIstiFajl();


                    if (b)
                    {
                        Console.WriteLine("Fajlovi su isti!\nFajl nije upisan u bazu!\n");

                    }
                    else
                    {
                        Console.WriteLine("Fajlovi nisu isti!\nFajl je uspesno upisan u tabelu Fajl i u tabelu SadrzajFajla!\n");
                    }



                    bool bb = ui.ProveraPromene(ptt.PrimljenaPoruka);
                    if (bb)
                    {
                        Console.WriteLine("Isti su\n");
                    }
                    else
                    {
                        Console.WriteLine("Nisu isti\n");
                    }
                    Console.WriteLine("Odgovor od virtualui na controleru \n"+uc.NazivFajlaOdVirtualUiKomponente()+"\n");
                    Console.WriteLine("Odgovor od virtualui na controleru \n" + ui.SaljiUiControlleruSadrzajFajla()+"\n");

                }
                else
                {
                    pf.Odgovorparserfile();
                }

            } while (pt.UnetiTekst != "izadji");
        }
    }
}
