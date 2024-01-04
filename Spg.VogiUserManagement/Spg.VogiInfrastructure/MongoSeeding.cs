using Bogus;
using MongoDB.Driver;
using Spg.VogiDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.VogiInfrastructure
{
    public class MongoSeeding
    {
        private readonly IMongoCollection<User> _usersCollection;
        private readonly IMongoCollection<UserProfile> _userProfilesCollection;

        public MongoSeeding(IMongoDatabase database)
        {
            _usersCollection = database.GetCollection<User>("users");
            _userProfilesCollection = database.GetCollection<UserProfile>("users");
        }

        public void SeedData(int numberOfUsers, int numberOfUserProfiles)
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Guid, f => Guid.NewGuid())
                .RuleFor(u => u.id, f => f.UniqueIndex)
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password());

            var userProfileFaker = new Faker<UserProfile>()
                .RuleFor(u => u.Guid, f => Guid.NewGuid())
                .RuleFor(u => u.id, f => f.UniqueIndex)
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Firstname, f => f.Person.FirstName)
                .RuleFor(u => u.Lastname, f => f.Person.LastName)
                .RuleFor(u => u.Biographie, f => f.Lorem.Sentence())
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.eMail, f => f.Internet.Email())
                .RuleFor(u => u.ProfilePicture, f => f.Random.Bytes(100))
                .RuleFor(u => u.Follower, f => new List<UserProfile>())
                .RuleFor(u => u.Following, f => new List<UserProfile>());

            var users = userFaker.Generate(numberOfUsers);
            var userProfiles = userProfileFaker.Generate(numberOfUserProfiles);

            _usersCollection.InsertMany(users);
            _userProfilesCollection.InsertMany(userProfiles);

            Console.WriteLine($"Seeded {numberOfUsers} Users and {numberOfUserProfiles} UserProfiles.");
        }
    }
}