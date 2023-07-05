using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow360.Functionalities
{
    public class Transaction
    {
        private int account;
        private int id;
        private String details;
        private double credit;
        private double debit;

        public Transaction(int account, int id, string details, double credit, double debit)
        {
            this.account = account;
            this.id = id;
            this.details = details;
            this.credit = credit;
            this.debit = debit;
        }

        public int Account
        {
            get { return account; }
        }


        public int ID
        {
            get { return id; }
        }

        public String Details
        {
            get { return details; }
        }

        public double Credit {
            get { return credit; }
        }
        public double Debit {
            get { return debit; }
        }
    }
}
