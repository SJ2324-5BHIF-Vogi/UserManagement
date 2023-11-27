namespace Spg.Vogi.Domain.Interfaces.Repository.UserProfileRepositories;

public interface IModifyUserProfileRepository
{
    UserProfile GetById(int id);
    IEnumerable<UserProfile> GetAll();
}
