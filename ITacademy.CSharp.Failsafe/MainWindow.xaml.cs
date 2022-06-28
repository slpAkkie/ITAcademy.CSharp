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
using ITacademy.CSharp.SwitchDevice;

namespace ITacademy.CSharp.Failsafe
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
        /// Initiate the reactor shutdown using a Switch object
        /// Record details of shutdown status in a TextBlock - recording all exceptions thrown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.textBlock1.Text = "Initiating test sequence: " + DateTime.Now.ToLongTimeString();
            Switch sd = new Switch();

            try
            {
                if (sd.DisconnectPowerGenerator() == SuccessFailureResult.Fail)
                {
                    this.textBlock1.Text += "\nStep 1: Failed to disconnect power generation system";
                }
                else
                {
                    this.textBlock1.Text += "\nStep 1: Successfully disconnected power generation system";
                }
            }
            catch (PowerGeneratorCommsException ex)
            {
                this.textBlock1.Text += $"\n*** Exception in step 1: {ex.Message}";
            }


            try
            {
                switch (sd.VerifyPrimaryCoolantSystem())
                {
                    case CoolantSystemStatus.OK:
                        this.textBlock1.Text += "\nStep 2: Primary coolant system OK";
                        break;
                    case CoolantSystemStatus.Check:
                        this.textBlock1.Text += "\nStep 2: Primary coolant system requires manual check";
                        break;
                    case CoolantSystemStatus.Fail:
                        this.textBlock1.Text += "\nStep 2: Problem reported with primary coolant system";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex is CoreTemperatureReadException || ex is CoolantPressureReadException)
                    this.textBlock1.Text += $"\n*** Exception in step 2: {ex.Message}";
            }


            try
            {
                switch (sd.VerifyBackupCoolantSystem())
                {
                    case CoolantSystemStatus.OK:
                        this.textBlock1.Text += "\nStep 3: Backup coolant system OK";
                        break;
                    case CoolantSystemStatus.Check:
                        this.textBlock1.Text += "\nStep 3: Backup coolant system requires manual check";
                        break;
                    case CoolantSystemStatus.Fail:
                        this.textBlock1.Text += "\nStep 3: Backup reported with primary coolant system";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex is CoreTemperatureReadException || ex is CoolantPressureReadException)
                    this.textBlock1.Text += $"\n*** Exception in step 3: {ex.Message}";
            }


            try
            {
                this.textBlock1.Text += "\nStep 4: Core temperature before shutdown: " + sd.GetCoreTemperature();
            }
            catch (CoreTemperatureReadException ex)
            {
                this.textBlock1.Text += $"\n*** Exception in step 4: {ex.Message}";
            }


            try
            {
                if (sd.InsertRodCluster() == SuccessFailureResult.Success)
                {
                    this.textBlock1.Text += "\nStep 5: Control rods successfully inserted";
                }
                else
                {
                    this.textBlock1.Text += "\nStep 5: Control rod insertion failed";
                }
            }
            catch (RodClusterReleaseException ex)
            {
                this.textBlock1.Text += $"\n*** Exception in step 5: {ex.Message}";
            }

            try
            {
                this.textBlock1.Text += "\nStep 6: Core temperature after shutdown: " + sd.GetCoreTemperature();
            }
            catch (CoreTemperatureReadException ex)
            {
                this.textBlock1.Text += $"\n*** Exception in step 6: {ex.Message}";
            }


            try
            {
                this.textBlock1.Text += "\nStep 7: Core radiation level after shutdown: " + sd.GetRadiationLevel();
            }
            catch (CoreRadiationLevelReadException ex)
            {
                this.textBlock1.Text += $"\n*** Exception in step 7: {ex.Message}";
            }


            try
            {
                sd.SignalShutdownComplete();
                this.textBlock1.Text += "\nStep 8: Broadcasting shutdown complete message";


                this.textBlock1.Text += "\nTest sequence complete: " + DateTime.Now.ToLongTimeString();
            }
            catch (SignallingException ex)
            {
                this.textBlock1.Text += $"\n*** Exception in step 8: {ex.Message}";
            }
        }
    }
}
