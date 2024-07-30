﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleApp07__EF__CdF_.DatabaseLayer;

#nullable disable

namespace SimpleApp07__EF__CdF_.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SimpleApp07__EF__CdF_.DatabaseLayer.ActorMovie", b =>
                {
                    b.Property<int>("IdActorMovie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdActorMovie"));

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<int>("IdActor")
                        .HasColumnType("int");

                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.HasKey("IdActorMovie")
                        .HasName("AktorFilm_pk");

                    b.HasIndex("IdActor");

                    b.HasIndex("IdMovie");

                    b.ToTable("AktorFilm", (string)null);
                });

            modelBuilder.Entity("SimpleApp07__EF__CdF_.DatabaseLayer.Movie", b =>
                {
                    b.Property<int>("IdMovie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMovie"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar");

                    b.Property<DateOnly>("RelizeDate")
                        .HasColumnType("date");

                    b.HasKey("IdMovie")
                        .HasName("Film_pk");

                    b.ToTable("Film", (string)null);

                    b.HasData(
                        new
                        {
                            IdMovie = 1,
                            Name = "GoldenEye",
                            RelizeDate = new DateOnly(1995, 12, 1)
                        },
                        new
                        {
                            IdMovie = 2,
                            Name = "Jutro nie umiera nigdy ",
                            RelizeDate = new DateOnly(1997, 1, 16)
                        },
                        new
                        {
                            IdMovie = 3,
                            Name = "Świat to za mało",
                            RelizeDate = new DateOnly(1999, 11, 8)
                        });
                });

            modelBuilder.Entity("SimpleApp07__EF__CdF_.DatabaseLayer.ActorMovie", b =>
                {
                    b.HasOne("SimpleApp07__EF__CdF_.DatabaseLayer.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdActor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ActorMovie_Actor");

                    b.HasOne("SimpleApp07__EF__CdF_.DatabaseLayer.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ActorMovie_Movie");

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SimpleApp07__EF__CdF_.DatabaseLayer.Actor", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("SimpleApp07__EF__CdF_.DatabaseLayer.Movie", b =>
                {
                    b.Navigation("ActorMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
