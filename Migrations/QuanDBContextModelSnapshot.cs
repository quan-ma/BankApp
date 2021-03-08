﻿// <auto-generated />
using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankApp.Migrations
{
    [DbContext(typeof(QuanDBContext))]
    partial class QuanDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankApp.Models.Account", b =>
                {
                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("balance");

                    b.Property<string>("CheckingNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("checkingNumber");

                    b.Property<int>("UserPkid")
                        .HasColumnType("int")
                        .HasColumnName("userPKID");

                    b.HasIndex("UserPkid");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("BankApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("firstName");

                    b.Property<string>("Lastname")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("password")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BankApp.Models.Account", b =>
                {
                    b.HasOne("BankApp.Models.User", "UserPk")
                        .WithMany()
                        .HasForeignKey("UserPkid")
                        .HasConstraintName("FK__accounts__userPK__3C69FB99")
                        .IsRequired();

                    b.Navigation("UserPk");
                });
#pragma warning restore 612, 618
        }
    }
}