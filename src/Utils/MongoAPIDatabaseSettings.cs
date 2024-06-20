namespace Mongo_API.Utils
{
    public class MongoAPIDatabaseSettings : IMongoApiDatabaseSettings
    {
        public string? PersonCollectionName { get; set; }

        public string? ConnectionString { get; set; }

        public string? DataBaseName { get; set; }
    }
}