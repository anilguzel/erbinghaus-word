
using Ebbinghaus.Framework.Domain;

public class Card : BaseAggregate
{
    public User User {get;set;}
    public List<Word> Words {get;set;}

    // value object'ler aggregate constructer'inda tanimlanmalidir.
    public Card(User user)
    {
        User = user;
        Words = new List<Word>();
    }
}