using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CashFlow360.Functionalities;

namespace CashFlow360
{
    public partial class MoneyManagement : Window
    {
        public List<Transaction> TransactionList
        {
            get;
            set;
        }

        private Account SelectedAccount;

        public MoneyManagement(Account a)
        {
            InitializeComponent();
            this.SelectedAccount = a;
            Balance_Label.SetValue(Label.ContentProperty, "$" + SelectedAccount.AccountBalance);
            TransactionList = DatabaseConnection.ReadAllTransactions(a);
            MM_TransactionList.ItemsSource = TransactionList;

            Address_TextBox.Text = SelectedAccount.CustomerAddress;
            PhoneNumber_TextBox.Text = SelectedAccount.CustomerPhone;
            Password_TextBox.Text = SelectedAccount.Password;

            DataContext = this;
        }

        private void refreshMoneyManagement()
        {
            Amount_TextBox.Text = "";

            TransactionList = DatabaseConnection.ReadAllTransactions(SelectedAccount);
            MM_TransactionList.ItemsSource = TransactionList;

            DataContext = this;
        }

        private void Deposit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Amount_TextBox.Text == "" || Amount_TextBox.Text == "0")
            {
                MessageBox.Show("Amount field is required!");
            }
            else
            {
                Random rnd = new Random();
                int tranNumber = rnd.Next(1000);

                Double newAmount = Double.Parse(Amount_TextBox.Text);

                Transaction t = new Transaction(SelectedAccount.AccountNumber, tranNumber, "Deposit request", newAmount, 0.00);
                DatabaseConnection.CreateTransaction(t);

                SelectedAccount.AccountBalance = SelectedAccount.AccountBalance + newAmount;
                Balance_Label.SetValue(Label.ContentProperty, "$" + SelectedAccount.AccountBalance);
                DatabaseConnection.UpdateAccount(SelectedAccount);

                refreshMoneyManagement();
            }
        }

        private void Withdraw_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Amount_TextBox.Text == "" || Amount_TextBox.Text == "0")
            {
                MessageBox.Show("Amount field is required!");
            }
            else
            {
                Random rnd = new Random();
                int tranNumber = rnd.Next(1000);

                Double newAmount = Double.Parse(Amount_TextBox.Text);

                Transaction t = new Transaction(SelectedAccount.AccountNumber, tranNumber, "Withdraw request", 0.00, newAmount);
                DatabaseConnection.CreateTransaction(t);
                
                SelectedAccount.AccountBalance = SelectedAccount.AccountBalance - newAmount;
                Balance_Label.SetValue(Label.ContentProperty, "$" + SelectedAccount.AccountBalance);
                DatabaseConnection.UpdateAccount(SelectedAccount);

                refreshMoneyManagement();
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedAccount.CustomerAddress = Address_TextBox.Text;
            SelectedAccount.CustomerPhone = PhoneNumber_TextBox.Text;
            SelectedAccount.Password = Password_TextBox.Text;

            DatabaseConnection.UpdateAccount(SelectedAccount);
            MessageBox.Show("Account Updated!");
        }

        private void MM_AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
