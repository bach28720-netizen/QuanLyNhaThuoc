using System;
using System.Linq;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    // Form Danh mục > Nhân sự: danh sách nhân viên (bác sĩ, lễ tân, dược sĩ...),
    // lọc/tìm kiếm theo vai trò và tên, thêm/sửa thông tin cơ bản, xóa nhân sự.
    // Việc đổi mật khẩu đăng nhập/đặt lại mật khẩu được thực hiện ở frmQuanLyUser (Admin).
    public partial class frmNhanSu : Form
    {
        QuanLyPhongKhamMedproEntities db = new QuanLyPhongKhamMedproEntities();
        int? selectedUserId = null;
        private const string MatKhauMacDinh = "123456";

        public frmNhanSu()
        {
            InitializeComponent();
        }

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            TaiDanhSachVaiTroLoc();
            TaiDanhSachVaiTro();
            TaiDanhSachNhanSu(null, "");
        }

        private void TaiDanhSachVaiTroLoc()
        {
            var ds = db.Roles.ToList();
            ds.Insert(0, new Role { RoleID = 0, RoleName = "-- Tất cả vai trò --" });
            cboLocVaiTro.DataSource = ds;
            cboLocVaiTro.DisplayMember = "RoleName";
            cboLocVaiTro.ValueMember = "RoleID";
        }

        private void TaiDanhSachVaiTro()
        {
            cboVaiTro.DataSource = db.Roles.ToList();
            cboVaiTro.DisplayMember = "RoleName";
            cboVaiTro.ValueMember = "RoleID";
        }

        private void TaiDanhSachNhanSu(int? roleId, string tuKhoa)
        {
            var query = from u in db.Users select u;

            if (roleId.HasValue && roleId.Value > 0)
            {
                query = query.Where(u => u.RoleID == roleId.Value);
            }

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(u => u.FullName.Contains(tuKhoa));
            }

            var ds = (from u in query
                      select new
                      {
                          u.UserID,
                          u.FullName,
                          u.Username,
                          TenVaiTro = u.Role != null ? u.Role.RoleName : "(Chưa gán)"
                      }).ToList();

            dgvNhanSu.DataSource = ds;

            if (dgvNhanSu.Columns.Count > 0)
            {
                dgvNhanSu.Columns["UserID"].HeaderText = "Mã NV";
                dgvNhanSu.Columns["FullName"].HeaderText = "Họ tên";
                dgvNhanSu.Columns["Username"].HeaderText = "Tên đăng nhập";
                dgvNhanSu.Columns["TenVaiTro"].HeaderText = "Vai trò";
            }

            XoaTrangThongTin();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int? roleId = (cboLocVaiTro.SelectedValue != null) ? (int?)(int)cboLocVaiTro.SelectedValue : null;
            TaiDanhSachNhanSu(roleId, txbTimKiem.Text.Trim());
        }

        private void dgvNhanSu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanSu.CurrentRow == null) return;

            selectedUserId = (int)dgvNhanSu.CurrentRow.Cells["UserID"].Value;
            txbHoTen.Text = dgvNhanSu.CurrentRow.Cells["FullName"].Value.ToString();
            txbTenDangNhap.Text = dgvNhanSu.CurrentRow.Cells["Username"].Value.ToString();

            User user = db.Users.FirstOrDefault(u => u.UserID == selectedUserId);
            if (user != null && user.RoleID.HasValue)
            {
                cboVaiTro.SelectedValue = user.RoleID.Value;
            }

            txbTenDangNhap.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txbHoTen.Text.Trim();
            string tenDangNhap = txbTenDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboVaiTro.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (db.Users.Any(u => u.Username == tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User
            {
                FullName = hoTen,
                Username = tenDangNhap,
                PasswordHash = PasswordHelper.HashPassword(MatKhauMacDinh),
                RoleID = (int)cboVaiTro.SelectedValue
            };

            db.Users.Add(user);
            db.SaveChanges();

            MessageBox.Show(
                "Thêm nhân sự thành công!\nMật khẩu đăng nhập mặc định: " + MatKhauMacDinh +
                "\nVui lòng thông báo cho nhân viên đổi mật khẩu ngay sau khi đăng nhập lần đầu.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TaiDanhSachNhanSu(null, "");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn nhân sự cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            MessageBox.Show("Cập nhật thông tin nhân sự thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDanhSachNhanSu(null, "");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn nhân sự cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmMain.CurrentUser != null && selectedUserId == frmMain.CurrentUser.UserID)
            {
                MessageBox.Show("Không thể xóa chính tài khoản đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân sự \"" + txbHoTen.Text + "\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes) return;

            try
            {
                User user = db.Users.FirstOrDefault(u => u.UserID == selectedUserId);
                if (user == null) return;

                db.Users.Remove(user);
                db.SaveChanges();

                MessageBox.Show("Xóa nhân sự thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachNhanSu(null, "");
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Không thể xóa vì nhân sự này còn dữ liệu liên quan (lịch hẹn, hóa đơn,...).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbTimKiem.Text = "";
            if (cboLocVaiTro.Items.Count > 0) cboLocVaiTro.SelectedIndex = 0;
            TaiDanhSachNhanSu(null, "");
        }

        private void XoaTrangThongTin()
        {
            selectedUserId = null;
            txbHoTen.Text = "";
            txbTenDangNhap.Text = "";
            txbTenDangNhap.Enabled = true;
            if (cboVaiTro.Items.Count > 0) cboVaiTro.SelectedIndex = 0;
        }
    }
}
