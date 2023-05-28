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

    public partial class QLNS : Form
    {
        NhanVienContextDB context = new NhanVienContextDB();
        private object dataGridView1;

        public QLNS()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void QLNS_Load(object sender, EventArgs e)
        {
            try
            {
                NhanVienContextDB context = new NhanVienContextDB();
                List<NhanVien> listNhanvien = context.NhanViens.ToList();
                List<TrinhDoHocVan> listTDHV = context.TrinhDoHocVans.ToList();
                List<PhongBan> listPB = context.PhongBans.ToList();
                List<ChucVu> listCV = context.ChucVus.ToList();
                FillPBCbx(listPB);
                FillCVCbx(listCV);
                FillTDHVCbx(listTDHV);


                BindGrid(listNhanvien);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void FillTDHVCbx(List<TrinhDoHocVan> listTDHV)
        {
            this.cbxTDHV.DataSource = listTDHV;
            this.cbxTDHV.DisplayMember = "TenTDHV";
            this.cbxTDHV.ValueMember = "MaTDHV";
        }
        private void FillPBCbx(List<PhongBan> listPB)
        {
            this.cbxPB.DataSource = listPB;
            this.cbxPB.DisplayMember = "TenPB";
            this.cbxPB.ValueMember = "MaPB";
        }
        private void FillCVCbx(List<ChucVu> listCV)
        {
            this.cbxChucVu.DataSource = listCV;
            this.cbxChucVu.DisplayMember = "TenCV";
            this.cbxChucVu.ValueMember = "MaCV";
        }

        private void BindGrid(List<NhanVien> listNhanvien)
        {
            dgvNV.Rows.Clear();
            foreach (var item in listNhanvien)
            {
                int index = dgvNV.Rows.Add();
                dgvNV.Rows[index].Cells[0].Value = item.MaNV;
                dgvNV.Rows[index].Cells[1].Value = item.TenNV;
                dgvNV.Rows[index].Cells[2].Value = item.PhongBan;
                dgvNV.Rows[index].Cells[3].Value = item.ChucVu;

                if (item.GioiTinh == true)
                {
                    dgvNV.Rows[index].Cells[4].Value = "Nam";
                }
                else
                {
                    dgvNV.Rows[index].Cells[4].Value = "Nữ";
                }

                dgvNV.Rows[index].Cells[5].Value = item.NgaySinh.Value.ToShortDateString();
                dgvNV.Rows[index].Cells[6].Value = item.DiaChi;
                dgvNV.Rows[index].Cells[7].Value = item.CMND;
                dgvNV.Rows[index].Cells[8].Value = item.SDT;
                dgvNV.Rows[index].Cells[9].Value = item.TrinhDoHocVan;
                dgvNV.Rows[index].Cells[10].Value = item.Email;

            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
       
            if (txtID.Text == "" || txtName.Text == "" || txtCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
                
            else
            {
                NhanVien nv = new NhanVien()
                {
                    MaNV = txtID.Text,
                    TenNV = txtName.Text,
                    PhongBan = cbxPB.Text,
                    //MaPB = cbxPB.SelectedIndex,
                    ChucVu = cbxChucVu.Text,
                    GioiTinh = rdbMale.Checked,
                    NgaySinh = dateTimePicker1.Value.Date,
                    DiaChi = txtAddress.Text,
                    CMND = txtCMND.Text,
                    SDT = txtSDT.Text,
                    TrinhDoHocVan = cbxTDHV.Text,
                    Email = txtMail.Text,

                };

                context.NhanViens.Add(nv);
                context.SaveChanges();
                List<NhanVien> ls = context.NhanViens.ToList();
                BindGrid(ls);
                MessageBox.Show("Thêm nhân viên thành công ", "THÔNG BÁO");
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            NhanVien dbUpdate = context.NhanViens.FirstOrDefault(p => p.MaNV == txtID.Text);
            if (dbUpdate != null)
            {
                dbUpdate.MaNV = txtID.Text;
                dbUpdate.TenNV = txtName.Text;
                dbUpdate.PhongBan = cbxPB.Text;
                dbUpdate.ChucVu = cbxChucVu.Text;
                dbUpdate.GioiTinh = rdbMale.Checked;
                //? "Nam" : "Nữ",
                dbUpdate.NgaySinh = dateTimePicker1.Value.Date;
                dbUpdate.DiaChi = txtAddress.Text;
                dbUpdate.CMND = txtCMND.Text;
                dbUpdate.SDT = txtSDT.Text;
                dbUpdate.TrinhDoHocVan = cbxTDHV.Text;
                dbUpdate.Email = txtMail.Text;

                context.SaveChanges();
                List<NhanVien> ls = context.NhanViens.ToList();
                BindGrid(ls);
                MessageBox.Show("Sửa thông tin nhân viên thành công ", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần sửa  ", "THÔNG BÁO");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            NhanVien checkDelete = context.NhanViens.FirstOrDefault(p => p.MaNV == txtID.Text);
            if (checkDelete != null)
            {
                DialogResult yesno = MessageBox.Show("Bạn có muốn xóa ?", "THÔNG BÁO", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    context.NhanViens.Remove(checkDelete);
                    context.SaveChanges();
                    List<NhanVien> listNhanVien = context.NhanViens.ToList();
                    BindGrid(listNhanVien);
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK);
                }

            }

        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvNV.Rows[e.RowIndex];
            txtID.Text = row.Cells["colID"].Value.ToString();
            txtName.Text = row.Cells["colName"].Value.ToString();
            cbxPB.Text = row.Cells["colDisivion"].Value.ToString();
            cbxChucVu.Text = row.Cells["colRole"].Value.ToString();
            dateTimePicker1.Text = row.Cells["colNgaySinh"].Value.ToString();
            txtAddress.Text = row.Cells["colDiaChi"].Value.ToString();
            txtCMND.Text = row.Cells["colCMND"].Value.ToString();
            txtSDT.Text = row.Cells["colSDT"].Value.ToString();
            cbxTDHV.Text = row.Cells["colTrinhDoHocVan"].Value.ToString();
            txtMail.Text = row.Cells["colMail"].Value.ToString();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgvNV, saveFileDialog1.FileName);
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