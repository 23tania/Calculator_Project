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

namespace Calculator_Project
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double value = 0.0;
        String operation = "";
        bool operationPerformed = false;
        bool isResult = false;
        bool isZeroCommaNecessery = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            lengthCheck();
            
            if (isResult && isZeroCommaNecessery==false)
            {
                textBoxResult.Clear();
                isResult = false;
            }

            if (textBoxResult.Text == "No division by 0!")
            {
                textBoxResult.Text = "0";
            }

            if ((textBoxResult.Text == "0")||(operationPerformed))
            {
                textBoxResult.Clear();
            }

            operationPerformed = false;
            textBoxResult.Text = textBoxResult.Text + (string)button.Content;
        }

        private void ButtonOPERATION_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (textBoxResult.Text == "No division by 0!")
            {
                textBoxResult.Text = "0";
            }

            if (divideByZero() /*&& operationPerformed==false*/) // 9/0 + działa
            {
                textBoxResult.Text = "No division by 0!";
                operationPerformed = true;
                operation = "";
            }
            else if (value != 0)
            {
                PerformClickEquals();
                operationPerformed = true;
                operation = (string)button.Content;
                equation.Text = value + " " + operation; //+=
            }
            else
            {
                operation = (string)button.Content;
                value = Double.Parse(textBoxResult.Text);
                equation.Text = value + " " + operation;
                operationPerformed = true;
            }
        }

        private void ButtonEQUALS_Click(object sender, RoutedEventArgs e)
        {
            isResult = true;

            if (divideByZero())
            {
                textBoxResult.Text = "No division by 0!";

            }
            else if (textBoxResult.Text == "No division by 0!")
            {
                textBoxResult.Text = "0";
            }
            else
            {
                double newValue = Double.Parse(textBoxResult.Text);
                equation.Clear();

                if (operation == "+" && operationPerformed == false)
                {
                    textBoxResult.Text = (value + newValue).ToString();
                }
                else if (operation == "-" && operationPerformed == false)
                {
                    textBoxResult.Text = (value - newValue).ToString();
                }
                else if (operation == "x" && operationPerformed == false)
                {
                    textBoxResult.Text = (value * newValue).ToString();
                }
                else if (operation == "/" && operationPerformed == false)
                {
                    textBoxResult.Text = (value / newValue).ToString();
                }

                value = Double.Parse(textBoxResult.Text);
                operation = "";
            }

            //operationPerformed = false;
        }

        private void ButtonPLUSMINUS_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxResult.Text == "No division by 0!")
            {
                textBoxResult.Text = "0";
            }

            double val = Double.Parse(textBoxResult.Text);
            val *= -1;
            textBoxResult.Text = val.ToString();
        }

        private void ButtonCOMMA_Click(object sender, RoutedEventArgs e)
        {
            if (operationPerformed == false)
            {
                if (!textBoxResult.Text.Contains(","))
                {
                   textBoxResult.Text = textBoxResult.Text + ",";
                }
                isZeroCommaNecessery = false;
            }
            else
            {
                textBoxResult.Text = "0,";
                operationPerformed = false;
                isZeroCommaNecessery = true;
            }
            
        }

        private void ButtonPOWER_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxResult.Text == "No division by 0!")
            {
                textBoxResult.Text = "0";
            }

            double val = Double.Parse(textBoxResult.Text);
            val *= val;
            textBoxResult.Text = val.ToString();
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            textBoxResult.Text = "0";
            operation = "";
            equation.Clear();
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            textBoxResult.Text = "0";
        }

        private bool divideByZero()
        {
            if (operation == "/" && textBoxResult.Text == "0")
            {
                operation = "";
                equation.Clear();
                //operationPerformed = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PerformClickEquals()
        {
            if (divideByZero())
            {
                textBoxResult.Text = "No division by 0!";
            }
            else if (textBoxResult.Text == "No division by 0!")
            {
                textBoxResult.Text = "0";
            }
            else
            {
                double newValue = Double.Parse(textBoxResult.Text);
                //equation.Clear();
                if (operation == "+" && operationPerformed == false)
                {
                    textBoxResult.Text = (value + newValue).ToString();
                }
                else if (operation == "-" && operationPerformed == false)
                {
                    textBoxResult.Text = (value - newValue).ToString();
                }
                else if (operation == "x" && operationPerformed == false)
                {
                    textBoxResult.Text = (value * newValue).ToString();
                }
                else if (operation == "/" && operationPerformed == false)
                {
                    textBoxResult.Text = (value / newValue).ToString();
                }

                value = Double.Parse(textBoxResult.Text);
                operation = "";
            }
            operationPerformed = false;

        }

        private void lengthCheck()
        {
            if (textBoxResult.Text.Length > 18)
            {
                textBoxResult.FontSize = 20;
            }

        }
    }
}
