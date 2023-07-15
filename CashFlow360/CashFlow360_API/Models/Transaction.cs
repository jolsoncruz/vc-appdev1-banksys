using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CashFlow360_API.Models
{
    [BsonIgnoreExtraElements]
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public int account { get; set; }
        public String details { get; set; }
        public double credit { get; set; }
        public double debit { get; set; }

        public Transaction(int account, string details, double credit, double debit)
        {
            this.account = account;
            this.details = details;
            this.credit = credit;
            this.debit = debit;
        }
    }
}
