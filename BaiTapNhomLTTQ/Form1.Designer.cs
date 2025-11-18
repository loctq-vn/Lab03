using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTapNhomLTTQ
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dọn dẹp các tài nguyên đã quản lý (managed resources)
                if (components != null)
                {
                    components.Dispose();
                }

                // Dọn dẹp sprite và timer
                if (sprite != null)
                {
                    sprite.Dispose();
                }
                if (timer != null)
                {
                    timer.Tick -= new EventHandler(timer_Tick); // Hủy đăng ký sự kiện
                    timer.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private Bitmap sprite;
        private Timer timer;
        // Số thứ tự của frame (0-25)
        private int index;
        // Dòng và cột hiện tại của frame (sẽ được tính toán trong OnPaint)
        private int curFrameColumn;
        private int curFrameRow;

        // ===================================================================
        // ▼▼▼ HÀM KHỞI TẠO (CONSTRUCTOR) BỊ THIẾU ĐÃ ĐƯỢC THÊM LẠI ▼▼▼
        // ===================================================================
        public SpriteFrm()
        {
            InitializeComponent(); // Rất quan trọng, gọi hàm trong file .Designer.cs

            // Set double buffering cho hiệu suất tốt hơn và giảm nháy hình
            // Thêm UserPaint để báo rằng chúng ta sẽ tự vẽ
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint, true);

            // Lấy ảnh sprite
            try
            {
                // Đảm bảo file "Sprite.png" nằm trong thư mục Debug
                // (Properties -> Copy to Output Directory = Copy if newer)
                sprite = new Bitmap("Sprite.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh sprite: " + ex.Message);
            }

            index = 0;

            // Khởi tạo một đồng hồ
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 60; // 60 milliseconds ≈ 16.7 FPS
            timer.Tick += new EventHandler(timer_Tick);
        }
        // ===================================================================
        // ▲▲▲ KẾT THÚC HÀM KHỞI TẠO ▲▲▲
        // ===================================================================


        // Ghi đè phương thức OnPaint để vẽ
        protected override void OnPaint(PaintEventArgs e)
        {
            // Gọi phương thức base
            base.OnPaint(e);

            // Lấy đối tượng Graphics từ sự kiện
            // Đây là bề mặt vẽ đã được double-buffered
            Graphics g = e.Graphics;

            // Xóa màn hình
            g.Clear(Color.White);

            if (sprite != null)
            {
                // Xác định số dòng, cột của một frame trên ảnh sprite
                curFrameColumn = index % 5;
                curFrameRow = index / 5;

                // Vẽ lên bề mặt của e.Graphics
                // (Giả định mỗi frame là 64x64 pixel)
                g.DrawImage(sprite, 120, 120,
                            new Rectangle(curFrameColumn * 64,
                            curFrameRow * 64, 64, 64), GraphicsUnit.Pixel);
            }

            // Không cần g.Dispose() vì đối tượng 'e.Graphics'
            // được quản lý bởi hệ thống.
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            // Cập nhật logic frame
            index++;
            if (index > 25) // Lặp lại animation từ frame 0 đến 25 (tổng 26 frames)
                index = 0;

            // Yêu cầu Form vẽ lại
            // Hệ thống sẽ tự động gọi phương thức OnPaint
            this.Invalidate();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Sprite Animation";
            this.ResumeLayout(false);

        }

        #endregion
    }
}