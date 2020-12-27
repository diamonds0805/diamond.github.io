using System;
namespace EmployeeTracker
{
    public abstract class Hourly:Employee
    {
        protected decimal _payPerHour;
        protected decimal _hoursPerWeek;

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

        public Hourly(string n, string a, decimal payPerHour, decimal hoursPerWeek):base(n,a)
        {
            _payPerHour = payPerHour;
            _hoursPerWeek = hoursPerWeek;
            AnnualWage = CalcPay(_payPerHour, _hoursPerWeek);
        }
    }
}
