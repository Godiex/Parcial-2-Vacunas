﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(VacunaContext))]
    partial class VacunaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreInstitucionEducativa")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("NombresAcudiente")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Identificacion");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entidad.Vacuna", b =>
                {
                    b.Property<int>("VacunaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("VacunaId");

                    b.HasIndex("Identificacion");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Entidad.Vacuna", b =>
                {
                    b.HasOne("Entidad.Persona", null)
                        .WithMany()
                        .HasForeignKey("Identificacion");
                });
#pragma warning restore 612, 618
        }
    }
}
