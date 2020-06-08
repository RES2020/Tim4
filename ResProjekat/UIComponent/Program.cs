using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using virtualui;
using UnosTeksta;


namespace UIComponent
{
    public class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Naziv fajla\n" +UnosTeksta.Program.ui.SaljiUiControlleruNazivFajla());
                Console.WriteLine("Sadrzaj fajla\n" + UnosTeksta.Program.ui.SaljiUiControlleruSadrzajFajla());
                Console.ReadLine();
            }
        }
    }
}
