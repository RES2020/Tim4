using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnosTeksta
{
   public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UnesiteTekst ut = new UnesiteTekst();
                ut.Unos();
                Console.ReadLine();
            }
        }
    }
}
