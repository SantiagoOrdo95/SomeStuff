using ClientMongoApp.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientMongoApp.Infrastructure.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _clientCollection;

        public ClientService(IOptions<AppSettings> dataBaseSetting)
        {
            var client = new MongoClient(dataBaseSetting.Value.ConnectionString);
            var database = client.GetDatabase(dataBaseSetting.Value.DatabaseName);

            _clientCollection = database.GetCollection<Client>(typeof(Client).Name);
        }

        public async Task<List<Client>> GetAsync() => await _clientCollection.Find(_ => true).ToListAsync();
        public async Task<Client> GetAsync(string documentId) => await _clientCollection.Find(x => x.Document_id == documentId).FirstOrDefaultAsync();
        public async Task CreateAsync(Client newClient) => await _clientCollection.InsertOneAsync(newClient);
        public async Task UpdateAsync(string documentId, Client updateClient) => await _clientCollection.ReplaceOneAsync(x => x.Document_id == documentId, updateClient);
        public async Task DeleteAsync(string documentId) => await _clientCollection.DeleteOneAsync(x => x.Document_id == documentId);
    }
}
