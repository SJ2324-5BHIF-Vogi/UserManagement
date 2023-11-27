namespace Spg.VogiDomain.Model
{
    public class User
    {
        //Properties
        public Guid Guid { get; private set; } = Guid.NewGuid();
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