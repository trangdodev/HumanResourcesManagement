using FormQLNS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FormQLNS
{
    public partial class QuanLyPhongBan : Form
    {
        NhanVienContextDB context = new NhanVienContextDB();
        public QuanLyPhongBan()
        {
            InitializeComponent();
        }
        private int DemNhanVien(string TenPB)
        {
            int num = 0;
            var listNV = context.NhanViens.Where(p => p.PhongBan == TenPB).ToList();
            num = listNV.Count;     
            return num;
        }

        private void BindGrid(List<PhongBan> listPhongBan)
        {
            dgvPhongBan.Rows.Clear();
            foreach (var item in listPhongBan)
            {
                int index = dgvPhongBan.Rows.Add();
                dgvPhongBan.Rows[index].Cells[0].Value = item.MaPB;
                dgvPhongBan.Rows[index].Cells[1].Value = item.TenPB;
                dgvPhongBan.Rows[index].Cells[2].Value = DemNhanVien(item.TenPB);

            }
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow row = dgvPhongBan.Rows[e.RowIndex];
            txtMaPhongBan.Text = row.Cells["Column1"].Value.ToString();
          
            txtTenPhongBan.Text = row.Cells["Column2"].Value.ToString();

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            PhongBan pb = new PhongBan();
            if (txtMaPhongBan.Text == "" || txtTenPhongBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                pb.MaPB = Int32.Parse(txtMaPhongBan.Text);
                pb.TenPB = txtTenPhongBan.Text;
            }

            PhongBan dbName = context.PhongBans.FirstOrDefault(p => p.TenPB == txtMaPhongBan.Text);
            if (dbName != null)
            {
                MessageBox.Show("Không thể thêm phòng ban đã có trong danh sách ! ", "THÔNG BÁO");

                return;
            }
            else
            {
                context.PhongBans.Add(pb);
                context.SaveChanges();
                List<PhongBan> ls = context.PhongBans.ToList();
                BindGrid(ls);
                MessageBox.Show("Thêm phòng ban thành công ", "THÔNG BÁO");


            }
        }

        private void QuanLyPhongBan_Load(object sender, EventArgs e)
        {
            try
            {

                List<PhongBan> listPB = context.PhongBans.ToList();
                List<NhanVien> listNV = context.NhanViens.ToList();
                BindGrid(listPB);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maPhongBan = Int32.Parse(txtMaPhongBan.Text);
            PhongBan checkDelete = context.PhongBans.FirstOrDefault(p => p.MaPB == maPhongBan);
            if (checkDelete != null)
            {
                DialogResult yesno = MessageBox.Show("Bạn có muốn xóa ?", "THÔNG BÁO", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    context.PhongBans.Remove(checkDelete);
                    context.SaveChanges();
                    List<PhongBan> listPhongBan = context.PhongBans.ToList();
                    BindGrid(listPhongBan);
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK);
                }

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvPhongBan, saveFileDialog1.FileName);
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

