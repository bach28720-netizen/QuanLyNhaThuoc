namespace Quản_lý_phòng_khám
{
    partial class frmNhanSu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblLocVaiTro = new System.Windows.Forms.Label();
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txbTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvNhanSu = new System.Windows.Forms.DataGridView();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblGhiChuMacDinh = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.txbTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txbHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanSu)).BeginInit();
            this.pnlThongTin.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(287, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "DANH SÁCH NHÂN SỰ";
            //
            // lblLocVaiTro
            //
            this.lblLocVaiTro.AutoSize = true;
            this.lblLocVaiTro.Location = new System.Drawing.Point(20, 62);
            this.lblLocVaiTro.Name = "lblLocVaiTro";
            this.lblLocVaiTro.Size = new System.Drawing.Size(56, 16);
            this.lblLocVaiTro.TabIndex = 1;
            this.lblLocVaiTro.Text = "Vai trò:";
            //
            // cboLocVaiTro
            //
            this.cboLocVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocVaiTro.FormattingEnabled = true;
            this.cboLocVaiTro.Location = new System.Drawing.Point(80, 58);
            this.cboLocVaiTro.Name = "cboLocVaiTro";
            this.cboLocVaiTro.Size = new System.Drawing.Size(180, 24);
            this.cboLocVaiTro.TabIndex = 2;
            //
            // lblTimKiem
            //
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(280, 62);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(96, 16);
            this.lblTimKiem.TabIndex = 3;
            this.lblTimKiem.Text = "Tìm theo tên:";
            //
            // txbTimKiem
            //
            this.txbTimKiem.Location = new System.Drawing.Point(380, 58);
            this.txbTimKiem.Name = "txbTimKiem";
            this.txbTimKiem.Size = new System.Drawing.Size(200, 22);
            this.txbTimKiem.TabIndex = 4;
            //
            // btnTimKiem
            //
            this.btnTimKiem.Location = new System.Drawing.Point(590, 56);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(70, 28);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            //
            // dgvNhanSu
            //
            this.dgvNhanSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhanSu.AllowUserToAddRows = false;
            this.dgvNhanSu.AllowUserToDeleteRows = false;
            this.dgvNhanSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanSu.Location = new System.Drawing.Point(20, 95);
            this.dgvNhanSu.MultiSelect = false;
            this.dgvNhanSu.Name = "dgvNhanSu";
            this.dgvNhanSu.ReadOnly = true;
            this.dgvNhanSu.RowHeadersWidth = 30;
            this.dgvNhanSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanSu.Size = new System.Drawing.Size(640, 445);
            this.dgvNhanSu.TabIndex = 6;
            this.dgvNhanSu.SelectionChanged += new System.EventHandler(this.dgvNhanSu_SelectionChanged);
            //
            // pnlThongTin
            //
            this.pnlThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTin.Controls.Add(this.lblGhiChuMacDinh);
            this.pnlThongTin.Controls.Add(this.btnLamMoi);
            this.pnlThongTin.Controls.Add(this.btnXoa);
            this.pnlThongTin.Controls.Add(this.btnCapNhat);
            this.pnlThongTin.Controls.Add(this.btnThem);
            this.pnlThongTin.Controls.Add(this.cboVaiTro);
            this.pnlThongTin.Controls.Add(this.lblVaiTro);
            this.pnlThongTin.Controls.Add(this.txbTenDangNhap);
            this.pnlThongTin.Controls.Add(this.lblTenDangNhap);
            this.pnlThongTin.Controls.Add(this.txbHoTen);
            this.pnlThongTin.Controls.Add(this.lblHoTen);
            this.pnlThongTin.Location = new System.Drawing.Point(675, 95);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(300, 445);
            this.pnlThongTin.TabIndex = 7;
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 20);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(58, 16);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên:";
            //
            // txbHoTen
            //
            this.txbHoTen.Location = new System.Drawing.Point(15, 40);
            this.txbHoTen.Name = "txbHoTen";
            this.txbHoTen.Size = new System.Drawing.Size(260, 22);
            this.txbHoTen.TabIndex = 1;
            //
            // lblTenDangNhap
            //
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(15, 75);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(100, 16);
            this.lblTenDangNhap.TabIndex = 2;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            //
            // txbTenDangNhap
            //
            this.txbTenDangNhap.Location = new System.Drawing.Point(15, 95);
            this.txbTenDangNhap.Name = "txbTenDangNhap";
            this.txbTenDangNhap.Size = new System.Drawing.Size(260, 22);
            this.txbTenDangNhap.TabIndex = 3;
            //
            // lblVaiTro
            //
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(15, 130);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(56, 16);
            this.lblVaiTro.TabIndex = 4;
            this.lblVaiTro.Text = "Vai trò:";
            //
            // cboVaiTro
            //
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(15, 150);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(260, 24);
            this.cboVaiTro.TabIndex = 5;
            //
            // lblGhiChuMacDinh
            //
            this.lblGhiChuMacDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChuMacDinh.ForeColor = System.Drawing.Color.Gray;
            this.lblGhiChuMacDinh.Location = new System.Drawing.Point(15, 178);
            this.lblGhiChuMacDinh.MaximumSize = new System.Drawing.Size(265, 0);
            this.lblGhiChuMacDinh.Name = "lblGhiChuMacDinh";
            this.lblGhiChuMacDinh.Size = new System.Drawing.Size(260, 48);
            this.lblGhiChuMacDinh.TabIndex = 6;
            this.lblGhiChuMacDinh.Text = "Khi thêm nhân sự mới, hệ thống tự đặt mật khẩu mặc định là \"123456\". Việc đổi mậ" +
    "t khẩu đăng nhập được thực hiện ở menu Quản lý User.";
            //
            // btnThem
            //
            this.btnThem.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(15, 235);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(260, 34);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "➕ Thêm nhân sự mới";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnCapNhat
            //
            this.btnCapNhat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(15, 275);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(260, 34);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "✏️ Cập nhật thông tin";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            //
            // btnXoa
            //
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(15, 315);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(260, 34);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "❌ Xóa nhân sự";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            //
            // btnLamMoi
            //
            this.btnLamMoi.Location = new System.Drawing.Point(15, 355);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(260, 30);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // frmNhanSu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(995, 560);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.dgvNhanSu);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txbTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.cboLocVaiTro);
            this.Controls.Add(this.lblLocVaiTro);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "frmNhanSu";
            this.Text = "Nhân sự";
            this.Load += new System.EventHandler(this.frmNhanSu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanSu)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblLocVaiTro;
        private System.Windows.Forms.ComboBox cboLocVaiTro;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvNhanSu;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txbHoTen;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txbTenDangNhap;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblGhiChuMacDinh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
