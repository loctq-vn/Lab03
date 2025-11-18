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

namespace Bai6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double temp;

        public MainWindow()
        {
            InitializeComponent();
            temp = 0;
        }

        private void Calculating()
        {
            switch (Label2.Text)
            {
                case "+":
                    {
                        if (Label1.Text == "") temp = temp;
                        else temp = temp + Convert.ToDouble(Label1.Text);
                        Label1.Text = Convert.ToString(temp);
                        break;
                    }
                case "-":
                    {
                        if (Label1.Text == "") temp = temp;
                        else temp = temp - Convert.ToDouble(Label1.Text);
                        Label1.Text = Convert.ToString(temp);
                        break;
                    }
                case "x":
                    {
                        if (Label1.Text == "") temp = temp;
                        else temp = temp * Convert.ToDouble(Label1.Text);
                        Label1.Text = Convert.ToString(temp);
                        break;
                    }
                case "/":
                    {
                        if (Label1.Text == "") temp = temp;
                        else temp = temp / Convert.ToDouble(Label1.Text);
                        Label1.Text = Convert.ToString(temp);
                        break;
                    }
                default:
                    {
                        if (Label1.Text == "") temp = 0;
                        else  temp = Convert.ToDouble(Label1.Text);
                        Label1.Text = Convert.ToString(temp);
                        break;
                    }
            }
            Label2.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text.Substring(0, Label1.Text.Length-1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Label1.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            temp = 0;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "7";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "8";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "9";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Calculating();
            Label1.Text = "";
            Label2.Text = "/";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Label1.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(Label1.Text)));
            Label2.Text = "";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "4";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "5";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "6";
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Calculating();
            Label1.Text = "";
            Label2.Text = "x";
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Label1.Text = Convert.ToString(Convert.ToDouble(Label1.Text)/100);
            Label2.Text = "";
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "1";
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "2";
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "3";
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Calculating();
            Label1.Text = "";
            Label2.Text = "-";
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Label1.Text = Convert.ToString(1/Convert.ToDouble(Label1.Text));
            Label2.Text = "";
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + "0";
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            if (Label1.Text[0] == '-')
            {
                Label1.Text = Label1.Text.Substring(1, Label1.Text.Length - 1);
            }
            else
            {
                Label1.Text = "-" + Label1.Text;
            }
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Label1.Text = Label1.Text + ".";
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            Calculating();
            Label1.Text = "";
            Label2.Text = "+";
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Calculating();
        }
    }
}