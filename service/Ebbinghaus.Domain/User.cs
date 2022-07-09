using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    public User(string firstname, string lastname)
    {
        this.firstname = firstname;
        this.lastname = lastname;
    }
    public string firstname { get; set; }
    public string lastname { get; set; }
}