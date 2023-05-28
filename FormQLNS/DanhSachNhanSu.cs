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

namespace FormQLNS
{
    public partial class DanhSachNhanSu : Form
    {
        NhanVienContextDB context = new NhanVienContextDB();
        public DanhSachNhanSu()
        {
            InitializeComponent();
        }

        private void DanhSachNhanSu_Load(object sender, EventArgs e)
        {
            try
            {
                NhanVienContextDB context = new NhanVienContextDB();
                List<NhanVien> listNhanvien = context.NhanViens.Include("Luongs").ToList();
                BindGrid(listNhanvien);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<NhanVien> listNhanvien)
        {
            dgvTatCaNhanVien.Rows.Clear();
            foreach (var item in listNhanvien)
            {
                int index = dgvTatCaNhanVien.Rows.Add();
                dgvTatCaNhanVien.Rows[index].Cells[0].Value = item.MaNV;
                dgvTatCaNhanVien.Rows[index].Cells[1].Value = item.TenNV;
                dgvTatCaNhanVien.Rows[index].Cells[2].Value = item.PhongBan;
                dgvTatCaNhanVien.Rows[index].Cells[3].Value = item.ChucVu;

                if (item.GioiTinh == true)
                {
                    dgvTatCaNhanVien.Rows[index].Cells[4].Value = "Nam";
                }
                else
                {
                    dgvTatCaNhanVien.Rows[index].Cells[4].Value = "Nữ";
                }

                dgvTatCaNhanVien.Rows[index].Cells[5].Value = item.NgaySinh.Value.ToShortDateString();
                dgvTatCaNhanVien.Rows[index].Cells[6].Value = item.DiaChi;
                dgvTatCaNhanVien.Rows[index].Cells[7].Value = item.CMND;
                dgvTatCaNhanVien.Rows[index].Cells[8].Value = item.SDT;
                dgvTatCaNhanVien.Rows[index].Cells[9].Value = item.TrinhDoHocVan;
                dgvTatCaNhanVien.Rows[index].Cells[10].Value = item.Email;
                dgvTatCaNhanVien.Rows[index].Cells[11].Value = item.Luongs.FirstOrDefault()?.LuongChinhThuc ?? 0;

            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvTatCaNhanVien, saveFileDialog1.FileName);
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
    
}
