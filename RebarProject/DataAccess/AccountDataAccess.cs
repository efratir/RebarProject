using MongoDB.Driver;
using RebarProject.ModelsDB;

namespace RebarProject.DataAccess
{
    public class AccountDataAccess : DataAccess
    {
        private const string AccountCollection = "account";

        public Task CreateAccount(Account account)
        {
            var accountCollection = ConnectToMongo<Account>(AccountCollection);
            return accountCollection.InsertOneAsync(account);
        }
        public async Task<List<Account>> GetAccounts()
        {
            var accountsCollection = ConnectToMongo<Account>(AccountCollection);
            var results = await accountsCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public Task UpdateAccount(Account account)
        {
            var accountsCollection = ConnectToMongo<Account>(AccountCollection);
            var filter = Builders<Account>.Filter.Eq(a => a.Id, account.Id);
            return accountsCollection.ReplaceOneAsync(filter, account, new ReplaceOptions() { IsUpsert = true });
        }
    }
}

