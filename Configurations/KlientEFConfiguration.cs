using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class KlientEFConfiguration : IEntityTypeConfiguration<Klient>
    {
        public void Configure(EntityTypeBuilder<Klient> builder)
        {
            builder.HasKey(e => e.IdKlient);
            builder.Property(e => e.IdKlient).ValueGeneratedOnAdd();
            builder.Property(e => e.Imie).IsRequired();
            builder.Property(e => e.Imie).HasMaxLength(50);
            builder.Property(e => e.Nazwisko).IsRequired();
            builder.Property(e => e.Nazwisko).HasMaxLength(60);

            builder.HasMany(e => e.Zamowienia)
                .WithOne(e => e.Klient)
                .HasForeignKey(e => e.IdKlient)
                .IsRequired();
        }
    }
}