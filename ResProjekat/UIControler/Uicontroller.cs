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
        public static VirtualUI vui=new VirtualUI();
        
        private string primljeniFajl;

        public string PrimljeniFajl
        {
            get { return primljeniFajl; }
            set { primljeniFajl = value; }
        }
        private string sadrzaj;

        public string Sadrzaj
        {
            get { return sadrzaj; }
            set { sadrzaj = value; }
        }


        public Uicontroller()
        {
            primljeniFajl = pf.Fajl;
            vui.PrimljeniFajl = primljeniFajl;
        }
    }
}
