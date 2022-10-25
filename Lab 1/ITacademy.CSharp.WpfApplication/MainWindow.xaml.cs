using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITAcademy.CSharp.WpfApplication
{
    /// <summary>
    /// WPF application to read and format data
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor for MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// After the Window has loaded, read data from the standard input.
        /// Format each line and display the results in the
        /// formattedText TextBlock control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string line;

            while ((line = Console.ReadLine()) != null)
            {
                line = "x:" + line.Replace(",", " y:") + "\n";

                this.formattedText.Text += line;
            }
        }

        /// <summary>
        /// Read a line of data entered by the user.
        /// Format the data and display the results in the
        /// formattedText TextBlock control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            string line = "x:" + this.testInput.Text.Replace(",", " y:");

            this.formattedText.Text = line;
        }
    }
}
