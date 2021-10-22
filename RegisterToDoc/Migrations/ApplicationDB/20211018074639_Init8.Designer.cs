﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegisterToDoc.BD;

namespace RegisterToDoc.Migrations.ApplicationDB
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211018074639_Init8")]
    partial class Init8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("RegisterToDoc.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("RegisterToDoc.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("BLOB");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.Property<string>("Education")
                        .HasColumnType("TEXT");

                    b.Property<int>("Experience")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialization")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("RegisterToDoc.Models.Interval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Busy")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartHour")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkGraphicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkGraphicId");

                    b.ToTable("Intervals");
                });

            modelBuilder.Entity("RegisterToDoc.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("RegisterToDoc.Models.WorkGraphic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartHour")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("WorkGraphics");
                });

            modelBuilder.Entity("RegisterToDoc.Models.Interval", b =>
                {
                    b.HasOne("RegisterToDoc.Models.WorkGraphic", "WorkGraphic")
                        .WithMany("Intervals")
                        .HasForeignKey("WorkGraphicId");

                    b.Navigation("WorkGraphic");
                });

            modelBuilder.Entity("RegisterToDoc.Models.WorkGraphic", b =>
                {
                    b.HasOne("RegisterToDoc.Models.Doctor", "Doctor")
                        .WithMany("WorkGraphic")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("RegisterToDoc.Models.Doctor", b =>
                {
                    b.Navigation("WorkGraphic");
                });

            modelBuilder.Entity("RegisterToDoc.Models.WorkGraphic", b =>
                {
                    b.Navigation("Intervals");
                });
#pragma warning restore 612, 618
        }
    }
}
