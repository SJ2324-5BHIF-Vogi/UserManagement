namespace Spg.Vogi.Domain.Interfaces.Repository.UserProfileRepositories;

public interface IReadOnlyUserProfileRepository
{
    UserProfile GetById(int id);
    IEnumerable<UserProfile> GetAll();
    UserProfile GetByUsername(string username);
    UserProfile GetUserwithFollowerCount( UserProfile userProfile);
}
