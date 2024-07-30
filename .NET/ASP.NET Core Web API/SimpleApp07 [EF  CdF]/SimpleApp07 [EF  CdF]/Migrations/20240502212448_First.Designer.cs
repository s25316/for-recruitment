﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleApp07__EF__CdF_.DatabaseLayer;

#nullable disable

namespace SimpleApp07__EF__CdF_.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240502212448_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleApp07__EF__CdF_.DatabaseLayer.Actor", b =>
                {
                    b.Property<int>("IdActor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdActor"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Nickname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("IdActor")
                        .HasName("Aktor_pk");

                    b.ToTable("Aktor", (string)null);

                    b.HasData(
                        new
                        {
                            IdActor = 1,
                            Name = "Frank",
                            Nickname = "Punisher",
                            Surname = "Castle"
                        },
                        new
                        {
                            IdActor = 2,
                            Name = "Billy",
                            Nickname = "Jigsaw",
                            Surname = "Russo"
                        },
                        new
                        {
                            IdActor = 3,
                            Name = "Caren",
                            Surname = "Page"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}