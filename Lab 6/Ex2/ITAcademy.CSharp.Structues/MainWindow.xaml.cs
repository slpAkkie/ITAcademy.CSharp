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

namespace ITAcademy.CSharp.Structues
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO - Declare a TestCaseResult array
        TestCaseResult[] testCaseResults;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create some sample Test Case Results and display
        /// in a ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        private void RunTests_Click(object sender, RoutedEventArgs e)
        {
            reasonsList.Items.Clear();
            testCaseResults = new TestCaseResult[10];

            for (int i = 0; i < testCaseResults.Length; i++)
                testCaseResults[i] = TestManager.GenerateResult();

            int passCount = 0, failCount = 0;

            for (int i = 0; i < testCaseResults.Length; i++)
                if (testCaseResults[i].Result == TestResult.Pass)
                    passCount++;
                else
                {
                    failCount++;
                    reasonsList.Items.Add(testCaseResults[i].ReasonForFailure);
                }

            successLabel.Content = $"Successes: {passCount}";
            failureLabel.Content = $"Failures: {failCount}";
        }
    }
}
