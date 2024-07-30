﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleApp09__EF__CdF_.DatabaseLayer;

#nullable disable

namespace SimpleApp09__EF__CdF_.Migrations
{
    [DbContext(typeof(MusicDBContext))]
    [Migration("20240503233053_Third")]
    partial class Third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdAlbum");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlbum"));

                    b.Property<int>("IdLabel")
                        .HasColumnType("int");

                    b.Property<string>("NameAlbum")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("NazwaAlbumu");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataWydania");

                    b.HasKey("IdAlbum")
                        .HasName("Album_pk");

                    b.HasIndex("IdLabel");

                    b.ToTable("Album", (string)null);

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            IdLabel = 1,
                            NameAlbum = "Syrenki",
                            ReleaseDate = new DateTime(2024, 5, 4, 1, 30, 53, 723, DateTimeKind.Local).AddTicks(2739)
                        },
                        new
                        {
                            IdAlbum = 2,
                            IdLabel = 1,
                            NameAlbum = "Nadwislanskie Szanty",
                            ReleaseDate = new DateTime(2024, 5, 4, 1, 30, 53, 723, DateTimeKind.Local).AddTicks(2786)
                        });
                });

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Label", b =>
                {
                    b.Property<int>("IdLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdWytwornia");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLabel"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Nazwa");

                    b.HasKey("IdLabel")
                        .HasName("Wytwornia_pk");

                    b.ToTable("Wytwornia", (string)null);

                    b.HasData(
                        new
                        {
                            IdLabel = 1,
                            Name = "Warszawianka"
                        },
                        new
                        {
                            IdLabel = 2,
                            Name = "Głos Wrocławia"
                        });
                });

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdMuzyk");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMusician"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Imie");

                    b.Property<string>("Nickname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Pseudonim");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Nazwisko");

                    b.HasKey("IdMusician")
                        .HasName("Muzyk_pk");

                    b.ToTable("Muzyk", (string)null);

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            Name = "Andrzej",
                            Surname = "Kwiatkowski"
                        },
                        new
                        {
                            IdMusician = 2,
                            Name = "Damian",
                            Nickname = "Cebula",
                            Surname = "Cebulski"
                        },
                        new
                        {
                            IdMusician = 3,
                            Name = "Anna",
                            Surname = "Kwiatkowska"
                        });
                });

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Song", b =>
                {
                    b.Property<int>("IdSong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdUtwor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSong"));

                    b.Property<float>("Duration")
                        .HasColumnType("real")
                        .HasColumnName("CzasTrwania");

                    b.Property<int?>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<string>("SongName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("NazwaUtworu");

                    b.HasKey("IdSong")
                        .HasName("Utwor_pk");

                    b.HasIndex("IdAlbum");

                    b.ToTable("Utwor", (string)null);

                    b.HasData(
                        new
                        {
                            IdSong = 1,
                            Duration = 2.12f,
                            IdAlbum = 1,
                            SongName = "Warszawa"
                        },
                        new
                        {
                            IdSong = 2,
                            Duration = 2.12f,
                            SongName = "Poznan"
                        });
                });

            modelBuilder.Entity("WykonwcaUtworu", b =>
                {
                    b.Property<int>("MusiciansIdMusician")
                        .HasColumnType("int");

                    b.Property<int>("SongsIdSong")
                        .HasColumnType("int");

                    b.HasKey("MusiciansIdMusician", "SongsIdSong");

                    b.HasIndex("SongsIdSong");

                    b.ToTable("WykonwcaUtworu");
                });

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Album", b =>
                {
                    b.HasOne("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Label", "Label")
                        .WithMany("Albums")
                        .HasForeignKey("IdLabel")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Albums_Label");

                    b.Navigation("Label");
                });

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Song", b =>
                {
                    b.HasOne("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("IdAlbum")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("Songs_Album");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("WykonwcaUtworu", b =>
                {
                    b.HasOne("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Musician", null)
                        .WithMany()
                        .HasForeignKey("MusiciansIdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsIdSong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SimpleApp09__EF__CdF_.DatabaseLayer.Models.Label", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
