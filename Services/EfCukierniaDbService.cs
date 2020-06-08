using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cw13.DTOs;
using Cw13.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw13.Services
{
    public class EfCukierniaDbService : ICukierniaDbService
    {
        private readonly CukierniaDbContext _context;
        public EfCukierniaDbService(CukierniaDbContext context)
        {
            _context = context;
        }

        public IEnumerable GetOrders()
        {
            var res = _context.Zamowienie.Select(z => new
            {
                z.IdZamowienia,
                z.DataPrzyjecia,
                z.DataRealizacji,
                z.Uwagi,
                wyroby = z.Zamowienie_WyrobCukierniczy.Join(_context.WyrobCukierniczy, zam_wyr => zam_wyr.IdWyrobuCukierniczego, wyr => wyr.IdWyrobuCukierniczego,
                    (zam_wyr, wyr) => new {
                        wyr.Nazwa,
                        wyr.Typ,
                        wyr.CenaZaSzt,
                        zam_wyr.Ilosc, 
                        zam_wyr.Uwagi
                    
                    })
            }).ToList();

            return res;
        }

        public IEnumerable GetOrders(string name)
        {
            var client = _context.Klient.FirstOrDefault(e => e.Nazwisko == name);
            
            if(client == null)
                throw new Exception("Nie ma takiego klienta!");
            
            var res = _context.Zamowienie.Where(e => e.Klient.Nazwisko.Equals(name))
                .Select(z => new
                {
                    z.IdZamowienia,
                    z.DataPrzyjecia,
                    z.DataRealizacji,
                    z.Uwagi,
                    wyroby = z.Zamowienie_WyrobCukierniczy.Join(_context.WyrobCukierniczy, zam_wyr => zam_wyr.IdWyrobuCukierniczego, wyr => wyr.IdWyrobuCukierniczego,
                         (zam_wyr, wyr) => new {
                              wyr.Nazwa,
                              wyr.Typ,
                              wyr.CenaZaSzt,
                              zam_wyr.Ilosc, 
                              zam_wyr.Uwagi
                          })
                }).ToList();
            
            return res;
        }

        public string AddNewOrder(int id, AddNewOrderRequest request)
        {
            var client = _context.Klient.FirstOrDefault(e => e.IdKlient == id);
            
            if(client == null)
                throw new Exception("Nie ma takiego klienta!");

            foreach (var wyrobRequest in request.wyroby)
            {
                var res = _context.WyrobCukierniczy.FirstOrDefault(e => e.Nazwa.Equals(wyrobRequest.wyrob));
                if(res == null)
                    throw new Exception(wyrobRequest.wyrob + "- Nie ma takiego wyrobu!");
            }
            
            Zamowienie zamowienie = new Zamowienie()
            {
                DataPrzyjecia = request.dataPrzyjecia,
                Uwagi = request.uwagi,
                IdKlient = id,
                IdPracownik = 1,
                Zamowienie_WyrobCukierniczy = new List<Zamowienie_WyrobCukierniczy>()
            };

            foreach (var wyrobRequest in request.wyroby)
             { 
                 Zamowienie_WyrobCukierniczy zam_wyr = new Zamowienie_WyrobCukierniczy()
                 {
                     IdWyrobuCukierniczego = _context.WyrobCukierniczy.First(e => e.Nazwa==wyrobRequest.wyrob).IdWyrobuCukierniczego,
                     Ilosc = wyrobRequest.ilosc,
                     Uwagi = wyrobRequest.uwagi
                 };
                 zamowienie.Zamowienie_WyrobCukierniczy.Add(zam_wyr);
             }

            _context.Zamowienie.Add(zamowienie);
            _context.SaveChanges();
            
            return "Złożono nowe zamówienie";
        }
    }
}