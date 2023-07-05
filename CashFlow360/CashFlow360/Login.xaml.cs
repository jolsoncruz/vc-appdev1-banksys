using System;
using System.Windows;

namespace CashFlow360
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            string username = Username_TextBox.Text;
            string password = Password_TextBox.Text;

            if (username == "admin" && password == "admin123!")
            {
                MainWindow adminView = new MainWindow();
                adminView.Show();
                this.Close();
            }
            else
            {
                Account a = DatabaseConnection.ReadAccount(Int32.Parse(username));
                if (a == null)
                {
                    MessageBox.Show("Account Not Found!");
                }
                else
                {
                    if (a.Password == password)
                    {
                        MoneyManagement userView = new MoneyManagement(a);
                        userView.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password!");
                    }
                }
            }
        }
    }
}
