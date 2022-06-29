using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITacademy.CSharp.GreatestCommonDivisor;
using System;

namespace ITAcademy.CSharp.GCDTestProject
{
    [TestClass]
    public class GCDAlgorithmsTest
    {
        [TestMethod]
        public void FindGCDEuclid2Num()
        {
            int a = 298467352, b = 569484;
            int expected = 4;
            int actual;
            actual = GCDAlgorithms.FindGCDEuclid(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclid3Num()
        {
            int a = 7396, b = 1978, c = 1204;
            int expected = 86;
            int actual;
            actual = GCDAlgorithms.FindGCDEuclid(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclid4Num()
        {
            int a = 298467352, b = 569484, c = 1024, d = 109286;
            int expected = 2;
            int actual;
            actual = GCDAlgorithms.FindGCDEuclid(a, b, c, d);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclid5Num()
        {
            int a = 298467352, b = 569484, c = 1024, d = 109286, e = 867584396;
            int expected = 2;
            int actual;
            actual = GCDAlgorithms.FindGCDEuclid(a, b, c, d, e);

            Assert.AreEqual(expected, actual);
        }
    }
}
