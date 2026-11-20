using System;
using System.Linq;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public class frmBenhNhan : Form
    {
        private readonly TextBox txtId = new TextBox();
        private readonly TextBox txtName = new TextBox();
        private readonly TextBox txtPhone = new TextBox();
        private readonly TextBox txtAddress = new TextBox();
        private readonly DateTimePicker dtpDob = new DateTimePicker();
        private readonly TextBox txtSearch = new TextBox();
        private readonly DataGridView grid = new DataGridView();

        public frmBenhNhan()
        {
            Text = "Quản lý bệnh nhân";
            Width = 980; Height = 650; StartPosition = FormStartPosition.CenterScreen;
            BuildUi();
            LoadPatients();
        }

        private void BuildUi()
        {
            var panel = new Panel { Dock = DockStyle.Top, Height = 185, Padding = new Padding(12) };
            Controls.Add(panel);

            AddLabel(panel, "Mã BN", 12, 15);
            txtId.SetBounds(100, 12, 120, 25);
            txtId.ReadOnly = false; // Đã mở khóa để nhập
            panel.Controls.Add(txtId);

            AddLabel(panel, "Họ tên", 250, 15); txtName.SetBounds(330, 12, 260, 25); panel.Controls.Add(txtName);
            AddLabel(panel, "Điện thoại", 12, 55); txtPhone.SetBounds(100, 52, 180, 25); panel.Controls.Add(txtPhone);
            AddLabel(panel, "Ngày sinh", 310, 55); dtpDob.SetBounds(390, 52, 200, 25); dtpDob.Format = DateTimePickerFormat.Short; panel.Controls.Add(dtpDob);
            AddLabel(panel, "Địa chỉ", 12, 95); txtAddress.SetBounds(100, 92, 490, 25); panel.Controls.Add(txtAddress);
            AddLabel(panel, "Tìm", 620, 15); txtSearch.SetBounds(665, 12, 250, 25); panel.Controls.Add(txtSearch);
            txtSearch.TextChanged += (s, e) => LoadPatients(txtSearch.Text.Trim());

            // Sửa logic các nút
            AddButton(panel, "Thêm", 620, 55, SavePatient);
            AddButton(panel, "Sửa", 710, 55, SavePatient);
            AddButton(panel, "Xóa", 800, 55, DeletePatient);
            AddButton(panel, "Làm mới", 620, 95, (s, e) => { ClearForm(); LoadPatients(); });

            grid.Dock = DockStyle.Fill; grid.ReadOnly = true; grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionChanged += GridSelectionChanged;
            Controls.Add(grid);
            grid.BringToFront(); // Fix lỗi mất bảng dữ liệu
        }

        private static void AddLabel(Control p, string text, int x, int y)
        { p.Controls.Add(new Label { Text = text, Left = x, Top = y + 4, Width = 80 }); }
        private static void AddButton(Control p, string text, int x, int y, EventHandler click)
        { var b = new Button { Text = text, Left = x, Top = y, Width = 85, Height = 30 }; b.Click += click; p.Controls.Add(b); }

        private void LoadPatients(string keyword = "")
        {
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var q = db.Patients.AsQueryable();
                    if (!string.IsNullOrWhiteSpace(keyword))
                        q = q.Where(x => x.FullName.Contains(keyword) || x.Phone.Contains(keyword));
                    grid.DataSource = q.OrderByDescending(x => x.PatientID)
                        .Select(x => new { x.PatientID, x.FullName, x.Phone, x.Address, x.DOB }).ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Không tải được bệnh nhân: " + ex.Message); }
        }

        private void GridSelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.DataBoundItem == null) return;
            try
            {
                dynamic r = grid.CurrentRow.DataBoundItem;
                txtId.Text = Convert.ToString(r.PatientID);
                txtName.Text = Convert.ToString(r.FullName);
                txtPhone.Text = Convert.ToString(r.Phone);
                txtAddress.Text = Convert.ToString(r.Address);
                if (r.DOB != null && r.DOB != DBNull.Value) dtpDob.Value = Convert.ToDateTime(r.DOB);
            }
            catch { }
        }

        private void ClearForm()
        { txtId.Clear(); txtName.Clear(); txtPhone.Clear(); txtAddress.Clear(); dtpDob.Value = DateTime.Today.AddYears(-18); txtId.Focus(); }

        private void SavePatient(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Vui lòng nhập họ tên."); return; }
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    Patient p = null;
                    if (int.TryParse(txtId.Text, out int id) && db.Patients.Any(x => x.PatientID == id))
                    {
                        p = db.Patients.Find(id); // Sửa nếu ID đã có
                    }
                    else
                    {
                        p = new Patient(); // Thêm mới
                        db.Patients.Add(p);
                    }

                    p.FullName = txtName.Text.Trim();
                    p.Phone = txtPhone.Text.Trim();
                    p.Address = txtAddress.Text.Trim();
                    p.DOB = dtpDob.Value.Date;
                    db.SaveChanges();
                }
                LoadPatients(); ClearForm(); MessageBox.Show("Đã lưu bệnh nhân thành công.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu bệnh nhân: " + ex.Message); }
        }

        private void DeletePatient(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("Chọn bệnh nhân cần xóa."); return; }
            if (MessageBox.Show("Xóa bệnh nhân này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var p = db.Patients.Find(id);
                    if (p == null) return;
                    if (db.Appointments.Any(a => a.PatientID == id))
                    { MessageBox.Show("Bệnh nhân đã có lịch khám nên không thể xóa."); return; }
                    db.Patients.Remove(p); db.SaveChanges();
                }
                LoadPatients(); ClearForm();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }
    }
}