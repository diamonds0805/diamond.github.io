using System;
namespace EmployeeTracker
{
    public class PartTime:Hourly
    {
        public PartTime(string n,string a, decimal payPH, decimal hoursPW):base(n,a,payPH,hoursPW)
        {

        }
    }
}
