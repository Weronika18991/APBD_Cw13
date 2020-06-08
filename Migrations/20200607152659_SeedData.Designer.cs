﻿// <auto-generated />
using System;
using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw13.Migrations
{
    [DbContext(typeof(CukierniaDbContext))]
    [Migration("20200607152659_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw13.Models.Klient", b =>
                {
                    b.Property<int>("IdKlient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdKlient");

                    b.ToTable("Klient");

                    b.HasData(
                        new
                        {
                            IdKlient = 1,
                            Imie = "Jan",
                            Nazwisko = "Kowalski"
                        },
                        new
                        {
                            IdKlient = 2,
                            Imie = "Mateusz",
                            Nazwisko = "Malczewski"
                        });
                });

            modelBuilder.Entity("Cw13.Models.Pracownik", b =>
                {
                    b.Property<int>("IdPracownik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdPracownik");

                    b.ToTable("Pracownik");

                    b.HasData(
                        new
                        {
                            IdPracownik = 1,
                            Imie = "Ola",
                            Nazwisko = "Nowak"
                        });
                });

            modelBuilder.Entity("Cw13.Models.WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdWyrobuCukierniczego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CenaZaSzt")
                        .HasColumnType("real");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdWyrobuCukierniczego");

                    b.ToTable("WyrobCukierniczy");

                    b.HasData(
                        new
                        {
                            IdWyrobuCukierniczego = 1,
                            CenaZaSzt = 2.5f,
                            Nazwa = "Jagodzianka",
                            Typ = "Słodkie"
                        },
                        new
                        {
                            IdWyrobuCukierniczego = 2,
                            CenaZaSzt = 2.9f,
                            Nazwa = "Pączek",
                            Typ = "Słodkie"
                        });
                });

            modelBuilder.Entity("Cw13.Models.Zamowienie", b =>
                {
                    b.Property<int>("IdZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPrzyjecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRealizacji")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdKlient")
                        .HasColumnType("int");

                    b.Property<int>("IdPracownik")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdZamowienia");

                    b.HasIndex("IdKlient");

                    b.HasIndex("IdPracownik");

                    b.ToTable("Zamowienie");

                    b.HasData(
                        new
                        {
                            IdZamowienia = 1,
                            DataPrzyjecia = new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataRealizacji = new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdKlient = 1,
                            IdPracownik = 1,
                            Uwagi = "Brak"
                        },
                        new
                        {
                            IdZamowienia = 2,
                            DataPrzyjecia = new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataRealizacji = new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdKlient = 2,
                            IdPracownik = 1,
                            Uwagi = "Brak"
                        });
                });

            modelBuilder.Entity("Cw13.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdWyrobuCukierniczego")
                        .HasColumnType("int");

                    b.Property<int>("IdZamowienia")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdWyrobuCukierniczego", "IdZamowienia");

                    b.HasIndex("IdZamowienia");

                    b.ToTable("Zamowienie_WyrobCukierniczy");

                    b.HasData(
                        new
                        {
                            IdWyrobuCukierniczego = 1,
                            IdZamowienia = 1,
                            Ilosc = 2
                        },
                        new
                        {
                            IdWyrobuCukierniczego = 2,
                            IdZamowienia = 1,
                            Ilosc = 3,
                            Uwagi = "Osobne pakowanie"
                        });
                });

            modelBuilder.Entity("Cw13.Models.Zamowienie", b =>
                {
                    b.HasOne("Cw13.Models.Klient", "Klient")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdKlient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cw13.Models.Pracownik", "Pracownik")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdPracownik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cw13.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.HasOne("Cw13.Models.WyrobCukierniczy", "WyrobCukierniczy")
                        .WithMany("Zamowienie_WyrobCukierniczy")
                        .HasForeignKey("IdWyrobuCukierniczego")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cw13.Models.Zamowienie", "Zamowienie")
                        .WithMany("Zamowienie_WyrobCukierniczy")
                        .HasForeignKey("IdZamowienia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
