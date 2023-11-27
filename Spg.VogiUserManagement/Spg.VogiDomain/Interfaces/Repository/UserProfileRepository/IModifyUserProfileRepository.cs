using Spg.VogiDomain.Model;

namespace Spg.VogiDomain.Interfaces.Repository.UserProfileRepositories;

public interface IModifyUserProfileRepository
{
    void Create(UserProfile entity);
    void Delete(int id);
}
