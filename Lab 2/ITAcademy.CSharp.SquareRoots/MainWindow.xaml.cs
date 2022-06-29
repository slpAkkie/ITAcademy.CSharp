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

namespace ITacademy.CSharp.SquareRoots
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculate the square root with the Newton method
        /// </summary>
        /// <param name="nubmer"></param>
        /// <returns></returns>
        private decimal newtonMethod(decimal nubmer)
        {
            decimal delta = (decimal)Math.Pow(10, -28),
                guess = nubmer / 2,
                result = ((nubmer / guess) + guess) / 2;

            while (Math.Abs(result - guess) > delta)
            {
                guess = result;
                result = ((nubmer / guess) + guess) / 2;
            }

            return result;
        }

        /// <summary>
        /// Button click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double numberDouble, squareRoot;
            decimal numberDeciaml, newtonRoot;

            // Try to parse user input
            if (!(Double.TryParse(this.inputTextBox.Text, out numberDouble) && Decimal.TryParse(this.inputTextBox.Text, out numberDeciaml)))
            {
                MessageBox.Show("Вы должны ввести число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (numberDouble < 0)
            {
                MessageBox.Show("Вы должны ввести положительное число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Newton method
            newtonRoot = this.newtonMethod(numberDeciaml);

            // .NET Framework method
            squareRoot = Math.Sqrt(numberDouble);

            // Output
            this.frameworkLabel.Content = $"{squareRoot} (Using the .NET Framework)";
            this.newtonLabel.Content = $"{newtonRoot} (Using Newton)";
        }
    }
}
