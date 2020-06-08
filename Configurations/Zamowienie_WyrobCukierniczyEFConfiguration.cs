using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class Zamowienie_WyrobCukierniczyEFConfiguration : IEntityTypeConfiguration<Zamowienie_WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<Zamowienie_WyrobCukierniczy> builder)
        {
            builder.HasKey(e => new { e.IdWyrobuCukierniczego, e.IdZamowienia });
            builder.Property(e => e.Ilosc).IsRequired();
            builder.Property(e => e.Uwagi).HasMaxLength(300);
        }
    }
}