﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkForceManagement.Web.Models;

#nullable disable

namespace WorkForceManagement.Web.Migrations
{
    [DbContext(typeof(WFMDbContext))]
    partial class WFMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WorkForceManagement.Domain.Employees", b =>
                {
                    b.Property<int>("employee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employee_id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("employee_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("experience")
                        .HasColumnType("decimal(5,0)");

                    b.Property<string>("lockstatus")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("manager")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("profile_id")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("wfm_manager")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("employee_id");

                    b.HasIndex("profile_id");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Profile", b =>
                {
                    b.Property<int>("profile_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("profile_id"), 1L, 1);

                    b.Property<string>("profile_name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("profile_id");

                    b.ToTable("Profiles", (string)null);
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Skillmap", b =>
                {
                    b.Property<int>("employee_id")
                        .HasColumnType("int");

                    b.Property<int>("skillid")
                        .HasColumnType("int");

                    b.Property<int>("SkillmapId")
                        .HasColumnType("int");

                    b.HasKey("employee_id", "skillid");

                    b.HasIndex("skillid");

                    b.ToTable("Skillmap", (string)null);
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Skills", b =>
                {
                    b.Property<int>("skillid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("skillid"), 1L, 1);

                    b.Property<string>("skillname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("skillid");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Softlock", b =>
                {
                    b.Property<int>("lockid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lockid"), 1L, 1);

                    b.Property<int>("employee_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("lastupdated")
                        .HasColumnType("datetime");

                    b.Property<string>("manager")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("managerstatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("awaiting_approval");

                    b.Property<DateTime>("mgrlastupdate")
                        .HasColumnType("datetime");

                    b.Property<string>("mgrstatuscomment")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<DateTime>("reqdate")
                        .HasColumnType("datetime");

                    b.Property<string>("requestmessage")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("wfmremark")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("lockid");

                    b.HasIndex("employee_id");

                    b.ToTable("Softlock", (string)null);
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Users", b =>
                {
                    b.Property<string>("username")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("username");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Employees", b =>
                {
                    b.HasOne("WorkForceManagement.Domain.Profile", "profile")
                        .WithMany("employees")
                        .HasForeignKey("profile_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("profile");
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Skillmap", b =>
                {
                    b.HasOne("WorkForceManagement.Domain.Employees", "employees")
                        .WithMany("skillmaps")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkForceManagement.Domain.Skills", "skills")
                        .WithMany("skillmaps")
                        .HasForeignKey("skillid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employees");

                    b.Navigation("skills");
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Softlock", b =>
                {
                    b.HasOne("WorkForceManagement.Domain.Employees", "employees")
                        .WithMany("softlocks")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employees");
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Employees", b =>
                {
                    b.Navigation("skillmaps");

                    b.Navigation("softlocks");
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Profile", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("WorkForceManagement.Domain.Skills", b =>
                {
                    b.Navigation("skillmaps");
                });
#pragma warning restore 612, 618
        }
    }
}