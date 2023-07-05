using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CashFlow360
{
    public partial class MainWindow : Window
    {
        public List<Account> AccountList
        {
            get;
            set;
        }

        public MainWindow()
        {
            InitializeComponent();

            //Account accObj1 = new Account(001, "Jolson Eric Cruz", "288 Av Grosvenor, Westmount, QC, H3Z2L9", "(438) 802 2223", "111-111-111", "p@ssw0rd!", 100.00);
            //Account accObj2 = new Account(002, "Sean Marco Naldoza", "288 Av Grosvenor, Westmount, QC, H3Z2L9", "(514) 913 8869", "222-222-222", "p@ssw0rd!", 100.00);
            //Account accObj3 = new Account(003, "John Francis Velez", "288 Av Grosvenor, Westmount, QC, H3Z2L9", "(514) 894 4449", "333-333-333", "p@ssw0rd!", 100.00);
            //DatabaseConnection.CreateAccount(accObj1);
            //DatabaseConnection.CreateAccount(accObj2);
            //DatabaseConnection.CreateAccount(accObj3);

            //sampleData.SetValue(Label.ContentProperty,DatabaseConnection.ReadAccount(001).CustomerName);
            AccountList = DatabaseConnection.ReadAllAccounts();
            UM_AccountList.ItemsSource = AccountList;

            DataContext = this;
        }

        private void refreshUserManagement()
        {
            UM_AccountList.UnselectAll();

            AccountNumber_TextBox.Text = "";
            Name_TextBox.Text = "";
            Address_TextBox.Text = "";
            PhoneNumber_TextBox.Text = "";
            SIN_TextBox.Text = "";
            Balance_TextBox.Text = "";
            Password_TextBox.Text = "";

            AccountList = DatabaseConnection.ReadAllAccounts();
            UM_AccountList.ItemsSource = AccountList;

            DataContext = this;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = AccountNumber_TextBox.Text;
            string name = Name_TextBox.Text;
            string address = Address_TextBox.Text;
            string phoneNumber = PhoneNumber_TextBox.Text;
            string sin = SIN_TextBox.Text;
            string balance = Balance_TextBox.Text;
            string password = Password_TextBox.Text;

            if (AccountNumber_TextBox.Text == "" || name == "" || address == "" || phoneNumber == "" || sin == "" || Balance_TextBox.Text == "" || password == "")
            {
                MessageBox.Show("All fields required!");
            }
            else
            {
                Account account = new Account(Int32.Parse(accountNumber), name, address, phoneNumber, sin, password, Double.Parse(balance));
                DatabaseConnection.CreateAccount(account);

                refreshUserManagement();
            }
        }

        private void UM_AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account selectedAccount = (Account)UM_AccountList.SelectedItem;

            if (selectedAccount != null)
            {
                AccountNumber_TextBox.Text = selectedAccount.AccountNumber.ToString();
                Name_TextBox.Text = selectedAccount.CustomerName;
                Address_TextBox.Text = selectedAccount.CustomerAddress;
                PhoneNumber_TextBox.Text = selectedAccount.CustomerPhone;
                SIN_TextBox.Text = selectedAccount.CustomerSIN;
                Balance_TextBox.Text = selectedAccount.AccountBalance.ToString();
                Password_TextBox.Text = selectedAccount.Password;
            }
        }

        private void Manage_Button_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = (Account)UM_AccountList.SelectedItem;

            if (selectedAccount != null)
            {
                MoneyManagement moneyManagementWindow = new MoneyManagement(selectedAccount);
                moneyManagementWindow.Show();
            }
            else
            {
                MessageBox.Show("No account selected!");
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = (Account)UM_AccountList.SelectedItem;

            if (selectedAccount != null)
            {
                DatabaseConnection.DeleteAccount(selectedAccount.AccountNumber);
            }
            else
            {
                MessageBox.Show("No account selected!");
            }

            refreshUserManagement();
        }
    }
}
