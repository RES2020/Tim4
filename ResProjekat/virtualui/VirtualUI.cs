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
        }

        public VirtualUI(SqlCommand cmd, List<KolekcijaFajlovaIzBaze> kolekcija, string primljeniFajl, string sadrzaj)
        {
            this.cmd = cmd;
            this.kolekcija = kolekcija;
            this.primljeniFajl = primljeniFajl;
            this.sadrzaj = sadrzaj;
            
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
            UpisiUTabeluSadrzaj(putanja,primljeniFajl);
            return b;
        }



        public bool ProveraPromene(string s)
        {
            int id = VratiId();
            string sadrzaj = "";
            bool b = false;
            string query2 = "SELECT Sadrzaj FROM SadrzajFajla where IdSadrzaja='" + id + "'";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd2 = new SqlCommand(query2, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))
            {
                try
                {
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    sadrzaj = tabela.Rows[0]["Sadrzaj"].ToString();
                }
                catch
                {
                    b = false;
                }
            }
            if (sadrzaj == s)
            {
                b = true;
            }
            return b;
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
            int id = 0;
            string query2 = "SELECT Id FROM Fajl where Naziv='" + primljeniFajl + "'";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd2 = new SqlCommand(query2, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))
            {
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                id = int.Parse(tabela.Rows[0]["Id"].ToString());

            }
            return id;
        }



        public static void UpisiUTabeluFajl(string name, string putanja)
        {
            string query = "INSERT INTO Fajl VALUES (@Ime,@Ekstenzija)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Ime", name);
                    cmd.Parameters.AddWithValue("@Ekstenzija", putanja);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }

        public static void UpisiUTabeluSadrzaj(string putanja,string primljeniFajl)
        {
            try
            {
                List<string> stringovi = File.ReadLines(putanja).ToList();
                string s = "";
                int id = 0;
                foreach (var item in stringovi)
                {
                    s += item;
                }


                string query2 = "SELECT Id FROM Fajl where Naziv='" + primljeniFajl + "'";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd2 = new SqlCommand(query2, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))
                {
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    id = int.Parse(tabela.Rows[0]["Id"].ToString());

                }


                string query = "INSERT INTO SadrzajFajla VALUES (@Id,@Sadrzaj)";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Sadrzaj", s);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public static void PopuniTabeluFajlInicijalno()
        {


            string query2 = "SELECT * FROM Fajl";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd2 = new SqlCommand(query2, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))
            {
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                if (tabela.Rows.Count == 0)
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
                else
                {
                    //Ne radi nista!
                }

            }
        }
    }
}
