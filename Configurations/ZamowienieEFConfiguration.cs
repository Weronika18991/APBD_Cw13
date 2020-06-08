using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class ZamowienieEFConfiguration : IEntityTypeConfiguration<Zamowienie>
    {
        public void Configure(EntityTypeBuilder<Zamowienie> builder)
        {
            builder.HasKey(e => e.IdZamowienia);
            builder.Property(e => e.IdZamowienia).ValueGeneratedOnAdd();
            builder.Property(e => e.DataPrzyjecia).IsRequired();
            builder.Property(e => e.Uwagi).HasMaxLength(300);
           
            builder.HasMany(e => e.Zamowienie_WyrobCukierniczy)
                .WithOne(e => e.Zamowienie)
                .HasForeignKey(e => e.IdZamowienia)
                .IsRequired();
        }
    }
}