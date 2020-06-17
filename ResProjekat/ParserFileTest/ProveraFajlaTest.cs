using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ParserFile;

namespace ParserFileTest
{
    [TestFixture]
    public class ProveraFajlaTest
    {


        [Test]
        public void ProveraPutanjeFajlaLosa()
        {
            ProveraFajla pf = new ProveraFajla();
            bool b = pf.ProveraPutanjeFajla();
            Assert.AreEqual(false, b);
        }

        [Test]
        public void ProveraPutanjeFajlaDobra()
        {
            ProveraFajla pf = new ProveraFajla();
            pf.PrimljenFajl= @"D:\  proba1.html";
            pf.Fajl = "proba1.html";
            bool b = pf.ProveraPutanjeFajla();
            Assert.AreEqual(true, b);
        }


    }
}
