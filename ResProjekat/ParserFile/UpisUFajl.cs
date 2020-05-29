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


        public void UpisiUFajl(string s)
        {
            pt.PrimljenaPoruka = s;
            string putanja = Environment.CurrentDirectory + "/" + "test.html";
                if (ProveriTekst())
                {
                FileStream stream = new FileStream(putanja, FileMode.Create);
                StreamWriter sw = new StreamWriter(stream);
                sw.WriteLine(s);
                Console.WriteLine("Uneti tekst je uspesno upisan u fajl!\n");
                UpisiUBazu("test.html", putanja);
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


        public static void UpisiUBazu(string name, string putanja)
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Fajl values('" + name + "','" + putanja + "')";
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }





    }
}
