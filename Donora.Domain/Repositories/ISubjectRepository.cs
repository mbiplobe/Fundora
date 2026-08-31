public interface ISubjectRepository
{
    Task<SubjectEntity?> GetAsync(long id);

    Task AddAsync(SubjectEntity entity);
    Task UpdateAsync(SubjectEntity entity);
    Task DeleteAsync(SubjectEntity entity);
}

