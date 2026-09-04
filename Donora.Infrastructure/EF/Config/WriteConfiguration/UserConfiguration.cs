using Donora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class UserConfiguration
    : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(x => x.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.UserName)
            .HasColumnName("username")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasColumnName("middle_name")
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Mobile)
            .HasColumnName("mobile")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .HasColumnName("password_hash")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(x => x.IsEmailVerified)
            .HasColumnName("is_email_verified")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.Mobile)
            .IsUnique();
    }
}