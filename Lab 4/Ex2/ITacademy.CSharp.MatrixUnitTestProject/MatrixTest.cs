using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ITacademy.CSharp.MatrixMultiplication;

namespace ITacademy.CSharp.MatrixUnitTestProject
{
    /// <summary>
    ///This is a test class for MatrixTest and is intended
    ///to contain all MatrixTest Unit Tests
    ///</summary>
    [TestClass]
    public class MatrixTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        /// <summary>
        ///A test for MatrixMultiply
        ///</summary>
        [TestMethod]
        public void MatrixMultiplyTest1()
        {
            double[,] matrix1 = { { 4, 6 }, { 2, 2 }, { 5, 1 } };
            double[,] matrix2 = { { 1, 5, 1 }, { 7, 3, 1 } };
            double[,] expected = { { 19, 17 }, { 39, 49 } };
            double[,] actual;
            actual = Matrix.MatrixMultiply(matrix1, matrix2);
            Assert.AreEqual(expected[0, 0], actual[0, 0], 0.000001);
            Assert.AreEqual(expected[0, 1], actual[0, 1], 0.000001);
            Assert.AreEqual(expected[1, 0], actual[1, 0], 0.000001);
            Assert.AreEqual(expected[1, 1], actual[1, 1], 0.000001);
        }

        /// <summary>
        ///A test for MatrixMultiply - checking for negative values
        ///</summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixMultiplyTest2()
        {
            double[,] matrix1 = { { 4, 6 }, { 2, 2 }, { 5, 1 } };
            double[,] matrix2 = { { 1, 5, 1 }, { 7, -3, 1 } };
            double[,] actual;
            actual = Matrix.MatrixMultiply(matrix1, matrix2);
        }

        /// <summary>
        ///A test for MatrixMultiply - checking for incompatible matrices
        ///</summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixMultiplyTest3()
        {
            double[,] matrix1 = { { 4, 6 }, { 2, 2 }, { 5, 1 }, { 4, 4 } };
            double[,] matrix2 = { { 1, 5, 1 }, { 7, 3, 1 } };
            double[,] actual;
            actual = Matrix.MatrixMultiply(matrix1, matrix2);
        }
    }
}
