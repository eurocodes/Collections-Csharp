using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningCollections.TopTenCountriesPop
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\hp\Desktop\Ugee\.NET\WEEK-2\Pluralsight\Projects\LearningCollections\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();
            Console.Write("How many countries would you like to view? ");
            bool validInput = int.TryParse(Console.ReadLine(), out int maxToShow);

            // lists only first 10 countries
            /*foreach(Country country in countries.Take(10))
            {
                Console.WriteLine( $"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}:" +
                    $" {country.Name}");
            }*/

            // List the countries in ordered manner
            /*if (!validInput || maxToShow <= 0)
            {
                Console.WriteLine("Kindly put a valid and positive input.");
            }
            else
            {
                foreach (Country country in countries.OrderBy(x => x.Name).Take(maxToShow))
                {
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}:" +
                        $" {country.Name}");
                }
            }*/

            // Display countries that doesnot have comma (",")
            /*foreach (Country country in countries.Where(x=>!x.Name.Contains(",")).Take(maxToShow))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}:" +
                    $" {country.Name}");
            }*/

            // Using Linq query syntax
            var filteredList = countries.Where(x => !x.Name.Contains(",")); // .Take(maxToShow);
            var filteredList2 = from country in countries
                                where !country.Name.Contains(";")
                                select country;
            foreach (Country country in filteredList2)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}:" +
                    $" {country.Name}");
            }

            Console.WriteLine();
            // Show the items that where removed
            foreach (Country country in countries.Where(x => x.Name.Contains(",")).Take(maxToShow))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}:" +
                    $" {country.Name}");
            }

            Console.WriteLine($"Total countries: {countries.Count}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
