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

namespace ITAcademy.CSharp.Enumerations
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
        /// Display the enumeration values in ListBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Material[] materialsList = (Material[])System.Enum.GetValues(typeof (Material));
            for (int i = 0; i < materialsList.Length; i++)
            {
                materials.Items.Add(materialsList[i]);
            } 
 
            CrossSection[] crossSectionList = (CrossSection[])System.Enum.GetValues(typeof(CrossSection));
            for (int i = 0; i < crossSectionList.Length; i++)
            {
                crosssections.Items.Add(crossSectionList[i]);
            }
 
            TestResult[] testResultsList = (TestResult[])System.Enum.GetValues(typeof(TestResult));
            for (int i = 0; i < testResultsList.Length; i++)
            {
                testresults.Items.Add(testResultsList[i]);
            }

            materials.SelectedIndex = 0;
            crosssections.SelectedIndex = 0;
            testresults.SelectedIndex = 0;
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (materials.SelectedIndex == -1 || crosssections.SelectedIndex == -1 || testresults.SelectedIndex == -1) return;

            Material selectedMaterial = (Material) materials.SelectedIndex;
            CrossSection selectedCrossSection = (CrossSection) crosssections.SelectedIndex;
            TestResult selectedTestResult = (TestResult) testresults.SelectedIndex;

            char[] symbolsAtTheEnd = { ',', ' ' };

            StringBuilder selectionStringBuilder = new StringBuilder();
            string materialLineLayout = "Material: {0}, ";
            string CrossSectionLineLayout = "Cross-section: {0}, ";
            string TestResultLineLayout = "Result: {0}, ";

            switch ((Material) materials.SelectedIndex)
            {
                case Material.StainlessSteel: selectionStringBuilder.Append(String.Format(materialLineLayout, "Stainless Steel")); break;
                case Material.Aluminium: selectionStringBuilder.Append(String.Format(materialLineLayout, "Aluminium")); break;
                case Material.ReinforcedConcrete: selectionStringBuilder.Append(String.Format(materialLineLayout, "Rainforced Concrete")); break;
                case Material.Composite: selectionStringBuilder.Append(String.Format(materialLineLayout, "Composite")); break;
                case Material.Titanium: selectionStringBuilder.Append(String.Format(materialLineLayout, "Titanium")); break;
            }

            switch ((CrossSection) crosssections.SelectedIndex)
            {
                case CrossSection.IBeam: selectionStringBuilder.Append(String.Format(CrossSectionLineLayout, "I-Beam")); break;
                case CrossSection.Box: selectionStringBuilder.Append(String.Format(CrossSectionLineLayout, "Box")); break;
                case CrossSection.ZShaped: selectionStringBuilder.Append(String.Format(CrossSectionLineLayout, "Z-Shaped")); break;
                case CrossSection.CShaped: selectionStringBuilder.Append(String.Format(CrossSectionLineLayout, "C-Shaped")); break;
            }

            switch ((TestResult) testresults.SelectedIndex)
            {
                case TestResult.Pass: selectionStringBuilder.Append(String.Format(TestResultLineLayout, "Pass")); break;
                case TestResult.Fail: selectionStringBuilder.Append(String.Format(TestResultLineLayout, "Fail")); break;
            }

            testDetails.Content = selectionStringBuilder.ToString().TrimEnd(symbolsAtTheEnd);
        }
    }
}
