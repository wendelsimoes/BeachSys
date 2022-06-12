﻿// <auto-generated />
using System;
using BeachSys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeachSys.Migrations
{
    [DbContext(typeof(BeachSysContext))]
    [Migration("20220612152114_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeachSys.Models.Armario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int>("PontoX")
                        .HasColumnType("int");

                    b.Property<int>("PontoY")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Armarios");
                });

            modelBuilder.Entity("BeachSys.Models.Compartimento", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ArmarioID")
                        .HasColumnType("int");

                    b.Property<int>("Comprimento")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Largura")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Numero");

                    b.HasIndex("ArmarioID");

                    b.HasIndex("UsuarioID")
                        .IsUnique();

                    b.ToTable("Compartimentos");
                });

            modelBuilder.Entity("BeachSys.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("BeachSys.Models.Admin", b =>
                {
                    b.HasBaseType("BeachSys.Models.Usuario");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CPF = "admin",
                            Email = "admin",
                            Nome = "admin"
                        });
                });

            modelBuilder.Entity("BeachSys.Models.Armario", b =>
                {
                    b.HasOne("BeachSys.Models.Admin", "Admin")
                        .WithMany("Armarios")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeachSys.Models.Compartimento", b =>
                {
                    b.HasOne("BeachSys.Models.Armario", null)
                        .WithMany("Compartimentos")
                        .HasForeignKey("ArmarioID");

                    b.HasOne("BeachSys.Models.Usuario", "Usuario")
                        .WithOne("Compartimento")
                        .HasForeignKey("BeachSys.Models.Compartimento", "UsuarioID");
                });
#pragma warning restore 612, 618
        }
    }
}