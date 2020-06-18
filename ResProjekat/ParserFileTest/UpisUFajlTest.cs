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
    public class UpisUFajlTest
    {
        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>tekst_tekst</b> </body> </html>")]
        public void UpisiUFajlDobro(string s)
        {
            bool b;
            UpisUFajl uf = new UpisUFajl();
            b = uf.UpisiUFajl(s);
            Assert.AreEqual(false, b);

        }

        [Test]
        [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>tekst_tekst</b> </body> </html>;proba1")]
        public void UpisiUFajlDobrodrugi(string s)
        {
            bool b;
            UpisUFajl uf = new UpisUFajl();
            b = uf.UpisiUFajl(s);
            Assert.AreEqual(false, b);

        }

        /* [Test]
         [TestCase("<html> <head> <title> naziv </title> </head> <body> <b>tekst</b><p>ja_sam</p> </body> </html>")]
         public void UpisiUFajlDobro2(string s)
         {
             bool b;
             UpisUFajl uf = new UpisUFajl();
             b = uf.UpisiUFajl(s);
             Assert.AreEqual(true, b);

         }*/

        [Test]
        [TestCase("<html> <head> <title> naziv </head> <body> <b>tekst</b> </body> </html>")]
        public void UpisiUFajlLose(string s)
        {
            bool b;
            UpisUFajl uf = new UpisUFajl();
            b = uf.UpisiUFajl(s);
            Assert.AreEqual(false, b);
        }

        [Test]
        [TestCase("<html> <head> <title> naziv <body> <b>tekst</b> </body> </html>")]
        public void UpisiUFajlLose2(string s)
        {
            bool b;
            UpisUFajl uf = new UpisUFajl();
            b = uf.UpisiUFajl(s);
            Assert.AreEqual(false, b);
        }
    }
}
