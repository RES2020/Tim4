using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Parser;

namespace ParserFile
{
    public class ProveraFajla
    {
        public bool Isfile { get; set; }
        private string primljenFajl;

        public string PrimljenFajl
        {
            get { return primljenFajl; }
            set { primljenFajl = value; }
        }

        private string fajl;

        public string Fajl
        {
            get { return fajl; }
            set { fajl = value; }
        }


        public ProveraFajla()
        {
        }

        
        public bool ProveraPutanjeFajla()
        {
           
            bool b = false;
            try
            {


                string putanja = primljenFajl.Split(' ')[0];

                var files = Directory.GetFiles(putanja);
                foreach (var file in files)
                {
                    if (Path.GetFileName(file) == fajl)
                    {
                        b = true;
                        break;
                    }
                    else
                    {
                        b = false;
                        //break;
                    }
                }
            }
            catch
            {
               b = false;
                return b;
            }
            return b;
        }
        public void Odgovorparserfile()
        {
            if (ProveraPutanjeFajla())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PROVERENA PUTANJA FAJLA");
                Console.ResetColor();
                Console.WriteLine(">>>FAJL POSTOJI!\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PROVERENA PUTANJA FAJLA ");
                Console.ResetColor();
                Console.WriteLine(">>>FAJL NE POSTOJI!\n");
            }
        }
        
    }
}
