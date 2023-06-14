﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infra.SqlServer.EF;

#nullable disable

namespace infra.SqlServer.EF.Migrations
{
    [DbContext(typeof(EntrepriseDbContext))]
    [Migration("20230614075718_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("infra.SqlServer.EF.Client", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("History")
                        .HasColumnType("xml");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("infra.SqlServer.EF.Departement", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("Label")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departement", (string)null);
                });

            modelBuilder.Entity("infra.SqlServer.EF.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("DaysOff")
                        .HasColumnType("int");

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("DepartementId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("infra.SqlServer.EF.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("infra.SqlServer.EF.Client", b =>
                {
                    b.HasOne("infra.SqlServer.EF.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Client_Employee");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("infra.SqlServer.EF.Employee", b =>
                {
                    b.HasOne("infra.SqlServer.EF.Departement", "Departement")
                        .WithMany("Employees")
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Employee_Departement");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("infra.SqlServer.EF.Invoice", b =>
                {
                    b.HasOne("infra.SqlServer.EF.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("infra.SqlServer.EF.Client", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("infra.SqlServer.EF.Departement", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
