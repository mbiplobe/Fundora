public interface ISectionRepository
{
    Task<SectionEntity?> GetAsync(long id);
        
    Task AddAsync(SectionEntity entity);
    Task UpdateAsync(SectionEntity entity);
    Task DeleteAsync(SectionEntity entity);
}