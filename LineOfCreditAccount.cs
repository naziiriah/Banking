using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initalBalance, decimal creditBalance) : base(name, initalBalance, -creditBalance)
        {
        }

        public override void PerformingMonthEndTransaction()
        {
            if(Balance < 0)
            {
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge Monthly Interest");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
             isOverdrawn
             ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
             : default;
    }
}
