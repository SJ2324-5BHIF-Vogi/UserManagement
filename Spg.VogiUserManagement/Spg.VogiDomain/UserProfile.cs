using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.VogiDomain
{
    public class UserProfile 
    {
        //Properties
        public Guid Guid { get; private set; } = Guid.NewGuid();
        public String Firstname { get; set; } = string.Empty;
        public String Lastname { get; set; } = string.Empty;
        public String Biographie { get; set; } = string.Empty;
        public String Address { get; set; } = string.Empty;
        public String eMail { get; set; } = string.Empty;
        public byte[] ProfilePicture { get; set; }
        private List<UserProfile> _follower = new();
        private List<UserProfile> _following = new();
        public virtual IReadOnlyList<UserProfile> Follower => _follower;
        public virtual IReadOnlyList<UserProfile> Following => _following;
        

        //Constructor
        public UserProfile(string fname, string lname, string bio, string  address, string email, byte[] profilePicture)
        {
            Firstname = fname;
            Lastname = lname;
            Biographie = bio;
            Address = address;
            eMail = email;
            ProfilePicture = profilePicture;
        }

        public UserProfile(string fname, string lname, string address, string email)
        {
            Firstname = fname;
            Lastname = lname;
            Address = address;
            eMail = email;
        }

    }
}
