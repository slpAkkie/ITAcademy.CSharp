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

using MeasuringDevice;

namespace ITAcademy.CSharp.TestHarness
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

        const string labFolder = @"./";
        MeasureMassDevice device;
        private void createInstance_Click(object sender, RoutedEventArgs e)
        {
            device = new MeasureMassDevice(Units.Metric, labFolder + "LogFile.txt");
            device.StartCollecting();
            unitsBox.Text = device.UnitsToUse.ToString();
            System.Threading.Thread.Sleep(10000);
            mostRecentMeasureBox.Text = device.MostRecentMeasure.ToString();
            loggingFileNameBox.Text = device.GetLoggingFile().Replace(labFolder, "");
            metricValueBox.Text = device.MetricValue().ToString();
            imperialValueBox.Text = device.ImperialValue().ToString();
            rawDataValues.ItemsSource = null;
            rawDataValues.ItemsSource = device.GetRawData();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)  device.LoggingFileName = labFolder + loggingFileNameBox.Text;
            else MessageBox.Show("You must start collecting first.");
        }

        private void dispose_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                device.StopCollecting();
                device.Dispose();
                device = null;
            }
        }
    }
}
