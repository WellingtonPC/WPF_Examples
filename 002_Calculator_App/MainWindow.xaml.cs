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

namespace _002_Calculator_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click +=AcButton_Click;
            negativeButton.Click +=NegativeButton_Click;
            percentageButton.Click +=PercentageButton_Click;
            equalButton.Click +=EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SiimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SiimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SiimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SiimpleMath.Devide(lastNumber, newNumber);
                        break;

                }
                resultLabel.Content = result.ToString();
            }


        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = 0;
            }

            if (sender == timesButton) selectedOperator = SelectedOperator.Multiplication;
            if (sender == plusButton) selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton) selectedOperator = SelectedOperator.Substraction;
            if (sender == divisionButton) selectedOperator = SelectedOperator.Division;

        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        public enum SelectedOperator
        {
            Addition,
            Substraction,
            Multiplication,
            Division
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                ///Do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        public class SiimpleMath
        {
            public static double Add(double number1, double number2)
            {
                return number1 + number2;
            }

            public static double Subtraction(double number1, double number2)
            {
                return number1 - number2;
            }

            public static double Multiply(double number1, double number2)
            {
                return number1 * number2;
            }

            public static double Devide(double number1, double number2)
            {
                if (number2 == 0)
                {
                    MessageBox.Show("Divison by zero is not allowed!", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return number1 / number2;
            }



        }


    }

}
