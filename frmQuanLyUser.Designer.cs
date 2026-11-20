namespace Quản_lý_phòng_khám
{
    partial class frmQuanLyUser
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDatLaiMatKhau = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblGhiChuMatKhau = new System.Windows.Forms.Label();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txbHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txbTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
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
            this.lblTieuDe.Size = new System.Drawing.Size(487, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ TÀI KHOẢN NGƯỜI DÙNG";
            //
            // dgvUsers
            //
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.Location = new System.Drawing.Point(20, 60);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 30;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(640, 480);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
            //
            // pnlThongTin
            //
            this.pnlThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTin.Controls.Add(this.btnLamMoi);
            this.pnlThongTin.Controls.Add(this.btnXoa);
            this.pnlThongTin.Controls.Add(this.btnDatLaiMatKhau);
            this.pnlThongTin.Controls.Add(this.btnCapNhat);
            this.pnlThongTin.Controls.Add(this.btnThem);
            this.pnlThongTin.Controls.Add(this.cboVaiTro);
            this.pnlThongTin.Controls.Add(this.lblVaiTro);
            this.pnlThongTin.Controls.Add(this.lblGhiChuMatKhau);
            this.pnlThongTin.Controls.Add(this.txbMatKhau);
            this.pnlThongTin.Controls.Add(this.lblMatKhau);
            this.pnlThongTin.Controls.Add(this.txbHoTen);
            this.pnlThongTin.Controls.Add(this.lblHoTen);
            this.pnlThongTin.Controls.Add(this.txbTenDangNhap);
            this.pnlThongTin.Controls.Add(this.lblTenDangNhap);
            this.pnlThongTin.Location = new System.Drawing.Point(675, 60);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(300, 480);
            this.pnlThongTin.TabIndex = 2;
            //
            // lblTenDangNhap
            //
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(15, 20);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(100, 16);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            //
            // txbTenDangNhap
            //
            this.txbTenDangNhap.Location = new System.Drawing.Point(15, 40);
            this.txbTenDangNhap.Name = "txbTenDangNhap";
            this.txbTenDangNhap.Size = new System.Drawing.Size(260, 22);
            this.txbTenDangNhap.TabIndex = 1;
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 75);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(58, 16);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            //
            // txbHoTen
            //
            this.txbHoTen.Location = new System.Drawing.Point(15, 95);
            this.txbHoTen.Name = "txbHoTen";
            this.txbHoTen.Size = new System.Drawing.Size(260, 22);
            this.txbHoTen.TabIndex = 3;
            //
            // lblMatKhau
            //
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(15, 130);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(66, 16);
            this.lblMatKhau.TabIndex = 4;
            this.lblMatKhau.Text = "Mật khẩu:";
            //
            // txbMatKhau
            //
            this.txbMatKhau.Location = new System.Drawing.Point(15, 150);
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.Size = new System.Drawing.Size(260, 22);
            this.txbMatKhau.TabIndex = 5;
            //
            // lblGhiChuMatKhau
            //
            this.lblGhiChuMatKhau.AutoSize = true;
            this.lblGhiChuMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChuMatKhau.ForeColor = System.Drawing.Color.Gray;
            this.lblGhiChuMatKhau.Location = new System.Drawing.Point(15, 178);
            this.lblGhiChuMatKhau.MaximumSize = new System.Drawing.Size(265, 0);
            this.lblGhiChuMatKhau.Name = "lblGhiChuMatKhau";
            this.lblGhiChuMatKhau.Size = new System.Drawing.Size(257, 32);
            this.lblGhiChuMatKhau.TabIndex = 6;
            this.lblGhiChuMatKhau.Text = "Chỉ nhập khi Thêm mới hoặc Đặt lại mật khẩu.";
            //
            // lblVaiTro
            //
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(15, 220);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(56, 16);
            this.lblVaiTro.TabIndex = 7;
            this.lblVaiTro.Text = "Vai trò:";
            //
            // cboVaiTro
            //
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(15, 240);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(260, 24);
            this.cboVaiTro.TabIndex = 8;
            //
            // btnThem
            //
            this.btnThem.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(15, 285);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(260, 34);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "➕ Thêm tài khoản";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnCapNhat
            //
            this.btnCapNhat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(15, 325);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(260, 34);
            this.btnCapNhat.TabIndex = 10;
            this.btnCapNhat.Text = "✏️ Cập nhật thông tin";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            //
            // btnDatLaiMatKhau
            //
            this.btnDatLaiMatKhau.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDatLaiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnDatLaiMatKhau.Location = new System.Drawing.Point(15, 365);
            this.btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            this.btnDatLaiMatKhau.Size = new System.Drawing.Size(260, 34);
            this.btnDatLaiMatKhau.TabIndex = 11;
            this.btnDatLaiMatKhau.Text = "🔑 Đặt lại mật khẩu";
            this.btnDatLaiMatKhau.UseVisualStyleBackColor = false;
            this.btnDatLaiMatKhau.Click += new System.EventHandler(this.btnDatLaiMatKhau_Click);
            //
            // btnXoa
            //
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(15, 405);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(260, 34);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "❌ Xóa tài khoản";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            //
            // btnLamMoi
            //
            this.btnLamMoi.Location = new System.Drawing.Point(15, 445);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(260, 30);
            this.btnLamMoi.TabIndex = 13;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // frmQuanLyUser
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(995, 560);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "frmQuanLyUser";
            this.Text = "Quản lý User";
            this.Load += new System.EventHandler(this.frmQuanLyUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txbTenDangNhap;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txbHoTen;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.Label lblGhiChuMatKhau;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnDatLaiMatKhau;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
