namespace Quản_lý_phòng_khám
{
    partial class frmThietBi
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
            this.txtMaTB = new System.Windows.Forms.TextBox();
            this.txtTenTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSoLuongTB = new System.Windows.Forms.NumericUpDown();
            this.dgvThietBi = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoaTB = new System.Windows.Forms.Button();
            this.txtLoaiTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaTB
            // 
            this.txtMaTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaTB.Location = new System.Drawing.Point(233, 72);
            this.txtMaTB.Name = "txtMaTB";
            this.txtMaTB.Size = new System.Drawing.Size(100, 26);
            this.txtMaTB.TabIndex = 0;
            // 
            // txtTenTB
            // 
            this.txtTenTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenTB.Location = new System.Drawing.Point(233, 145);
            this.txtTenTB.Name = "txtTenTB";
            this.txtTenTB.Size = new System.Drawing.Size(100, 26);
            this.txtTenTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã thiết bị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên thiết bị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số Lượng";
            // 
            // nudSoLuongTB
            // 
            this.nudSoLuongTB.Location = new System.Drawing.Point(233, 271);
            this.nudSoLuongTB.Name = "nudSoLuongTB";
            this.nudSoLuongTB.Size = new System.Drawing.Size(120, 26);
            this.nudSoLuongTB.TabIndex = 8;
            // 
            // dgvThietBi
            // 
            this.dgvThietBi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThietBi.Location = new System.Drawing.Point(437, -1);
            this.dgvThietBi.Name = "dgvThietBi";
            this.dgvThietBi.RowHeadersWidth = 62;
            this.dgvThietBi.RowTemplate.Height = 28;
            this.dgvThietBi.Size = new System.Drawing.Size(817, 439);
            this.dgvThietBi.TabIndex = 9;
            this.dgvThietBi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThietBi_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(27, 350);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 37);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(149, 350);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(86, 37);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoaTB
            // 
            this.btnXoaTB.Location = new System.Drawing.Point(271, 350);
            this.btnXoaTB.Name = "btnXoaTB";
            this.btnXoaTB.Size = new System.Drawing.Size(95, 37);
            this.btnXoaTB.TabIndex = 12;
            this.btnXoaTB.Text = "Xóa";
            this.btnXoaTB.UseVisualStyleBackColor = true;
            this.btnXoaTB.Click += new System.EventHandler(this.btnXoaTB_Click);
            // 
            // txtLoaiTB
            // 
            this.txtLoaiTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoaiTB.Location = new System.Drawing.Point(233, 206);
            this.txtLoaiTB.Name = "txtLoaiTB";
            this.txtLoaiTB.Size = new System.Drawing.Size(100, 26);
            this.txtLoaiTB.TabIndex = 13;
            // 
            // frmThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 450);
            this.Controls.Add(this.txtLoaiTB);
            this.Controls.Add(this.btnXoaTB);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvThietBi);
            this.Controls.Add(this.nudSoLuongTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenTB);
            this.Controls.Add(this.txtMaTB);
            this.Name = "frmThietBi";
            this.Text = "frmThietBi";
            this.Load += new System.EventHandler(this.frmThietBi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaTB;
        private System.Windows.Forms.TextBox txtTenTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSoLuongTB;
        private System.Windows.Forms.DataGridView dgvThietBi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoaTB;
        private System.Windows.Forms.TextBox txtLoaiTB;
    }
}