using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BankApp.Models
{
    public partial class QuanDBContext : DbContext
    {
        public QuanDBContext()
        {
        }

        public QuanDBContext(DbContextOptions<QuanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString.myDatabase);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("accounts");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("balance");

                entity.Property(e => e.CheckingNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("checkingNumber");

                entity.Property(e => e.UserPkid).HasColumnName("userPKID");

                entity.HasOne(d => d.UserPk)
                    .WithMany()
                    .HasForeignKey(d => d.UserPkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accounts__userPK__3C69FB99");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
