using NUnit.Framework;
using CashFlow360;
using CashFlow360.Functionalities;
using System.Security.Principal;

namespace CashFlow360_Test
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private Account testAccount;

        [SetUp]
        public void SetUp()
        {
            testAccount = new Account(123456, "John Doe", "123 Main St", "123-456-7890", "123456789", "password", 100.0);
        }

        [Test]
        public void CreateAccount_ValidAccount_AccountCreated()
        {
            DatabaseConnection.CreateAccount(testAccount);

            Account createdAccount = DatabaseConnection.ReadAccount(testAccount.AccountNumber);
            Assert.NotNull(createdAccount);
            Assert.AreEqual(testAccount.AccountNumber, createdAccount.AccountNumber);
            Assert.AreEqual(testAccount.CustomerName, createdAccount.CustomerName);
            Assert.AreEqual(testAccount.CustomerAddress, createdAccount.CustomerAddress);
            Assert.AreEqual(testAccount.CustomerPhone, createdAccount.CustomerPhone);
            Assert.AreEqual(testAccount.CustomerSIN, createdAccount.CustomerSIN);
            Assert.AreEqual(testAccount.Password, createdAccount.Password);
            Assert.AreEqual(testAccount.AccountBalance, createdAccount.AccountBalance);
        }

        [Test]
        public void ReadAccount_ExistingAccount_ReturnsAccount()
        {
            DatabaseConnection.CreateAccount(testAccount);

            Account retrievedAccount = DatabaseConnection.ReadAccount(testAccount.AccountNumber);

            Assert.NotNull(retrievedAccount);
            Assert.AreEqual(testAccount.AccountNumber, retrievedAccount.AccountNumber);
            Assert.AreEqual(testAccount.CustomerName, retrievedAccount.CustomerName);
            Assert.AreEqual(testAccount.CustomerAddress, retrievedAccount.CustomerAddress);
            Assert.AreEqual(testAccount.CustomerPhone, retrievedAccount.CustomerPhone);
            Assert.AreEqual(testAccount.CustomerSIN, retrievedAccount.CustomerSIN);
            Assert.AreEqual(testAccount.Password, retrievedAccount.Password);
            Assert.AreEqual(testAccount.AccountBalance, retrievedAccount.AccountBalance);
        }

        [Test]
        public void ReadAccount_NonExistingAccount_ReturnsNull()
        {
            Account retrievedAccount = DatabaseConnection.ReadAccount(999999);

            Assert.Null(retrievedAccount);
        }

        [Test]
        public void ReadAllAccounts_MultipleAccounts_ReturnsAllAccounts()
        {
            Account account1 = new Account(1, "John Doe", "123 Main St", "123-456-7890", "123456789", "password", 100.0);
            Account account2 = new Account(2, "Jane Smith", "456 Elm St", "987-654-3210", "987654321", "password", 200.0);
            DatabaseConnection.CreateAccount(account1);
            DatabaseConnection.CreateAccount(account2);

            var allAccounts = DatabaseConnection.ReadAllAccounts();

            Assert.AreEqual(2, allAccounts.Count);
            Assert.Contains(account1, allAccounts);
            Assert.Contains(account2, allAccounts);
        }

        [Test]
        public void UpdateAccount_ExistingAccount_AccountUpdated()
        {
            DatabaseConnection.CreateAccount(testAccount);
            testAccount.CustomerName = "Updated Name";
            testAccount.CustomerAddress = "Updated Address";
            testAccount.CustomerPhone = "Updated Phone";
            testAccount.CustomerSIN = "Updated SIN";
            testAccount.AccountBalance = 999.0;

            DatabaseConnection.UpdateAccount(testAccount);
            Account updatedAccount = DatabaseConnection.ReadAccount(testAccount.AccountNumber);

            Assert.NotNull(updatedAccount);
            Assert.AreEqual(testAccount.AccountNumber, updatedAccount.AccountNumber);
            Assert.AreEqual(testAccount.CustomerName, updatedAccount.CustomerName);
            Assert.AreEqual(testAccount.CustomerAddress, updatedAccount.CustomerAddress);
            Assert.AreEqual(testAccount.CustomerPhone, updatedAccount.CustomerPhone);
            Assert.AreEqual(testAccount.CustomerSIN, updatedAccount.CustomerSIN);
            Assert.AreEqual(testAccount.AccountBalance, updatedAccount.AccountBalance);
        }

        [Test]
        public void DeleteAccount_ExistingAccount_AccountDeleted()
        {
            DatabaseConnection.CreateAccount(testAccount);

            DatabaseConnection.DeleteAccount(testAccount.AccountNumber);
            Account deletedAccount = DatabaseConnection.ReadAccount(testAccount.AccountNumber);

            Assert.Null(deletedAccount);
        }

        [Test]
        public void CreateTransaction_ValidTransaction_TransactionAdded()
        {
            Transaction testTransaction = new Transaction(testAccount.AccountNumber, 1, "Test Transaction", 100.0, 0.0);

            DatabaseConnection.CreateTransaction(testTransaction);

            var transactions = DatabaseConnection.ReadAllTransactions(testAccount);
            Assert.AreEqual(1, transactions.Count);
            Assert.AreEqual(testTransaction.Account, transactions[0].Account);
            Assert.AreEqual(testTransaction.ID, transactions[0].ID);
            Assert.AreEqual(testTransaction.Details, transactions[0].Details);
            Assert.AreEqual(testTransaction.Credit, transactions[0].Credit);
            Assert.AreEqual(testTransaction.Debit, transactions[0].Debit);
        }

        [Test]
        public void ReadAllTransactions_MultipleTransactions_ReturnsAllTransactionsForAccount()
        {
            Transaction transaction1 = new Transaction(testAccount.AccountNumber, 1, "Transaction 1", 100.0, 0.0);
            Transaction transaction2 = new Transaction(testAccount.AccountNumber, 2, "Transaction 2", 0.0, 50.0);
            DatabaseConnection.CreateTransaction(transaction1);
            DatabaseConnection.CreateTransaction(transaction2);

            var transactions = DatabaseConnection.ReadAllTransactions(testAccount);

            Assert.AreEqual(2, transactions.Count);
            Assert.Contains(transaction1, transactions);
            Assert.Contains(transaction2, transactions);
        }
    }
}
