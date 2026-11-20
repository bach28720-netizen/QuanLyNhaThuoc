using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public partial class frmThietBi : Form
    {
        private readonly string connectionString = @"Data Source=localhost;Initial Catalog=QuanLyPhongKhamMedpro;Integrated Security=True;TrustServerCertificate=True";

        public frmThietBi()
        {
            InitializeComponent();
            nudSoLuongTB.Maximum = 100000;
        }

        private void frmThietBi_Load(object sender, EventArgs e)
        {
            LoadDataThietBi();
        }

        private void LoadDataThietBi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT EquipID AS MaTB, EquipName AS TenTB, EquipType AS LoaiTB, Quantity AS SoLuong FROM Equipments";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvThietBi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ClearInput()
        {
            txtMaTB.Clear();
            txtTenTB.Clear();
            txtLoaiTB.Clear();

            nudSoLuongTB.Value = nudSoLuongTB.Minimum;

            txtMaTB.Enabled = true;
            txtMaTB.Focus();
        }

        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvThietBi.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvThietBi.Rows[e.RowIndex];

                txtMaTB.Text = row.Cells["MaTB"].Value?.ToString();
                txtTenTB.Text = row.Cells["TenTB"].Value?.ToString();
                txtLoaiTB.Text = row.Cells["LoaiTB"].Value?.ToString();

                if (row.Cells["SoLuong"].Value != null && row.Cells["SoLuong"].Value != DBNull.Value)
                {
                    decimal val = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                    nudSoLuongTB.Value = Math.Min(nudSoLuongTB.Maximum, Math.Max(nudSoLuongTB.Minimum, val));
                }
                else
                {
                    nudSoLuongTB.Value = nudSoLuongTB.Minimum;
                }

                txtMaTB.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTB.Text.Trim()) || string.IsNullOrEmpty(txtTenTB.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên thiết bị!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Equipments (EquipID, EquipName, EquipType, Quantity, Status) VALUES (@Ma, @Ten, @Loai, @SL, N'Đang sử dụng')";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma", txtMaTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ten", txtTenTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@Loai", txtLoaiTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@SL", Convert.ToInt32(nudSoLuongTB.Value));

                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataThietBi();
                ClearInput();
                MessageBox.Show("Thêm thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("Mã thiết bị bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTB.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn một thiết bị để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Equipments SET EquipName=@Ten, EquipType=@Loai, Quantity=@SL WHERE EquipID=@Ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", txtTenTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@Loai", txtLoaiTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@SL", Convert.ToInt32(nudSoLuongTB.Value));
                        cmd.Parameters.AddWithValue("@Ma", txtMaTB.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataThietBi();
                ClearInput();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTB.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM Equipments WHERE EquipID=@Ma";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", txtMaTB.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadDataThietBi();
                    ClearInput();
                    MessageBox.Show("Đã xóa thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) MessageBox.Show("Không thể xóa thiết bị đang được sử dụng ở bảng khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}