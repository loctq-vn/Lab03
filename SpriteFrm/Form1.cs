using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteFrm
{
    public partial class Form1 : Form
    {
        private Bitmap sprite;
        //  Back buffer
        private Bitmap backBuffer;
        private Timer timer;
        public Graphics graphics;
        // Số thự tự của frame (16 frame ảnh)
        private int index;
        //  dòng hiện tại của frame
        private int curFrameColumn;
        // cột hiện tại của frame
        private int curFrameRow;

        private int x,y;



        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // Tạo back buffer
            backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            // Lấy ảnh sprite
            sprite = new Bitmap("Sprite.png");
            index = 0;
            // Khởi tạo một đồng hồ
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 5;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void Render()
        {
            // Lấy đối tượng graphics để vẽ lên back buffer
            Graphics g = Graphics.FromImage(backBuffer);
            g.Clear(Color.White);

            // Xác dịnh số dòng, cột của một frame trên ảnh sprite
            curFrameColumn = index % 5;
            curFrameRow = index / 5;

            // Vẽ lên buffer
            g.DrawImage(sprite, x, 200,
                        new Rectangle(curFrameColumn * 96,
                        curFrameRow * 96, 96, 96), GraphicsUnit.Pixel);
            g.Dispose();
            index++;
            if (index > 25)
            {
                index = 0;

                x += 50;
                if(x>=500)
                {
                    x = 0;
                }
            }
            else
            {
                index++;
            }
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Render();
            // Vẽ lên màn hình
            graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }

    }
}
