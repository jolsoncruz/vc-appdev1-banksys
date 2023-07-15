using CashFlow360_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CashFlow360_API.Services
{
    public class MongoDBServices
    {
        private readonly IMongoCollection<Account> _accountsCollection;
        private readonly IMongoCollection<Transaction> _transactionsCollection;

        public MongoDBServices(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _accountsCollection = database.GetCollection<Account>(mongoDBSettings.Value.CollectionName_Accounts);
            _transactionsCollection = database.GetCollection<Transaction>(mongoDBSettings.Value.CollectionName_Transactions);
        }

        // Account-related Functionalities
        public async Task CreateUserAsync(Account a)
        {
            await _accountsCollection.InsertOneAsync(a);
            return;
        }

        public async Task<List<Account>> GetUserAsync()
        {
            return await _accountsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateUserAsync(string id, string CustomerName, string CustomerAddress, string CustomerPhone, string CustomerSIN, double AccountBalance)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq("Id", id);
            UpdateDefinition<Account> update = Builders<Account>.Update
                .Set("name", CustomerName)
                .Set("address", CustomerAddress)
                .Set("phone", CustomerPhone)
                .Set("sin", CustomerSIN)
                .Set("balance", AccountBalance);
            await _accountsCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteUserAsync(string id)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq("Id", id);
            await _accountsCollection.DeleteOneAsync(filter);
            return;
        }

        // Transaction-related Functionalities
        public async Task CreateTransactionAsync(Transaction t)
        {
            await _transactionsCollection.InsertOneAsync(t);
            return;
        }

        public async Task<List<Transaction>> GetTransactionAsync()
        {
            return await _transactionsCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
