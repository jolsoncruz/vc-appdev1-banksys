using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Windows;
using CashFlow360.Functionalities;

namespace CashFlow360
{
    public class DatabaseConnection
    {
        private static readonly string connectionUri = "mongodb+srv://2219359:QAY5VO3Xt5Te6IY2@vc-appdev.iomihxc.mongodb.net/?retryWrites=true&w=majority";

        public static void CreateAccount(Account a)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var collection = client.GetDatabase("CashFlow360").GetCollection<BsonDocument>("accounts");
            var filter = Builders<BsonDocument>.Filter.Eq("account", a.AccountNumber);
            var document = collection.Find(filter).FirstOrDefault();

            try
            {
                if(document == null)
                {
                    collection.InsertOne(new BsonDocument
                    {
                        {"account" , a.AccountNumber},
                        {"name", a.CustomerName},
                        {"address", a.CustomerAddress},
                        {"phone", a.CustomerPhone},
                        {"sin", a.CustomerSIN},
                        {"password", a.Password},
                        {"balance", a.AccountBalance}
                    });

                        MessageBox.Show("Account Created!");
                }
                else
                {
                    MessageBox.Show("Account already exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.ToString());
            }
        }

        public static Account ReadAccount(int accountNumber)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var collection = client.GetDatabase("CashFlow360").GetCollection<BsonDocument>("accounts");

            var filter = Builders<BsonDocument>.Filter.Eq("account", accountNumber);
            var document = collection.Find(filter).FirstOrDefault();

            if (document != null)
            {
                Account account = new Account(document["account"].AsInt32, document["name"].AsString, document["address"].AsString, document["phone"].AsString, document["sin"].AsString, document["password"].AsString, document["balance"].AsDouble);
                return account;
            }
            else
            {
                return null;
            }
        }

        public static List<Account> ReadAllAccounts()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var collection = client.GetDatabase("CashFlow360").GetCollection<BsonDocument>("accounts");

            var documents = collection.Find(new BsonDocument()).ToList();

            List<Account> accounts = new List<Account>();

            foreach (var document in documents)
            {
                Account account = new Account(document["account"].AsInt32, document["name"].AsString, document["address"].AsString, document["phone"].AsString, document["sin"].AsString, document["password"].AsString, document["balance"].AsDouble);
                accounts.Add(account);
            }

            return accounts;
        }

        public static void UpdateAccount(Account a)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var collection = client.GetDatabase("CashFlow360").GetCollection<BsonDocument>("accounts");

            var filter = Builders<BsonDocument>.Filter.Eq("account", a.AccountNumber);
            var update = Builders<BsonDocument>.Update
                .Set("name", a.CustomerName)
                .Set("address", a.CustomerAddress)
                .Set("phone", a.CustomerPhone)
                .Set("sin", a.CustomerSIN)
                .Set("balance", a.AccountBalance);

            collection.UpdateOne(filter, update);
        }

        public static void DeleteAccount(int accountNumber)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var collection = client.GetDatabase("CashFlow360").GetCollection<BsonDocument>("accounts");

            var filter = Builders<BsonDocument>.Filter.Eq("account", accountNumber);
            
            try
            {
                collection.DeleteOne(filter);

                MessageBox.Show("Account Deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.ToString());
            }
        }

        public static void CreateTransaction(Transaction t)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var collection = client.GetDatabase("CashFlow360").GetCollection<BsonDocument>("transactions");

            try
            {
                collection.InsertOne(new BsonDocument
                {
                    {"account" , t.Account},
                    {"id", t.ID},
                    {"details", t.Details},
                    {"debit", t.Debit},
                    {"credit", t.Credit}
                });

                MessageBox.Show("Transaction Added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.ToString());
            }
        }

        public static List<Transaction> ReadAllTransactions(Account a)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var collection = client.GetDatabase("CashFlow360").GetCollection<BsonDocument>("transactions");

            var documents = collection.Find(new BsonDocument()).ToList();

            List<Transaction> transactions = new List<Transaction>();

            foreach (var document in documents)
            {
                if (document["account"] == a.AccountNumber)
                {
                    Transaction transaction = new Transaction(document["account"].AsInt32, document["id"].AsInt32, document["details"].AsString, document["credit"].AsDouble, document["debit"].AsDouble);
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

    }
}
