using Donora.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class DonorReadConfiguration
    : IEntityTypeConfiguration<DonorReadModel>
{
    public void Configure(EntityTypeBuilder<DonorReadModel> builder)
    {
        builder.ToTable("donors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DisplayName)
            .HasMaxLength(200);

        builder.Property(x => x.IsAnonymous)
            .IsRequired();
    }
}