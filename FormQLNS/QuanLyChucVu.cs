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

namespace FormQLNS
{
    public partial class QuanLyChucVu : Form
    {
        NhanVienContextDB context = new NhanVienContextDB();
        public QuanLyChucVu()
        {
            InitializeComponent();
        }

        private void BindGrid(List<ChucVu> listChucVu)
        {
            dgvChucVu.Rows.Clear();
            foreach (var item in listChucVu)
            {
                int index = dgvChucVu.Rows.Add();
                dgvChucVu.Rows[index].Cells[0].Value = item.MaCV;
                dgvChucVu.Rows[index].Cells[1].Value = item.TenCV;
                dgvChucVu.Rows[index].Cells[2].Value = DemNhanVien(item.TenCV);

            }
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow row = dgvChucVu.Rows[e.RowIndex];
            txtMaChucVu.Text = row.Cells["Column1"].Value.ToString();
            txtTenChucVu.Text = row.Cells["Column2"].Value.ToString();

        }
        private void btnADD_Click(object sender, EventArgs e)
        {
            ChucVu cv = new ChucVu();
            if (txtTenChucVu.Text == "" || txtMaChucVu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                cv.MaCV = Int32.Parse(txtMaChucVu.Text);
                cv.TenCV = txtTenChucVu.Text;
            }

            ChucVu dbName = context.ChucVus.FirstOrDefault(p => p.TenCV == txtMaChucVu.Text);
            if (dbName != null)
            {
                MessageBox.Show("Không thể thêm phòng ban đã có trong danh sách ! ", "THÔNG BÁO");

                return;
            }
            else
            {
                context.ChucVus.Add(cv);
                context.SaveChanges();
                List<ChucVu> ls = context.ChucVus.ToList();
                BindGrid(ls);
                MessageBox.Show("Thêm phòng ban thành công ", "THÔNG BÁO");


            }
        }

        private void QuanLyChucVu_Load(object sender, EventArgs e)
        {
            try
            {

                List<ChucVu> listChucVu = context.ChucVus.ToList();
                List<NhanVien> listNV = context.NhanViens.ToList();
                BindGrid(listChucVu);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private int DemNhanVien(string TenChucV)
        {
            int num = 0;
            var listNV = context.NhanViens.Where(p => p.ChucVu == TenChucV).ToList();
            num = listNV.Count;
            return num;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maChucVu = Int32.Parse(txtMaChucVu.Text);
            ChucVu checkDelete = context.ChucVus.FirstOrDefault(p => p.MaCV == maChucVu); ;
            if (checkDelete != null)
            {
                DialogResult yesno = MessageBox.Show("Bạn có muốn xóa ?", "THÔNG BÁO", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    context.ChucVus.Remove(checkDelete);
                    context.SaveChanges();
                    List<ChucVu> listChucVu = context.ChucVus.ToList();
                    BindGrid(listChucVu);
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK);
                }

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvChucVu, saveFileDialog1.FileName);
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
