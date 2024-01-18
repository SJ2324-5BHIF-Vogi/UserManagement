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
    

    private List<UserProfile> _follower = new();
    private List<UserProfile> _following = new();
    public virtual IReadOnlyList<UserProfile> Follower => _follower;
    public virtual IReadOnlyList<UserProfile> Following => _following;



    public void AddFollower(UserProfile follower)
        {
        if (!_follower.Contains(follower))
            {
            _follower.Add(follower);
        }
    }

    public void RemoveFollower(UserProfile follower)
        {
        if (_follower.Contains(follower))
            {
            _follower.Remove(follower);
        }
    }

    public void AddFollowing(UserProfile following)
        {
        if (!_following.Contains(following))
            {
            _following.Add(following);
        }
    }

    public void RemoveFollowing(UserProfile following)
        {
        if (_following.Contains(following))
            {
            _following.Remove(following);
        }
    }

    // Constructor calling base class constructor
    public UserProfile(string username, string password, string fname, string lname, string bio, string address, string email)
        : base(username, password)
    {
        Firstname = fname;
        Lastname = lname;
        Biographie = bio;
        Address = address;
        eMail = email;
      
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
