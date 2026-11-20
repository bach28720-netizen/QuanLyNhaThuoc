using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Configuration;

namespace Quản_lý_phòng_khám
{
    [Table("Examinations")]
    public class ClinicalExamination
    {
        [Key]
        public int ExaminationID { get; set; }
        public int ApptID { get; set; }
        [MaxLength(1000)]
        public string Symptoms { get; set; }
        [MaxLength(1000)]
        public string Diagnosis { get; set; }
        [MaxLength(1000)]
        public string Conclusion { get; set; }
        public DateTime ExaminationDate { get; set; }
    }

    [Table("ExaminationServices")]
    public class ClinicalExaminationService
    {
        [Key]
        public int ExaminationServiceID { get; set; }
        public int ExaminationID { get; set; }
        [Required, StringLength(20)]
        public string ServiceID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class ClinicalDbContext : DbContext
    {
        public ClinicalDbContext()
            : base(CreateSqlConnection(), true)
        {
            // Bảng bổ sung được tạo bằng script SQL, không dùng initializer.
            Database.SetInitializer<ClinicalDbContext>(null);
        }

        private static SqlConnection CreateSqlConnection()
        {
            var configured = ConfigurationManager.ConnectionStrings["QuanLyPhongKhamMedproEntities"];
            if (configured == null)
                throw new InvalidOperationException("Thiếu connection string QuanLyPhongKhamMedproEntities trong App.config.");
            var entityBuilder = new EntityConnectionStringBuilder(configured.ConnectionString);
            return new SqlConnection(entityBuilder.ProviderConnectionString);
        }

        public DbSet<ClinicalExamination> Examinations { get; set; }
        public DbSet<ClinicalExaminationService> ExaminationServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalExamination>().ToTable("Examinations");
            modelBuilder.Entity<ClinicalExaminationService>().ToTable("ExaminationServices");
            modelBuilder.Entity<ClinicalExaminationService>()
                .Property(x => x.UnitPrice).HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
