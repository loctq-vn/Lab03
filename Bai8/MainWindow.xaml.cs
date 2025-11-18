using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Bai8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tongTien;
        public class Account
        {
            public int STT { get; set; }
            public string MaTaiKhoan { get; set; }
            public string TenKhachHang { get; set; }
            public string DiaChi { get; set; }
            public int SoTien { get; set; }
            public Account(int a, string b, string c, string d, string e) {
                STT = a;
                MaTaiKhoan = b;
                TenKhachHang = c;
                DiaChi = d;
                SoTien = Convert.ToInt32(e);
            }
        }
        private int soThuTu;
        public MainWindow()
        {
            InitializeComponent();
            soThuTu = 0;
            tongTien = 0;
        }

        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

        private bool IsAlphabetic(string text)
        {
            foreach(char c in text)
            {
                if (char.IsDigit(c)) return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtSTK.Text=="" || txtTEN.Text=="" || txtDIACHI.Text=="" || txtSOTIEN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (!IsNumeric(txtSTK.Text))
            {
                MessageBox.Show("Số tài khoản phải là chữ số!");
                return;
            }
            if (!IsAlphabetic(txtTEN.Text))
            {
                MessageBox.Show("Tên khách hàng phải là chữ cái!");
                return;
            }
            if (!IsNumeric(txtSOTIEN.Text))
            {
                MessageBox.Show("Số tiền phải là chữ số!");
                return;
            }
            foreach (Account account in List.Items)
            {
                if (account.MaTaiKhoan == txtSTK.Text)
                {
                    tongTien -= account.SoTien;
                    tongTien += Convert.ToInt32(txtSOTIEN.Text);
                    txtTongTien.Text = Convert.ToString(tongTien);
                    account.TenKhachHang = txtTEN.Text;
                    account.DiaChi = txtDIACHI.Text;
                    account.SoTien = Convert.ToInt32(txtSOTIEN.Text);
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    txtSTK.Text = "";
                    txtTEN.Text = "";
                    txtDIACHI.Text = "";
                    txtSOTIEN.Text = "";
                    List.Items.Refresh();
                    return;
                }
            }
            soThuTu += 1;
            List.Items.Add(new Account(soThuTu, txtSTK.Text, txtTEN.Text, txtDIACHI.Text, txtSOTIEN.Text));
            MessageBox.Show("Thêm mới dữ liệu thành công!");
            tongTien += Convert.ToInt32(txtSOTIEN.Text);
            txtTongTien.Text = Convert.ToString(tongTien);
            txtSTK.Text = "";
            txtTEN.Text = "";
            txtDIACHI.Text = "";
            txtSOTIEN.Text = "";
            List.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtSTK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (!IsNumeric(txtSTK.Text))
            {
                MessageBox.Show("Số tài khoản phải là chữ số!");
                return;
            }

            bool check = false;
            foreach (Account account in List.Items)
            {
                if (account.MaTaiKhoan == txtSTK.Text)
                {
                    tongTien -= account.SoTien;
                    txtTongTien.Text = Convert.ToString(tongTien);
                    List.Items.Remove(account);
                    MessageBox.Show("Xóa tài khoản thành công");
                    check = true;
                    soThuTu--;
                    txtSTK.Text = "";
                    txtTEN.Text = "";
                    txtDIACHI.Text = "";
                    txtSOTIEN.Text = "";
                    break;
                }
            }
            if (check)
            {
                int t = 1;
                foreach (Account account in List.Items)
                {
                    account.STT = t;
                    t++;
                }
                List.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa");
            }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null) return;
            Account account = (Account)List.SelectedItem;
            txtSTK.Text = account.MaTaiKhoan;
            txtTEN.Text = account.TenKhachHang;
            txtDIACHI.Text = account.DiaChi;
            txtSOTIEN.Text = Convert.ToString(account.SoTien);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
