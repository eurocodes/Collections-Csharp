using System;

namespace LearningCollections.TopTenCountriesPop
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\hp\Desktop\Ugee\.NET\WEEK-2\Pluralsight\Projects\LearningCollections\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
