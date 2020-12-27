using System;
namespace EmployeeTracker
{
    public class FullTime:Hourly
    {
        public FullTime(string n, string a, decimal payPH):base(n,a,payPH,40)
        {

        }
    }
}
