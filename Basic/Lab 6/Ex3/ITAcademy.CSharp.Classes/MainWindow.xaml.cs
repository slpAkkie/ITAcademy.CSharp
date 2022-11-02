using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITAcademy.CSharp.StressTest;

namespace ITAcademy.CSharp.Classes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Execute some stress tests on girders and show the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doTests_Click(object sender, RoutedEventArgs e)
        {
            testList.Items.Clear();
            resultList.Items.Clear();

            StressTestCase[] stressTestCases = CreateTestCases();

            foreach (StressTestCase testCase in stressTestCases)
            {
                testCase.PerformStressTest();
                testList.Items.Add(testCase);
                TestCaseResult testCaseResult = testCase.GetStressTestResult();
                resultList.Items.Add($"{testCaseResult.Result}{(testCaseResult.Result == TestResult.Fail ? testCaseResult.ReasonForFailure : "")}");
            }
        }

        private StressTestCase[] CreateTestCases()
        {
            StressTestCase[] stressTestCase = {
                new StressTestCase(),
                new StressTestCase(Material.Composite, CrossSection.CShaped, 3500, 100, 20),
                new StressTestCase(),
                new StressTestCase(Material.Aluminium, CrossSection.Box, 3500, 100, 20),
                new StressTestCase(),
                new StressTestCase(Material.Titanium, CrossSection.CShaped, 3600, 150, 20),
                new StressTestCase(Material.Titanium, CrossSection.ZShaped, 4000, 80, 20),
                new StressTestCase(Material.Titanium, CrossSection.Box, 5000, 90, 20),
                new StressTestCase(),
                new StressTestCase(Material.StainlessSteel, CrossSection.Box, 3500, 100, 20),
            };
            
            return stressTestCase;
        }
    }
}
