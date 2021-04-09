using System;
using System.Collections.Generic;

namespace LearningCollections.TopTenCountriesPop
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\hp\Desktop\Ugee\.NET\WEEK-2\Pluralsight\Projects\LearningCollections\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();
            Console.Write("enter number of countries to display ");

            bool inputIsint = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsint || userInput <= 0)
            {
                Console.WriteLine("You must type a +ve integer. Exiting...");
                return;
            }
            int maxToDisplay = userInput;
            for (int i = 0; i < maxToDisplay; i++)
            {
                if (i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit > ..");
                    if (Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine( $"{i + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}:" +
                    $" {country.Name}");
            }

            Console.WriteLine($"Total countries: {countries.Count}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
