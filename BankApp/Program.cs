using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bank1 = new BankAccount();

            bank1.enterNameAndSurname("Jan", "Kowalski");
            bank1.takeALoan(10000, 1, 12);


        }
    }
}
