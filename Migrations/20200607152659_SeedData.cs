using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw13.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klient",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Mateusz", "Malczewski" }
                });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[] { 1, "Ola", "Nowak" });

            migrationBuilder.InsertData(
                table: "WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 2.5f, "Jagodzianka", "Słodkie" },
                    { 2, 2.9f, "Pączek", "Słodkie" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 1, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Brak" });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 2, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Brak" });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 1, 1, 2, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 2, 1, 3, "Osobne pakowanie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 1);
        }
    }
}
