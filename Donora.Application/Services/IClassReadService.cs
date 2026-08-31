public interface IClassReadService
{
    Task<bool> ExistsByNameAsync(string name);
}