﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosTeksta;
using ProsledjivanjeTeksta;
using Parser;

namespace UnosTeksta
{
   public class Program
    {
        public static ProslediTekst pt = new ProslediTekst();
        public static PrimljeniTekst ptt = new PrimljeniTekst();
        private static string povrataPoruka;

        public string PovratnaPoruka
        {
            get { return povrataPoruka; }
            set { povrataPoruka = value; }
        }

        public static string povratna()
        {
            if (povrataPoruka != null)
            {
                return "Uspesno ste uneli poruku!";

            }
            else
            {
                return "Pogresno ste uneli poruku, unesite ponovo!";
            }
        }


        static void Main(string[] args)
        {
            do
            {
                UnesiteTekst ut = new UnesiteTekst();
                pt.UnetiTekst = ut.Unos();
                ptt.PrimljenaPoruka = pt.UnetiTekst;
                string s = "";
                s = ptt.SaljiKlijentu();
                Console.WriteLine("Odgovor parsera je: " + s);
                Console.ReadLine();
            } while (pt.UnetiTekst != "izadji");
        }
    }
}
