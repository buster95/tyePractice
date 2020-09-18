using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using userservice.Interfaces;
using userservice.Models;

namespace userservice.Repositories {
    public class UserRepository : IUserRepository {
        private IMongoCollection<User> collection;

        public UserRepository(string mongourl, string database) {
            // MongoClientSettings settings = new MongoClientSettings();

            // string username = "user";
            // string password = "password";
            // MongoCredential mongoCredential = new MongoCredential("SCRAM-SHA-1",
            //     new MongoInternalIdentity("admin", username),
            //     new PasswordEvidence(password));
            // List<MongoCredential> credentials = new List<MongoCredential>() { mongoCredential };
            // settings.Credential = mongoCredential;

            // MongoServerAddress address = new MongoServerAddress("", 1);
            // settings.Server = address;
            // var mongoClient = new MongoClient(settings);

            var mongoClient = new MongoClient(mongourl);
            var mongoData = mongoClient.GetDatabase(database);
            collection = mongoData.GetCollection<User>("usuarios");
        }

        public async Task<bool> Create(User Entity) {
            try {
                await collection.InsertOneAsync(Entity);
                return true;
            } catch (System.Exception) {
                return false;
            }
        }

        public async Task<List<User>> GetAll() {
            return await (await collection.FindAsync(x => true)).ToListAsync();
        }

        public async Task<User> GetById(string Id) {
            var entity = await (await collection.FindAsync(x => true)).FirstOrDefaultAsync();
            return entity;
        }
    }
}