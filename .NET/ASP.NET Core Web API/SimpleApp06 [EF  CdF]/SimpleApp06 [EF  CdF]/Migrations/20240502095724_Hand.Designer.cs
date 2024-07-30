﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleApp06__EF__CdF_.DatabaseLayer;

#nullable disable

namespace SimpleApp06__EF__CdF_.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240502095724_Hand")]
    partial class Hand
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleApp06__EF__CdF_.DatabaseLayer.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCar"));

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<int>("PropductionYear")
                        .HasColumnType("int");

                    b.HasKey("IdCar")
                        .HasName("Car_pk");

                    b.ToTable("Samochody", (string)null);

                    b.HasData(
                        new
                        {
                            IdCar = 1,
                            Make = "Poland",
                            PropductionYear = 1990
                        },
                        new
                        {
                            IdCar = 2,
                            Make = "Germany",
                            PropductionYear = 1991
                        });
                });

            modelBuilder.Entity("SimpleApp06__EF__CdF_.DatabaseLayer.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerson"));

                    b.Property<string>("DrivingLicence")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar");

                    b.HasKey("IdPerson")
                        .HasName("Person_pk");

                    b.ToTable("Osoba", (string)null);

                    b.HasData(
                        new
                        {
                            IdPerson = 1,
                            Name = "John",
                            Surname = "Reese"
                        },
                        new
                        {
                            IdPerson = 2,
                            DrivingLicence = "ASD32",
                            Name = "Mark",
                            Surname = "Snow"
                        },
                        new
                        {
                            IdPerson = 3,
                            DrivingLicence = "AAAAA",
                            Name = "Harold",
                            Surname = "Finch"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}