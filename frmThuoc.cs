using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public partial class frmThuoc : Form
    {
        private readonly string connectionString = @"Data Source=localhost;Initial Catalog=QuanLyPhongKhamMedpro;Integrated Security=True;TrustServerCertificate=True";

        public frmThuoc()
        {
            InitializeComponent();
        }

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT MedID AS MaThuoc, MedName AS TenThuoc, StockQuantity AS SoLuongTon, Price AS DonGia FROM Medicines";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThuoc.DataSource = dt;
            }
        }

        private void ClearInput()
        {
            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            nudSoLuongTon.Value = 0;
            txtDonGia.Clear();
            txtMaThuoc.Enabled = true;
            txtMaThuoc.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaThuoc.Text.Trim()) || string.IsNullOrEmpty(txtTenThuoc.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã thuốc và Tên thuốc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ và không được âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Medicines (MedID, MedName, StockQuantity, Price) VALUES (@Ma, @Ten, @SL, @Gia)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma", txtMaThuoc.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ten", txtTenThuoc.Text.Trim());
                        cmd.Parameters.AddWithValue("@SL", Convert.ToInt32(nudSoLuongTon.Value));
                        cmd.Parameters.AddWithValue("@Gia", donGia);

                        cmd.ExecuteNonQuery();

                        LoadData();
                        ClearInput();
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Mã thuốc này đã tồn tại trong hệ thống. Vui lòng nhập mã khác!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvThuoc.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvThuoc.Rows[e.RowIndex];

                txtMaThuoc.Text = row.Cells["MaThuoc"].Value?.ToString();
                txtTenThuoc.Text = row.Cells["TenThuoc"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();

                if (row.Cells["SoLuongTon"].Value != null && row.Cells["SoLuongTon"].Value != DBNull.Value)
                {
                    decimal val = Convert.ToDecimal(row.Cells["SoLuongTon"].Value);
                    nudSoLuongTon.Value = Math.Min(nudSoLuongTon.Maximum, Math.Max(nudSoLuongTon.Minimum, val));
                }
                else
                {
                    nudSoLuongTon.Value = 0;
                }

                txtMaThuoc.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaThuoc.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn một loại thuốc từ danh sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ và không được âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Medicines SET MedName = @Ten, StockQuantity = @SL, Price = @Gia WHERE MedID = @Ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", txtTenThuoc.Text.Trim());
                        cmd.Parameters.AddWithValue("@SL", Convert.ToInt32(nudSoLuongTon.Value));
                        cmd.Parameters.AddWithValue("@Gia", donGia);
                        cmd.Parameters.AddWithValue("@Ma", txtMaThuoc.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    LoadData();
                    ClearInput();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaThuoc.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn một loại thuốc từ danh sách để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Medicines WHERE MedID = @Ma";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", txtMaThuoc.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        LoadData();
                        ClearInput();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException sqlEx)
                    {
                        if (sqlEx.Number == 547)
                        {
                            MessageBox.Show("Không thể xóa thuốc này vì nó đã được sử dụng trong hóa đơn!", "Lỗi Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi từ CSDL: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }
    }
}