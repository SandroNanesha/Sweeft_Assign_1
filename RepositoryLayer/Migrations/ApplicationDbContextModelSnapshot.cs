﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainLayer.Models.Car", b =>
                {
                    b.Property<string>("carKey")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("Date");

                    b.Property<bool>("ForSale")
                        .HasColumnType("Bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("Bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("Float");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("Int");

                    b.Property<string>("SerialNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("Date");

                    b.Property<string>("ownerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("vinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("carKey");

                    b.ToTable("CarTable");
                });

            modelBuilder.Entity("DomainLayer.Models.Client", b =>
                {
                    b.Property<string>("clientKey")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<string>("ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("Bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("clientKey");

                    b.ToTable("ClientTable");
                });
#pragma warning restore 612, 618
        }
    }
}
