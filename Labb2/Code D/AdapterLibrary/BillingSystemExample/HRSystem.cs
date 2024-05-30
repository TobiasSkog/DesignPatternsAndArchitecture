namespace Library.BillingSystemExample
{

    public class HRSystem
    {
        public string[,] GetEmployeesInfo()
        {
            return new string[4, 3]
            {
                { "1", "John", "5950" },
                { "2", "Anna", "5800" },
                { "3", "Nicole", "6100" },
                { "4", "Steven", "5000" },
            };
        }
    }
}
