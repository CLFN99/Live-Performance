using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using Repository.Data;
using System.Collections.Generic;

using Models;

namespace UnitTests
{
    [TestClass]
    public class TestCoalition
    {
        [TestMethod]
        public void TestNewCoaliton()
        {
            DateTime date = DateTime.Now;
            Verkiezingsuitslag v = new Verkiezingsuitslag("TestVerkiezing", date, TestSoort());
            v.ZetelsEnPercentageBerekenen();
            foreach(Partij p in v.Partijen)
            {
                Assert.AreEqual(8, p.NieuweZetels);
                Assert.AreEqual(32, p.Percentage);
            }
        }

        private Verkiezingssoort TestSoort()
        {
            Verkiezingssoort v = new Verkiezingssoort(2, "Test Verkiezing", 25)
            {
                Partijen = TestParties()
            };
            return v;
        }

        private List<Partij> TestParties()
        {
            List<Partij> partijen = new List<Partij>();
            partijen.Add(new Partij("T1", "Test1", 10, 1));
            partijen.Add(new Partij("T3", "Test2", 8, 2));
            partijen.Add(new Partij("T1", "Test3", 6, 3));
            foreach(Partij p in partijen)
            {
                p.Stemmen = 300;
            }
            return partijen;
        }
    }
}
