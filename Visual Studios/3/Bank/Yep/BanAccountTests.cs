using System;
using NUnit.Framework;
using BankAccountNS;


namespace Yep
{
    [TestFixture]
    public class TestsSample
    {
       
        [Test]
        public void Pass()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            Console.WriteLine("test1");
        }

       
    }
}