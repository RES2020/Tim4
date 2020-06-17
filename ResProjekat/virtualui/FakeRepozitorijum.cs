using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace virtualui
{
   public class FakeRepozitorijum:IRepozitorijum
    {
        List<string> DaLiJeIstiFajlLista ;
        Dictionary<int, string> RecnikZaVratiId ;
        Dictionary<string, string> RecnikZaProveraPromene;
        public  Dictionary<string, string> RecnikZaUpisUTabeluFajl { get; set; }

        public FakeRepozitorijum() { }

       public bool ProveraPromene(string s, string naziv, string ss)
        {
            RecnikZaProveraPromene = new Dictionary<string, string>();
            RecnikZaProveraPromene.Add(naziv, ss);
            string stringIzBaze ="";
            bool b = false;
            foreach(var item in RecnikZaProveraPromene)
            {
                stringIzBaze = item.Value;
            }
            if (s == stringIzBaze)
            {
                b = true;
            }
            return b;
        }
        public Dictionary<int,string> ProveraPromenee(string s, string naziv, string ss)
        {
            RecnikZaProveraPromene = new Dictionary<string, string>();
            RecnikZaProveraPromene.Add(naziv, ss);
            Dictionary<int, string> pom = new Dictionary<int, string>();
            string stringIzBaze = "";
            foreach (var item in RecnikZaProveraPromene)
            {
                stringIzBaze = item.Value;
            }
            if (s == stringIzBaze)
            {
            }
            return pom;
        }


        public bool DaLiJeIstiFajl(string s)
        {
            bool b = false;
            DaLiJeIstiFajlLista = new List<string>();
            DaLiJeIstiFajlLista.Add(s);
            foreach (var item in DaLiJeIstiFajlLista)
            {
                if (item == s)
                {
                    b = true;
                }
            }
            return b;
        }


        public int VratiId(string s)
        {
            RecnikZaVratiId = new Dictionary<int, string>();
            RecnikZaVratiId.Add(1, s);
            int id=0;
            foreach(var item in RecnikZaVratiId)
            {
                id = item.Key;
            }
            return id;
        }


        public void UpisiUTabeluFajl(string name, string putanja)
        {
            RecnikZaUpisUTabeluFajl = new Dictionary<string, string>();
            RecnikZaUpisUTabeluFajl.Add(name, putanja);
            if (RecnikZaUpisUTabeluFajl == null)
            {
                throw new Exception();
            }
        }
        public void UpisiUTabeluSadrzaj(string putanja, string primljeniFajl)
        {
            RecnikZaUpisUTabeluFajl = new Dictionary<string, string>();
            RecnikZaUpisUTabeluFajl.Add(putanja, primljeniFajl);
            if (RecnikZaUpisUTabeluFajl == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void PopuniTabeluFajlInicijalno()
        {
            RecnikZaUpisUTabeluFajl = new Dictionary<string, string>();
            RecnikZaUpisUTabeluFajl.Add("", "");
        }

    }
}
