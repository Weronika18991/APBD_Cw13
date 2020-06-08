using System;
using System.Collections.Generic;
using Cw13.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cw13.Models
{
    public class CukierniaDbContext : DbContext
    {
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Pracownik> Pracownik { get; set; }
        public DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
        
        public CukierniaDbContext(){}

        public CukierniaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new KlientEFConfiguration());
            modelBuilder.ApplyConfiguration(new PracownikEFConfiguration());
            modelBuilder.ApplyConfiguration(new WyrobCukierniczyEFConfiguration());
            modelBuilder.ApplyConfiguration(new ZamowienieEFConfiguration());
            modelBuilder.ApplyConfiguration(new Zamowienie_WyrobCukierniczyEFConfiguration());
            SeedData(modelBuilder);

        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            var klienci = new List<Klient>();
            klienci.Add(new Klient()
            {
                IdKlient = 1,
                Imie = "Jan",
                Nazwisko = "Kowalski"
            });
            klienci.Add(new Klient()
            {
                IdKlient = 2,
                Imie = "Mateusz",
                Nazwisko = "Malczewski"
            });
            modelBuilder.Entity<Klient>().HasData(klienci);
            
            var pracownicy = new List<Pracownik>();
            pracownicy.Add(new Pracownik()
            {
                IdPracownik = 1,
                Imie = "Ola",
                Nazwisko = "Nowak"
            });
            modelBuilder.Entity<Pracownik>().HasData(pracownicy);
            
            var wyrobycukiernicze = new List<WyrobCukierniczy>();
            wyrobycukiernicze.Add(new WyrobCukierniczy()
            {
                IdWyrobuCukierniczego = 1,
                Nazwa = "Jagodzianka",
                CenaZaSzt = 2.5f,
                Typ="Słodkie"
            });
            wyrobycukiernicze.Add(new WyrobCukierniczy()
            {
                IdWyrobuCukierniczego = 2,
                Nazwa = "Pączek",
                CenaZaSzt = 2.9f,
                Typ="Słodkie"
            });
            modelBuilder.Entity<WyrobCukierniczy>().HasData(wyrobycukiernicze);
            
            var zamowienia = new List<Zamowienie>();
            zamowienia.Add(new Zamowienie()
            {
                IdZamowienia = 1,
                DataPrzyjecia = Convert.ToDateTime("08.04.2020"),
                DataRealizacji = Convert.ToDateTime("20.04.2020"),
                Uwagi = "Brak",
                IdKlient = 1,
                IdPracownik = 1
            });
            zamowienia.Add(new Zamowienie()
            {
                IdZamowienia = 2,
                DataPrzyjecia = Convert.ToDateTime("08.05.2020"),
                DataRealizacji = Convert.ToDateTime("10.05.2020"),
                Uwagi = "Brak",
                IdKlient = 2,
                IdPracownik = 1
            });
            modelBuilder.Entity<Zamowienie>().HasData(zamowienia);


            var zamowienia_wyroby = new List<Zamowienie_WyrobCukierniczy>();
            zamowienia_wyroby.Add(new Zamowienie_WyrobCukierniczy()
            {
                IdWyrobuCukierniczego = 1,
                IdZamowienia = 1,
                Ilosc = 2
            });
            zamowienia_wyroby.Add(new Zamowienie_WyrobCukierniczy()
            {
                IdWyrobuCukierniczego = 2,
                IdZamowienia = 1,
                Ilosc = 3,
                Uwagi = "Osobne pakowanie"
            });
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>().HasData(zamowienia_wyroby);




        }
        
        
        
        
    }
}