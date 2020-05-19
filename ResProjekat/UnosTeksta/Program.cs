using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosTeksta;
using ProsledjivanjeTeksta;

namespace UnosTeksta
{
   public class Program
    {
        public static ProslediTekst pt = new ProslediTekst();

        static void Main(string[] args)
        {
            while (true)
            {
                UnesiteTekst ut = new UnesiteTekst();             
                pt.UnetiTekst = ut.Unos();
                Console.ReadLine();
            }
        }
    }
}
