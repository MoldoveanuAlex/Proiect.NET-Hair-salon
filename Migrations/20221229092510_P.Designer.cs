﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_.NET_Hair_salon.Data;

#nullable disable

namespace Proiect_.NET_Hair_salon.Migrations
{
    [DbContext(typeof(Proiect_NET_Hair_salonContext))]
    [Migration("20221229092510_P")]
    partial class P
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.CategorieServiciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("ServiciuID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("ServiciuID");

                    b.ToTable("CategorieServiciu");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Hairstylist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hairstylist");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Membru", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Membru");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("MembruID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OraProgramare")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiciuID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MembruID");

                    b.HasIndex("ServiciuID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Serviciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<int?>("HairstylistID")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HairstylistID");

                    b.ToTable("Serviciu");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.CategorieServiciu", b =>
                {
                    b.HasOne("Proiect_.NET_Hair_salon.Models.Categorie", "Categorie")
                        .WithMany("CategoriiServiciu")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_.NET_Hair_salon.Models.Serviciu", "Serviciu")
                        .WithMany("CategoriiServiciu")
                        .HasForeignKey("ServiciuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Serviciu");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Programare", b =>
                {
                    b.HasOne("Proiect_.NET_Hair_salon.Models.Membru", "Membru")
                        .WithMany("Programari")
                        .HasForeignKey("MembruID");

                    b.HasOne("Proiect_.NET_Hair_salon.Models.Serviciu", "Serviciu")
                        .WithMany()
                        .HasForeignKey("ServiciuID");

                    b.Navigation("Membru");

                    b.Navigation("Serviciu");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Serviciu", b =>
                {
                    b.HasOne("Proiect_.NET_Hair_salon.Models.Hairstylist", "Hairstylist")
                        .WithMany("Servicii")
                        .HasForeignKey("HairstylistID");

                    b.Navigation("Hairstylist");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Categorie", b =>
                {
                    b.Navigation("CategoriiServiciu");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Hairstylist", b =>
                {
                    b.Navigation("Servicii");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Membru", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("Proiect_.NET_Hair_salon.Models.Serviciu", b =>
                {
                    b.Navigation("CategoriiServiciu");
                });
#pragma warning restore 612, 618
        }
    }
}