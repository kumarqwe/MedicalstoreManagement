using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedicalstoreManagement.Models
{
    public partial class medical_store_management_systemDbContext : DbContext
    {
        public medical_store_management_systemDbContext()
        {
        }

        public medical_store_management_systemDbContext(DbContextOptions<medical_store_management_systemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingMedicine> BookingMedicine { get; set; }
        public virtual DbSet<EventDetails> EventDetails { get; set; }
        public virtual DbSet<Invitation> Invitation { get; set; }
        public virtual DbSet<LoginRegistration> LoginRegistration { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-KDS5JVQR\\SQLEXPRESS;Database='medical_store_management_system'; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingMedicine>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__booking___5F01023548E8FC47");

                entity.ToTable("booking_medicine");

                entity.HasIndex(e => e.MedicineName)
                    .HasName("UQ__booking___7B380736B9BEC09E")
                    .IsUnique();

                entity.Property(e => e.MedicineId)
                    .HasColumnName("Medicine_ID")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.AvailabilityMd).HasColumnName("Availability_MD");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("MEdicine_Name")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventDetails>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Event_De__FD6AEB9C11CF261F");

                entity.ToTable("Event_Details");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_id")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnName("Event_Name")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.ToTable("invitation");

                entity.Property(e => e.InvitationId)
                    .HasColumnName("invitation_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SentAt)
                    .HasColumnName("sent_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email")
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__login_re__B9BE370FF2AE9049");

                entity.ToTable("login_registration");

                entity.HasIndex(e => e.EMail)
                    .HasName("UQ__login_re__31660442939822B8")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("UQ__login_re__6E2DBEDE5FCEAA03")
                    .IsUnique();

                entity.HasIndex(e => e.RePassword)
                    .HasName("UQ__login_re__17FB52E76E043C7B")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("E_mail")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RePassword)
                    .IsRequired()
                    .HasColumnName("re_password")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__logins__C2C971DB44680A23");

                entity.ToTable("logins");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ActionAt)
                    .HasColumnName("action_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__payments__ED1FC9EA9D2DB940");

                entity.ToTable("payments");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PaymentAt)
                    .HasColumnName("payment_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Reciept)
                    .HasColumnName("reciept")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionAmount)
                    .HasColumnName("transaction_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
