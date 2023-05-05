﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityCourseAndResultManagementSystem.Data;

#nullable disable

namespace UniversityCourseAndResultManagementSystem.Data.Migrations
{
    [DbContext(typeof(UniversityCourseAndResultManagementSystemContext))]
    [Migration("20230505125409_isDelete_added_to_studentEnrolledCourse")]
    partial class isDeleteaddedtostudentEnrolledCourse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.AssignedCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("AssignedCourses");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Credit")
                        .HasColumnType("real");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Designation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.EnrolledCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("EnrolledCourses");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("RoomId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Semester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.SemesterCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("SemesterId");

                    b.ToTable("SemesterCourses");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegiNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.StudentEnrolledCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EnrolledCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EnrolledCourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentEnrolledCourses");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CreditTaken")
                        .HasColumnType("real");

                    b.Property<float>("CreditToBeTaken")
                        .HasColumnType("real");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DesignationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.AssignedCourse", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Course", "Course")
                        .WithOne("AssignedCourse")
                        .HasForeignKey("UniversityCourseAndResultManagementSystem.Model.AssignedCourse", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Teacher", "Teacher")
                        .WithMany("AssignedCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Course", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.EnrolledCourse", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Course", "Course")
                        .WithOne("EnrolledCourse")
                        .HasForeignKey("UniversityCourseAndResultManagementSystem.Model.EnrolledCourse", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Schedule", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Course", "Course")
                        .WithMany("Schedules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Room", "Room")
                        .WithMany("Schedules")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.SemesterCourse", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Course", "Course")
                        .WithMany("SemesterCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Semester", "Semester")
                        .WithMany("SemesterCourse")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Student", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.StudentEnrolledCourse", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.EnrolledCourse", "EnrolledCourse")
                        .WithMany("StudentEnrolledCourse")
                        .HasForeignKey("EnrolledCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Student", "Student")
                        .WithMany("StudentEnrolledCourse")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnrolledCourse");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Teacher", b =>
                {
                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityCourseAndResultManagementSystem.Model.Designation", "Designation")
                        .WithMany("Teachers")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Designation");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Course", b =>
                {
                    b.Navigation("AssignedCourse")
                        .IsRequired();

                    b.Navigation("EnrolledCourse")
                        .IsRequired();

                    b.Navigation("Schedules");

                    b.Navigation("SemesterCourse");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Designation", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.EnrolledCourse", b =>
                {
                    b.Navigation("StudentEnrolledCourse");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Room", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Semester", b =>
                {
                    b.Navigation("SemesterCourse");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Student", b =>
                {
                    b.Navigation("StudentEnrolledCourse");
                });

            modelBuilder.Entity("UniversityCourseAndResultManagementSystem.Model.Teacher", b =>
                {
                    b.Navigation("AssignedCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
