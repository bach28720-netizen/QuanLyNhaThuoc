namespace Quản_lý_phòng_khám
{
    partial class frmQuanLyQuyen
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
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txbTenVaiTro = new System.Windows.Forms.TextBox();
            this.lblTenVaiTro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
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
            this.lblTieuDe.Size = new System.Drawing.Size(479, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ VAI TRÒ / PHÂN QUYỀN";
            //
            // dgvRoles
            //
            this.dgvRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoles.Location = new System.Drawing.Point(20, 60);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersWidth = 30;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(600, 480);
            this.dgvRoles.TabIndex = 1;
            this.dgvRoles.SelectionChanged += new System.EventHandler(this.dgvRoles_SelectionChanged);
            //
            // pnlThongTin
            //
            this.pnlThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTin.Controls.Add(this.btnLamMoi);
            this.pnlThongTin.Controls.Add(this.btnXoa);
            this.pnlThongTin.Controls.Add(this.btnCapNhat);
            this.pnlThongTin.Controls.Add(this.btnThem);
            this.pnlThongTin.Controls.Add(this.lblGhiChu);
            this.pnlThongTin.Controls.Add(this.txbTenVaiTro);
            this.pnlThongTin.Controls.Add(this.lblTenVaiTro);
            this.pnlThongTin.Location = new System.Drawing.Point(635, 60);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(300, 480);
            this.pnlThongTin.TabIndex = 2;
            //
            // lblTenVaiTro
            //
            this.lblTenVaiTro.AutoSize = true;
            this.lblTenVaiTro.Location = new System.Drawing.Point(15, 20);
            this.lblTenVaiTro.Name = "lblTenVaiTro";
            this.lblTenVaiTro.Size = new System.Drawing.Size(74, 16);
            this.lblTenVaiTro.TabIndex = 0;
            this.lblTenVaiTro.Text = "Tên vai trò:";
            //
            // txbTenVaiTro
            //
            this.txbTenVaiTro.Location = new System.Drawing.Point(15, 40);
            this.txbTenVaiTro.Name = "txbTenVaiTro";
            this.txbTenVaiTro.Size = new System.Drawing.Size(260, 22);
            this.txbTenVaiTro.TabIndex = 1;
            //
            // lblGhiChu
            //
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.Gray;
            this.lblGhiChu.Location = new System.Drawing.Point(15, 70);
            this.lblGhiChu.MaximumSize = new System.Drawing.Size(265, 0);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(260, 60);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Lưu ý: các vai trò \"Admin\", \"Lễ tân\", \"Bác sĩ\", \"Dược sĩ\" đang được hệ thống dùn" +
    "g để ẩn/hiện chức năng. Đổi tên các vai trò này có thể ảnh hưởng tới phân quyền" +
    ".";
            //
            // btnThem
            //
            this.btnThem.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(15, 145);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(260, 34);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "➕ Thêm vai trò";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnCapNhat
            //
            this.btnCapNhat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(15, 185);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(260, 34);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "✏️ Cập nhật tên vai trò";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            //
            // btnXoa
            //
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(15, 225);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(260, 34);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "❌ Xóa vai trò";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            //
            // btnLamMoi
            //
            this.btnLamMoi.Location = new System.Drawing.Point(15, 265);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(260, 30);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // frmQuanLyQuyen
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 560);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "frmQuanLyQuyen";
            this.Text = "Quản lý Quyền";
            this.Load += new System.EventHandler(this.frmQuanLyQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblTenVaiTro;
        private System.Windows.Forms.TextBox txbTenVaiTro;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
