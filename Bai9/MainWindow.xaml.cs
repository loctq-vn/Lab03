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

namespace Bai9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class SV 
        {
            public string MSSV { get; set; }
            public string Ten { get; set; }
            public string Nganh { get; set; }
            public string GioiTinh { get; set; }
            public int SoMon { get; set; }
            public SV(string a, string b, string c, string d, int e)
            {
                MSSV = a;
                Ten = b;
                Nganh = c;
                GioiTinh = d;
                SoMon = e;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<ListBoxItem> itemsToMove = new List<ListBoxItem>();
            foreach (ListBoxItem item in lstChuaChon.SelectedItems)
            {
                itemsToMove.Add(item);
            }
            foreach (ListBoxItem item in itemsToMove)
            {
                lstChuaChon.Items.Remove(item);
                lstDaChon.Items.Add(item);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<ListBoxItem> itemsToMove = new List<ListBoxItem>();
            foreach (ListBoxItem item in lstDaChon.SelectedItems)
            {
                itemsToMove.Add(item);
            }
            foreach (ListBoxItem item in itemsToMove)
            {
                lstDaChon.Items.Remove(item);
                lstChuaChon.Items.Add(item);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string a = txtMSSV.Text;
            string b = txtTen.Text;
            string c = cmbNganh.Text;
            string d = (radNam.IsChecked == true) ? "Nam" : "Nữ";
            int ee = 0;
            foreach (ListBoxItem item in lstDaChon.Items)
            {
                ee++;
            }
            if (a=="" || b=="" || c=="" || d== "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            SV sv = new SV(a, b, c, d, ee);
            DS.Items.Add(sv);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            txtMSSV.Text = "";
            txtTen.Text = "";
            cmbNganh.SelectedIndex = 0;
            radNam.IsChecked = true;
            List<ListBoxItem> itemsToMove = new List<ListBoxItem>();
            foreach (ListBoxItem item in lstDaChon.Items)
            {
                itemsToMove.Add(item);
            }
            foreach (ListBoxItem item in itemsToMove)
            {
                lstDaChon.Items.Remove(item);
                lstChuaChon.Items.Add(item);
            }
        }
    }
}
