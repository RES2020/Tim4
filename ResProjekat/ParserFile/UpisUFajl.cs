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


        public void UpisiUFajl(string s,string connect)
        {
            pt.PrimljenaPoruka = s;
            string putanja = Environment.CurrentDirectory + "/" + "test.html";
            string putt = "asfgsag";
                if (ProveriTekst())
                {
                FileStream stream = new FileStream(putanja, FileMode.Create);
                StreamWriter sw = new StreamWriter(stream);
                sw.WriteLine(s);
                Console.WriteLine("Uneti tekst je uspesno upisan u fajl!\n");
                UpisiUBazu("test.html", putanja,connect);
                sw.Close();
                stream.Close();

                }
                else
                {
                Console.WriteLine("Tekst nije u ispravnom formatu!\nNe moze da se upise u fajl!\n");

                }
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


        public static void UpisiUBazu(string name, string putanja,string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Fajl values('" + name + "','" + putanja + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
        }





    }
}
