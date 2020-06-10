using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Parser;


namespace ParserTest
{
    [TestFixture]
    public class PrimljeniTekstTest
    {


        PrimljeniTekst pt = new PrimljeniTekst();
        [Test]
        public void OtvarajuciTagovi()
        {
            bool b=pt.OtvarajuciTagovi();
            Assert.AreEqual(false, b);
        }


        [Test]
        public void ZatvarajuciTagovi()
        {
            bool b = pt.ZatvarajuciTagovi();
            Assert.AreEqual(false, b);
        }

        [Test]
        public void IspravnostTeksta()
        {
            bool b = pt.IspravnostTeksta();
            Assert.AreEqual(false, b);
        }


    }
}
