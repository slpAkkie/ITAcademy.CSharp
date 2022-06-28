using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ITacademy.CSharp.GCDTestProject
{
    [TestClass]
    public class GCDAlgorithmsTest
    {
        [TestMethod]
        public void FindGCDEuclid()
        {
            int a = 298467352, b = 569484;
            int expected = 4;
            int actual;
            actual = GCDAlgorithms.GCDAlgorithms.FindGCDEuclid(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
