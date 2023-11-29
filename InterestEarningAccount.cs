using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initalBalance) : base(name, initalBalance)
        {
        }

        public override void PerformingMonthEndTransaction()
        {
            if(Balance >  500m)
            {
                decimal interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "Applied Monthly Interest");
            }
        }
    }
}
