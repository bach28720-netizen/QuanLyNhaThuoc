using System;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public class frmKhamBenh : Form
    {
        private readonly DataGridView grid = new DataGridView();
        private readonly TextBox txtSymptoms = new TextBox();
        private readonly TextBox txtDiagnosis = new TextBox();
        private readonly TextBox txtConclusion = new TextBox();
        private readonly CheckedListBox lstServices = new CheckedListBox();
        private readonly ComboBox cboDoctor = new ComboBox();
        private int apptId;
        private int patientId;

        public frmKhamBenh()
        {
            Text = "Khám bệnh – danh sách chờ"; Width = 1150; Height = 760; StartPosition = FormStartPosition.CenterScreen;
            BuildUi(); LoadDoctors(); LoadServices(); LoadWaitingList();
        }

        private void BuildUi()
        {
            var top = new Panel { Dock = DockStyle.Top, Height = 58, Padding = new Padding(10) }; Controls.Add(top);
            top.Controls.Add(new Label { Text = "Bác sĩ", Left = 10, Top = 16, Width = 55 });
            cboDoctor.SetBounds(70, 12, 230, 26); cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList; top.Controls.Add(cboDoctor);
            var refresh = new Button { Text = "Tải danh sách", Left = 320, Top = 10, Width = 110, Height = 30 }; refresh.Click += (s,e) => LoadWaitingList(); top.Controls.Add(refresh);
            grid.Dock = DockStyle.Top; grid.Height = 235; grid.ReadOnly = true; grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionChanged += SelectAppointment; Controls.Add(grid);
            var form = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12), AutoScroll = true }; Controls.Add(form);
            AddLabel(form, "Triệu chứng", 12, 15); txtSymptoms.SetBounds(115, 12, 500, 55); txtSymptoms.Multiline = true; form.Controls.Add(txtSymptoms);
            AddLabel(form, "Chẩn đoán", 12, 85); txtDiagnosis.SetBounds(115, 82, 500, 55); txtDiagnosis.Multiline = true; form.Controls.Add(txtDiagnosis);
            AddLabel(form, "Kết luận", 12, 155); txtConclusion.SetBounds(115, 152, 500, 55); txtConclusion.Multiline = true; form.Controls.Add(txtConclusion);
            AddLabel(form, "Dịch vụ", 650, 15); lstServices.SetBounds(720, 12, 360, 195); lstServices.CheckOnClick = true; form.Controls.Add(lstServices);
            var start = new Button { Text = "Nhận khám", Left = 115, Top = 230, Width = 110, Height = 34 }; start.Click += StartExam; form.Controls.Add(start);
            var save = new Button { Text = "Lưu kết quả", Left = 240, Top = 230, Width = 120, Height = 34 }; save.Click += SaveExam; form.Controls.Add(save);
            var done = new Button { Text = "Hoàn tất khám", Left = 375, Top = 230, Width = 120, Height = 34 }; done.Click += CompleteExam; form.Controls.Add(done);
        }

        private static void AddLabel(Control p, string t, int x, int y) { p.Controls.Add(new Label { Text=t, Left=x, Top=y+4, Width=100 }); }

        private void LoadDoctors()
        {
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var docs = (from u in db.Users join r in db.Roles on u.RoleID equals r.RoleID
                                where r.RoleName.ToLower().Contains("bác sĩ") || r.RoleName.ToLower().Contains("doctor")
                                orderby u.FullName select u).ToList();
                    cboDoctor.DataSource = docs; cboDoctor.DisplayMember = "FullName"; cboDoctor.ValueMember = "UserID";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải bác sĩ: " + ex.Message); }
        }

        private void LoadServices()
        {
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                    foreach (var s in db.Services.OrderBy(x => x.ServiceName).ToList())
                        lstServices.Items.Add(new ServiceChoice { ID=s.ServiceID, Name=s.ServiceName, Price=s.Price ?? 0m }, false);
                lstServices.DisplayMember = "Display";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dịch vụ: " + ex.Message); }
        }

        private void LoadWaitingList()
        {
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var q = from a in db.Appointments
                            join p in db.Patients on a.PatientID equals p.PatientID
                            join u in db.Users on a.DoctorID equals u.UserID
                            where a.Status == "Chờ khám" || a.Status == "Đang khám"
                            select new { a.ApptID, a.PatientID, a.DoctorID, p.FullName, p.Phone, a.ApptDate, a.Status, DoctorName=u.FullName };
                    if (cboDoctor.SelectedValue != null)
                    {
                        int did; if (int.TryParse(cboDoctor.SelectedValue.ToString(), out did)) q = q.Where(x => x.DoctorID == did);
                    }
                    grid.DataSource = q.OrderBy(x => x.ApptDate).ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách chờ: " + ex.Message); }
        }

        private void SelectAppointment(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.DataBoundItem == null) return;
            dynamic r = grid.CurrentRow.DataBoundItem;
            apptId = Convert.ToInt32(r.ApptID); patientId = Convert.ToInt32(r.PatientID);
            try
            {
                using (var clinical = new ClinicalDbContext())
                {
                    var exam = clinical.Examinations.FirstOrDefault(x => x.ApptID == apptId);
                    txtSymptoms.Text = exam == null ? "" : exam.Symptoms;
                    txtDiagnosis.Text = exam == null ? "" : exam.Diagnosis;
                    txtConclusion.Text = exam == null ? "" : exam.Conclusion;
                    for (int i=0; i<lstServices.Items.Count; i++) lstServices.SetItemChecked(i, false);
                    if (exam != null)
                    {
                        var ids = clinical.ExaminationServices.Where(x => x.ExaminationID == exam.ExaminationID).Select(x => x.ServiceID).ToList();
                        for (int i=0; i<lstServices.Items.Count; i++)
                            if (ids.Contains(((ServiceChoice)lstServices.Items[i]).ID)) lstServices.SetItemChecked(i, true);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải hồ sơ khám: " + ex.Message); }
        }

        private void StartExam(object sender, EventArgs e)
        {
            if (apptId == 0) { MessageBox.Show("Chọn bệnh nhân trong danh sách."); return; }
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var a = db.Appointments.Find(apptId); if (a == null) return;
                    if (a.Status == "Đã hủy" || a.Status == "Đã khám") { MessageBox.Show("Lịch đã hủy hoặc đã hoàn tất."); return; }
                    a.Status = "Đang khám"; db.SaveChanges();
                }
                LoadWaitingList();
            }
            catch (Exception ex) { MessageBox.Show("Không thể nhận khám: " + ex.Message); }
        }

        private void SaveExam(object sender, EventArgs e)
        {
            PersistExam();
        }

        private bool PersistExam()
        {
            if (apptId == 0) { MessageBox.Show("Chọn lịch khám trước."); return false; }
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text)) { MessageBox.Show("Vui lòng nhập chẩn đoán."); return false; }
            using (var db = new QuanLyPhongKhamMedproEntities())
            using (var clinical = new ClinicalDbContext())
            using (var tx = clinical.Database.BeginTransaction())
            {
                try
                {
                    var a = db.Appointments.Find(apptId);
                    if (a == null || a.Status == "Đã hủy") throw new InvalidOperationException("Lịch không hợp lệ hoặc đã hủy.");
                    var exam = clinical.Examinations.FirstOrDefault(x => x.ApptID == apptId);
                    if (exam == null)
                    {
                        exam = new ClinicalExamination { ApptID=apptId, ExaminationDate=DateTime.Now };
                        clinical.Examinations.Add(exam);
                        clinical.SaveChanges();
                    }
                    exam.Symptoms = txtSymptoms.Text.Trim();
                    exam.Diagnosis = txtDiagnosis.Text.Trim();
                    exam.Conclusion = txtConclusion.Text.Trim();
                    exam.ExaminationDate = DateTime.Now;
                    clinical.SaveChanges();

                    var old = clinical.ExaminationServices.Where(x => x.ExaminationID == exam.ExaminationID).ToList();
                    clinical.ExaminationServices.RemoveRange(old);
                    foreach (ServiceChoice item in lstServices.CheckedItems)
                        clinical.ExaminationServices.Add(new ClinicalExaminationService {
                            ExaminationID=exam.ExaminationID, ServiceID=item.ID, Quantity=1, UnitPrice=item.Price
                        });
                    clinical.SaveChanges();
                    tx.Commit();
                    MessageBox.Show("Đã lưu hồ sơ khám và dịch vụ chỉ định.");
                    return true;
                }
                catch (Exception ex) { tx.Rollback(); MessageBox.Show("Lỗi lưu hồ sơ khám: " + ex.Message); return false; }
            }
        }

        private void CompleteExam(object sender, EventArgs e)
        {
            if (apptId == 0) { MessageBox.Show("Chọn lịch khám."); return; }
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text)) { MessageBox.Show("Hãy lưu chẩn đoán trước khi hoàn tất."); return; }
            if (!PersistExam()) return;
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                { var a=db.Appointments.Find(apptId); if (a==null) return; a.Status="Đã khám"; db.SaveChanges(); }
                LoadWaitingList(); MessageBox.Show("Đã hoàn tất lượt khám.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message); }
        }

        private class ServiceChoice
        {
            public string ID; public string Name; public decimal Price;
            public string Display { get { return Name + " – " + Price.ToString("N0") + " đ"; } }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmKhamBenh
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "frmKhamBenh";
            this.Load += new System.EventHandler(this.frmKhamBenh_Load);
            this.ResumeLayout(false);

        }

        private void frmKhamBenh_Load(object sender, EventArgs e)
        {

        }
    }
}
