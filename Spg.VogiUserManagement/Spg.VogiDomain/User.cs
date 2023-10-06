namespace Spg.VogiDomain
{
    public class User
    {
        //Properties
        public Guid Guid { get; private set; } = Guid.NewGuid();
        public String Username { get; set; } = string.Empty;
        public String Password { get; set; } = string.Empty;

        //Constructor
        public User(string username, string password) { 
            Username = username;
            Password = password;
        }


    }
}