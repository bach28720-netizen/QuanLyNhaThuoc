namespace Quản_lý_phòng_khám
{
    partial class frmHoaDon
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
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThemChiTiet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nudSoLuongMua = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cboThuoc = new System.Windows.Forms.ComboBox();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.ColMaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongMua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaHD
            // 
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHD.Location = new System.Drawing.Point(166, 20);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(141, 22);
            this.txtMaHD.TabIndex = 0;
            // 
            // txtTenKH
            // 
            this.txtTenKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKH.Location = new System.Drawing.Point(166, 59);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(141, 22);
            this.txtTenKH.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã Hóa Đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên Khách Hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày Lập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tổng Tiền";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Location = new System.Drawing.Point(166, 102);
            this.dtpNgayLap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(245, 22);
            this.dtpNgayLap.TabIndex = 6;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Location = new System.Drawing.Point(166, 183);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(141, 22);
            this.txtTongTien.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.txtMaHD);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.dtpNgayLap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(480, 236);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Hóa Đơn";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtDonGia
            // 
            this.txtDonGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDonGia.Location = new System.Drawing.Point(166, 142);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(89, 22);
            this.txtDonGia.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThemChiTiet);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudSoLuongMua);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboThuoc);
            this.groupBox2.Location = new System.Drawing.Point(529, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(512, 236);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khu vực Chọn Thuốc";
            // 
            // btnThemChiTiet
            // 
            this.btnThemChiTiet.Location = new System.Drawing.Point(202, 115);
            this.btnThemChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemChiTiet.Name = "btnThemChiTiet";
            this.btnThemChiTiet.Size = new System.Drawing.Size(81, 28);
            this.btnThemChiTiet.TabIndex = 5;
            this.btnThemChiTiet.Text = "Thêm";
            this.btnThemChiTiet.UseVisualStyleBackColor = true;
            this.btnThemChiTiet.Click += new System.EventHandler(this.btnThemChiTiet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Số Lượng Mua";
            // 
            // nudSoLuongMua
            // 
            this.nudSoLuongMua.Location = new System.Drawing.Point(202, 70);
            this.nudSoLuongMua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudSoLuongMua.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuongMua.Name = "nudSoLuongMua";
            this.nudSoLuongMua.Size = new System.Drawing.Size(111, 22);
            this.nudSoLuongMua.TabIndex = 2;
            this.nudSoLuongMua.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Chọn Thuốc";
            // 
            // cboThuoc
            // 
            this.cboThuoc.FormattingEnabled = true;
            this.cboThuoc.Location = new System.Drawing.Point(202, 22);
            this.cboThuoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboThuoc.Name = "cboThuoc";
            this.cboThuoc.Size = new System.Drawing.Size(161, 24);
            this.cboThuoc.TabIndex = 0;
            this.cboThuoc.SelectedIndexChanged += new System.EventHandler(this.cboThuoc_SelectedIndexChanged);
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaThuoc,
            this.ColTenThuoc,
            this.ColSoLuong,
            this.ColDonGia,
            this.ColThanhTien});
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(11, 250);
            this.dgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.RowTemplate.Height = 28;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(860, 249);
            this.dgvChiTietHoaDon.TabIndex = 10;
            // 
            // ColMaThuoc
            // 
            this.ColMaThuoc.HeaderText = "Mã Thuốc";
            this.ColMaThuoc.MinimumWidth = 8;
            this.ColMaThuoc.Name = "ColMaThuoc";
            // 
            // ColTenThuoc
            // 
            this.ColTenThuoc.HeaderText = "Tên Thuốc";
            this.ColTenThuoc.MinimumWidth = 8;
            this.ColTenThuoc.Name = "ColTenThuoc";
            // 
            // ColSoLuong
            // 
            this.ColSoLuong.HeaderText = "Số Lượng";
            this.ColSoLuong.MinimumWidth = 8;
            this.ColSoLuong.Name = "ColSoLuong";
            // 
            // ColDonGia
            // 
            this.ColDonGia.HeaderText = "Đơn Giá";
            this.ColDonGia.MinimumWidth = 8;
            this.ColDonGia.Name = "ColDonGia";
            // 
            // ColThanhTien
            // 
            this.ColThanhTien.HeaderText = "Thành Tiền";
            this.ColThanhTien.MinimumWidth = 8;
            this.ColThanhTien.Name = "ColThanhTien";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(926, 322);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(108, 36);
            this.btnThanhToan.TabIndex = 11;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 530);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmHoaDon";
            this.Text = "frmHoaDon";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongMua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudSoLuongMua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboThuoc;
        private System.Windows.Forms.Button btnThemChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThanhTien;
        private System.Windows.Forms.Button btnThanhToan;
    }
}