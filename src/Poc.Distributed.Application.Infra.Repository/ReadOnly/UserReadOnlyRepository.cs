using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Poc.Distributed.Application.Business.Domain.Entities;
using Poc.Distributed.Application.Infra.Repository.ReadOnly.Entities;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Infra.Repository.ReadOnly
{
    public class UserReadOnlyRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<UserReadOnly> _userCollection;
        public UserReadOnlyRepository(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = _client.GetDatabase("poc-distributed-application");
            _userCollection = _database.GetCollection<UserReadOnly>("user");
        }

        public async Task InsertAsync(User user)
        {
            UserReadOnly userPersistence = user;

            await _userCollection.InsertOneAsync(userPersistence);
        }
    }
}
