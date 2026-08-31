
    public interface IUserEntityRepository
    {
        Task<UserEntity?> GetAsync(EntityID id);

        Task AddAsync(UserEntity userEntity);
        Task UpdateAsync(UserEntity userEntity);
        Task DeleteAsync(UserEntity userEntity);
    }