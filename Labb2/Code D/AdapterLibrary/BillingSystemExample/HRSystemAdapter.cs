using System;
using System.Collections.Generic;

namespace Library.BillingSystemExample
{

    public class HRSystem : ISalaryProcessor
    {
        private readonly ThirdPartyBillingSystem _thirdPartyBillingSystem;

        public HRSystem()
        {
            _thirdPartyBillingSystem = new ThirdPartyBillingSystem();
        }

        public void ProcessSalaries(string[,] rawEmployees)
        {
            var employeesForProcessing = PrepareEmployeesForSalaryProcessing(rawEmployees);

            _thirdPartyBillingSystem.ProcessSalary(employeesForProcessing);
        }

        private List<Employee> PrepareEmployeesForSalaryProcessing(string[,] rawEmployees)
        {
            var employeesForProcessing = new List<Employee>();

            for (int i = 0; i < rawEmployees.GetLength(0); i++)
            {
                string id = null;
                string name = null;
                string salary = null;

                for (int j = 0; j < rawEmployees.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        id = rawEmployees[i, j];
                    }
                    else if (j == 1)
                    {
                        name = rawEmployees[i, j];
                    }
                    else
                    {
                        salary = rawEmployees[i, j];
                    }
                }

                var employee = new Employee
                {
                    Id = Convert.ToInt32(id),
                    Name = name,
                    Salary = Convert.ToDecimal(salary),
                };

                employeesForProcessing.Add(employee);
            }

            Console.WriteLine(" converted array of employees to list of employees...");

            return employeesForProcessing;
        }
    }
}
