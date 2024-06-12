using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbChatMessage> TbChatMessages { get; set; }

    public virtual DbSet<TbChatSession> TbChatSessions { get; set; }

    public virtual DbSet<TbChatSessionUser> TbChatSessionUsers { get; set; }

    public virtual DbSet<TbClinic> TbClinics { get; set; }

    public virtual DbSet<TbClinicService> TbClinicServices { get; set; }

    public virtual DbSet<TbClinicStaff> TbClinicStaffs { get; set; }

    public virtual DbSet<TbClinicWaiting> TbClinicWaitings { get; set; }

    public virtual DbSet<TbDocument> TbDocuments { get; set; }

    public virtual DbSet<TbMasterAdmin> TbMasterAdmins { get; set; }

    public virtual DbSet<TbMasterAdminRole> TbMasterAdminRoles { get; set; }

    public virtual DbSet<TbMedicalRecord> TbMedicalRecords { get; set; }

    public virtual DbSet<TbMedicalRecordDoctor> TbMedicalRecordDoctors { get; set; }

    public virtual DbSet<TbMedicalRecordDocument> TbMedicalRecordDocuments { get; set; }

    public virtual DbSet<TbOrganization> TbOrganizations { get; set; }

    public virtual DbSet<TbReservation> TbReservations { get; set; }

    public virtual DbSet<TbReservationGuide> TbReservationGuides { get; set; }

    public virtual DbSet<TbReview> TbReviews { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbStaffRole> TbStaffRoles { get; set; }

    public virtual DbSet<TbStaticDataType> TbStaticDataTypes { get; set; }

    public virtual DbSet<TbStaticDatum> TbStaticData { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Database=ClinicDB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ChatMessage_Id");

            entity.ToTable("tb_ChatMessage");

            entity.HasIndex(e => e.DocumentId, "IX_ChatMessageDocumentId");

            entity.HasIndex(e => e.DateCreated, "IX_ChatMessage_DateCreated");

            entity.HasIndex(e => e.SessionId, "IX_ChatMessage_SessionId");

            entity.HasIndex(e => e.UserId, "IX_ChatMessage_UserId");

            entity.HasIndex(e => new { e.SessionId, e.UserId, e.DateCreated }, "UK_ChatMessage_SessionIdAndUserIdAndDateCreated").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Document).WithMany(p => p.TbChatMessages)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_ChatMessage");

            entity.HasOne(d => d.Session).WithMany(p => p.TbChatMessages)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatSession_ChatMessage");

            entity.HasOne(d => d.User).WithMany(p => p.TbChatMessages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatSessionUser_ChatMessage");
        });

        modelBuilder.Entity<TbChatSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ChatSession_Id");

            entity.ToTable("tb_ChatSession");

            entity.HasIndex(e => e.DateCreated, "IX_ChatSession_DateCreated");

            entity.HasIndex(e => e.Topic, "IX_ChatSession_Topic");

            entity.HasIndex(e => new { e.Topic, e.DateCreated }, "UK_ChatSession_TopicAndDateCreated").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Topic).HasMaxLength(400);
        });

        modelBuilder.Entity<TbChatSessionUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ChatSessionUser_Id");

            entity.ToTable("tb_ChatSessionUser");

            entity.HasIndex(e => e.DateCreated, "IX_ChatSessionUser_DateCreated");

            entity.HasIndex(e => e.SessionId, "IX_ChatSessionUser_SessionId");

            entity.HasIndex(e => e.User1Id, "IX_ChatSessionUser_User1Id");

            entity.HasIndex(e => e.User2Id, "IX_ChatSessionUser_User2Id");

            entity.HasIndex(e => new { e.SessionId, e.User1Id, e.User2Id }, "UK_ChatSessionUser_SessionIdAndUser1IdAndUser2Id").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Session).WithMany(p => p.TbChatSessionUsers)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatSession_ChatSessionUser");

            entity.HasOne(d => d.User1).WithMany(p => p.TbChatSessionUserUser1s)
                .HasForeignKey(d => d.User1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_ChatSessionUser1");

            entity.HasOne(d => d.User2).WithMany(p => p.TbChatSessionUserUser2s)
                .HasForeignKey(d => d.User2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_ChatSessionUser2");
        });

        modelBuilder.Entity<TbClinic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clinic_Id");

            entity.ToTable("tb_Clinic");

            entity.HasIndex(e => e.SpecialityId, "IX_Clinic_SpecialityId").IsUnique();

            entity.HasIndex(e => e.BrandName, "UK_Clinic_BrandName").IsUnique();

            entity.HasIndex(e => e.Email, "UK_Clinic_Email").IsUnique();

            entity.HasIndex(e => e.Phone, "UK_Clinic_Phone").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Bio).HasMaxLength(4000);
            entity.Property(e => e.BrandName).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ImageKey).HasMaxLength(400);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Organization).WithMany(p => p.TbClinics)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_Organization_Clinic__OrganizationId");

            entity.HasOne(d => d.Speciality).WithOne(p => p.TbClinic)
                .HasForeignKey<TbClinic>(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaticData_Clinic");
        });

        modelBuilder.Entity<TbClinicService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ClinicService_Id");

            entity.ToTable("tb_ClinicService");

            entity.HasIndex(e => e.ClinicId, "IX_ClinicService_ClinicId");

            entity.HasIndex(e => e.ServiceId, "IX_ClinicService_ServiceId");

            entity.HasIndex(e => new { e.ClinicId, e.ServiceId }, "UK_ClinicService_ClinicIdAndServiceId").IsUnique();

            entity.Property(e => e.Fees).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Clinic).WithMany(p => p.TbClinicServices)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_ClinicService");

            entity.HasOne(d => d.Service).WithMany(p => p.TbClinicServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaticData_ClinicService");
        });

        modelBuilder.Entity<TbClinicStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ClinicStaff_Id");

            entity.ToTable("tb_ClinicStaff");

            entity.HasIndex(e => e.ClinicId, "IX_ClinicStaff_ClinicId");

            entity.HasIndex(e => e.UserId, "IX_ClinicStaff_UserId");

            entity.HasIndex(e => new { e.ClinicId, e.UserId }, "UK_ClinicStaff_ClinicIdAndUserId").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Clinic).WithMany(p => p.TbClinicStaffs)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_ClinicStaff");

            entity.HasOne(d => d.User).WithMany(p => p.TbClinicStaffs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_ClinicStaff");
        });

        modelBuilder.Entity<TbClinicWaiting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ClinicWaiting_Id");

            entity.ToTable("tb_ClinicWaiting");

            entity.HasIndex(e => e.ClinicId, "IX_ClinicWaiting_ClinicId");

            entity.HasIndex(e => new { e.ClinicId, e.PatientId }, "IX_ClinicWaiting_ClinicIdAndUserId").IsUnique();

            entity.HasIndex(e => e.DateCreated, "IX_ClinicWaiting_DateCreated");

            entity.HasIndex(e => e.PatientId, "IX_ClinicWaiting_UserId");

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Clinic).WithMany(p => p.TbClinicWaitings)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_ClinicWaiting");
        });

        modelBuilder.Entity<TbDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document_Id");

            entity.ToTable("tb_Document");

            entity.HasIndex(e => e.DocumentKey, "IX_Document_DocumentKey");

            entity.HasIndex(e => e.PatientId, "IX_Document_UserId");

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.DocumentKey).HasMaxLength(400);

            entity.HasOne(d => d.Patient).WithMany(p => p.TbDocuments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Document");
        });

        modelBuilder.Entity<TbMasterAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MasterAdmin_Id");

            entity.ToTable("tb_MasterAdmin");

            entity.HasIndex(e => e.Password, "IX_MasterAdmin_Password");

            entity.HasIndex(e => e.Email, "UK_MasterAdmin_Email").IsUnique();

            entity.HasIndex(e => e.FullName, "UK_MasterAdmin_FullName").IsUnique();

            entity.HasIndex(e => e.Phone, "UK_MasterAdmin_Phone").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbMasterAdminRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MasterAdminRole_Id");

            entity.ToTable("tb_MasterAdminRole");

            entity.HasIndex(e => e.MasterAdminId, "IX_MasterAdminRole_MasterAdminId");

            entity.HasIndex(e => e.RoleId, "IX_MasterAdminRole_RoleId");

            entity.HasIndex(e => new { e.MasterAdminId, e.RoleId }, "UK_MasterAdminRole_MasterAdminIdAndRoleId").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.MasterAdmin).WithMany(p => p.TbMasterAdminRoles)
                .HasForeignKey(d => d.MasterAdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterAdmin_MasterAdminRole");

            entity.HasOne(d => d.Role).WithMany(p => p.TbMasterAdminRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_MasterAdminRole");
        });

        modelBuilder.Entity<TbMedicalRecord>(entity =>
        {
            entity.ToTable("tb_MedicalRecord");

            entity.HasIndex(e => e.ClinicId, "IX_MedicalRecord_ClinicId");

            entity.HasIndex(e => e.PatientId, "IX_MedicalRecord_UserId");

            entity.HasIndex(e => e.DateCreated, "IX_MedicalRecord_VisitDate");

            entity.HasIndex(e => e.Id, "IX_tb_MedicalRecord");

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.DayPayment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NextVisitDate).HasColumnType("datetime");
            entity.Property(e => e.PreviousPayment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RemainingPayment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalFees).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Clinic).WithMany(p => p.TbMedicalRecords)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_MedicalRecord");

            entity.HasOne(d => d.Patient).WithMany(p => p.TbMedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_MedicalRecord");

            entity.HasOne(d => d.RecordType).WithMany(p => p.TbMedicalRecords)
                .HasForeignKey(d => d.RecordTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaticData_MedicalRecord");
        });

        modelBuilder.Entity<TbMedicalRecordDoctor>(entity =>
        {
            entity.ToTable("tb_MedicalRecordDoctors");

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Doctor).WithMany(p => p.TbMedicalRecordDoctors)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_MedicalRecordDoctors");

            entity.HasOne(d => d.MedicalRecord).WithMany(p => p.TbMedicalRecordDoctors)
                .HasForeignKey(d => d.MedicalRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalRecord_MedicalRecordDoctors");
        });

        modelBuilder.Entity<TbMedicalRecordDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MedicalRecordDocument_Id");

            entity.ToTable("tb_MedicalRecordDocument");

            entity.HasIndex(e => new { e.MedicalRecordId, e.DocumentIdId }, "UK_MedicalRecordDocument_RecordIdAndDocumentId").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.DocumentId).WithMany(p => p.TbMedicalRecordDocuments)
                .HasForeignKey(d => d.DocumentIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_MedicalRecordDocument");

            entity.HasOne(d => d.MedicalRecord).WithMany(p => p.TbMedicalRecordDocuments)
                .HasForeignKey(d => d.MedicalRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalRecord_MedicalRecordDocument");
        });

        modelBuilder.Entity<TbOrganization>(entity =>
        {
            entity.ToTable("tb_Organization");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Bio).HasMaxLength(4000);
            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.OrganizationName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ClinicReservation_Id");

            entity.ToTable("tb_Reservation");

            entity.HasIndex(e => e.ClinicId, "IX_Reservation_ClinicId");

            entity.HasIndex(e => e.ReservationDate, "IX_Reservation_ReservationDate");

            entity.HasIndex(e => e.UserId, "IX_Reservation_UserId");

            entity.HasIndex(e => new { e.ClinicId, e.UserId, e.ReservationDate }, "UK_Reservation_ClinicIdAndUserIdAndResDate").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ReservationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Clinic).WithMany(p => p.TbReservations)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_Reservation");

            entity.HasOne(d => d.User).WithMany(p => p.TbReservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Reservation");
        });

        modelBuilder.Entity<TbReservationGuide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ReservationGuide_Id");

            entity.ToTable("tb_ReservationGuide");

            entity.HasIndex(e => e.ClinicId, "IX_ReservationGuide_ClinicId");

            entity.HasIndex(e => e.Id, "UK_ReservationGuide_ClinicId");

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Clinic).WithMany(p => p.TbReservationGuides)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_ReservationGuide");
        });

        modelBuilder.Entity<TbReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Review_Id");

            entity.ToTable("tb_Review");

            entity.HasIndex(e => e.ClinicId, "IX_Review_ClinicId");

            entity.HasIndex(e => e.DateCreated, "IX_Review_DateCreated");

            entity.HasIndex(e => e.UserId, "IX_Review_UserId");

            entity.HasIndex(e => new { e.ClinicId, e.UserId }, "UK_Review_ClinicIdAndUserId").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ReviewText).HasMaxLength(4000);

            entity.HasOne(d => d.Clinic).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_Review");

            entity.HasOne(d => d.User).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Review");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Role_Id");

            entity.ToTable("tb_Role");

            entity.HasIndex(e => e.RoleName, "IX_Role_RoleName");

            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<TbStaffRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StaffRole_Id");

            entity.ToTable("tb_StaffRole");

            entity.HasIndex(e => e.ClinicStaffId, "IX_StaffRole_ClinicStaffId");

            entity.HasIndex(e => e.RoleId, "IX_StaffRole_RoleId");

            entity.HasIndex(e => new { e.ClinicStaffId, e.RoleId }, "UK_StaffRole_ClinicStaffIdAndRoleId").IsUnique();

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.ClinicStaff).WithMany(p => p.TbStaffRoles)
                .HasForeignKey(d => d.ClinicStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClinicStaff_StaffRole");

            entity.HasOne(d => d.Role).WithMany(p => p.TbStaffRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_StaffRole");
        });

        modelBuilder.Entity<TbStaticDataType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StaticDataType_Id");

            entity.ToTable("tb_StaticDataType");

            entity.HasIndex(e => e.Name, "UK_StaticDataType_Name").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TbStaticDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StaticData_Id");

            entity.ToTable("tb_StaticData");

            entity.HasIndex(e => e.StaticDataTypeId, "IX_StaticData_StaticDataTypeId");

            entity.HasIndex(e => new { e.StaticDataTypeId, e.Name }, "UK_StaticData_TypeIdAndName").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.StaticDataType).WithMany(p => p.TbStaticData)
                .HasForeignKey(d => d.StaticDataTypeId)
                .HasConstraintName("FK_StaticDataType_StaticData");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Doctor_Id");

            entity.ToTable("tb_User");

            entity.HasIndex(e => e.SpecialityId, "IX_User_SpecialityId");

            entity.HasIndex(e => e.UserTypeId, "IX_User_UserTypeId");

            entity.HasIndex(e => e.Id, "UK_User_Email");

            entity.HasIndex(e => e.FullName, "UK_User_FullName").IsUnique();

            entity.HasIndex(e => e.Phone, "UK_User_Phone");

            entity.Property(e => e.DateCreated)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.ImageKey).HasMaxLength(400);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Organization).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_Organization_User_OrganizationId");

            entity.HasOne(d => d.Speciality).WithMany(p => p.TbUserSpecialities)
                .HasForeignKey(d => d.SpecialityId)
                .HasConstraintName("FK_StaticData_User_Speciality");

            entity.HasOne(d => d.UserType).WithMany(p => p.TbUserUserTypes)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaticData_User_UserType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
