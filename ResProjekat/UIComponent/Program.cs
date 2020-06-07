using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using virtualui;


namespace UIComponent
{
    public class Program
    {
        public static VirtualUI ui = new VirtualUI();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Naziv fajla\n" + ui.SaljiUiControlleruNazivFajla());
                Console.WriteLine("Sadrzaj fajla\n" + ui.SaljiUiControlleruSadrzajFajla());
                Console.ReadLine();
            }
        }
    }
}
