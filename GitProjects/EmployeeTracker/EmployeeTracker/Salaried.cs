using System;
namespace EmployeeTracker
{
    public class Salaried: Employee
    {
        private decimal _bonus;

        public decimal AnnualWage { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Salaried(string n, string a, decimal salary):base(n,a)
        {
            _bonus = 500;
            AnnualWage = salary + _bonus;
        }
    }
}
