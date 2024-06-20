using Mongo_API.Models;
using Mongo_API.Utils;
using MongoDB.Driver;

namespace Mongo_API.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person>? _person;

        public PersonService(IMongoApiDatabaseSettings settings)
        {
            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DataBaseName);
            _person = database.GetCollection<Person>(settings.PersonCollectionName);
        }

        public List<Person> Get() => _person.Find(person => true).ToList();

        public Person Get(string id) => _person.Find<Person>(person => person.Id == id).FirstOrDefault();

        public Person Create(Person person)
        {
            _person!.InsertOne(person);
            return person;
        }

        public void Update(string id, Person personIn) => _person!.ReplaceOne(person => person.Id == id, personIn);

        public void Remove(Person personIn) => _person!.DeleteOne(person => person.Id == personIn.Id);

        public void Remove(string id) => _person!.DeleteOne(person => person.Id == id);
    }
}