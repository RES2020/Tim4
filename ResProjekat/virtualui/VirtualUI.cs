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
            string query = "SELECT * FROM Fajl";
            bool b = false;
            using (connection = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                for(int i = 0; i < tabela.Rows.Count; i++)
                {
                    string naziv = tabela.Rows[i]["Naziv"].ToString().Trim();
                    string ekstenzija= tabela.Rows[i]["Ekstenzija"].ToString().Trim();
                    kolekcija.Add(new KolekcijaFajlovaIzBaze(naziv, ekstenzija));
                }
            }
            foreach(var item in kolekcija)
            {
                if (item.NazivFajla == primljeniFajl)
                {
                    b = true;
                    return b;
                }
            }
            string putanja = Environment.CurrentDirectory + "/" + primljeniFajl + ".html";
            UpisiUTabeluFajl(primljeniFajl, putanja);
            UpisiUTabeluSadrzaj(putanja);
            return b;
        }

        public string ProveraPromene()
        {

            return "";
        }
        public string SaljiUiControlleru()
        {
            return "";
        }



        public static void UpisiUTabeluFajl(string name, string putanja)
        {
            string query = "INSERT INTO Fajl VALUES (@Ime,@Ekstenzija)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@Ime", name);
                cmd.Parameters.AddWithValue("@Ekstenzija", putanja);
                cmd.ExecuteNonQuery();
            }

        }

        public static void UpisiUTabeluSadrzaj(string putanja)
        {
            List<string> stringovi = File.ReadLines(putanja).ToList();
            string s = Convert.ToString(stringovi);
                string query = "INSERT INTO SadrzajFajla VALUES (@Sadrzaj)";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Sadrzaj", s);
                    cmd.ExecuteNonQuery();
                }

        }


        public static void PopuniTabeluFajlInicijalno()
        {
            string query = "INSERT INTO Fajl VALUES (@Ime,@Ekstenzija)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@Ime", "fajl1");
                cmd.Parameters.AddWithValue("@Ekstenzija", @"C:\Users\Milenko\Documents\Tim4\ResProjekat\UnosTeksta\bin\Debug");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
