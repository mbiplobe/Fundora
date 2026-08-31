using Microsoft.EntityFrameworkCore;

namespace Donora.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ClassEntity> Classes { get; set; }
    public DbSet<SectionEntity> Sections { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }


    public WriteDbContext(DbContextOptions<WriteDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(WriteDbContext).Assembly);
    }
}