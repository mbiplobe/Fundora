using Donora.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class OrganizationReadConfiguration
    : IEntityTypeConfiguration<OrganizationReadModel>
{
    public void Configure(EntityTypeBuilder<OrganizationReadModel> builder)
    {
        builder.ToTable("organizations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Slug)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description);

        builder.Property(x => x.Email)
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .HasMaxLength(50);
    }
}