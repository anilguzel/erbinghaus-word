using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

public class AppMongoContext : IMongoContext
{
    private readonly string databaseName = "ebbinghaus";
    private readonly string connectionString = "mongodb://localhost:27017";

    private IMongoDatabase _database;
    public AppMongoContext()
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
        // BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(BsonType.String));
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return _database.GetCollection<T>(typeof(T).ToString());
    }
}


public interface IMongoContext
{
    IMongoCollection<T> GetCollection<T>();
}