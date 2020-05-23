using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserFile;
using virtualui;

namespace UIControler
{
    public class Uicontroller
    {

        public static ProveraFajla pf = new ProveraFajla();
        public static VirtualUI vui = new VirtualUI();
        private string primljeniFajl;

        public string PrimljeniFajl
        {
            get { return primljeniFajl; }
            set { primljeniFajl = value; }
        }

        public Uicontroller()
        {
            primljeniFajl = pf.fajl;
            vui.PrimljeniFajl = primljeniFajl;
        }

        public string FajlOdVirtualUiKomponente()
        {
            return "";
        }

        public string SaljiUiKomponenti()
        {
            return "";
        }
    }
}
