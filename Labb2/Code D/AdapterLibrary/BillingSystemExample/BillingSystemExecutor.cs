using BuildingBlocks;

namespace Library.BillingSystemExample
{
    public static class BillingSystemExecutor
    {
 
        public static void Execute()
        {
            ConsoleExtension.WriteSeparator("Billing system example");

            HRSystem hrSystem = new HRSystem();
            string[,] employeesInfo = hrSystem.GetEmployeesInfo();

            ISalaryProcessor salaryProcessor = new HRSystem();

            salaryProcessor.ProcessSalaries(employeesInfo);
        }
    }
}
