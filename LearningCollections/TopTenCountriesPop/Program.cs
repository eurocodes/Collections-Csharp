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

            var countries = reader.ReadAllCountries();
            Console.WriteLine("Which country code do you want to lookup?...");
            string userinput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userinput, out Country country);
            if (!gotCountry)
                Console.WriteLine($"Sorry there is no country with country code, {userinput}");
            else
                Console.WriteLine($"{country.Name} has population " +
                    $"{PopulationFormatter.FormatPopulation(country.Population)}");

            Console.WriteLine($"Total countries: {countries.Count}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
