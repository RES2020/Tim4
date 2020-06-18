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
        #region OtvarajuciTagovi Testovi
        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>tekst</b> </body> </html>")]
        public void OtvarajuciTagoviDobar(string s)
        {
            bool b=pt.OtvarajuciTagovi(s);
            Assert.AreEqual(true, b);
        }

        [Test]
        [TestCase("<title> <html> <title> naziv </title> </head> <body> <b>tekst</b> </body> </html>")]
        public void OtvarajuciTagoviPrviIf(string s)
        {
            bool b = pt.OtvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <dgsdgsd> <title> naziv </title> </head> <body> <b>tekst</b> </body> </html>")]
        public void OtvarajuciTagoviDrugiIf(string s)
        {
            bool b = pt.OtvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <hfddfhfdh> naziv </title> </head> <body> <b>tekst</b> </body> </html>")]
        public void OtvarajuciTagoviTreciiIf(string s)
        {
            bool b = pt.OtvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("")]
        public void OtvarajuciTagoviTryCatch(string s)
        {
            bool b = pt.OtvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        #endregion OtvarajuciTagovi Testovi

        #region ZatvarajuciTagovi Testovi

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>tekst</b> </body> </html>")]
        public void ZatvarajuciTagoviDobar(string s)
        {
            bool b = pt.ZatvarajuciTagovi(s);
            Assert.AreEqual(true, b);
        }
        [Test]
        [TestCase("<title><html> <title> naziv </title> </head> <body> <b>tekst</b> </body> </html>")]
        public void ZatvarajuciTagoviPrviIf(string s)
        {
            bool b = pt.ZatvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("")]
        public void ZatvarajuciTagoviZaTryCatch(string s)
        {
            bool b = pt.ZatvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </gdsg> <body> <b>tekst</b> </body> </html>")]
        public void ZatvarajuciTagoviDrugiIf(string s)
        {
            bool b = pt.ZatvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>tekst</b> </gsdaga> </html>")]
        public void ZatvarajuciTagoviTreciIf(string s)
        {
            bool b = pt.ZatvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>tekst</b> </body> </gsdgsd>")]
        public void ZatvarajuciTagoviCetvrtiIf(string s)
        {
            bool b = pt.ZatvarajuciTagovi(s);
            Assert.AreEqual(false, b);
        }
        #endregion ZatvarajuciTagovi Testovi

        #region IspravnostTeksta Test
        [Test]
        public void IspravnostTekstaLose()
        {
            bool b = pt.IspravnostTeksta();
            Assert.AreEqual(false, b);
        }
        #endregion ZatvarajuciTagovi Test

        #region BodyDeo Testovi
        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>ja</p> </body> </html>")]
        public void BodyDeoPrviIf(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>ja</p><br> </body> </html>")]
        public void BodyDeoDrugiIf(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <ul></ul> </body> </html>")]
        public void BodyDeoTreciIf(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }
        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <ul><li></ul> </body> </html>")]
        public void BodyDeoPrviIfUTrecem(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }
        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <ul><li>sok</li></ul> </body> </html>")]
        public void BodyDeoDrugiIfUTrecem(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(true, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <ul><li>sok</jkhkh></ul> </body> </html>")]
        public void BodyDeoElseUTrecemIf(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }
        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>ja</p> </body> </html>")]
        public void BodyDeoCetvrtiIf(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <p>ja</gsdgsdg> </body> </html>")]
        public void BodyDeoElseUCetvrtomIf(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <ahref></a> </body> </html>")]
        public void BodyDeoPetiIf(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(true, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <ahref></dgsgdsg" +
            "> </body> </html>")]
        public void BodyDeoPetiIfElse(string s)
        {
            bool b = pt.ProveraBody(s);
            Assert.AreEqual(false, b);
        }

        #endregion BodyDeo Testovi
    }
}
