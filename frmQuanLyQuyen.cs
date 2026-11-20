using System;
using System.Linq;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    // Form Quản lý Quyền (bảng Roles) - Admin only.
    // Lưu ý: tên 4 vai trò "Admin", "Lễ tân", "Bác sĩ", "Dược sĩ" được dùng làm khóa so sánh
    // chuỗi trong hàm PhanQuyen() ở frmMain.cs để ẩn/hiện chức năng, nên đổi tên các vai trò
    // này cần cẩn trọng (có cảnh báo khi cập nhật).
    public partial class frmQuanLyQuyen : Form
    {
        QuanLyPhongKhamMedproEntities db = new QuanLyPhongKhamMedproEntities();
        int? selectedRoleId = null;

        private static readonly string[] CacVaiTroHeThong = { "Admin", "Lễ tân", "Bác sĩ", "Dược sĩ" };

        public frmQuanLyQuyen()
        {
            InitializeComponent();
        }

        private void frmQuanLyQuyen_Load(object sender, EventArgs e)
        {
            TaiDanhSachVaiTro();
        }

        private void TaiDanhSachVaiTro()
        {
            var ds = (from r in db.Roles
                      select new
                      {
                          r.RoleID,
                          r.RoleName,
                          SoLuongTaiKhoan = r.Users.Count
                      }).ToList();

            dgvRoles.DataSource = ds;

            if (dgvRoles.Columns.Count > 0)
            {
                dgvRoles.Columns["RoleID"].HeaderText = "Mã vai trò";
                dgvRoles.Columns["RoleName"].HeaderText = "Tên vai trò";
                dgvRoles.Columns["SoLuongTaiKhoan"].HeaderText = "Số tài khoản";
            }

            XoaTrangThongTin();
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null) return;

            selectedRoleId = (int)dgvRoles.CurrentRow.Cells["RoleID"].Value;
            txbTenVaiTro.Text = dgvRoles.CurrentRow.Cells["RoleName"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenVaiTro = txbTenVaiTro.Text.Trim();
            if (string.IsNullOrEmpty(tenVaiTro))
            {
                MessageBox.Show("Vui lòng nhập tên vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (db.Roles.Any(r => r.RoleName == tenVaiTro))
            {
                MessageBox.Show("Vai trò này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.Roles.Add(new Role { RoleName = tenVaiTro });
            db.SaveChanges();

            MessageBox.Show("Thêm vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDanhSachVaiTro();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (selectedRoleId == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenVaiTroMoi = txbTenVaiTro.Text.Trim();
            if (string.IsNullOrEmpty(tenVaiTroMoi))
            {
                MessageBox.Show("Tên vai trò không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Role role = db.Roles.FirstOrDefault(r => r.RoleID == selectedRoleId);
            if (role == null) return;

            // Cảnh báo nếu đổi tên 1 trong 4 vai trò hệ thống đang dùng để phân quyền ẩn/hiện menu
            if (CacVaiTroHeThong.Contains(role.RoleName) && role.RoleName != tenVaiTroMoi)
            {
                DialogResult xacNhan = MessageBox.Show(
                    "Vai trò \"" + role.RoleName + "\" đang được hệ thống dùng để phân quyền ẩn/hiện chức năng.\n" +
                    "Đổi tên có thể khiến logic phân quyền không còn nhận diện đúng vai trò này.\n" +
                    "Bạn có chắc chắn muốn tiếp tục?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (xacNhan != DialogResult.Yes) return;
            }

            if (db.Roles.Any(r => r.RoleName == tenVaiTroMoi && r.RoleID != selectedRoleId))
            {
                MessageBox.Show("Đã có vai trò khác dùng tên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            role.RoleName = tenVaiTroMoi;
            db.SaveChanges();

            MessageBox.Show("Cập nhật vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDanhSachVaiTro();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRoleId == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Role role = db.Roles.FirstOrDefault(r => r.RoleID == selectedRoleId);
            if (role == null) return;

            bool conTaiKhoan = db.Users.Any(u => u.RoleID == selectedRoleId);
            if (conTaiKhoan)
            {
                MessageBox.Show(
                    "Không thể xóa vì vẫn còn tài khoản đang gán vai trò này.\n" +
                    "Vui lòng chuyển các tài khoản sang vai trò khác trước khi xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa vai trò \"" + role.RoleName + "\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes) return;

            db.Roles.Remove(role);
            db.SaveChanges();

            MessageBox.Show("Xóa vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDanhSachVaiTro();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDanhSachVaiTro();
        }

        private void XoaTrangThongTin()
        {
            selectedRoleId = null;
            txbTenVaiTro.Text = "";
        }
    }
}
