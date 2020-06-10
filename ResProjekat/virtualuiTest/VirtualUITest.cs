using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using virtualui;

namespace virtualuiTest
{
    [TestFixture]
    public class VirtualUITest
    {
        private IRepozitorijum repozitorijum;
        private VirtualUI virtualui;


        [SetUp]
        public void SetUp()
        {
            repozitorijum = new FakeRepozitorijum();
            virtualui = new VirtualUI(repozitorijum);
        }


        [Test]
        [TestCase("da","naziv","da")]
        public void ProveraPromene(string s, string naziv, string ss)
        {
            bool b;
            b=repozitorijum.ProveraPromene(s, naziv, ss);
            Assert.AreEqual(true, b);
        }

        [Test]
        [TestCase("da")]
        public void DaLiJeIstiFajl(string s)
        {
            bool b;
            b = repozitorijum.DaLiJeIstiFajl(s);
            Assert.AreEqual(true, b);
        }

        [Test]
        [TestCase("Naziv")]
        public void VratiId(string s)
        {
            int id=0;
            id = repozitorijum.VratiId(s);
            Assert.AreEqual(id,1);
        }

        [Test]
        [TestCase(null, @"C:\Users\Milenko\Documents\Tim4\ResProjekat\UnosTeksta\bin\Debug\proba1.html")]
        public void UpisiUTabeluFajl(string name,string putanja)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                repozitorijum.UpisiUTabeluFajl(name, putanja);
            });
        }

        [Test]
        [TestCase(null, @"C:\Users\Milenko\Documents\Tim4\ResProjekat\UnosTeksta\bin\Debug\proba1.html")]
        public void UpisiUTabeluSadrzaj(string putanja, string primljeniFajl)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                repozitorijum.UpisiUTabeluFajl(putanja, primljeniFajl);
            });
        }

        [Test]
        public void PopuniTabeluFajlInicijalnoDobro()
        {
            FakeRepozitorijum fk = new FakeRepozitorijum();
            fk.PopuniTabeluFajlInicijalno();
            Assert.AreNotEqual(0, fk.RecnikZaUpisUTabeluFajl.Count);
        }
    }
}
