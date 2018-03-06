using System;

namespace DoFactory.GangOfFour.Facade.RealWorld

{

    class MainApp

    {

        static void Main()

        {

            // Facade

            Mortgage mortgage = new Mortgage();

            //Evaluo si es factible una hipoteca para un cliente

            Customer customer = new Customer("Ann McKinsey");

            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));

            Console.ReadKey();

        }

    }

    class Bank

    {

        public bool HasSufficientSavings(Customer c, int amount)

        {

            Console.WriteLine("Check bank for " + c.Name);

            return true;

        }

    }

    class Credit

    {

        public bool HasGoodCredit(Customer c)

        {

            Console.WriteLine("Check credit for " + c.Name);

            return true;

        }

    }

    class Loan

    {

        public bool HasNoBadLoans(Customer c)

        {

            Console.WriteLine("Check loans for " + c.Name);

            return true;

        }

    }

    class Customer

    {

        private string _name;

        public Customer(string name)

        {

            this._name = name;

        }

        public string Name

        {

            get { return _name; }

        }

    }

    //La clase que hace de Facade

    class Mortgage

    {

        private Bank _bank = new Bank();

        private Loan _loan = new Loan();

        private Credit _credit = new Credit();

        public bool IsEligible(Customer cust, int amount)

        {

            Console.WriteLine("{0} applies for {1:C} loan\n",

              cust.Name, amount);

            bool eligible = true;

            // Check creditworthyness of applicant

            if (!_bank.HasSufficientSavings(cust, amount))

            {

                eligible = false;

            }

            else if (!_loan.HasNoBadLoans(cust))

            {

                eligible = false;

            }

            else if (!_credit.HasGoodCredit(cust))

            {

                eligible = false;

            }

            return eligible;

        }

    }

}
