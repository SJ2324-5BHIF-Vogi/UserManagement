using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Spg.VogiDomain.Model

{ 
public class UserProfile : User
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Biographie { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string eMail { get; set; } = string.Empty;
    public byte[] ProfilePicture { get; set; } = Array.Empty<byte>();

    private List<UserProfile> _follower = new();
    private List<UserProfile> _following = new();
    public virtual IReadOnlyList<UserProfile> Follower => _follower;
    public virtual IReadOnlyList<UserProfile> Following => _following;

    // Constructor calling base class constructor
    public UserProfile(string username, string password, string fname, string lname, string bio, string address, string email, byte[] profilePicture)
        : base(username, password)
    {
        Firstname = fname;
        Lastname = lname;
        Biographie = bio;
        Address = address;
        eMail = email;
        ProfilePicture = profilePicture;
    }

    public UserProfile(string username, string password, string fname, string lname, string address, string email)
        : base(username, password)
    {
        Firstname = fname;
        Lastname = lname;
        Address = address;
        eMail = email;
    }
}
}
