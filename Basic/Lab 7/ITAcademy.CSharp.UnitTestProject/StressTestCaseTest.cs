﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITAcademy.CSharp.StressTest;
using System;

namespace ITAcademy.CSharp.UnitTestProject
{
    /// <summary>
    ///This is a test class for StressTestCaseTest and is intended
    ///to contain all StressTestCaseTest Unit Tests
    ///</summary>
    [TestClass]
    public class StressTestCaseTest
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
        ///A test for StressTestCase parameterized Constructor
        ///</summary>
        [TestMethod]
        public void StressTestCaseConstructorTest()
        {
            Material girderMaterial = Material.Composite;
            CrossSection crossSection = CrossSection.CShaped;
            int lengthInMm = 5000;
            int heightInMm = 32;
            int widthInMm = 18;
            StressTestCase target = new StressTestCase(girderMaterial, crossSection, lengthInMm, heightInMm, widthInMm);
            //Assert.AreEqual(Material.Composite, target.girderMaterial);
            //Assert.AreEqual(CrossSection.CShaped, target.crossSection);
            //Assert.AreEqual(5000, target.lengthInMm);
            //Assert.AreEqual(32, target.heightInMm);
            //Assert.AreEqual(18, target.widthInMm);
        }

        /// <summary>
        ///A test for StressTestCase default Constructor
        ///</summary>
        [TestMethod]
        public void StressTestCaseConstructorTest1()
        {
            StressTestCase target = new StressTestCase();
            //Assert.AreEqual(Material.StainlessSteel, target.girderMaterial);
            //Assert.AreEqual(CrossSection.IBeam, target.crossSection);
            //Assert.AreEqual(4000, target.lengthInMm);
            //Assert.AreEqual(20, target.heightInMm);
            //Assert.AreEqual(15, target.widthInMm);
        }

        /// <summary>
        ///A test for GetStressTestResult
        ///</summary>
        [TestMethod]
        public void GetStressTestResultTest()
        {
            StressTestCase target = new StressTestCase();
            Assert.IsFalse(target.GetStressTestResult().HasValue);
            target.PerformStressTest();
            Assert.IsTrue(target.GetStressTestResult().HasValue);
        }

        /// <summary>
        ///A test for PerformStressTest
        ///</summary>
        [TestMethod]
        public void PerformStressTestTest()
        {
            for (int i = 0; i < 30; i++)
            {
                StressTestCase target = new StressTestCase();
                target.PerformStressTest();
                Assert.IsTrue(target.GetStressTestResult().HasValue);
                TestCaseResult actual = target.GetStressTestResult().Value;
                if (actual.result == StressTest.TestResult.Fail)
                    Assert.IsTrue(actual.reasonForFailure.Length > 0);
                else
                    Assert.IsTrue(actual.reasonForFailure == null);
            }
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod]
        public void ToStringTest()
        {
            StressTestCase target = new StressTestCase();
            string expected = "Material: StainlessSteel, CrossSection: IBeam, Length: 4000mm, Height: 20mm, Width: 15mm, No Stress Test Performed";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
