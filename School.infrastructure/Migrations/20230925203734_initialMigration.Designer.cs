﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.infrastructure.Data;

#nullable disable

namespace School.infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230925203734_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("School.data.Entities.Department", b =>
                {
                    b.Property<int>("DID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DID"));

                    b.Property<string>("DName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("InsManagerId")
                        .HasColumnType("int");

                    b.HasKey("DID");

                    b.HasIndex("InsManagerId")
                        .IsUnique()
                        .HasFilter("[InsManagerId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("School.data.Entities.DepartmentSubject", b =>
                {
                    b.Property<int>("DID")
                        .HasColumnType("int");

                    b.Property<int>("SubID")
                        .HasColumnType("int");

                    b.HasKey("DID", "SubID");

                    b.HasIndex("SubID");

                    b.ToTable("DepartmentSubjects");
                });

            modelBuilder.Entity("School.data.Entities.InsSubject", b =>
                {
                    b.Property<int>("InsId")
                        .HasColumnType("int");

                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.HasKey("InsId", "SubId");

                    b.HasIndex("SubId");

                    b.ToTable("InsSubjects");
                });

            modelBuilder.Entity("School.data.Entities.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("InsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SuperVisorId")
                        .HasColumnType("int");

                    b.HasKey("InsId");

                    b.HasIndex("DID");

                    b.HasIndex("SuperVisorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("School.data.Entities.Student", b =>
                {
                    b.Property<int>("StudID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("StudID");

                    b.HasIndex("DID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("School.data.Entities.StudentSubject", b =>
                {
                    b.Property<int>("StudID")
                        .HasColumnType("int");

                    b.Property<int>("SubID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudID", "SubID");

                    b.HasIndex("SubID");

                    b.ToTable("StudentSubjects");
                });

            modelBuilder.Entity("School.data.Entities.Subject", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubID"));

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("SubID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("School.data.Entities.Department", b =>
                {
                    b.HasOne("School.data.Entities.Instructor", "InsManager")
                        .WithOne("DepartmentManager")
                        .HasForeignKey("School.data.Entities.Department", "InsManagerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("InsManager");
                });

            modelBuilder.Entity("School.data.Entities.DepartmentSubject", b =>
                {
                    b.HasOne("School.data.Entities.Department", "Department")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.data.Entities.Subject", "Subjects")
                        .WithMany("DepartmetsSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("School.data.Entities.InsSubject", b =>
                {
                    b.HasOne("School.data.Entities.Instructor", "Instructor")
                        .WithMany("InsSubjects")
                        .HasForeignKey("InsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.data.Entities.Subject", "Subject")
                        .WithMany("InsSubjects")
                        .HasForeignKey("SubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School.data.Entities.Instructor", b =>
                {
                    b.HasOne("School.data.Entities.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DID");

                    b.HasOne("School.data.Entities.Instructor", "SuperVisor")
                        .WithMany("Instructors")
                        .HasForeignKey("SuperVisorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Department");

                    b.Navigation("SuperVisor");
                });

            modelBuilder.Entity("School.data.Entities.Student", b =>
                {
                    b.HasOne("School.data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("School.data.Entities.StudentSubject", b =>
                {
                    b.HasOne("School.data.Entities.Student", "Student")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("StudID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.data.Entities.Subject", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School.data.Entities.Department", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("School.data.Entities.Instructor", b =>
                {
                    b.Navigation("DepartmentManager");

                    b.Navigation("InsSubjects");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("School.data.Entities.Student", b =>
                {
                    b.Navigation("StudentsSubjects");
                });

            modelBuilder.Entity("School.data.Entities.Subject", b =>
                {
                    b.Navigation("DepartmetsSubjects");

                    b.Navigation("InsSubjects");

                    b.Navigation("StudentsSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
