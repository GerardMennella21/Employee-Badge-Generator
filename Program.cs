using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Would you like to create custom badges? (enter yes or no)");
            string option = Console.ReadLine() ?? "";
            if (option == "yes") {
                List<Employee> employees = PeopleFetcher.GetEmployees();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                await Util.MakeBadges(employees);
            } else if (option == "no") {
                List<Employee> employees = await PeopleFetcher.GetFromApi();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                await Util.MakeBadges(employees);
            } else {
                Console.WriteLine("Invalid response!");
            }      
        }
    }
}