using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class WyrobCukierniczyEFConfiguration : IEntityTypeConfiguration<WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<WyrobCukierniczy> builder)
        {
            builder.HasKey(e => e.IdWyrobuCukierniczego);
            builder.Property(e => e.IdWyrobuCukierniczego).ValueGeneratedOnAdd();
            builder.Property(e => e.Nazwa).IsRequired();
            builder.Property(e => e.Nazwa).HasMaxLength(200);
            builder.Property(e => e.CenaZaSzt).IsRequired();
            builder.Property(e => e.Typ).IsRequired();
            builder.Property(e => e.Typ).HasMaxLength(40);
            
            builder.HasMany(e => e.Zamowienie_WyrobCukierniczy)
                .WithOne(e => e.WyrobCukierniczy)
                .HasForeignKey(e => e.IdWyrobuCukierniczego)
                .IsRequired();
        }
    }
}