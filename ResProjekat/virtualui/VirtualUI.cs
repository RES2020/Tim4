using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace virtualui
{
    public class VirtualUI
    {
        private string primljeniFajl;

        public string PrimljeniFajl
        {
            get { return primljeniFajl; }
            set { primljeniFajl = value; }
        }

        public VirtualUI()
        {
            
        }

        public bool DaLiJeIstiFajl()
        {
            return true;
        }

        public string ProveraPromene()
        {
            return "";
        }
        public string SaljiUiControlleru()
        {
            return "";
        }
    }
}
