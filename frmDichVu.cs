using System;
using System.Linq;
using System.Windows.Forms;

namespace Quản_lý_phòng_khám
{
    public class frmDichVu : Form
    {
        private readonly TextBox txtId = new TextBox();
        private readonly TextBox txtName = new TextBox();
        private readonly NumericUpDown numPrice = new NumericUpDown();
        private readonly TextBox txtSearch = new TextBox();
        private readonly DataGridView grid = new DataGridView();

        public frmDichVu()
        {
            Text = "Quản lý dịch vụ khám"; Width = 900; Height = 600; StartPosition = FormStartPosition.CenterScreen;
            var p = new Panel { Dock = DockStyle.Top, Height = 125, Padding = new Padding(12) }; Controls.Add(p);
            AddLabel(p, "Mã dịch vụ", 12, 15); txtId.SetBounds(100, 12, 150, 25); p.Controls.Add(txtId);
            AddLabel(p, "Tên dịch vụ", 280, 15); txtName.SetBounds(370, 12, 250, 25); p.Controls.Add(txtName);
            AddLabel(p, "Giá", 12, 55); numPrice.SetBounds(100, 52, 150, 25); numPrice.Maximum = 1000000000; numPrice.ThousandsSeparator = true; p.Controls.Add(numPrice);
            AddLabel(p, "Tìm", 280, 55); txtSearch.SetBounds(370, 52, 250, 25); p.Controls.Add(txtSearch);
            txtSearch.TextChanged += (s, e) => LoadServices(txtSearch.Text.Trim());

            // Sửa logic các nút
            AddButton(p, "Thêm", 650, 10, SaveService);
            AddButton(p, "Sửa", 740, 10, SaveService);
            AddButton(p, "Xóa", 650, 50, DeleteService);
            AddButton(p, "Làm mới", 740, 50, (s, e) => { ClearForm(); LoadServices(); });

            grid.Dock = DockStyle.Fill; grid.ReadOnly = true; grid.AllowUserToAddRows = false; grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; grid.SelectionChanged += SelectRow;
            Controls.Add(grid);
            grid.BringToFront(); // Fix lỗi mất bảng dữ liệu
            LoadServices();
        }

        private static void AddLabel(Control p, string t, int x, int y) { p.Controls.Add(new Label { Text = t, Left = x, Top = y + 4, Width = 85 }); }
        private static void AddButton(Control p, string t, int x, int y, EventHandler h) { var b = new Button { Text = t, Left = x, Top = y, Width = 80, Height = 30 }; b.Click += h; p.Controls.Add(b); }

        private void LoadServices(string keyword = "")
        {
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var q = db.Services.AsQueryable();
                    if (!string.IsNullOrWhiteSpace(keyword)) q = q.Where(x => x.ServiceID.Contains(keyword) || x.ServiceName.Contains(keyword));
                    grid.DataSource = q.OrderBy(x => x.ServiceName).Select(x => new { x.ServiceID, x.ServiceName, x.Price }).ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dịch vụ: " + ex.Message); }
        }

        private void SelectRow(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.DataBoundItem == null) return;
            dynamic r = grid.CurrentRow.DataBoundItem;
            txtId.Text = Convert.ToString(r.ServiceID); txtName.Text = Convert.ToString(r.ServiceName);
            numPrice.Value = Math.Min(numPrice.Maximum, Convert.ToDecimal(r.Price ?? 0m));
        }

        private void ClearForm() { txtId.Clear(); txtName.Clear(); numPrice.Value = 0; txtId.Focus(); }

        private void SaveService(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Nhập mã và tên dịch vụ."); return; }
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var s = db.Services.Find(txtId.Text.Trim());
                    if (s == null) { s = new Service { ServiceID = txtId.Text.Trim() }; db.Services.Add(s); }
                    s.ServiceName = txtName.Text.Trim(); s.Price = numPrice.Value; db.SaveChanges();
                }
                LoadServices(); ClearForm(); MessageBox.Show("Đã lưu dịch vụ.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu dịch vụ: " + ex.Message); }
        }

        private void DeleteService(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) { MessageBox.Show("Chọn dịch vụ cần xóa."); return; }
            if (MessageBox.Show("Xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                using (var db = new QuanLyPhongKhamMedproEntities())
                {
                    var s = db.Services.Find(txtId.Text.Trim()); if (s == null) return;
                    db.Services.Remove(s); db.SaveChanges();
                }
                LoadServices(); ClearForm();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa dịch vụ: " + ex.Message); }
        }
    }
}