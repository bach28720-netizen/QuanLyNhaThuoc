using System;
using System.Linq;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public class frmDatLich : Form
    {
        private readonly ComboBox cboPatient = new ComboBox();
        private readonly ComboBox cboDoctor = new ComboBox();
        private readonly DateTimePicker dtpDate = new DateTimePicker();
        private readonly ComboBox cboStatus = new ComboBox();
        private readonly DataGridView grid = new DataGridView();
        private readonly TextBox txtSearch = new TextBox();
        private int selectedId;

        public frmDatLich()
        {
            Text = "Đặt lịch khám"; Width = 1000; Height = 650; StartPosition = FormStartPosition.CenterScreen;
            BuildUi(); LoadCombos(); LoadAppointments();
        }

        private void BuildUi()
        {
            var p = new Panel { Dock = DockStyle.Top, Height = 150, Padding = new Padding(12) }; Controls.Add(p);
            p.Controls.Add(new Label { Text = "Bệnh nhân", Left = 12, Top = 18, Width = 80 });
            cboPatient.SetBounds(95, 14, 230, 25); cboPatient.DropDownStyle = ComboBoxStyle.DropDownList; p.Controls.Add(cboPatient);
            p.Controls.Add(new Label { Text = "Bác sĩ", Left = 350, Top = 18, Width = 60 });
            cboDoctor.SetBounds(410, 14, 220, 25); cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList; p.Controls.Add(cboDoctor);
            p.Controls.Add(new Label { Text = "Ngày giờ", Left = 12, Top = 58, Width = 80 });
            dtpDate.SetBounds(95, 54, 230, 25); dtpDate.Format = DateTimePickerFormat.Custom; dtpDate.CustomFormat = "dd/MM/yyyy HH:mm"; dtpDate.ShowUpDown = true; p.Controls.Add(dtpDate);
            p.Controls.Add(new Label { Text = "Trạng thái", Left = 350, Top = 58, Width = 60 });
            cboStatus.SetBounds(410, 54, 220, 25); cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[] { "Chờ khám", "Đang khám", "Đã khám", "Đã hủy" }); cboStatus.SelectedIndex = 0; p.Controls.Add(cboStatus);
            p.Controls.Add(new Label { Text = "Tìm", Left = 660, Top = 18, Width = 35 });
            txtSearch.SetBounds(700, 14, 240, 25); p.Controls.Add(txtSearch); txtSearch.TextChanged += (s,e) => LoadAppointments(txtSearch.Text.Trim());
            AddButton(p, "Tạo lịch", 660, 55, CreateAppointment); AddButton(p, "Cập nhật", 750, 55, UpdateAppointment); AddButton(p, "Hủy lịch", 840, 55, CancelAppointment);
            grid.Dock = DockStyle.Fill; grid.ReadOnly = true; grid.AllowUserToAddRows = false; grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; grid.SelectionChanged += (s,e) => SelectRow(); Controls.Add(grid);
        }

        private static void AddButton(Control p, string t, int x, int y, EventHandler h)
        { var b = new Button { Text=t, Left=x, Top=y, Width=85, Height=30 }; b.Click += h; p.Controls.Add(b); }

        private void LoadCombos()
        {
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    cboPatient.DataSource = db.Patients.OrderBy(x => x.FullName).ToList();
                    cboPatient.DisplayMember = "FullName"; cboPatient.ValueMember = "PatientID";
                    var docs = (from u in db.Users
                                join r in db.Roles on u.RoleID equals r.RoleID
                                where r.RoleName.ToLower().Contains("bác sĩ") || r.RoleName.ToLower().Contains("doctor")
                                orderby u.FullName select u).ToList();
                    cboDoctor.DataSource = docs; cboDoctor.DisplayMember = "FullName"; cboDoctor.ValueMember = "UserID";
                }
                if (cboDoctor.Items.Count == 0) MessageBox.Show("Chưa có tài khoản mang vai trò Bác sĩ trong bảng Users/Roles.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách: " + ex.Message); }
        }

        private void LoadAppointments(string keyword = "")
        {
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var q = from a in db.Appointments
                            join p in db.Patients on a.PatientID equals p.PatientID
                            join u in db.Users on a.DoctorID equals u.UserID
                            select new { a.ApptID, a.PatientID, a.DoctorID, p.FullName, DoctorName = u.FullName, a.ApptDate, a.Status };
                    if (!string.IsNullOrWhiteSpace(keyword)) q = q.Where(x => x.FullName.Contains(keyword) || x.DoctorName.Contains(keyword));
                    grid.DataSource = q.OrderByDescending(x => x.ApptDate).ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Không tải được lịch: " + ex.Message); }
        }

        private void SelectRow()
        {
            if (grid.CurrentRow == null || grid.CurrentRow.DataBoundItem == null) return;
            dynamic r = grid.CurrentRow.DataBoundItem;
            selectedId = Convert.ToInt32(r.ApptID);
            cboPatient.SelectedValue = Convert.ToInt32(r.PatientID);
            cboDoctor.SelectedValue = Convert.ToInt32(r.DoctorID);
            if (r.ApptDate != null) dtpDate.Value = Convert.ToDateTime(r.ApptDate);
            cboStatus.Text = Convert.ToString(r.Status);
        }

        private bool ValidateInput()
        {
            if (cboPatient.SelectedValue == null || cboDoctor.SelectedValue == null)
            { MessageBox.Show("Cần có bệnh nhân và bác sĩ trước khi đặt lịch."); return false; }
            if (dtpDate.Value < DateTime.Now.AddMinutes(-5))
            { MessageBox.Show("Không thể đặt lịch ở thời điểm đã qua."); return false; }
            return true;
        }

        private void CreateAppointment(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    int pid = Convert.ToInt32(cboPatient.SelectedValue), did = Convert.ToInt32(cboDoctor.SelectedValue);
                    bool conflict = db.Appointments.Any(a => a.DoctorID == did && a.ApptDate == dtpDate.Value && a.Status != "Đã hủy");
                    if (conflict) { MessageBox.Show("Bác sĩ đã có lịch tại đúng thời điểm này."); return; }
                    db.Appointments.Add(new Appointment { PatientID = pid, DoctorID = did, ApptDate = dtpDate.Value, Status = "Chờ khám" });
                    db.SaveChanges();
                }
                LoadAppointments(); MessageBox.Show("Đã tạo lịch. Lịch mới sẽ xuất hiện trong danh sách chờ khám.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tạo lịch: " + ex.Message); }
        }

        private void UpdateAppointment(object sender, EventArgs e)
        {
            if (selectedId == 0 || !ValidateInput()) { MessageBox.Show("Chọn lịch cần cập nhật."); return; }
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    int did = Convert.ToInt32(cboDoctor.SelectedValue);
                    if (db.Appointments.Any(a => a.ApptID != selectedId && a.DoctorID == did && a.ApptDate == dtpDate.Value && a.Status != "Đã hủy"))
                    { MessageBox.Show("Bác sĩ đã có lịch tại đúng thời điểm này."); return; }
                    var appt = db.Appointments.Find(selectedId); if (appt == null) return;
                    appt.PatientID = Convert.ToInt32(cboPatient.SelectedValue); appt.DoctorID = did;
                    appt.ApptDate = dtpDate.Value; appt.Status = cboStatus.Text; db.SaveChanges();
                }
                LoadAppointments(); MessageBox.Show("Đã cập nhật lịch.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        private void CancelAppointment(object sender, EventArgs e)
        {
            if (selectedId == 0) { MessageBox.Show("Chọn lịch cần hủy."); return; }
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                { var a = db.Appointments.Find(selectedId); if (a == null) return; a.Status = "Đã hủy"; db.SaveChanges(); }
                LoadAppointments(); MessageBox.Show("Đã hủy lịch.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi hủy lịch: " + ex.Message); }
        }
    }
}
