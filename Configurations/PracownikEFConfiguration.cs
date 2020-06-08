using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class PracownikEFConfiguration: IEntityTypeConfiguration<Pracownik>
    {
        public void Configure(EntityTypeBuilder<Pracownik> builder)
        {
            builder.HasKey(e => e.IdPracownik);
            builder.Property(e => e.IdPracownik).ValueGeneratedOnAdd();
            builder.Property(e => e.Imie).IsRequired();
            builder.Property(e => e.Imie).HasMaxLength(50);
            builder.Property(e => e.Nazwisko).IsRequired();
            builder.Property(e => e.Nazwisko).HasMaxLength(60);
            
            builder.HasMany(e => e.Zamowienia)
                .WithOne(e => e.Pracownik)
                .HasForeignKey(e => e.IdPracownik)
                .IsRequired();
        }
    }
}