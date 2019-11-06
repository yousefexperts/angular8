﻿// <auto-generated />
using System;
using DotNetCoreArchitecture.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCoreArchitecture.Database.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreArchitecture.Database.Tables.CatogriesTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ItemsInventoryTableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemsInventoryTableId");

                    b.ToTable("CatogriesTable");
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Database.Tables.ItemsInventoryTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsExist")
                        .HasColumnName("IsExist")
                        .HasColumnType("bit");

                    b.Property<string>("ItemDescription")
                        .HasColumnName("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnName("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxNum")
                        .HasColumnName("MaxNum")
                        .HasColumnType("int");

                    b.Property<int>("MinNum")
                        .HasColumnName("MinNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InventoryTable");
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Domain.Catogry.CatogryEntity", b =>
                {
                    b.Property<Guid>("CatogryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatogryId");

                    b.ToTable("CatogryItems");
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Domain.ItemEntity", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CatogriesCatogryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CatogryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateDate")
                        .HasColumnName("CreateDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExist")
                        .HasColumnName("IsExist")
                        .HasColumnType("bit");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnName("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxNum")
                        .IsRequired()
                        .HasColumnName("MaxNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinNum")
                        .IsRequired()
                        .HasColumnName("MinNum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("CatogriesCatogryId");

                    b.ToTable("ItemInventory","User");
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Domain.UserEntity", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users","User");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            Roles = 3,
                            Status = 1
                        });
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Domain.UserLogEntity", b =>
                {
                    b.Property<long>("UserLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LogType")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("UserLogId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersLogs","User");
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Database.Tables.CatogriesTable", b =>
                {
                    b.HasOne("DotNetCoreArchitecture.Database.Tables.ItemsInventoryTable", null)
                        .WithMany("CatogriesTables")
                        .HasForeignKey("ItemsInventoryTableId");
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Domain.ItemEntity", b =>
                {
                    b.HasOne("DotNetCoreArchitecture.Domain.Catogry.CatogryEntity", "Catogries")
                        .WithMany()
                        .HasForeignKey("CatogriesCatogryId");
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Domain.UserEntity", b =>
                {
                    b.OwnsOne("DotNetCoreArchitecture.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<long>("UserEntityUserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("nvarchar(300)")
                                .HasMaxLength(300);

                            b1.HasKey("UserEntityUserId");

                            b1.HasIndex("Address")
                                .IsUnique()
                                .HasFilter("[Email] IS NOT NULL");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityUserId");

                            b1.HasData(
                                new
                                {
                                    UserEntityUserId = 1L,
                                    Address = "administrator@administrator.com"
                                });
                        });

                    b.OwnsOne("DotNetCoreArchitecture.Domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<long>("UserEntityUserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnName("Surname")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("UserEntityUserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityUserId");

                            b1.HasData(
                                new
                                {
                                    UserEntityUserId = 1L,
                                    Name = "Administrator",
                                    Surname = "Administrator"
                                });
                        });

                    b.OwnsOne("DotNetCoreArchitecture.Domain.SignIn", "SignIn", b1 =>
                        {
                            b1.Property<long>("UserEntityUserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Login")
                                .IsRequired()
                                .HasColumnName("Login")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnName("Password")
                                .HasColumnType("nvarchar(500)")
                                .HasMaxLength(500);

                            b1.Property<string>("Salt")
                                .IsRequired()
                                .HasColumnName("Salt")
                                .HasColumnType("nvarchar(500)")
                                .HasMaxLength(500);

                            b1.HasKey("UserEntityUserId");

                            b1.HasIndex("Login")
                                .IsUnique()
                                .HasFilter("[Login] IS NOT NULL");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityUserId");

                            b1.HasData(
                                new
                                {
                                    UserEntityUserId = 1L,
                                    Login = "admin",
                                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                                });
                        });
                });

            modelBuilder.Entity("DotNetCoreArchitecture.Domain.UserLogEntity", b =>
                {
                    b.HasOne("DotNetCoreArchitecture.Domain.UserEntity", "User")
                        .WithMany("UsersLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
