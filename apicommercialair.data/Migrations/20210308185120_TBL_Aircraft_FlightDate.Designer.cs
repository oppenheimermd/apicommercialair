﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apicommercialair.data;

namespace apicommercialair.data.Migrations
{
    [DbContext(typeof(CommercialairDbContext))]
    [Migration("20210308185120_TBL_Aircraft_FlightDate")]
    partial class TBL_Aircraft_FlightDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apicommercialair.core.Models.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftCategory")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("apicommercialair.core.Models.AircraftImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("VariantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VariantId");

                    b.ToTable("AircraftImages");
                });

            modelBuilder.Entity("apicommercialair.core.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAbout")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyWebsite")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("apicommercialair.core.Models.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("apicommercialair.core.Models.Aircraft", b =>
                {
                    b.HasOne("apicommercialair.core.Models.Manufacturer", "Manufacturer")
                        .WithMany("Aircraft")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("apicommercialair.core.Models.AircraftImage", b =>
                {
                    b.HasOne("apicommercialair.core.Models.Variant", "Variant")
                        .WithMany("AircraftImages")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("apicommercialair.core.Models.Variant", b =>
                {
                    b.HasOne("apicommercialair.core.Models.Aircraft", "Aircraft")
                        .WithMany("Variants")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("apicommercialair.core.Models.Aircraft", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("apicommercialair.core.Models.Manufacturer", b =>
                {
                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("apicommercialair.core.Models.Variant", b =>
                {
                    b.Navigation("AircraftImages");
                });
#pragma warning restore 612, 618
        }
    }
}
