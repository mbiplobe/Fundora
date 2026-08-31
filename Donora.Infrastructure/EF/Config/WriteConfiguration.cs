using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<UserEntity>,
IEntityTypeConfiguration<ClassEntity>,
IEntityTypeConfiguration<SectionEntity>, 
IEntityTypeConfiguration<SubjectEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        // EntityID conversion
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new EntityID(value));

        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.FirstName)
                .HasColumnName("First_Name")
                .HasMaxLength(100)
                .IsRequired();

            name.Property(x => x.MiddleName)
                .HasColumnName("Middle_Name")
                .HasMaxLength(100);

            name.Property(x => x.LastName)
                .HasColumnName("Last_Name")
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Value)
                .HasColumnName("Email")
                .HasMaxLength(150)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Mobile, mobile =>
        {
            mobile.Property(x => x.Value)
                .HasColumnName("Mobile")
                .HasMaxLength(11)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Password, password =>
        {
            password.Property(x => x.Value)
                .HasColumnName("Password")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.Property(x => x.CreatedBy)
        .HasColumnName("created_by")
        .HasMaxLength(50);

        builder.Property(x => x.CreatedDate)
        .HasColumnName("created_date")
        .HasMaxLength(50);


        builder.Property(x => x.UpdatedBy)
        .HasColumnName("updated_by")
        .HasMaxLength(50);

        builder.Property(x => x.UpdatedDate)
        .HasColumnName("updated_date")
        .HasMaxLength(50);
    }
    public void Configure(EntityTypeBuilder<ClassEntity> builder)
    {
        builder.ToTable("classes");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.Value)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();
        });

        builder.Property(x => x.Description)
        .HasColumnName("Description")
        .HasMaxLength(500);

        builder.Property(x => x.CreatedBy)
        .HasColumnName("created_by")
        .HasMaxLength(50);

        builder.Property(x => x.CreatedDate)
        .HasColumnName("created_date")
        .HasMaxLength(50);


        builder.Property(x => x.UpdatedBy)
        .HasColumnName("updated_by")
        .HasMaxLength(50);

        builder.Property(x => x.UpdatedDate)
        .HasColumnName("updated_date")
        .HasMaxLength(50);

    }
    public void Configure(EntityTypeBuilder<SectionEntity> builder)
    {
        builder.ToTable("Sections");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.Value)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();
        });

        builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(500);

        builder.Property(x => x.CreatedBy)
        .HasColumnName("created_by")
        .HasMaxLength(50);

        builder.Property(x => x.CreatedDate)
        .HasColumnName("created_date")
        .HasMaxLength(50);

        builder.Property(x => x.UpdatedBy)
        .HasColumnName("updated_by")
        .HasMaxLength(50);

        builder.Property(x => x.UpdatedDate)
        .HasColumnName("updated_date")
        .HasMaxLength(50);
    }

    public void Configure(EntityTypeBuilder<SubjectEntity> builder)
    {
        builder.ToTable("subjects");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.Value)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();
        });

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(x => x.CreatedBy)
            .HasColumnName("created_by")
            .HasMaxLength(50);

        builder.Property(x => x.CreatedDate)
            .HasColumnName("created_date");

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("updated_by")
            .HasMaxLength(50);

        builder.Property(x => x.UpdatedDate)
            .HasColumnName("updated_date");
    }
}