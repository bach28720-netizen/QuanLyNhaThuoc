using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public partial class frmHoaDon : Form
    {
        private readonly string connectionString = @"Data Source=localhost;Initial Catalog=QuanLyPhongKhamMedpro;Integrated Security=True;TrustServerCertificate=True";

        public frmHoaDon()
        {
            InitializeComponent();
            dgvChiTietHoaDon.AllowUserToAddRows = false;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadDataToComboBox();
        }

        private void LoadDataToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT MedID AS MaThuoc, MedName AS TenThuoc, Price AS DonGia, StockQuantity AS SoLuongTon FROM Medicines WHERE StockQuantity > 0";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dtThuoc = new DataTable();
                    da.Fill(dtThuoc);

                    cboThuoc.DataSource = dtThuoc;
                    cboThuoc.DisplayMember = "TenThuoc";
                    cboThuoc.ValueMember = "MaThuoc";

                    cboThuoc.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedIndex != -1 && cboThuoc.SelectedItem is DataRowView drv)
            {
                txtDonGia.Text = drv["DonGia"].ToString();
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một loại thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudSoLuongMua.Value <= 0)
            {
                MessageBox.Show("Số lượng mua phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = (DataRowView)cboThuoc.SelectedItem;

            string maThuoc = drv["MaThuoc"].ToString();
            string tenThuoc = drv["TenThuoc"].ToString();
            decimal donGia = Convert.ToDecimal(drv["DonGia"]);
            int soLuong = Convert.ToInt32(nudSoLuongMua.Value);
            int tonKho = Convert.ToInt32(drv["SoLuongTon"]);

            decimal thanhTien = donGia * soLuong;
            bool daTonTai = false;

            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ColMaThuoc"].Value.ToString() == maThuoc)
                {
                    int soLuongCu = Convert.ToInt32(row.Cells["ColSoLuong"].Value);
                    int soLuongMoi = soLuongCu + soLuong;

                    if (soLuongMoi > tonKho)
                    {
                        MessageBox.Show($"Kho không đủ! Thuốc này chỉ còn {tonKho} đơn vị.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["ColSoLuong"].Value = soLuongMoi;
                    row.Cells["ColThanhTien"].Value = soLuongMoi * donGia;

                    daTonTai = true;
                    break;
                }
            }

            if (!daTonTai)
            {
                if (soLuong > tonKho)
                {
                    MessageBox.Show($"Kho không đủ! Thuốc này chỉ còn {tonKho} đơn vị.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dgvChiTietHoaDon.Rows.Add(maThuoc, tenThuoc, soLuong, donGia, thanhTien);
            }

            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ColThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["ColThanhTien"].Value);
                }
            }

            txtTongTien.Text = tongTien.ToString("#,##0");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text.Trim()) || dgvChiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã HĐ và phải có ít nhất 1 loại thuốc trong giỏ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTienThanhToan = 0;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.IsNewRow) continue;
                tongTienThanhToan += Convert.ToDecimal(row.Cells["ColThanhTien"].Value);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string sqlHoaDon = "INSERT INTO HoaDon (MaHD, NgayLap, TenKH, TongTien) VALUES (@MaHD, @NgayLap, @TenKH, @TongTien)";

                    using (SqlCommand cmdHoaDon = new SqlCommand(sqlHoaDon, conn, transaction))
                    {
                        cmdHoaDon.Parameters.AddWithValue("@MaHD", txtMaHD.Text.Trim());
                        cmdHoaDon.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                        cmdHoaDon.Parameters.AddWithValue("@TenKH", txtTenKH.Text.Trim());
                        cmdHoaDon.Parameters.AddWithValue("@TongTien", tongTienThanhToan);

                        cmdHoaDon.ExecuteNonQuery();
                    }

                    foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string maThuoc = row.Cells["ColMaThuoc"].Value.ToString();
                        int soLuongBan = Convert.ToInt32(row.Cells["ColSoLuong"].Value);
                        decimal thanhTien = Convert.ToDecimal(row.Cells["ColThanhTien"].Value);

                        string sqlChiTiet = "INSERT INTO ChiTietHoaDon (MaHD, MaThuoc, SoLuongBan, ThanhTien) VALUES (@MaHD, @MaThuoc, @SoLuongBan, @ThanhTien)";
                        using (SqlCommand cmdChiTiet = new SqlCommand(sqlChiTiet, conn, transaction))
                        {
                            cmdChiTiet.Parameters.AddWithValue("@MaHD", txtMaHD.Text.Trim());
                            cmdChiTiet.Parameters.AddWithValue("@MaThuoc", maThuoc);
                            cmdChiTiet.Parameters.AddWithValue("@SoLuongBan", soLuongBan);
                            cmdChiTiet.Parameters.AddWithValue("@ThanhTien", thanhTien);

                            cmdChiTiet.ExecuteNonQuery();
                        }

                        string sqlTruKho = "UPDATE Medicines SET StockQuantity = StockQuantity - @SoLuongBan WHERE MedID = @MaThuoc AND StockQuantity >= @SoLuongBan";
                        using (SqlCommand cmdTruKho = new SqlCommand(sqlTruKho, conn, transaction))
                        {
                            cmdTruKho.Parameters.AddWithValue("@SoLuongBan", soLuongBan);
                            cmdTruKho.Parameters.AddWithValue("@MaThuoc", maThuoc);

                            int rowsAffected = cmdTruKho.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                throw new Exception($"Thuốc có mã {maThuoc} không đủ số lượng để bán!");
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Thanh toán thành công! Đã trừ tồn kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmBaoCao frmIn = new frmBaoCao(txtMaHD.Text.Trim());
                    frmIn.ShowDialog();

                    dgvChiTietHoaDon.Rows.Clear();
                    txtTongTien.Clear();
                    txtMaHD.Clear();
                    txtTenKH.Clear();
                    LoadDataToComboBox();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi giao dịch! Hệ thống đã khôi phục lại trạng thái ban đầu.\nChi tiết lỗi: " + ex.Message, "Lỗi Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}