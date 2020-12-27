using System;
namespace EmployeeTracker
{
    public abstract class Employee
    {
        protected string _name;
        protected string _address;

        public Employee(string name, string address)
        {
            _name = name;
            _address = address;
        }

        public virtual decimal CalcPay(decimal hoursPW, decimal hourlyWage)
        {
            decimal annualWage = (hoursPW * hourlyWage) * 52;
            return annualWage;
        }
    }
}
