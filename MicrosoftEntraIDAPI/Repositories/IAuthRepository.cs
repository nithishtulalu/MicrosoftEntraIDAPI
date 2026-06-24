namespace MicrosoftEntraIDAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}
