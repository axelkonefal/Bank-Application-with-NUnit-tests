using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp
{
    public class BankAccount
    {
        int pin;
        string name;
        string surname;
        double balance;
        double debitAmount;
        bool isDebitAvailable;
        //TODO: sprawdzenie czy imie / nazwisko jest poprawne

        public BankAccount() { }

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public BankAccount(bool isDebitAvailable)
        {
            this.isDebitAvailable = isDebitAvailable;
        }

        public BankAccount(double balance, bool isDebitAvailable)
        {
            this.balance = balance;
            this.isDebitAvailable = isDebitAvailable;
        }

        public BankAccount(string name, string surname, double balance, double debitAmount, bool isDebitAvailable)
        {
            this.name = name;
            this.surname = surname;
            this.balance = balance;
            this.debitAmount = debitAmount;
            this.isDebitAvailable = isDebitAvailable;
        }



        /// <summary>
        /// Set pin
        /// </summary>
        /// <param name="pin">pin int</param>
        /// <returns>if his more than 4 digits returns 0, else returns pin </returns>
        public int pinValidation(int pin)
        {
            if (pin > 9999 || pin < -9999)
            {
                return 0;
            }
            if (pin < 0)
                pin = pin * -1;
            this.pin = pin;
            return pin;
        }


        /// <summary>
        /// Enter name & surname to the program
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="surname">surname</param>
        /// <returns>name & surname if correct, else return empty string</returns>
        public string enterNameAndSurname(string name, string surname)
        {
            //return empty string if given name & surname is empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                Console.WriteLine("Wrong data");
                return "wrong data";
            }

            //return empty string if  name & surname do not contain normal letters
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$") || !Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Wrong data");
                return "wrong data";
            }
            this.name = name;
            this.surname = surname;
            Console.WriteLine("Welcome to the bank {0} {1}", name, surname);
            return name + " " + surname;



        }


        /// <summary>
        /// Withdraw funds from the acc
        /// </summary>
        /// <param name="funds">money to withdraw</param>
        /// <returns>balance minus withdraw or balance</returns>
        public double withdrawFunds(double funds)
        {
            if (funds < 0)
                return balance;

            return balance = (balance >= funds) ? (balance -= funds) : balance;
        }


        /// <summary>
        /// Deposit new funds
        /// </summary>
        /// <param name="funds">money added</param>
        /// <returns>Returns balance with added funds</returns>
        public double depositFunds(double funds)
        {
            return balance = (funds >= 0) ? balance += funds : balance;
        }

        /// <summary>
        /// Bank transfer 
        /// </summary>
        /// <param name="funds">money to transfer </param>
        /// <param name="isDebitAvailable">if debit is available return balence > 0</param>
        /// <returns>balance after transfer</returns>
        public double fundsTransfer(double funds)
        {
            if (isDebitAvailable)
            {            
                    return balance -= funds;            
            }          
            else
            {
                return balance = (funds > balance) ? double.NaN : balance -= funds;
            }
        }


        /// <summary>
        /// Method to take a loan
        /// </summary>
        /// <param name="loanAmount">the amount of money client wants to take</param>
        /// <param name="incomePerMonth">clients income per month</param>
        /// <param name="durationOfTheLoan">duration of the loan in months</param>
        /// <returns>loan to repay</returns>
        public double takeALoan(double loanAmount, double incomePerMonth, double durationOfTheLoan)
        {
            double loanInterestRate;

            if (durationOfTheLoan <= 0 || incomePerMonth <= 0 || loanAmount <= 0)
            {
                Console.WriteLine("Error in given data");
                return double.NaN;
            }
            if (durationOfTheLoan <= 12 && durationOfTheLoan > 0)
            {
                loanInterestRate = 3.5;
                Console.WriteLine("You will have to pay {0}", loanAmount * loanInterestRate);
                return loanAmount * loanInterestRate;

            }
            else if (durationOfTheLoan > 12 && durationOfTheLoan <= 24)
            {
                loanInterestRate = 2.2;
                return loanAmount * loanInterestRate;
            }
            else
            {
                loanInterestRate = 2.0;
                return loanAmount * loanInterestRate;
            }
        }



    }
}
