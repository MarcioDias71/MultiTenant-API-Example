﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211227164944_Quinto  migration")]
    partial class Quintomigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Core.Domain.Empresa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Core.Domain.EmpresaConexao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ID_EMPRESA")
                        .HasColumnType("integer");

                    b.Property<string>("NomeDoBanco")
                        .HasColumnType("text");

                    b.Property<int>("Porta")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.Property<string>("Servidor")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ID_EMPRESA");

                    b.ToTable("EmpresasConexoes");
                });

            modelBuilder.Entity("Core.Domain.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EmpresaID")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Core.Domain.EmpresaConexao", b =>
                {
                    b.HasOne("Core.Domain.Empresa", "EmpresaNavigation")
                        .WithMany()
                        .HasForeignKey("ID_EMPRESA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmpresaNavigation");
                });

            modelBuilder.Entity("Core.Domain.Usuario", b =>
                {
                    b.HasOne("Core.Domain.Empresa", "Empresa")
                        .WithMany("Usuarios")
                        .HasForeignKey("EmpresaID");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Core.Domain.Empresa", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
