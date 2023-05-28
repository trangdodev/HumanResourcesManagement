namespace FormQLNS
{
    partial class LuongNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnADD = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.txtMaLuong = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();
            this.txtPhuCap = new System.Windows.Forms.TextBox();
            this.txtLCB = new System.Windows.Forms.TextBox();
            this.bthExit = new System.Windows.Forms.Button();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.colMaLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLCB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHSPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Lương";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Nhân Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(829, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lương Cơ Bản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(827, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hệ Số Lương";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(827, 170);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hệ Số Phụ Cấp";
            // 
            // btnADD
            // 
            this.btnADD.Location = new System.Drawing.Point(489, 215);
            this.btnADD.Margin = new System.Windows.Forms.Padding(4);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(156, 46);
            this.btnADD.TabIndex = 7;
            this.btnADD.Text = "Thêm Lương Nhân Viên";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(723, 215);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 46);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa Lương Nhân Viên";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.Location = new System.Drawing.Point(955, 215);
            this.btnRepair.Margin = new System.Windows.Forms.Padding(4);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(156, 46);
            this.btnRepair.TabIndex = 9;
            this.btnRepair.Text = "Sửa Lương Nhân Viên";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // txtMaLuong
            // 
            this.txtMaLuong.Location = new System.Drawing.Point(236, 62);
            this.txtMaLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaLuong.Name = "txtMaLuong";
            this.txtMaLuong.Size = new System.Drawing.Size(317, 22);
            this.txtMaLuong.TabIndex = 11;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(236, 111);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(317, 22);
            this.txtMaNV.TabIndex = 12;
            // 
            // txtHeSoLuong
            // 
            this.txtHeSoLuong.Location = new System.Drawing.Point(1017, 113);
            this.txtHeSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeSoLuong.Name = "txtHeSoLuong";
            this.txtHeSoLuong.Size = new System.Drawing.Size(317, 22);
            this.txtHeSoLuong.TabIndex = 14;
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Location = new System.Drawing.Point(1017, 164);
            this.txtPhuCap.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Size = new System.Drawing.Size(317, 22);
            this.txtPhuCap.TabIndex = 15;
            // 
            // txtLCB
            // 
            this.txtLCB.Location = new System.Drawing.Point(1017, 62);
            this.txtLCB.Margin = new System.Windows.Forms.Padding(4);
            this.txtLCB.Name = "txtLCB";
            this.txtLCB.Size = new System.Drawing.Size(317, 22);
            this.txtLCB.TabIndex = 17;
            // 
            // bthExit
            // 
            this.bthExit.Location = new System.Drawing.Point(1105, 596);
            this.bthExit.Margin = new System.Windows.Forms.Padding(4);
            this.bthExit.Name = "bthExit";
            this.bthExit.Size = new System.Drawing.Size(165, 37);
            this.bthExit.TabIndex = 19;
            this.bthExit.Text = "Thoát";
            this.bthExit.UseVisualStyleBackColor = true;
            this.bthExit.Click += new System.EventHandler(this.button5_Click);
            // 
            // dgvLuong
            // 
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLuong,
            this.colMaNV,
            this.colLCB,
            this.colHSL,
            this.colHSPC,
            this.colTinhLuong});
            this.dgvLuong.Location = new System.Drawing.Point(169, 299);
            this.dgvLuong.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.RowHeadersWidth = 51;
            this.dgvLuong.Size = new System.Drawing.Size(1101, 273);
            this.dgvLuong.TabIndex = 18;
            this.dgvLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellClick);
            // 
            // colMaLuong
            // 
            this.colMaLuong.HeaderText = "Mã Lương";
            this.colMaLuong.MinimumWidth = 6;
            this.colMaLuong.Name = "colMaLuong";
            // 
            // colMaNV
            // 
            this.colMaNV.HeaderText = "Tên Nhân Viên";
            this.colMaNV.MinimumWidth = 6;
            this.colMaNV.Name = "colMaNV";
            // 
            // colLCB
            // 
            this.colLCB.HeaderText = "Lương Cơ Bản";
            this.colLCB.MinimumWidth = 6;
            this.colLCB.Name = "colLCB";
            // 
            // colHSL
            // 
            this.colHSL.HeaderText = "Hệ Số Lương";
            this.colHSL.MinimumWidth = 6;
            this.colHSL.Name = "colHSL";
            // 
            // colHSPC
            // 
            this.colHSPC.HeaderText = "Hệ Số Phụ Cấp";
            this.colHSPC.MinimumWidth = 6;
            this.colHSPC.Name = "colHSPC";
            // 
            // colTinhLuong
            // 
            this.colTinhLuong.HeaderText = "Lương";
            this.colTinhLuong.MinimumWidth = 6;
            this.colTinhLuong.Name = "colTinhLuong";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1178, 215);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(156, 46);
            this.btnExcel.TabIndex = 20;
            this.btnExcel.Text = "Xuất File Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // LuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1395, 659);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.bthExit);
            this.Controls.Add(this.dgvLuong);
            this.Controls.Add(this.txtLCB);
            this.Controls.Add(this.txtPhuCap);
            this.Controls.Add(this.txtHeSoLuong);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.txtMaLuong);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LuongNhanVien";
            this.Text = "LuongNhanVien";
            this.Load += new System.EventHandler(this.LuongNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.TextBox txtMaLuong;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtHeSoLuong;
        private System.Windows.Forms.TextBox txtPhuCap;
        private System.Windows.Forms.TextBox txtLCB;
        private System.Windows.Forms.Button bthExit;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLCB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHSPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhLuong;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}