using System;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int height = Convert.ToInt32(PaintBoard.ActualHeight);
            int width = Convert.ToInt32(PaintBoard.ActualWidth);
            int h = rand.Next(height);
            int w = rand.Next(width-60);
            Canvas.SetBottom(tb, h);
            Canvas.SetLeft(tb, w);
            byte r = (byte)rand.Next(256);
            byte g = (byte)rand.Next(256);
            byte b = (byte)rand.Next(256);
            Brush brush = new SolidColorBrush(Color.FromRgb(r, g, b));
            tb.Foreground = brush;
        }
    }
}