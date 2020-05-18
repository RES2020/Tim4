using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Modeli;


namespace ModeliTest
{
    [TestFixture]
    public class FajlTest
    {
        [Test]
        [TestCase(1,"naziv","ekstenzija")]

        public void DobarKonstruktor(int id, string naziv, string ekstenzija)
        {
            Fajl f = new Fajl(id, naziv, ekstenzija);
            Assert.AreEqual(f.Id, id);
            Assert.AreEqual(f.Naziv, naziv);
            Assert.AreEqual(f.Ekstenzija, ekstenzija);
        }

        [Test]
        [TestCase(-1, "naziv", "ekstenzija")]

        public void LosKonstruktor(int id, string naziv, string ekstenzija)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Fajl f = new Fajl(id, naziv, ekstenzija);
            }
            );
        }
    }
}
