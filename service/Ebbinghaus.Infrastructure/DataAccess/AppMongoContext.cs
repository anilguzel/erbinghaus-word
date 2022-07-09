using MongoDB.Driver;

public class AppMongoContext : IMongoContext
{
    private readonly string connectionString = "";
    private readonly string databaseName = "";

    private IMongoDatabase _database;
    public AppMongoContext()
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}


public interface IMongoContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}