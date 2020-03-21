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

            
            if (isResult && isZeroCommaNecessery==false)
            {
                wyswietlanieWyniku.Clear();
                isResult = false;
            }

            if (wyswietlanieWyniku.Text == "No division by 0!")
            {
                wyswietlanieWyniku.Text = "0";
            }

            if ((wyswietlanieWyniku.Text == "0")||(operationPerformed))
            {
                wyswietlanieWyniku.Clear();
            }

            operationPerformed = false;
            wyswietlanieWyniku.Text = wyswietlanieWyniku.Text + (string)button.Content;
        }

        private void ButtonPLUSMINUS_Click(object sender, RoutedEventArgs e)
        {

            if (wyswietlanieWyniku.Text == "No division by 0!")
            {
                wyswietlanieWyniku.Text = "0";
            }

            double val = Double.Parse(wyswietlanieWyniku.Text);
            val *= -1;
            wyswietlanieWyniku.Text = val.ToString();
        }

        //przy przecinku dopisuja sie liczby

        private void ButtonCOMMA_Click(object sender, RoutedEventArgs e)
        {
            
            var button = (Button)sender;
            if (operationPerformed == false)
            {
                if (!wyswietlanieWyniku.Text.Contains(","))
                {
                   wyswietlanieWyniku.Text = wyswietlanieWyniku.Text + ",";
                }
                isZeroCommaNecessery = false;
               
            }
            else
            {
                wyswietlanieWyniku.Text = "0,";
                operationPerformed = false;
                isZeroCommaNecessery = true;
            }
            
        }

        private void ButtonEQUALS_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            isResult = true;

            if (divideByZero())
            {
                wyswietlanieWyniku.Text = "No division by 0!";
                
            }
            else if (wyswietlanieWyniku.Text == "No division by 0!")
            {
                wyswietlanieWyniku.Text = "0";
            }
            else
            {
                double nowaWartosc = Double.Parse(wyswietlanieWyniku.Text);
                equation.Clear();
                if (operation == "+" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value + nowaWartosc).ToString();
                }
                else if (operation == "-" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value - nowaWartosc).ToString();
                }
                else if (operation == "x" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value * nowaWartosc).ToString();
                }
                else if (operation == "/" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value / nowaWartosc).ToString();
                }

                value = Double.Parse(wyswietlanieWyniku.Text);
                operation = "";
            }

            //operationPerformed = false;
        }

        private bool divideByZero()
        {
            if (operation == "/" && wyswietlanieWyniku.Text == "0")
            {
                operation = "";
                equation.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ButtonOPERATION_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (wyswietlanieWyniku.Text == "No division by 0!")
            {
                wyswietlanieWyniku.Text = "0";
            }

            if (divideByZero())
            {
                wyswietlanieWyniku.Text = "No division by 0!";
                operation = "";
            }
            else if (value != 0)
            {
                PerformClick();
                operationPerformed = true;
                operation = (string)button.Content;
                equation.Text = value + " " + operation; //+=
                
            }
            else
            {
                operation = (string)button.Content;
                value = Double.Parse(wyswietlanieWyniku.Text);
                equation.Text = value + " " + operation;
                operationPerformed = true;
            }
        }

        private void PerformClick()
        {
            if (divideByZero())
            {
                wyswietlanieWyniku.Text = "No division by 0!";
            }
            else if (wyswietlanieWyniku.Text == "No division by 0!")
            {
                wyswietlanieWyniku.Text = "0";
            }
            else
            {
                double nowaWartosc = Double.Parse(wyswietlanieWyniku.Text);
                //equation.Clear();
                if (operation == "+" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value + nowaWartosc).ToString();
                }
                else if (operation == "-" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value - nowaWartosc).ToString();
                }
                else if (operation == "x" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value * nowaWartosc).ToString();
                }
                else if (operation == "/" && operationPerformed == false)
                {
                    wyswietlanieWyniku.Text = (value / nowaWartosc).ToString();
                }

                value = Double.Parse(wyswietlanieWyniku.Text);
                operation = "";
            }
            operationPerformed = false;
        
    }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            wyswietlanieWyniku.Text = "0";
            operation = "";
            equation.Text = "";
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            wyswietlanieWyniku.Text = "0";
        }


        private void ButtonPOWER_Click(object sender, RoutedEventArgs e)
        {
            if (wyswietlanieWyniku.Text == "No division by 0!")
            {
                wyswietlanieWyniku.Text = "0";
            }

            value = Double.Parse(wyswietlanieWyniku.Text);
            value *= value;
            wyswietlanieWyniku.Text = value.ToString();
        }
    }
}
