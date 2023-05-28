using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLNS
{
    
    public partial class Main : Form
    {
        public bool isExit = true;
        public event EventHandler Logout;
        public Main()
        {
            InitializeComponent();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
            
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
           
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình", "WARNiNG",MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmax.Visible = false;
            btnmaxed.Location = btnmax.Location;
            btnmaxed.Visible = true;
        }

        private void btnmaxed_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnmaxed.Visible = false;
            btnmax.Visible = true;
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DanhSachNhanSu c = new DanhSachNhanSu();
            c.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            QLNS a = new QLNS();
            a.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LuongNhanVien b = new LuongNhanVien();
            b.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            QuanLyPhongBan d = new QuanLyPhongBan();
            d.Show();   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QuanLyChucVu f = new QuanLyChucVu();
            f.Show();
        }
  

        private void button6_Click(object sender, EventArgs e)
        {
            QuanLyTrinhDoHocVan g = new QuanLyTrinhDoHocVan();
            g.Show();   
        }

      

        private void button7_Click(object sender, EventArgs e)
        {
            if (isExit)
            {
                Application.Exit();

            }
            else
            {
                new Login().Show();
                this.Hide();
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
