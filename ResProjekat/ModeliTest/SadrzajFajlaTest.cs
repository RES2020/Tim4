using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeli;
using NUnit.Framework;

namespace ModeliTest
{
    [TestFixture]
    class SadrzajFajlaTest
    {
        [Test]
        [TestCase(1,"sadrzajF","sadrzaj")]

        public void DobarKonstruktor(int id,string sadrzajF,string sadrzaj)
        {
            SadrzajFajla sf = new SadrzajFajla(id, sadrzajF, sadrzaj);
            Assert.AreEqual(sf.Idfajla, id);
            Assert.AreEqual(sf.IdSadrzaja, sadrzajF);
            Assert.AreEqual(sf.Sadrzaj, sadrzaj);
        }

        [Test]
        [TestCase(-1,"sadrzajF","sadrzaj")]

        public void LosKontruktor(int id,string sadrzajF,string sadrzaj)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SadrzajFajla sf = new SadrzajFajla(id, sadrzajF, sadrzaj);
            }
             );
        }

    }
}
