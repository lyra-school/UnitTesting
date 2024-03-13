using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ex1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Deposit_AmountIntoBankAccount_BalanceUpdated()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();
            decimal amount = 100;

            //Act
            bankAccount.Deposit(amount);
            decimal result = bankAccount.Balance;

            // Assert
            Assert.AreEqual(amount, result);
        }

        [TestMethod]
        public void Deposit_MultipleAmountsIntoBankAccount_BalanceUpdated()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount();
            decimal amount = 69;
            decimal amount2 = 103;
            decimal amount3 = 32;

            //Act
            bankAccount.Deposit(amount);
            bankAccount.Deposit(amount2);
            bankAccount.Deposit(amount3);
            decimal result = bankAccount.Balance;

            //Assert
            Assert.AreEqual(amount + amount2 + amount3, result);
        }

        [TestMethod]
        public void Create_NewBankAccount_ReturnsNoBalance()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount();

            //Act & assert
            Assert.AreEqual(0, bankAccount.Balance);
        }

        [TestMethod]
        public void Withdraw_AmountLessThanBalance_BalanceUpdated()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount() { Balance = 100};
            decimal withdrawn = 32;

            //Act
            bankAccount.Withdraw(withdrawn);

            // Assert
            Assert.AreEqual(100 - withdrawn, bankAccount.Balance);
        }

        [TestMethod]
        public void Withdraw_AmountHigherThanBalance_BalanceNotUpdated()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount() { Balance = 100 };
            decimal withdrawn = 101;

            //Act
            bankAccount.Withdraw(withdrawn);

            //Assert
            Assert.AreEqual(100, bankAccount.Balance);
        }

        [TestMethod]
        public void Withdraw_AmountLessThanBalanceWithOverdraft_BalanceUpdated()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount() { Balance = 100, OverdraftLimit = 100 };
            decimal withdrawn = 101;

            // Act
            bankAccount.Withdraw(withdrawn);

            //Assert
            Assert.AreEqual(100 - withdrawn, bankAccount.Balance);
        }

        [TestMethod]
        public void Withdraw_AmountHigherThanBalanceWithOverdraft_BalanceNotUpdated()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount() { Balance = 100, OverdraftLimit = 100 };
            decimal withdrawn = 300;

            //Act
            bankAccount.Withdraw(withdrawn);

            //Assert
            Assert.AreEqual(100, bankAccount.Balance);
        }
    }
}
