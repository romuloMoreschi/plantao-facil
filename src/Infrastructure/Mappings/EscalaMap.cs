using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class EscalaMap : IEntityTypeConfiguration<Escala>
{
    public void Configure(EntityTypeBuilder<Escala> builder)
    {
        builder.ToTable("Escalas");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.DataInicial).HasColumnType("timestamp").IsRequired();

        builder.Property(e => e.DataTermino).HasColumnType("timestamp").IsRequired();

        builder
            .HasMany(e => e.Vagas)
            .WithOne(e => e.Escala)
            .HasForeignKey(e => e.EscalaId);

        builder
            .HasMany(e => e.Funcionarios)
            .WithOne(e => e.Escala)
            .HasForeignKey(e => e.EscalaId);
    }
}