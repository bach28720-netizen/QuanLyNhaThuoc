namespace Quản_lý_phòng_khám
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.rpvBaoCao = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBaoCao
            // 
            this.rpvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBaoCao.LocalReport.ReportEmbeddedResource = "Quản_lý_phòng_khám.rptHoaDon.rdlc";
            this.rpvBaoCao.Location = new System.Drawing.Point(0, 0);
            this.rpvBaoCao.Name = "rpvBaoCao";
            this.rpvBaoCao.ServerReport.BearerToken = null;
            this.rpvBaoCao.Size = new System.Drawing.Size(1225, 646);
            this.rpvBaoCao.TabIndex = 0;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 646);
            this.Controls.Add(this.rpvBaoCao);
            this.Name = "frmBaoCao";
            this.Text = "In Hóa Đơn & Báo Cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBaoCao;
    }
}