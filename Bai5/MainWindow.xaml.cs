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

namespace Bai5
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num1 = Convert.ToDouble(Num1.Text);
            double num2 = Convert.ToDouble(Num2.Text);
            double ans = num1 + num2;
            Answer.Text = Convert.ToString(ans);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double num1 = Convert.ToDouble(Num1.Text);
            double num2 = Convert.ToDouble(Num2.Text);
            double ans = num1 - num2;
            Answer.Text = Convert.ToString(ans);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double num1 = Convert.ToDouble(Num1.Text);
            double num2 = Convert.ToDouble(Num2.Text);
            double ans = num1 * num2;
            Answer.Text = Convert.ToString(ans);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            double num1 = Convert.ToDouble(Num1.Text);
            double num2 = Convert.ToDouble(Num2.Text);
            double ans = num1 / num2;
            Answer.Text = Convert.ToString(ans);
        }

        private void Num1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Num1.Text!="" && !double.TryParse(Num1.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập các số hợp lệ");
                Num1.Clear();
            }
        }

        private void Num2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Num2.Text != "" && !double.TryParse(Num2.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập các số hợp lệ");
                Num2.Clear();
            }
        }
    }
}
