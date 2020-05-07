using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BankApp.UnitTests
{
    [TestFixture]
    public class BankAccountTests
    {


        //methodName_Scenario_expectedResult
        [TestCase("J an", "Kowalski", "wrong data")]                //wrong input
        [TestCase("Jan", "K owalski", "wrong data")]                //wrong input
        [TestCase("Jan1", "Kowalski", "wrong data")]                //wrong input
        [TestCase("Jan", "Kow2alski", "wrong data")]                //wrong input
        [TestCase("", "Kowalski", "wrong data")]                    //wrong input
        [TestCase("Jan", "", "wrong data")]                         //wrong input
        [TestCase("Jan", "Kowalski", "Jan" + " " + "Kowalski")]     //correct input
        public void EnterNameAndSurname_GiveWrongAndCorrectNames_DependingOnInput(string name, string surname, string expectedResult)
        {
            var bank = new BankAccount();
            
            Assert.AreEqual(expectedResult, bank.enterNameAndSurname(name, surname));
            
        }

        [Test]
        public void PinValidation_GiveWrongNumber_ReturnsZero()
        {
            //Arrange
            var bank = new BankAccount();

            //Act
            var tmp = bank.pinValidation(10000);

            //Assert
            Assert.AreEqual(0, tmp);
        }

        [Test]
        public void PinValidation_GiveCorrectNumber_ReturnsNumber()
        {
            //Arrange
            var bank = new BankAccount();

            //Act
            var tmp = bank.pinValidation(5555);

            //Assert
            Assert.AreEqual(5555, tmp);
        }

        [Test]
        public void PinValidation_GiveMinusCorrectNumber_ReturnsPlusNumber()
        {
            //Arrange
            var bank = new BankAccount();

            //Act
            var tmp = bank.pinValidation(-5555);

            //Assert
            Assert.AreEqual(5555, tmp);
        }

        [Test]
        public void WithdrawFunds_GiveMinusFunds_ReturnsBalance()
        {
            //Arrange
            var bank = new BankAccount(20);
            

            //Act
            var tmp = bank.withdrawFunds(-1);

            //Assert
            Assert.AreEqual(20, tmp);

        }
        [Test]
        public void WithdrawFunds_FundsGreaterThanBalance_ReturnsBalance()
        {
            //Arrange
            var bank = new BankAccount(20);


            //Act
            var tmp = bank.withdrawFunds(25);

            //Assert
            Assert.AreEqual(20, tmp);

        }

        [Test]
        public void WithdrawFunds_GiveFundsSmallerThanBalance_ReturnsBalanceMinusFunds()
        {
            //Arrange
            var bank = new BankAccount(20);


            //Act
            var tmp = bank.withdrawFunds(5);

            //Assert
            Assert.AreEqual(15, tmp);

        }

        [TestCase(5,5,10)]
        [TestCase(0,5,5)]
        [TestCase(5,0,5)]
        public void DepositFunds_FundsAreGreaterOrEqualZero_ReturnsBalancePlusNewFunds(double deposit, double balance, double expectedResult)
        {
            
            var bank = new BankAccount(balance);


            Assert.AreEqual(bank.depositFunds(deposit), expectedResult);
        }

        [Test]
        public void DepositFunds_FundsAreSmallerThanZero_ReturnsBalance()
        {
            //Arrange
            var bank = new BankAccount(5);

            //Act
            var tmp = bank.depositFunds(-2);

            //Assert
            Assert.AreEqual(5, tmp);
        }

        [Test]
        public void FundsTransfer_DebitIsNotPresentAndFundsAreGreaterThanBalance_ReturnsDoubleNaN()
        {
            //Arrange
            var bank = new BankAccount(5, false);

            //Act
            var tmp = bank.fundsTransfer(6);

            //Assert
            Assert.IsNaN(tmp);
        }

        [Test]
        public void FundsTransfer_DebitIsPresentAndFundsAreGreaterThanBalance_ReturnsBalanceMinusFunds()
        {
            //Arrange
            var bank = new BankAccount(5, true);

            //Act
            var tmp = bank.fundsTransfer(6);

            //Assert
            Assert.AreEqual(-1,tmp);
        }

        [TestCase(1,1,0)]
        [TestCase(1,0,1)]
        [TestCase(0,1,1)]
        public void TakeALoan_OneOfTheVariablesIsZero_ReturnsDoubleNaN(double loanAmount, double incomePerMonth, double durationOfTheLoan)
        {
            var bank = new BankAccount();

            Assert.AreEqual(double.NaN, bank.takeALoan(loanAmount, incomePerMonth, durationOfTheLoan));
        }

        [TestCase(1, 1, 12)]
        [TestCase(1, 1, 5)]
        public void TakeALoan_DurationIsLessOrEqualThanTwelveMonths_ReturnsLoanAmountTimeThreePointFive(double loanAmount, double incomePerMonth, double durationOfTheLoan)
        {
            var bank = new BankAccount();

            Assert.AreEqual(3.5, bank.takeALoan(loanAmount, incomePerMonth, durationOfTheLoan));
        }

        [TestCase(1, 1, 13)]
        [TestCase(1, 1, 24)]
        public void TakeALoan_DurationIsMoreTahnTwelveMonthsButLessOrEqualThanTwentyFourMonths_ReturnsLoanAmountTimeTwoPointTwo
            (double loanAmount, double incomePerMonth, double durationOfTheLoan)
        {
            var bank = new BankAccount();

            Assert.AreEqual(2.2, bank.takeALoan(loanAmount, incomePerMonth, durationOfTheLoan));
        }

        [TestCase(1, 1, 25)]
        [TestCase(1, 1, 40)]
        public void TakeALoan_DurationIsMoreThanTwentyFour_ReturnsLoanAmountTimeTwoPointTwo(double loanAmount, double incomePerMonth, double durationOfTheLoan)
        {
            var bank = new BankAccount();

            Assert.AreEqual(2.0, bank.takeALoan(loanAmount, incomePerMonth, durationOfTheLoan));
        }

    }
}
