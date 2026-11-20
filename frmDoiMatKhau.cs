using System;
using System.Linq;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    // Form cho phép người dùng đang đăng nhập (bất kỳ vai trò nào) tự đổi mật khẩu của chính mình.
    // Mở dạng ShowDialog() từ menu "Hệ thống > Đổi mật khẩu" trên frmMain.
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();

            // Ẩn mật khẩu mặc định bằng dấu *
            txbMatKhauCu.PasswordChar = '*';
            txbMatKhauMoi.PasswordChar = '*';
            txbXacNhanMatKhauMoi.PasswordChar = '*';
        }

        // Tick vào "Hiện mật khẩu" sẽ hiện rõ ký tự trên cả 3 ô nhập
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            char kyTuAn = chkHienMatKhau.Checked ? '\0' : '*';
            txbMatKhauCu.PasswordChar = kyTuAn;
            txbMatKhauMoi.PasswordChar = kyTuAn;
            txbXacNhanMatKhauMoi.PasswordChar = kyTuAn;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string matKhauCu = txbMatKhauCu.Text.Trim();
            string matKhauMoi = txbMatKhauMoi.Text.Trim();
            string xacNhan = txbXacNhanMatKhauMoi.Text.Trim();

            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmMain.CurrentUser == null)
            {
                MessageBox.Show("Không xác định được người dùng đang đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dùng context riêng, luôn lấy lại bản ghi User mới nhất từ CSDL theo UserID
            // (tránh phụ thuộc vào đối tượng user cũ còn giữ từ lúc đăng nhập ở frmLogin)
            using (QuanLyPhongKhamMedproEntities db = new QuanLyPhongKhamMedproEntities())
            {
                User user = db.Users.FirstOrDefault(u => u.UserID == frmMain.CurrentUser.UserID);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashMatKhauCu = PasswordHelper.HashPassword(matKhauCu);
                if (user.PasswordHash != hashMatKhauCu)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                user.PasswordHash = PasswordHelper.HashPassword(matKhauMoi);
                db.SaveChanges();

                // Đồng bộ lại PasswordHash trong CurrentUser đang được frmMain giữ,
                // phòng trường hợp có màn hình khác đọc lại giá trị này trong cùng phiên làm việc
                frmMain.CurrentUser.PasswordHash = user.PasswordHash;

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
