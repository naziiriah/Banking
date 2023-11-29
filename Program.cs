using Banking;

//var account = new BankAccount("Nazir Abubakar", 1000);
//Console.WriteLine($"Account { account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
//account.MakeWithdrawal(500, DateTime.Now,"Rent payment");
// Console.WriteLine(account.Balance); 
//account.MakeDeposit(1000, DateTime.Now, "Friend paid me back"); 
//Console.WriteLine(account.Balance);
//account.MakeWithdrawal(20, DateTime.Now, "Making withdrawal");
//Console.WriteLine(account.GetAcountHistory());

var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformingMonthEndTransaction();
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAcountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformingMonthEndTransaction();
Console.WriteLine(savings.GetAcountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformingMonthEndTransaction();
Console.WriteLine(lineOfCredit.GetAcountHistory());
