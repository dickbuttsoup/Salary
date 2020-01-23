using System;
using Salary.Entities;
using Salary.Entities.Enums;
using System.Globalization;


namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter Worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseS = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseS, dept);


            Console.Write("How many contracts to this worker? ");
            int contracts = int.Parse(Console.ReadLine());

            for (int i = 0; i < contracts; i++)
            {
                Console.WriteLine("Enter #{0} contract data:", i + 1);
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract c = new HourContract(date, value, hours);
                worker.AddContract(c);


            }

            Console.Write("Enter month and year to " +
                "calculate income (MM/YYYY): ");
            string[] dateIncome = Console.ReadLine().Split("/");
            int month = int.Parse(dateIncome[0]);
            int year = int.Parse(dateIncome[1]);


            Loading.Load();

            Console.WriteLine("Name: {0} " +
                "\nDepartment: {1} " +
                "\nIncome for {2}/{3}: {4}",
                worker.Name,
                worker.Department.Name, 
                month.ToString("D2"), 
                year, worker.Income(year, month)
                .ToString("C2", CultureInfo.CurrentCulture));
        }



    }
}
