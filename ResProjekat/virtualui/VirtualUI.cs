using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Common;

namespace virtualui
{
    public class VirtualUI
    {
        public static string connectionString;
        public static SqlConnection connection;
        public SqlCommand cmd;

        List<KolekcijaFajlovaIzBaze> kolekcija = KolekcijaFajlovaIzBaze.Kolekcija;
        IRepozitorijum r;
        


        private string primljeniFajl;

        public  string PrimljeniFajl
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

        

        public VirtualUI()
        {
            r = new Repozitorijum(primljeniFajl,sadrzaj);
        }

        public VirtualUI(SqlCommand cmd, List<KolekcijaFajlovaIzBaze> kolekcija, string primljeniFajl, string sadrzaj)
        {
            this.cmd = cmd;
            this.kolekcija = kolekcija;
            this.primljeniFajl = primljeniFajl;
            this.sadrzaj = sadrzaj;
            
        }

        public VirtualUI(IRepozitorijum repo)
        {
            r = repo;
        }



        public bool DaLiJeIstiFajl()
        {
            string ime = primljeniFajl;
           bool b= r.DaLiJeIstiFajl(ime);
            return b;
        }



        public bool ProveraPromene(string s)
        {
            s = sadrzaj;
            bool b = r.ProveraPromene(s,primljeniFajl,sadrzaj);
            return b;
        }


        public Dictionary<int,string> ProveraPromene2(string s)
        {
            s = sadrzaj;
            Dictionary<int, string> pom = r.ProveraPromenee(s, primljeniFajl, sadrzaj);
            return pom;
        }


        public string SaljiUiControlleruNazivFajla()
        {
            return primljeniFajl;
        }

        public string SaljiUiControlleruSadrzajFajla()
        {
            return sadrzaj;
        }



        public int VratiId()
        {
            int id = r.VratiId(primljeniFajl);
            return id;
        }



        public  void UpisiUTabeluFajl(string ime, string putanja)
        {
            ime = primljeniFajl;
            r.UpisiUTabeluFajl(ime, putanja);

        }

        public  void UpisiUTabeluSadrzaj(string putanja,string ime)
        {
            ime = primljeniFajl;
            r.UpisiUTabeluSadrzaj(putanja, ime);
        }


        public  void PopuniTabeluFajlInicijalno()
        {
            r.PopuniTabeluFajlInicijalno();
        }
    }
}
