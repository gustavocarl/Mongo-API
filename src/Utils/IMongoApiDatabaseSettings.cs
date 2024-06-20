namespace Mongo_API.Utils
{
    public interface IMongoApiDatabaseSettings
    {
        string? PersonCollectionName { get; set; }

        string? ConnectionString { get; set; }

        string? DataBaseName { get; set; }
    }
}