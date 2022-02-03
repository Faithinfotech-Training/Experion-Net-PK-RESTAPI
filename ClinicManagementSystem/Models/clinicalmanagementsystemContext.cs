using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicManagementSystem.Models
{
    public partial class clinicalmanagementsystemContext : DbContext
    {
        public clinicalmanagementsystemContext()
        {
        }

        public clinicalmanagementsystemContext(DbContextOptions<clinicalmanagementsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<GeneralNotes> GeneralNotes { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicineBill> MedicineBill { get; set; }
        public virtual DbSet<MedicineItemPrice> MedicineItemPrice { get; set; }
        public virtual DbSet<MedicineList> MedicineList { get; set; }
        public virtual DbSet<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestBill> TestBill { get; set; }
        public virtual DbSet<TestPrescription> TestPrescription { get; set; }
        public virtual DbSet<TestPrice> TestPrice { get; set; }
        public virtual DbSet<TestReport> TestReport { get; set; }
        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source= ASHWINMADHU\\SQLEXPRESS01; Initial Catalog= clinicalmanagementsystem;Integrated security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.ReceptionId).HasColumnName("Reception_Id");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Appointment_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Appointment_Patient");

                entity.HasOne(d => d.Reception)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.ReceptionId)
                    .HasConstraintName("FK_Appointment_Users");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.BillId).HasColumnName("Bill_Id");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_Bill_Appointment");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.SpecializationId).HasColumnName("Specialization_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK_Doctor_Specialization1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Doctor_Users");
            });

            modelBuilder.Entity<GeneralNotes>(entity =>
            {
                entity.HasKey(e => e.GeneralNoteId);

                entity.Property(e => e.GeneralNoteId).HasColumnName("GeneralNote_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.GeneralNotes)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_GeneralNotes_Appointment");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineId).HasColumnName("Medicine_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<MedicineBill>(entity =>
            {
                entity.Property(e => e.MedicineBillId).HasColumnName("MedicineBill_Id");

                entity.Property(e => e.MedicinePrescriptionId).HasColumnName("MedicinePrescription_Id");

                entity.HasOne(d => d.MedicinePrescription)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.MedicinePrescriptionId)
                    .HasConstraintName("FK_MedicineBill_MedicinePrescription");
            });

            modelBuilder.Entity<MedicineItemPrice>(entity =>
            {
                entity.HasKey(e => e.MedicinePriceId);

                entity.Property(e => e.MedicinePriceId).HasColumnName("MedicinePrice_Id");

                entity.Property(e => e.MedicineBillId).HasColumnName("MedicineBill_Id");

                entity.Property(e => e.MedicineId).HasColumnName("Medicine_Id");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.MedicineBill)
                    .WithMany(p => p.MedicineItemPrice)
                    .HasForeignKey(d => d.MedicineBillId)
                    .HasConstraintName("FK_MedicineItemPrice_MedicineBill");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineItemPrice)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK_MedicineItemPrice_Medicine");
            });

            modelBuilder.Entity<MedicineList>(entity =>
            {
                entity.Property(e => e.MedicineListId).HasColumnName("MedicineList_Id");

                entity.Property(e => e.MedicineId).HasColumnName("Medicine_Id");

                entity.Property(e => e.MedicinePrescriptionId).HasColumnName("MedicinePrescription_Id");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineList)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK_MedicineList_Medicine");

                entity.HasOne(d => d.MedicinePrescription)
                    .WithMany(p => p.MedicineList)
                    .HasForeignKey(d => d.MedicinePrescriptionId)
                    .HasConstraintName("FK_MedicineList_MedicinePrescription");
            });

            modelBuilder.Entity<MedicinePrescription>(entity =>
            {
                entity.Property(e => e.MedicinePrescriptionId).HasColumnName("MedicinePrescription_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");

                entity.Property(e => e.PharmacistId).HasColumnName("Pharmacist_Id");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_MedicinePrescription_Appointment");

                entity.HasOne(d => d.Pharmacist)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.PharmacistId)
                    .HasConstraintName("FK_MedicinePrescription_Users");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.Property(e => e.QualificationId).HasColumnName("Qualification_Id");

                entity.Property(e => e.QualificationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("Role_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.SpecializationId).HasColumnName("Specialization_Id");

                entity.Property(e => e.SpecializationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.TestId).HasColumnName("Test_Id");

                entity.Property(e => e.NormalRangeEnd).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NormalRangeStart).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TestName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestBill>(entity =>
            {
                entity.Property(e => e.TestBillId).HasColumnName("TestBill_Id");

                entity.Property(e => e.TestPrescriptionId).HasColumnName("TestPrescription_Id");

                entity.HasOne(d => d.TestPrescription)
                    .WithMany(p => p.TestBill)
                    .HasForeignKey(d => d.TestPrescriptionId)
                    .HasConstraintName("FK_TestBill_TestPrescription");
            });

            modelBuilder.Entity<TestPrescription>(entity =>
            {
                entity.Property(e => e.TestPrescriptionId).HasColumnName("TestPrescription_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");

                entity.Property(e => e.LabTechnicianId).HasColumnName("LabTechnician_Id");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TestPrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_TestPrescription_Appointment");

                entity.HasOne(d => d.LabTechnician)
                    .WithMany(p => p.TestPrescription)
                    .HasForeignKey(d => d.LabTechnicianId)
                    .HasConstraintName("FK_TestPrescription_Users");
            });

            modelBuilder.Entity<TestPrice>(entity =>
            {
                entity.Property(e => e.TestPriceId).HasColumnName("TestPrice_Id");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TestBillId).HasColumnName("TestBill_Id");

                entity.Property(e => e.TestId).HasColumnName("Test_Id");

                entity.HasOne(d => d.TestBill)
                    .WithMany(p => p.TestPrice)
                    .HasForeignKey(d => d.TestBillId)
                    .HasConstraintName("FK_TestPrice_TestBill");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestPrice)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_TestPrice_Test");
            });

            modelBuilder.Entity<TestReport>(entity =>
            {
                entity.Property(e => e.TestReportId).HasColumnName("TestReport_Id");

                entity.Property(e => e.TestId).HasColumnName("Test_Id");

                entity.Property(e => e.TestPrescriptionId).HasColumnName("TestPrescription_Id");

                entity.Property(e => e.TestValue).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestReport)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_TestReport_Test");

                entity.HasOne(d => d.TestPrescription)
                    .WithMany(p => p.TestReport)
                    .HasForeignKey(d => d.TestPrescriptionId)
                    .HasConstraintName("FK_TestReport_TestPrescription");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDob).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
