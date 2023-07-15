namespace CashFlow360_API.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName_Accounts { get; set; } = null!;
        public string CollectionName_Transactions { get; set; } = null!;
    }
}
