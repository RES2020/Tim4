using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtualui
{
    public interface IRepozitorijum
    {
        bool ProveraPromene(string s,string naziv,string ss);
        Dictionary<int,string> ProveraPromenee(string s, string naziv, string ss);
        bool DaLiJeIstiFajl(string s);
        int VratiId(string s);
        void UpisiUTabeluFajl(string name, string putanja);
        void UpisiUTabeluSadrzaj(string putanja, string primljeniFajl);
         void PopuniTabeluFajlInicijalno();
    }
}
