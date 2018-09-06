﻿// <auto-generated />
using System;
using CAD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CAD.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20180906085136_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("CAD.Models.Setting.Lesson", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("Created_Time");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnName("Created_User")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnName("Modified_Time");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasColumnName("Modified_User")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("CAD.Models.Setting.TeachingAid", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnName("Created_Time");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnName("Created_User")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasMaxLength(20);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LessonId");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnName("Modified_Time");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasColumnName("Modified_User")
                        .HasMaxLength(10);

                    b.Property<string>("Seq")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Teaching_Aid");
                });

            modelBuilder.Entity("CAD.Models.Setting.TeachingAid", b =>
                {
                    b.HasOne("CAD.Models.Setting.Lesson", "Lesson")
                        .WithMany("TeachingAids")
                        .HasForeignKey("LessonId");
                });
#pragma warning restore 612, 618
        }
    }
}