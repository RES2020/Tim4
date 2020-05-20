using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnosTeksta
{


    public class UnesiteTekst
    {
        

        public UnesiteTekst()
        {

        }

        public string Unos()
        {

                Console.WriteLine("Unesite opciju(1 ili 2).\n1--->Unesite fajl u obliku teksta kao npr.: <html> <head> <title> Naslov aplikacije </title> </head> <body><b>NEKA APLIKACIJA </b></body></html> .\n2---->Unesite putanju do fajla.\nVas izbor je: ");
                int izbor = 0;
            try
            {
                izbor = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Morate uneti broj!");
            } 
                switch (izbor)
                {
                    case 1:
                        string s = "";
                        Console.WriteLine("Unesite tekst: ");
                        s = Console.ReadLine();
                        Console.WriteLine("Uneli ste tekst: " + s+"\n");
                    return s;
                       
                    case 2:
                        string ss = "";
                        Console.WriteLine("Unesite putanju do fajla: ");
                        ss = Console.ReadLine();
                        Console.WriteLine("Uneli ste putanju do fajla: " + ss+"\n");
                    return ss;
                       
                    default:
                        Console.WriteLine("Pogresnu ste opciju izabrali!");
                    return "Pogresna opcija!";
                       
                }


        }

       
    }
}
