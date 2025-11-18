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

namespace Bai7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> allSeats;
        private int tien;
        public MainWindow()
        {
            InitializeComponent();
            LoadSeatsToList();
            AddClickEventsToSeats();
            tien = 0;
            txtThanhTien.Text = Convert.ToString(tien);
        }
        private void LoadSeatsToList()
        {
            allSeats = new List<Button>();
            foreach (var child in SeatGrid.Children)
            {
                if (child is Button seatButton)
                {
                    allSeats.Add(seatButton);
                }
            }
        }
        private void AddClickEventsToSeats()
        {
            foreach (Button seat in allSeats)
            {
                seat.Click += Seat_Click;
            }
        }

        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            Button clickedSeat = (Button)sender;

            if (clickedSeat != null)
            {
                if (clickedSeat.Background == Brushes.Blue)
                {
                    clickedSeat.Background = Brushes.White;
                    if (Convert.ToInt32(clickedSeat.Content) <= 5)
                    {
                        tien -= 5000;
                    }
                    else if (Convert.ToInt32(clickedSeat.Content) <= 10)
                    {
                        tien -= 6500;
                    }
                    else
                    {
                        tien -= 8000;
                    }
                }
                else if (clickedSeat.Background == Brushes.White)
                {
                    clickedSeat.Background = Brushes.Blue;
                    if (Convert.ToInt32(clickedSeat.Content) <= 5)
                    {
                        tien += 5000;
                    } else if (Convert.ToInt32(clickedSeat.Content) <= 10)
                    {
                        tien += 6500;
                    } else
                    {
                        tien += 8000;
                    }
                } 
                else
                {
                    MessageBox.Show("Vị trí này đã được bán!");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button seat in allSeats)
            {
                if (seat.Background == Brushes.Blue)
                {
                    seat.Background = Brushes.Yellow;
                }
            }
            txtThanhTien.Text = Convert.ToString(tien);
            tien = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Button seat in allSeats)
            {
                if (seat.Background == Brushes.Blue)
                {
                    seat.Background = Brushes.White;
                }
            }
            tien = 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
