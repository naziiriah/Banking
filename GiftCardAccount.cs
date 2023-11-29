using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class GiftCardAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initalBalance, decimal monthlyDeposit = 0) :
            base(name, initalBalance) => _monthlyDeposit = monthlyDeposit;

        public override void PerformingMonthEndTransaction()
        {
            if(_monthlyDeposit > 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
    }
}
