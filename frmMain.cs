using System;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public partial class frmMain : Form
    {
        public static User CurrentUser { get; set; }

        public frmMain()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.Load += FormMain_Load;
            this.FormClosed += FormMain_FormClosed;

            // --- GẮN SỰ KIỆN MỞ FORM CHO HỆ THỐNG ---
            đổiMậtKhẩuToolStripMenuItem.Click += (s, e) => { new frmDoiMatKhau().ShowDialog(); };
            quảnLýUserToolStripMenuItem.Click += (s, e) => { new frmQuanLyUser().ShowDialog(); };
            quảnLýQuyềnToolStripMenuItem.Click += (s, e) => { new frmQuanLyQuyen().ShowDialog(); };
            đăngXuấtToolStripMenuItem.Click += ĐăngXuấtToolStripMenuItem_Click;

            // --- GẮN SỰ KIỆN MỞ FORM CHO DANH MỤC & NGHIỆP VỤ ---
            lịchTrựcToolStripMenuItem.Click += (s, e) => { new frmNhanSu().ShowDialog(); };
            lịchKhámCáNhânToolStripMenuItem.Click += (s, e) => { new frmThietBi().ShowDialog(); }; // Menu Thiết bị
            thuốcVậtTưYTếToolStripMenuItem.Click += (s, e) => { new frmThuoc().ShowDialog(); };
            thanhToánHóaĐơnToolStripMenuItem.Click += (s, e) => { new frmHoaDon().ShowDialog(); };
            báoCáoDoanhThuToolStripMenuItem.Click += (s, e) => { new frmBaoCao().ShowDialog(); };
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            frmHome home = new frmHome();
            home.MdiParent = this;
            home.FormBorderStyle = FormBorderStyle.None;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentUser = null;
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        public void PhanQuyen(string vaiTro)
        {
            if (vaiTro == "Lễ tân")
            {
                thốngKêToolStripMenuItem.Visible = false;
                quảnLýUserToolStripMenuItem.Visible = false;
                quảnLýQuyềnToolStripMenuItem.Visible = false;
                lịchKhámCáNhânToolStripMenuItem.Visible = false;
                thuốcVậtTưYTếToolStripMenuItem.Visible = false;
                lịchTrựcToolStripMenuItem.Visible = false;
            }
            else if (vaiTro == "Bác sĩ")
            {
                thốngKêToolStripMenuItem.Visible = false;
                quảnLýUserToolStripMenuItem.Visible = false;
                quảnLýQuyềnToolStripMenuItem.Visible = false;
                thanhToánHóaĐơnToolStripMenuItem.Visible = false;
                lịchKhámCáNhânToolStripMenuItem.Visible = false;
            }
            else if (vaiTro == "Dược sĩ")
            {
                khámBệnhToolStripMenuItem.Visible = false;
                doanhThuToolStripMenuItem.Visible = false;
                quảnLýUserToolStripMenuItem.Visible = false;
                quảnLýQuyềnToolStripMenuItem.Visible = false;
            }
        }

        private void thiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBenhNhan().ShowDialog();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDatLich().ShowDialog();
        }

        private void khámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmKhamBenh().ShowDialog();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDichVu().ShowDialog();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}