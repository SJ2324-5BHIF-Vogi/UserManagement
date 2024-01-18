using Spg.VogiDomain.Model;

namespace Spg.VogiDomain.Interfaces.Repository.UserProfileRepositories;

public interface IModifyUserProfileRepository
{
    void Create(UserProfile entity);
    void Delete(int id);
    void UpdateFirstLastName(UserProfile entity);
    void updateBio(UserProfile entity);
    void addFollowing(UserProfile entity);
    void deleteFollowing(UserProfile entity);
    void updateAddress(UserProfile entity);
    

}
