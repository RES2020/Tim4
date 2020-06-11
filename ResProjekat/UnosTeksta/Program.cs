using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosTeksta;
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
        
        public static PrimljeniTekst ptt = new PrimljeniTekst();
        public static ProveraFajla pf = new ProveraFajla();
        public static UnesiteTekst utt = new UnesiteTekst();
        public static IUnesiteTekst ut=utt;
        public static VirtualUI ui = new VirtualUI();
        public static UpisUFajl uf = new UpisUFajl();
        public static Uicontroller uc = new Uicontroller();
        public static Repozitorijum r = new Repozitorijum();

        public static string UnetiFajl = "";
        

        

        static void Main(string[] args)
        {
            UpisUFajl.connectionString = ConfigurationManager.ConnectionStrings["UnosTeksta.Properties.Settings.BazaConnectionString"].ConnectionString;
            VirtualUI.connectionString= ConfigurationManager.ConnectionStrings["UnosTeksta.Properties.Settings.BazaConnectionString"].ConnectionString;
            Repozitorijum.connectionString= ConfigurationManager.ConnectionStrings["UnosTeksta.Properties.Settings.BazaConnectionString"].ConnectionString;
            ui.PopuniTabeluFajlInicijalno();
            do
            {
                //Primamo tekst koji je korisnik uneo
                String s = ut.Unos();
                if (s == "Pogresna opcija!")
                {
                    Console.WriteLine(">>>Unesite ponovo!\n");
                    continue;
                }

                //Ako smo uneli izadji, prekidamo rad programa!
                if (s == "izadji")
                {
                    break;
                }
                //pt.UnetiTekst = ut.Unos();//saljemo tekst ili fajl u klasu prosledi tekst.

                //saljemo ekstenziju fajla parseru da proveri tekst da li je ispravna!
                pf.PrimljenFajl = s;

                //Nakon izbora(tekst ili file), ako smo izabrali tekst da unesemo necemo napraviti string "UnetiFajl"
                //jer je on namenjen za proveru fajla da bi izdvojili naziv fajla.
                if (!ut.FileOrText)
                {
                    try
                    {
                        //Ovde uzimamo naziv fajla.
                        UnetiFajl = s.Split(';')[1];
                    }
                    catch
                    {
                        //pf.fajl = "jgjfjh";
                       // Console.WriteLine("Greska!\n");
                    }
                }


              //  pf.Fajl = UnetiFajl;//Ovde saljemo naziv fajla parserfajlu koji smo uneli radi provere da li postoji!

                try
                {
                    //saljemo tekst na proveru!
                    ptt.PrimljenaPoruka = s.Split(';')[0];
                }
                catch
                {
                  //  Console.WriteLine("Greska!");
                }

                try
                {
                    //Uzimamo naziv fajla i saljemo ga VirtualUI za dalji rad
                    ui.PrimljeniFajl = s.Split(';')[1];
                }
                catch
                {
                   // Console.WriteLine("Greska!");

                }

                //saljemo tekst na proveru!
                ptt.PrimljenaPoruka = s.Split(';')[0];
                ui.Sadrzaj = ptt.PrimljenaPoruka;
                r.Sadrzaj = ptt.PrimljenaPoruka;
                r.PrimljeniFajl= s.Split(' ')[1].Split('.')[0];

                //primamo proveru od parsera
                string ss = "";
                ss = ptt.SaljiKlijentu();



                //Odgovor parsera da li je tekst u ispravnom formatu
                if (ut.FileOrText)
                {
                    Console.WriteLine("******ODGOVOR OD PARSERA ZA TEKST******\n" + ss);
                    if (ss == ">>>Tekst nije unet u ispravnom html formatu!\n")
                    {
                        continue;
                    }
                    try
                    {
                        uf.PrimljeniTekst = s.Split(';')[1].Trim();
                    }
                    catch
                    {
                        //Console.WriteLine("Greska!\n");
                    }

                    //Upisujemo tekst koji je korisnik uneo
                    //Splitujemo po ; i uzimamo sa prvog mesta tekst, a na drugom mestu je naziv fajla
                    try
                    {
                        if (uf.UpisiUFajl(s.Split(';')[0]))
                        {

                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    //Ovde proveravamo da li su fajlovi isti
                    bool b = false;

                    b = ui.DaLiJeIstiFajl();


                    if (b)
                    {
                        Console.WriteLine("******ODGOVOR OD VIRTUAL UI******");
                        Console.WriteLine(">>>Fajl sa tim nazivom vec postoji u bazi podataka!\n>>>Fajl nije upisan u bazu podataka!\n");
                        Console.WriteLine("***Podaci Fajla:");
                        Console.WriteLine(">>>Naziv fajla: " + ui.PrimljeniFajl);
                        Console.WriteLine(">>>Sadrzaj fajla: " + ui.Sadrzaj + "\n");

                    }
                    else
                    {
                        Console.WriteLine("******ODGOVOR OD VIRTUAL UI******\n");
                        Console.WriteLine(">>>Fajl sa tim nazivom ne postoji u bazi podataka!\n>>>Fajl je uspesno upisan u tabelu Fajl i u tabelu SadrzajFajla!\n");
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        continue;
                    }


                    //Proveravamo sadrzaj fajlova
                    bool bb = ui.ProveraPromene(ptt.PrimljenaPoruka);

                    if (bb)
                    {
                        Console.WriteLine("***Provera sadrzaja fajlova");
                        Console.WriteLine(">>>Isti su sadrzaji fajlova!\n>>>Nema promena u sadrzaju.\n");
                        Console.WriteLine("--------------------------------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("***Provera sadrzaja fajlova");
                        Console.WriteLine(">>>Nisu isti sadrzaji fajlova!\n");
                        Console.WriteLine("--------------------------------------------------------------------------------");
                    }

                   // Console.WriteLine("Odgovor od virtualui na controleru \n"+uc.NazivFajlaOdVirtualUiKomponente()+"\n");
                   // Console.WriteLine("Odgovor od virtualui na controleru \n" + ui.SaljiUiControlleruSadrzajFajla()+"\n");

                }
                else
                {

                    pf.Fajl = s.Split(' ')[1];
                    ui.PrimljeniFajl = s.Split(' ')[1].Split('.')[0];
                    pf.Odgovorparserfile();

                    bool b = false;
                    b = ui.DaLiJeIstiFajl();


                    if (b)
                    {
                        Console.WriteLine("Nazivi fajlova su isti!\nFajl nije upisan u bazu podataka!\n");
                        Console.WriteLine("Naziv fajla: " + ui.PrimljeniFajl + "\n");
                        Console.WriteLine("Ekstenzija: " + ui.Sadrzaj);

                    }
                    else
                    {
                        Console.WriteLine("Nazivi fajlova nisu isti!\nFajl je uspesno upisan u tabelu Fajl i u tabelu SadrzajFajla!\n");
                    }
                }

            } while (ptt.PrimljenaPoruka != "izadji");
        }
    }
}
