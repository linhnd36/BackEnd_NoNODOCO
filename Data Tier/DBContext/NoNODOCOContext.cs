using System;
using Data_Tier.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data_Tier.DBContext
{
    public partial class NoNODOCOContext : DbContext
    {
        public NoNODOCOContext()
        {
        }

        public NoNODOCOContext(DbContextOptions<NoNODOCOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Bonus> Bonus { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<DriverAvaiability> DriverAvaiability { get; set; }
        public virtual DbSet<DriverHaveBonus> DriverHaveBonus { get; set; }
        public virtual DbSet<TransactionWallet> TransactionWallet { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:nonodoco.database.windows.net,1433;Initial Catalog=nonodoco;Persist Security Info=False;User ID=toor;Password=%432%6#ATipa7$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.Property(e => e.BonusCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasIndex(e => e.AssignId)
                    .HasName("fkIdx_110");

                entity.HasIndex(e => e.CustumerId)
                    .HasName("fkIdx_107");

                entity.HasIndex(e => e.DriverId)
                    .HasName("fkIdx_104");

                entity.HasIndex(e => e.VehicleId)
                    .HasName("fkIdx_113");

                entity.Property(e => e.DateTimeEnd).HasColumnType("datetime");

                entity.Property(e => e.DateTimeStart).HasColumnType("datetime");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assign)
                    .WithMany(p => p.BookingAssign)
                    .HasForeignKey(d => d.AssignId)
                    .HasConstraintName("FK_booking_customer");

                entity.HasOne(d => d.Custumer)
                    .WithMany(p => p.BookingCustumer)
                    .HasForeignKey(d => d.CustumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_106");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_103");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_112");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasIndex(e => e.AdminRegisterId)
                    .HasName("fkIdx_119");

                entity.HasIndex(e => e.AdminUpdateId)
                    .HasName("fkIdx_122");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DrivingLicense)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasDefaultValueSql("((5))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.AdminRegister)
                    .WithMany(p => p.DriverAdminRegister)
                    .HasForeignKey(d => d.AdminRegisterId)
                    .HasConstraintName("FK_118");

                entity.HasOne(d => d.AdminUpdate)
                    .WithMany(p => p.DriverAdminUpdate)
                    .HasForeignKey(d => d.AdminUpdateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_121");
            });

            modelBuilder.Entity<DriverAvaiability>(entity =>
            {
                entity.HasIndex(e => e.DriverId)
                    .HasName("fkIdx_128");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TimeCloseApp).HasColumnType("datetime");

                entity.Property(e => e.TimeStartApp).HasColumnType("datetime");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverAvaiability)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_127");
            });

            modelBuilder.Entity<DriverHaveBonus>(entity =>
            {
                entity.HasIndex(e => e.BonusId)
                    .HasName("fkIdx_134");

                entity.HasIndex(e => e.DriverId)
                    .HasName("fkIdx_131");

                entity.HasOne(d => d.Bonus)
                    .WithMany(p => p.DriverHaveBonus)
                    .HasForeignKey(d => d.BonusId)
                    .HasConstraintName("FK_133");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverHaveBonus)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_130");
            });

            modelBuilder.Entity<TransactionWallet>(entity =>
            {
                entity.HasIndex(e => e.BookingId)
                    .HasName("fkIdx_95");

                entity.HasIndex(e => e.WalletId)
                    .HasName("fkIdx_92");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.TransactionWallet)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_booking");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.TransactionWallet)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK_91");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("fkIdx_116");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.LicensePlate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_customer_vehicle");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasIndex(e => e.CustumerId)
                    .HasName("fkIdx_141");

                entity.HasIndex(e => e.DriverId)
                    .HasName("fkIdx_138");

                entity.Property(e => e.DateTimeUpdate).HasColumnType("datetime");

                entity.Property(e => e.TypeWallet)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Custumer)
                    .WithMany(p => p.Wallet)
                    .HasForeignKey(d => d.CustumerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_wallet_customer");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Wallet)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_137");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
