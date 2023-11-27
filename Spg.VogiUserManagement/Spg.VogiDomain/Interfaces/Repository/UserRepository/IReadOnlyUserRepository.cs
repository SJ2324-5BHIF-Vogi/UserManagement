namespace Spg.Vogi.Domain.Interfaces.Repository.UserRepositories;

public interface IModifyUserRepository
{
    User GetById(int id);
    IEnumerable<User> GetAll();
}
