public interface IClassRepository
{
    Task<ClassEntity?> GetAsync(long id);
        
    Task AddAsync(ClassEntity entity);
    Task UpdateAsync(ClassEntity entity);
    Task DeleteAsync(ClassEntity entity);
}