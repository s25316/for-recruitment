using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAdapter.Database;

public partial class MasContext : DbContext
{
    public MasContext()
    {
    }

    public MasContext(DbContextOptions<MasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdministrativeType> AdministrativeTypes { get; set; }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Universite> Universites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MAS;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdministrativeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AdministrativeType_pk");

            entity.ToTable("AdministrativeType");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Adresses_pk");

            entity.HasIndex(e => e.DivisionId, "IX_Adresses_DivisionId");

            entity.HasIndex(e => e.StreetId, "IX_Adresses_StreetId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Division).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Adress_Division");

            entity.HasOne(d => d.Street).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.StreetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Adress_Street");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Company_pk");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nip).HasColumnName("NIP");
            entity.Property(e => e.Regon).HasColumnName("REGON");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Divisions_pk");

            entity.HasIndex(e => e.TypeId, "IX_Divisions_TypeId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Type).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Divisions_AdministrativeType");

            entity.HasMany(d => d.IdStreets).WithMany(p => p.IdDivisions)
                .UsingEntity<Dictionary<string, object>>(
                    "DivisionsStreet",
                    r => r.HasOne<Street>().WithMany()
                        .HasForeignKey("IdStreet")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Division>().WithMany()
                        .HasForeignKey("IdDivision")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("IdDivision", "IdStreet");
                        j.ToTable("DivisionsStreets");
                        j.HasIndex(new[] { "IdStreet" }, "IX_DivisionsStreets_IdStreet");
                    });
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Streets_pk");

            entity.HasIndex(e => e.TypeId, "IX_Streets_TypeId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Type).WithMany(p => p.Streets)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("Streets_AdministrativeType");
        });

        modelBuilder.Entity<Universite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("University_pk");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Www).HasColumnName("WWW");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Universite)
                .HasForeignKey<Universite>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("University_Company");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
