using MongoDB.Driver;
using Spg.Vogi.Domain.Interfaces.Repository.UserProfileRepositories;
using Spg.VogiDomain.Interfaces.Repository.UserProfileRepositories;
using Spg.VogiDomain.Model;
using Spg.VogiInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.VogiRepository
{
    public class UserProfileRepository : IModifyUserProfileRepository, IReadOnlyUserProfileRepository
    {
        private readonly IMongoCollection<UserProfile> _userProfiles;

        public UserProfileRepository()
        {
            var database = new MongoDbContext("", "Vogi");
            _userProfiles = database.UserProfiles;
        }

        public IEnumerable<UserProfile> GetAll()
        {
            var userProfiles = _userProfiles.Find(u => true).ToList();
            return userProfiles;
        }

        public UserProfile GetById(int id)
        {
            try
            {
                var userProfile = _userProfiles.Find(u => u.id == id).FirstOrDefault();
                return userProfile;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception in GetById{ex }");
                throw;
            }
            
        }

      

        public UserProfile GetByUsername(string username)
        {
            try
            {
                var userProfile = _userProfiles.Find(u => u.Username == username).FirstOrDefault();
                return userProfile;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception in GetByUsername{ex }");
                throw;
            }
        }

        public UserProfile GetUserwithFollowerCount(UserProfile userProfile)
        {
            try
            {
                var userProfileWithFollowerCount = _userProfiles.Find(u => u.id == userProfile.id).FirstOrDefault();
               
            }
        }

        public void addFollowing(UserProfile entity)
        {
            throw new NotImplementedException();
        }

        public void Create(UserProfile entity)
        {
            var userProfile = _userProfiles.Find(u => u.id == entity.id).FirstOrDefault();
            if (userProfile == null)
            {
                _userProfiles.InsertOne(entity);
            }
            else { throw new Exception("User already exists"); }
        }

        public void Delete(int id)
        {
            var deletableUser = _userProfiles.Find(u => u.id == id).FirstOrDefault();
            if (id == deletableUser.id)
            {
                _userProfiles.DeleteOne(u => u.id == id);
            }
        }

        public void deleteFollowing(UserProfile entity)
        {
            var userProfile = _userProfiles.Find(u => u.id == entity.id).FirstOrDefault();
            if (userProfile != null)
            {
                userProfile.RemoveFollower(entity);
                _userProfiles.ReplaceOne(u => u.id == entity.id, userProfile);
            }
            else { throw new Exception("User not found"); }
        }

        public void updateAddress(UserProfile entity)
        {
            var userProfile = _userProfiles.Find(u => u.id == entity.id).FirstOrDefault();
            if (userProfile != null)
            {
                userProfile.Address = entity.Address;
                _userProfiles.ReplaceOne(u => u.id == entity.id, userProfile);
            }
            else { throw new Exception("User not found"); }
        }

        public void updateBio(UserProfile entity)
        {
          var userProfile = _userProfiles.Find(u => u.id == entity.id).FirstOrDefault();
            if (userProfile != null)
            {
                userProfile.Biographie = entity.Biographie;
                _userProfiles.ReplaceOne(u => u.id == entity.id, userProfile);
            }
            else { throw new Exception("User not found"); }
        }

        public void UpdateFirstLastName(UserProfile entity)
        {
            var userProfile = _userProfiles.Find(u => u.id == entity.id).FirstOrDefault();
            if (userProfile != null)
            {
                userProfile.Firstname = entity.Firstname;
                userProfile.Lastname = entity.Lastname;
                _userProfiles.ReplaceOne(u => u.id == entity.id, userProfile);
            }
            else { throw new Exception("User not found"); }
        }
    }
}
