using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CashFlow360_API.Models
{
    [BsonIgnoreExtraElements]
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public int account { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String sin { get; set; }
        public double balance { get; set; }
        public String password { get; set; }

        public Account(int account, string name, string address, string phone, string sin, string password, double balance)
        {
            this.account = account;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.password = password;
            this.balance = balance;
        }
    }
}
