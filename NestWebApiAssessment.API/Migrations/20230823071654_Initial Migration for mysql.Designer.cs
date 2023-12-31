﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NestWebApiAssessment.API.Data;

#nullable disable

namespace NestWebApiAssessment.API.Migrations
{
    [DbContext(typeof(PolicyDbContext))]
    [Migration("20230823071654_Initial Migration for mysql")]
    partial class InitialMigrationformysql
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NestWebApiAssessment.API.Model.Domain.Brands", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("BrandId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("zBrand");
                });

            modelBuilder.Entity("NestWebApiAssessment.API.Model.Domain.Models", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.ToTable("zModel");
                });

            modelBuilder.Entity("NestWebApiAssessment.API.Model.Domain.VehicleTypes", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("zVehicleType");
                });

            modelBuilder.Entity("NestWebApiAssessment.API.Model.Domain.Brands", b =>
                {
                    b.HasOne("NestWebApiAssessment.API.Model.Domain.VehicleTypes", "VehicleTypes")
                        .WithMany("Brands")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleTypes");
                });

            modelBuilder.Entity("NestWebApiAssessment.API.Model.Domain.Models", b =>
                {
                    b.HasOne("NestWebApiAssessment.API.Model.Domain.Brands", "Brands")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brands");
                });

            modelBuilder.Entity("NestWebApiAssessment.API.Model.Domain.Brands", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("NestWebApiAssessment.API.Model.Domain.VehicleTypes", b =>
                {
                    b.Navigation("Brands");
                });
#pragma warning restore 612, 618
        }
    }
}
