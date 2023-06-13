using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace infra.SqlServer.EF;

public partial class EntrepriseDbContext : DbContext
{
    public EntrepriseDbContext()
    {
    }

    public EntrepriseDbContext(DbContextOptions<EntrepriseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Departement> Departements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=PC2023\\PC2023;TrustServerCertificate=true;Initial Catalog=EntrepriseDB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Client");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.History).HasColumnType("xml");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Client_Employee");
        });

        modelBuilder.Entity<Departement>(entity =>
        {
            entity.ToTable("Departement");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Label).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.Departement).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartementId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Employee_Departement");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
