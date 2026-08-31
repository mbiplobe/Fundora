using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Contexts;


namespace Donora.Infrastructure.EF.Repositories;
internal sealed class ClassEntityRepository : IClassRepository
{
    private readonly DbSet<ClassEntity> _classEntities;
    private readonly WriteDbContext _writeDbContext;

    public ClassEntityRepository(WriteDbContext writeDbContext)
    {
        _classEntities = writeDbContext.Classes;
        _writeDbContext = writeDbContext;
    }

    public async Task AddAsync(ClassEntity classEntity)
    {
       await _classEntities.AddAsync(classEntity);
       await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ClassEntity classEntity)
    {
          _classEntities.Remove(classEntity);
          await _writeDbContext.SaveChangesAsync();
    }

    public async Task<ClassEntity?> GetAsync(long id)
    {
        return await _classEntities.SingleAsync(pl => pl.Id == id);
    }

   
    public async Task UpdateAsync(ClassEntity classEntity)
    {
         _classEntities.Update(classEntity);
        await _writeDbContext.SaveChangesAsync();
    }

}


