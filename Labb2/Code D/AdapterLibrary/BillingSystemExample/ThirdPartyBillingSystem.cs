using System;
using System.Collections.Generic;

namespace Library.BillingSystemExample
{

    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"EUR {employee.Salary} salary credited to {employee.Name}'s account.");
            }
        }
    }
}
