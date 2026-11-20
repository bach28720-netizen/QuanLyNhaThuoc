using System;
using System.Linq;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    // Form Quản lý tài khoản đăng nhập (Admin only).
    // Cho phép: thêm tài khoản mới, sửa họ tên/vai trò, đặt lại mật khẩu, xóa tài khoản.
    public partial class frmQuanLyUser : Form
    {
        QuanLyPhongKhamMedproEntities db = new QuanLyPhongKhamMedproEntities();
        int? selectedUserId = null;

        public frmQuanLyUser()
        {
            InitializeComponent();
            txbMatKhau.PasswordChar = '*';
        }

        private void frmQuanLyUser_Load(object sender, EventArgs e)
        {
            TaiDanhSachVaiTro();
            TaiDanhSachUser();
        }

        private void TaiDanhSachVaiTro()
        {
            cboVaiTro.DataSource = db.Roles.ToList();
            cboVaiTro.DisplayMember = "RoleName";
            cboVaiTro.ValueMember = "RoleID";
        }

        private void TaiDanhSachUser()
        {
            var ds = (from u in db.Users
                      select new
                      {
                          u.UserID,
                          u.Username,
                          u.FullName,
                          TenVaiTro = u.Role != null ? u.Role.RoleName : "(Chưa gán)"
                      }).ToList();

            dgvUsers.DataSource = ds;

            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["UserID"].HeaderText = "Mã";
                dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
                dgvUsers.Columns["FullName"].HeaderText = "Họ tên";
                dgvUsers.Columns["TenVaiTro"].HeaderText = "Vai trò";
            }

            XoaTrangThongTin();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            selectedUserId = (int)dgvUsers.CurrentRow.Cells["UserID"].Value;
            txbTenDangNhap.Text = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            txbHoTen.Text = dgvUsers.CurrentRow.Cells["FullName"].Value.ToString();
            txbMatKhau.Text = "";

            User user = db.Users.FirstOrDefault(u => u.UserID == selectedUserId);
            if (user != null && user.RoleID.HasValue)
            {
                cboVaiTro.SelectedValue = user.RoleID.Value;
            }

            // Không cho đổi tên đăng nhập sau khi đã tạo tài khoản
            txbTenDangNhap.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txbTenDangNhap.Text.Trim();
            string hoTen = txbHoTen.Text.Trim();
            string matKhau = txbMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập, Họ tên và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhau.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboVaiTro.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool trungTen = db.Users.Any(u => u.Username == tenDangNhap);
            if (trungTen)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User
            {
                Username = tenDangNhap,
                FullName = hoTen,
                PasswordHash = PasswordHelper.HashPassword(matKhau),
                RoleID = (int)cboVaiTro.SelectedValue
            };

            db.Users.Add(user);
            db.SaveChanges();

            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDanhSachUser();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txbHoTen.Text.Trim();
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboVaiTro.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = db.Users.FirstOrDefault(u => u.UserID == selectedUserId);
            if (user == null) return;

            user.FullName = hoTen;
            user.RoleID = (int)cboVaiTro.SelectedValue;
            db.SaveChanges();

            MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDanhSachUser();
        }

        private void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đặt lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matKhauMoi = txbMatKhau.Text.Trim();
            if (string.IsNullOrEmpty(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới vào ô Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Xác nhận đặt lại mật khẩu cho tài khoản \"" + txbTenDangNhap.Text + "\"?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketQua != DialogResult.Yes) return;

            User user = db.Users.FirstOrDefault(u => u.UserID == selectedUserId);
            if (user == null) return;

            user.PasswordHash = PasswordHelper.HashPassword(matKhauMoi);
            db.SaveChanges();

            MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDanhSachUser();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmMain.CurrentUser != null && selectedUserId == frmMain.CurrentUser.UserID)
            {
                MessageBox.Show("Không thể xóa chính tài khoản đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản \"" + txbTenDangNhap.Text + "\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketQua != DialogResult.Yes) return;

            try
            {
                User user = db.Users.FirstOrDefault(u => u.UserID == selectedUserId);
                if (user == null) return;

                db.Users.Remove(user);
                db.SaveChanges();

                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachUser();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Không thể xóa tài khoản này vì còn dữ liệu liên quan (lịch hẹn, hóa đơn,...).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDanhSachUser();
        }

        private void XoaTrangThongTin()
        {
            selectedUserId = null;
            txbTenDangNhap.Text = "";
            txbHoTen.Text = "";
            txbMatKhau.Text = "";
            txbTenDangNhap.Enabled = true;
            if (cboVaiTro.Items.Count > 0) cboVaiTro.SelectedIndex = 0;
        }
    }
}
