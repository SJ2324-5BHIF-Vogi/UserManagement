namespace Spg.Vogi.Domain.Interfaces.Repository.UserRepositories;

public interface IReadOnlyUserRepository
{
    User GetById(int id);
    IEnumerable<User> GetAll();
    User GetByUsername(string username);

   
}
