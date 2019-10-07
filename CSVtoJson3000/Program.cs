using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVtoJson3000
{
    class Program
    {/// <summary>
    /// After downloading BigQuery Taxi database to CSV I made a serializer to json to store in firebase since the option to import to json requires money
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("How would you like to serialize");
            Console.WriteLine("s is  csv to json v is json to csv");
            string answer = Console.ReadLine().ToLower();
            Choice(answer);
            Console.WriteLine("Check file location");
            Console.ReadKey();
        }
        static void Choice(string answer)
        {
            if (answer == "s")
            {
                WriteJsonFile();
            }
            else if (answer == "v")
            {
                WriteCsvFile();
                    
            }
        }
        static void WriteCsvFile()
        {
            string path = GetPath();
            List<Taxi> taxi = JsonTaxi.JsonToList(path);
            path = WriteToPath();
            JsonTaxi.ListToCsv(taxi, path);
        }
        static void WriteJsonFile()
        {
            string path = GetPath();
            List<Taxi> taxi = JsonTaxi.CsvtoClass(path);
            path = WriteToPath();
            JsonTaxi.WriteToJson(taxi, path);
        }
        static string GetPath()
        {
            Console.WriteLine("Enter path to file");
            return Console.ReadLine();
        }
        static string WriteToPath()
        {
            Console.WriteLine("Enter path to write file");
           return Console.ReadLine();
        }
    }
  
}
