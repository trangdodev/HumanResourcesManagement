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
    public partial class QuanLyTrinhDoHocVan : Form
    {
        NhanVienContextDB context = new NhanVienContextDB();
        public QuanLyTrinhDoHocVan()
        {
            InitializeComponent();
        }
        private int DemNhanVien(string TenTDHV)
        {
            int num = 0;
            var listNV = context.NhanViens.Where(p => p.TrinhDoHocVan == TenTDHV).ToList();
            num = listNV.Count;
            return num;
        }

        private void BindGrid(List<TrinhDoHocVan> listTDHV)
        {
            dgvTDHV.Rows.Clear();
            foreach (var item in listTDHV)
            {
                int index = dgvTDHV.Rows.Add();
                dgvTDHV.Rows[index].Cells[0].Value = item.MaTDHV;
                dgvTDHV.Rows[index].Cells[1].Value = item.TenTDHV;
                dgvTDHV.Rows[index].Cells[2].Value = DemNhanVien(item.TenTDHV);

            }
        }

        private void dgvTDHV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow row = dgvTDHV.Rows[e.RowIndex];
            txtMaTDHV.Text = row.Cells["Column1"].Value.ToString();

            txtTenTDHV.Text = row.Cells["Column2"].Value.ToString();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            TrinhDoHocVan tdhv = new TrinhDoHocVan();
            if (txtMaTDHV.Text == "" || txtTenTDHV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                tdhv.MaTDHV = Int32.Parse(txtMaTDHV.Text);
                tdhv.TenTDHV = txtTenTDHV.Text;
            }

            TrinhDoHocVan dbName = context.TrinhDoHocVans.FirstOrDefault(p => p.TenTDHV == txtMaTDHV.Text);
            if (dbName != null)
            {
                MessageBox.Show("Không thể thêm Trình Độ Học Vấn đã có trong danh sách ! ", "THÔNG BÁO");

                return;
            }
            else
            {
                context.TrinhDoHocVans.Add(tdhv);
                context.SaveChanges();
                List<TrinhDoHocVan> ls = context.TrinhDoHocVans.ToList();
                BindGrid(ls);
                MessageBox.Show("Thêm Trình Độ Học Vấn thành công ", "THÔNG BÁO");
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maTDHV = Int32.Parse(txtMaTDHV.Text);
            TrinhDoHocVan checkDelete = context.TrinhDoHocVans.FirstOrDefault(p => p.MaTDHV == maTDHV);
            if (checkDelete != null)
            {
                DialogResult yesno = MessageBox.Show("Bạn có muốn xóa ?", "THÔNG BÁO", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    context.TrinhDoHocVans.Remove(checkDelete);
                    context.SaveChanges();
                    List<TrinhDoHocVan> listTDHV = context.TrinhDoHocVans.ToList();
                    BindGrid(listTDHV);
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK);
                }

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvTDHV, saveFileDialog1.FileName);
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

        private void QuanLyTrinhDoHocVan_Load_1(object sender, EventArgs e)
        {
            try
            {
                List<TrinhDoHocVan> listTDHV = context.TrinhDoHocVans.ToList();
                List<NhanVien> listNV = context.NhanViens.ToList();
                BindGrid(listTDHV);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
