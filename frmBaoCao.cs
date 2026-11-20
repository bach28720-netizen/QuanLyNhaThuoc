using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Quản_lý_phòng_khám
{
    public partial class frmBaoCao : Form
    {
        private readonly string connectionString = @"Data Source=localhost;Initial Catalog=QuanLyPhongKhamMedpro;Integrated Security=True;TrustServerCertificate=True";
        private string MaHD;

        public frmBaoCao()
        {
            InitializeComponent();
        }

        public frmBaoCao(string maHoaDon)
        {
            InitializeComponent();
            this.MaHD = maHoaDon;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaHD))
            {
                MaHD = LayMaHoaDonMoiNhat();
            }

            if (!string.IsNullOrEmpty(MaHD))
            {
                LoadBaoCao(MaHD);
            }
            else
            {
                MessageBox.Show("Chưa có hóa đơn nào trong hệ thống để hiển thị báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string LayMaHoaDonMoiNhat()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT TOP 1 MaHD FROM HoaDon ORDER BY NgayLap DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        private void LoadBaoCao(string maHD)
        {
            string sql = @"
                SELECT 
                    hd.MaHD, hd.NgayLap, hd.TenKH, hd.TongTien,
                    th.MedName AS TenThuoc, ct.SoLuongBan AS SoLuong, th.Price AS DonGia, ct.ThanhTien
                FROM HoaDon hd
                INNER JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                INNER JOIN Medicines th ON ct.MaThuoc = th.MedID
                WHERE hd.MaHD = @MaHD";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    try
                    {
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            rpvBaoCao.LocalReport.DataSources.Clear();
                            rpvBaoCao.LocalReport.ReportEmbeddedResource = "Quản_lý_phòng_khám.rptHoaDon.rdlc";

                            ReportDataSource rds = new ReportDataSource("DataSetHoaDon", dt);
                            rpvBaoCao.LocalReport.DataSources.Add(rds);

                            this.rpvBaoCao.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu cho hóa đơn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}