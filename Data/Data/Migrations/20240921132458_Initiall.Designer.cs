﻿// <auto-generated />
using System;
using Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(Connection))]
    [Migration("20240921132458_Initiall")]
    partial class Initiall
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Tables.DrillBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("DrillBlock");
                });

            modelBuilder.Entity("Data.Tables.DrillBlockPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer")
                        .HasColumnName("DrillBlockId");

                    b.Property<int>("Sequence")
                        .HasColumnType("integer")
                        .HasColumnName("Sequence");

                    b.Property<double>("X")
                        .HasColumnType("double precision")
                        .HasColumnName("X");

                    b.Property<double>("Y")
                        .HasColumnType("double precision")
                        .HasColumnName("Y");

                    b.Property<double>("Z")
                        .HasColumnType("double precision")
                        .HasColumnName("Z");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("DrillBlockPoint");
                });

            modelBuilder.Entity("Data.Tables.Hole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("DEPTH")
                        .HasColumnType("double precision")
                        .HasColumnName("DEPTH");

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer")
                        .HasColumnName("DrillBlockId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("Hole");
                });

            modelBuilder.Entity("Data.Tables.HolePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HoleId")
                        .HasColumnType("integer")
                        .HasColumnName("HoleId");

                    b.Property<double>("X")
                        .HasColumnType("double precision")
                        .HasColumnName("X");

                    b.Property<double>("Y")
                        .HasColumnType("double precision")
                        .HasColumnName("Y");

                    b.Property<double>("Z")
                        .HasColumnType("double precision")
                        .HasColumnName("Z");

                    b.HasKey("Id");

                    b.HasIndex("HoleId");

                    b.ToTable("HolePoint");
                });

            modelBuilder.Entity("Data.Tables.DrillBlockPoint", b =>
                {
                    b.HasOne("Data.Tables.DrillBlock", "DrillBlock")
                        .WithMany("DrillBlockPoints")
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("Data.Tables.Hole", b =>
                {
                    b.HasOne("Data.Tables.DrillBlock", "DrillBlock")
                        .WithMany("Holes")
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("Data.Tables.HolePoint", b =>
                {
                    b.HasOne("Data.Tables.Hole", "Hole")
                        .WithMany("HolePoints")
                        .HasForeignKey("HoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hole");
                });

            modelBuilder.Entity("Data.Tables.DrillBlock", b =>
                {
                    b.Navigation("DrillBlockPoints");

                    b.Navigation("Holes");
                });

            modelBuilder.Entity("Data.Tables.Hole", b =>
                {
                    b.Navigation("HolePoints");
                });
#pragma warning restore 612, 618
        }
    }
}
