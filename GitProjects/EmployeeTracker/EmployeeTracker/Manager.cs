using System;
namespace EmployeeTracker
{
    public class Manager:Salaried
    {
        private decimal _bonus;

        public Manager(string n, string a, decimal salary):base(n,a,salary)
        {
            _bonus = 1000 + _bonus;
            AnnualWage = salary + _bonus;
        }
    }
}
