using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITAcademy.CSharp.StressTest
{
    // Enumerations Exercise 1

    /// <summary>
    /// Enumeration of girder material types
    /// </summary>
    public enum Material { StainlessSteel, Aluminium, ReinforcedConcrete, Composite, Titanium }

    /// <summary>
    /// Enumeration of girder cross-sections
    /// </summary>
    public enum CrossSection { IBeam, Box, ZShaped, CShaped }

    /// <summary>
    /// Enumeration of test results
    /// </summary>
    public enum TestResult { Pass, Fail }

    // Structures Exercise 2

    /// <summary>
    /// Structure containing test results
    /// </summary>
    public struct TestCaseResult
    {
        /// <summary>
        /// Test result (enumeration type)
        /// </summary>
        public TestResult Result;

        /// <summary>
        /// Description of reason for failure
        /// </summary>
        public string ReasonForFailure;
    }   

    public class StressTestCase
    {
        public Material GirderMaterial;

        public CrossSection CrossSection;

        public int lengthInMm;

        public int heightInMm;

        public int widthInMm;

        public TestCaseResult testCaseResult;

        public StressTestCase() : this(Material.StainlessSteel, CrossSection.IBeam, 4000, 20, 15) { }

        public StressTestCase(Material girderMaterial, CrossSection crossSection, int lengthInMm, int heightInMm, int widthInMm)
        {
            this.GirderMaterial = girderMaterial;
            this.CrossSection = crossSection;
            this.lengthInMm = lengthInMm;
            this.heightInMm = heightInMm;
            this.widthInMm = widthInMm;
        }

        public void PerformStressTest()
        {
            string[] failureReasons = {
                "Fracture detected",
                "Beam snapped",
                "Beam dimensions wrong",
                "Beam wrapped",
                "Other",
            };

            if (Utility.Rand.Next(10) == 9)
            {
                testCaseResult.Result = TestResult.Fail;
                testCaseResult.ReasonForFailure = failureReasons[Utility.Rand.Next(5)];
            }
            else testCaseResult.Result = TestResult.Pass;
        }

        public TestCaseResult GetStressTestResult()
        {
            return testCaseResult;
        }

        override public string ToString()
        {
            return $"Material: {GirderMaterial}, CrossSection: {CrossSection}, Length: {lengthInMm}mm, Height: {heightInMm}mm, Width: {widthInMm}mm";
        }
    }
}
