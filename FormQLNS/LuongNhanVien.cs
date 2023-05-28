using FormQLNS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FormQLNS
{
    public partial class LuongNhanVien : Form
    {
        NhanVienContextDB context = new NhanVienContextDB();
        public LuongNhanVien()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LuongNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                NhanVienContextDB context = new NhanVienContextDB();
                List<Luong> listLuong = context.Luongs.ToList();
                BindGrid(listLuong);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<Luong> listLuong)
        {
            dgvLuong.Rows.Clear();
            foreach (var item in listLuong)
            {
                int index = dgvLuong.Rows.Add();
                dgvLuong.Rows[index].Cells[0].Value = item.MaLuong;
                dgvLuong.Rows[index].Cells[1].Value = item.NhanVien.TenNV;
                dgvLuong.Rows[index].Cells[2].Value = item.LuongCB;
                dgvLuong.Rows[index].Cells[3].Value = item.HeSoLuong;
                dgvLuong.Rows[index].Cells[4].Value = item.HeSoPhuCap;
                dgvLuong.Rows[index].Cells[5].Value = item.LuongChinhThuc;


            }
        }
        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgvLuong.Rows[e.RowIndex];
            txtMaLuong.Text = row.Cells["colMaLuong"].Value.ToString();
            txtMaNV.Text = row.Cells["colMaNV"].Value.ToString();
            txtLCB.Text = row.Cells["colLCB"].Value.ToString();
            txtHeSoLuong.Text = row.Cells["colHSL"].Value.ToString();
            txtPhuCap.Text = row.Cells["colHSPC"].Value.ToString();
            
           
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            Luong l = new Luong()
            {
                MaLuong = txtMaLuong.Text,
                MaNV = txtMaNV.Text,

                LuongCB = Int32.Parse(txtLCB.Text),
                HeSoLuong = Int32.Parse(txtHeSoLuong.Text),
                HeSoPhuCap = Int32.Parse(txtPhuCap.Text),
                LuongChinhThuc = (Int32.Parse(txtLCB.Text) * Int32.Parse(txtHeSoLuong.Text)) + Int32.Parse(txtPhuCap.Text),

            };
            context.Luongs.Add(l);
            context.SaveChanges();
            List<Luong> lnv = context.Luongs.ToList();
            BindGrid(lnv);
            MessageBox.Show("Thêm Lương nhân viên thành công ", "THÔNG BÁO");
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
          
            Luong dbUpdate = context.Luongs.FirstOrDefault(p => p.NhanVien.TenNV == txtMaNV.Text);
            if (dbUpdate != null)
            {
                dbUpdate.MaLuong = txtMaLuong.Text;
                dbUpdate.NhanVien.TenNV = txtMaNV.Text;
                dbUpdate.LuongCB = Convert.ToInt32(txtLCB.Text);
                dbUpdate.HeSoLuong = Convert.ToInt32(txtHeSoLuong.Text);
                dbUpdate.HeSoPhuCap = Convert.ToInt32(txtPhuCap.Text);
            
                context.SaveChanges();
                List<Luong> lnv = context.Luongs.ToList();
                BindGrid(lnv);
                MessageBox.Show("Sửa thông tin nhân viên thành công ", "THÔNG BÁO");
            } 
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần sửa  ", "THÔNG BÁO");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string maLuong =txtMaLuong.Text;
            Luong checkDelete = context.Luongs.FirstOrDefault(p => p.MaLuong == maLuong);
            //Luong checkDelete = context.Luongs.FirstOrDefault(p => p.MaNV == txtMaNV.Text);
            if (checkDelete != null)
            {
                DialogResult yesno = MessageBox.Show("Bạn có muốn xóa ?", "THÔNG BÁO", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    context.Luongs.Remove(checkDelete);
                    context.SaveChanges();
                    List<Luong> lnv = context.Luongs.ToList();
                    BindGrid(lnv);
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK);
                }

            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvLuong, saveFileDialog1.FileName);
            }
        }

        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý nhan vien";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }


    }
}
