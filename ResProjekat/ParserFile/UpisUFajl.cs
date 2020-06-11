using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace ParserFile
{
    public class UpisUFajl
    {

        public static SqlConnection connection;
        public static string connectionString;

        public static PrimljeniTekst pt = new PrimljeniTekst();

        private string primljeniTekst;

        public string PrimljeniTekst
        {
            get { return primljeniTekst; }
            set { primljeniTekst = value; }
        }



        public UpisUFajl()
        {
        }


        public bool UpisiUFajl(string s)
        {
            pt.PrimljenaPoruka = s;
            bool b = false;
            string putanja = Environment.CurrentDirectory + "/" + primljeniTekst+".html";
                if (ProveriTekst())
                {
                FileStream stream = new FileStream(putanja, FileMode.Create);
                StreamWriter sw = new StreamWriter(stream);
                sw.WriteLine(s);
                Console.WriteLine("******ODGOVOR OD PARSERA ZA FAJL******\n>>>Uneti tekst je uspesno upisan u fajl!\n");
                Console.WriteLine("--------------------------------------------------------------------------------\n");
                //UpisiUBazu(primljeniTekst, putanja);
                sw.Close();
                stream.Close();
                b = true;
                }
                else
                {
                b = false;
                Console.WriteLine("******ODGOVOR OD PARSERA ZA FAJL******\n>>>Tekst nije u ispravnom formatu!\nNe moze da se upise u fajl!\n");
                Console.WriteLine("--------------------------------------------------------------------------------\n");
            }
            return b;
        }

       public bool ProveriTekst()
        {
            bool b = false;
            if(pt.IspravnostTeksta())
            {
                b = true;
            }
            return b;
        }
    }
}
