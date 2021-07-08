using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;

namespace SPC.Models.DataModel
{
    public partial class SPCContext : DbContext
    {
        public SPCContext()
        {
        }

        public SPCContext(DbContextOptions<SPCContext> options)
            : base(options)
        {
        }
        public virtual DbSet<VtaskDefectReport> VtaskDefectReport { get; set; }
        public virtual DbSet<Acl> Acl { get; set; }
        public virtual DbSet<DefectItem> DefectItem { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentClass> EquipmentClass { get; set; }
        public virtual DbSet<EquipmentTag> EquipmentTag { get; set; }
        public virtual DbSet<InspectionOrder> InspectionOrder { get; set; }
        public virtual DbSet<InspectionOrderDetail> InspectionOrderDetail { get; set; }
        public virtual DbSet<InspectionParam> InspectionParam { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SystemSetting> SystemSetting { get; set; }
        public virtual DbSet<TagItem> TagItem { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<VinspectionOrder> VinspectionOrder { get; set; }
        public virtual DbSet<VinspectionOrderDetail> VinspectionOrderDetail { get; set; }
        public virtual DbSet<WorkProcess> WorkProcess { get; set; }
        public virtual DbSet<WorkProcessDefect> WorkProcessDefect { get; set; }
        public virtual DbSet<WorkProcessEquipment> WorkProcessEquipment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(SPC.Core.Utility.ConfigHelper.GetSection("AppSettings")["SQLServerConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<VtaskDefectReport>(entity =>
            {
                entity.ToTable("VTaskDefectReport");

                entity.Property(e => e.VtaskDefectReportId).HasColumnName("VTaskDefectReportID");

                entity.Property(e => e.DefectItemId).HasColumnName("DefectItemID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.HasOne(d => d.DefectItem)
                    .WithMany(p => p.VtaskDefectReport)
                    .HasForeignKey(d => d.DefectItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VTaskDefe__Defec__1BC821DD");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.VtaskDefectReport)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VTaskDefe__TaskI__1AD3FDA4");
            });
            modelBuilder.Entity<Acl>(entity =>
            {
                entity.ToTable("ACL");

                entity.Property(e => e.Aclid).HasColumnName("ACLID");

                entity.Property(e => e.AccessEntryId)
                    .IsRequired()
                    .HasColumnName("AccessEntryID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccessEntryType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.AccessParams)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AccessRight)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.VisitorId)
                    .IsRequired()
                    .HasColumnName("VisitorID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VisitorType)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<DefectItem>(entity =>
            {
                entity.Property(e => e.DefectItemId).HasColumnName("DefectItemID");

                entity.Property(e => e.DefectItemCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DefectItemName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasIndex(e => e.EquipmentCode)
                    .HasName("IX_EQPCODE")
                    .IsUnique();

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.EquipmentClassId).HasColumnName("EquipmentClassID");

                entity.Property(e => e.EquipmentCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EquipmentImage).HasColumnType("image");

                entity.Property(e => e.EquipmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EquipmentSpec)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EquipmentType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProductionDate).HasColumnType("datetime");

                entity.Property(e => e.StandCapacity).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.EquipmentClass)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipmentClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EQP_REF_EQPCLS");
            });

            modelBuilder.Entity<EquipmentClass>(entity =>
            {
                entity.Property(e => e.EquipmentClassId).HasColumnName("EquipmentClassID");

                entity.Property(e => e.EquipmentClassCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EquipmentClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ParentId)
                    .IsRequired()
                    .HasColumnName("ParentID")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<EquipmentTag>(entity =>
            {
                entity.Property(e => e.EquipmentTagId).HasColumnName("EquipmentTagID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentTag)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EQUIPMEN_REFERENCE_EQUIPMEN");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.EquipmentTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EQUIPMEN_REFERENCE_TAGITEM");
            });

            modelBuilder.Entity<InspectionOrder>(entity =>
            {
                entity.Property(e => e.InspectionOrderId).HasColumnName("InspectionOrderID");

                entity.Property(e => e.OrderDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductSn)
                    .IsRequired()
                    .HasColumnName("ProductSN")
                    .HasMaxLength(25);

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.InspectionOrder)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspectionOrder_Task");
            });

            modelBuilder.Entity<InspectionOrderDetail>(entity =>
            {
                entity.Property(e => e.InspectionOrderDetailId).HasColumnName("InspectionOrderDetailID");

                entity.Property(e => e.InspectionOrderId).HasColumnName("InspectionOrderID");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.ParameterValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.InspectionOrder)
                    .WithMany(p => p.InspectionOrderDetail)
                    .HasForeignKey(d => d.InspectionOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspectionOrderDetail_InspectionOrder");

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.InspectionOrderDetail)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspectionOrderDetail_ParameterID");
            });

            modelBuilder.Entity<InspectionParam>(entity =>
            {
                entity.Property(e => e.InspectionParamId).HasColumnName("InspectionParamID");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.InspectionParam)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INSPECTI_REFERENCE_PARAMETE");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InspectionParam)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INSPECTI_REFERENCE_PRODUCT");

                entity.HasOne(d => d.WorkProcess)
                    .WithMany(p => p.InspectionParam)
                    .HasForeignKey(d => d.WorkProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INSPECTI_REFERENCE_WORKPROC");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.MaxValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MinValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParameterCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ParameterDataType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ParameterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParameterValueType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StandardValue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemSetting>(entity =>
            {
                entity.Property(e => e.SystemSettingId).HasColumnName("SystemSettingID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SystemSettingKey)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.SystemSettingValue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TagItem>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TagTopic)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.BatchNo)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.BeginDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserDefine1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserDefine2)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserDefine3)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserDefine4)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserDefine5)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Equipment");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Product");

                entity.HasOne(d => d.WorkProcess)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.WorkProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_WorkProcess");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.UserCode)
                    .HasName("IX_User_Code")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(25);

               

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<VinspectionOrder>(entity =>
            {
                entity.ToTable("VInspectionOrder");

                entity.Property(e => e.VinspectionOrderId).HasColumnName("VInspectionOrderID");

                entity.Property(e => e.OrderDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductSn)
                    .IsRequired()
                    .HasColumnName("ProductSN")
                    .HasMaxLength(25);

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.VinspectionOrder)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VInspectionOrder_Task");
            });

            modelBuilder.Entity<VinspectionOrderDetail>(entity =>
            {
                entity.ToTable("VInspectionOrderDetail");

                entity.Property(e => e.VinspectionOrderDetailId).HasColumnName("VInspectionOrderDetailID");

                entity.Property(e => e.DefectItemId).HasColumnName("DefectItemID");

                entity.Property(e => e.VinspectionOrderId).HasColumnName("VInspectionOrderID");

                entity.HasOne(d => d.VinspectionOrder)
                    .WithMany(p => p.VinspectionOrderDetail)
                    .HasForeignKey(d => d.VinspectionOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VINSPECT_REFERENCE_VINSPECT");
            });

            modelBuilder.Entity<WorkProcess>(entity =>
            {
                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.WorkProcessCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WorkProcessName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<WorkProcessDefect>(entity =>
            {
                entity.Property(e => e.WorkProcessDefectId).HasColumnName("WorkProcessDefectID");

                entity.Property(e => e.DefectItemId).HasColumnName("DefectItemID");

                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.HasOne(d => d.DefectItem)
                    .WithMany(p => p.WorkProcessDefect)
                    .HasForeignKey(d => d.DefectItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKPROC_REFERENCE_DEFECTIT");

                entity.HasOne(d => d.WorkProcess)
                    .WithMany(p => p.WorkProcessDefect)
                    .HasForeignKey(d => d.WorkProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKPROC_REFERENCE_WORKPROC");
            });

            modelBuilder.Entity<WorkProcessEquipment>(entity =>
            {
                entity.Property(e => e.WorkProcessEquipmentId).HasColumnName("WorkProcessEquipmentID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.WorkProcessEquipment)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKPROC_REFERENCE_EQUIPMEN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}