using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public partial class frmLogin : Form
    {
        // Gọi Entity Framework kết nối CSDL
        QuanLyPhongKhamMedproEntities db = new QuanLyPhongKhamMedproEntities();
        public frmLogin()
        {
            InitializeComponent();
            // Tự động ẩn mật khẩu bằng dấu *
            txbPassWord.PasswordChar = '*';

            // Tự động gắn sự kiện cho nút Thoát và CheckBox (không cần mở Designer)
            button2.Click += button2_Click;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

        }

        // Hàm băm mật khẩu chuẩn SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Xử lý khi bấm nút Đăng Nhập
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text.Trim();
            string password = txbPassWord.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mã hóa mật khẩu người dùng vừa nhập
            string hashPass = HashPassword(password);

            // Dùng LINQ tìm user trong database
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hashPass);

            if (user != null)
            {
                string tenVaiTro = user.Role.RoleName;
                MessageBox.Show("Đăng nhập thành công với vai trò: " + tenVaiTro, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quan trọng: Lưu thông tin tài khoản đang đăng nhập để truyền sang cho code của Kiên
                frmMain.CurrentUser = user;

                // Mở FormMain và truyền quyền sang để ẩn/hiện nút
                frmMain frm = new frmMain();
                frm.PhanQuyen(tenVaiTro);
                frm.Show();

                // Ẩn form đăng nhập đi
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        // Xử lý CheckBox Ẩn/Hiện mật khẩu
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txbPassWord.PasswordChar = '\0'; // Hiện rõ chữ
            else
                txbPassWord.PasswordChar = '*';  // Ẩn thành dấu sao
        }

        // Xử lý nút Thoát
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}