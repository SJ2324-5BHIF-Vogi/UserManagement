using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Spg.VogiDomain.Model
{
    [BsonDiscriminator("user", RootClass = true)]
    [BsonKnownTypes(typeof(UserProfile))]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Guid { get; private set; } = Guid.NewGuid();
        public int id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        //Constructor
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }


    }
}