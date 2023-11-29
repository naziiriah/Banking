﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Banking
{
    public class BankAccount
    {
        public string? Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get
            {
                decimal balance = 0;
                foreach( var item in _allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            } 
        }

        private static int s_accountNumberSeed = 1234567890;

        private readonly decimal _minimumBalance;
        public BankAccount(string name, decimal initialBalance) : this(name,
        initialBalance, 0)
        { }
        public BankAccount(string name, decimal initialBalance, decimal
        minimumBalance)
        {
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
            Owner = name;
            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }


        private List<Transaction> _allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    "Amount of deposit must be positive");
            }
            var deposit =  new Transaction(amount, date, note);
            _allTransactions.Add(deposit);

        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);

            Transaction? withdrawal = new(-amount, date, note);

            _allTransactions.Add(withdrawal);

            if (overdraftTransaction is not null)
            {
                _allTransactions.Add(overdraftTransaction);
            }
        }
        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }


    public string GetAcountHistory()
        {
            var report = new StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach(var transaction in _allTransactions)
            {
                balance += transaction.Amount;
                report.
                    AppendLine(
                        $"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Notes}"
                    );
            }

            return report.ToString();
        }

        public virtual void PerformingMonthEndTransaction()
        {
            
        }
    }
}
