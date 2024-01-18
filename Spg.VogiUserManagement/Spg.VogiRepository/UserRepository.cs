using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using RepositoryMongo_Generic;
using Spg.Vogi.Domain.Interfaces.Repository.UserRepositories;
using Spg.VogiDomain.Interfaces.Repository.UserRepositories;
using Spg.VogiDomain.Model;
using Spg.VogiInfrastructure;


namespace Spg.VogiRepository
{
    public class UserRepository : IModifyUserRepository, IReadOnlyUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository()
        {
            var database = new MongoDbContext("","Vogi");
            _users = database.Users;
        }


        public void Create(User entity)

        {
            var existingUser = _users.Find(u => u.Username == entity.Username).FirstOrDefault();

            if (existingUser == null)
            {
                _users.InsertOne(entity);
            }
            else
            {
                throw new Exception("Username already exists");
            }
        }

        public void Delete(int id)
        {
            var deletableUser = _users.Find(u => u.id == id).FirstOrDefault();
            if (id== deletableUser.id)
            {
                _users.DeleteOne(u => u.id == id);
            }
        }

        public void UpdatePassword(User entity)
        {
           var user = _users.Find(u => u.id == entity.id).FirstOrDefault();
            if (user != null)
            {
                user.Password = entity.Password;
                _users.ReplaceOne(u => u.id == entity.id, user);
            }
            else { throw new Exception("User not found"); }
        }

        public void UpdateUsername(User entity) 
        { 
            var user = _users.Find(u => u.id == entity.id).FirstOrDefault();
            if (user != null)
            {
                user.Username = entity.Username;
                _users.ReplaceOne(u => u.id == entity.id, user);
            }
            else { throw new Exception("User not found"); }
        
        }

        public IEnumerable<User> GetAll()
        {
            var users = _users.Find(u => true).ToList();
            return users;
        }

        public User GetById(int id)
        {
           var user = _users.Find(u => u.id == id).FirstOrDefault();
            return user;
        }

        //get user by username
        public User GetByUsername(string username)
        {
            var user = _users.Find(u => u.Username == username).FirstOrDefault();
            return user;
        }

      
        

       
    }


}

   
