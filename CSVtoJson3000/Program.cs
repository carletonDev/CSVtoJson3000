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
        
        /// <summary>
        /// gets a users answer to write to file using specified class in class library to serialize into
        /// </summary>
        /// <param name="answer"></param>
        public static void Choice(string answer)
        {

            if (answer == "v")
            {
                ChoiceV();
            }
            else if (answer == "s")
            {
                ChoiceS();
            }
        }
        /// <summary>
        /// processes writing json to csv and getting class name to serialize into can add more classes for more explicit conversion
        /// </summary>
        public static void ChoiceV()
        {
            string className = ClassChoice();

            if (className == "taxi")
            {
                WriteCsvFile<Taxi>();
            }
            else
            {
                WriteCsvFile<string>();
            }
        }
        /// <summary>
        /// processes writing csv to json and getting class name to serialize into can add more classes for more csv files
        /// </summary>
        public static void ChoiceS()
        {
            string className = ClassChoice();
            if (className == "taxi")
            {
                WriteJsonFile<Taxi>();
            }
            else
            {
                WriteJsonFile<string>();
            }
        }
        public static string ClassChoice()
        {
            Console.WriteLine("Which class would you like to serialize to?");
           return Console.ReadLine().ToLower();
        }
        /// <summary>
        /// writes to csv file based on file specified by user
        /// </summary>
        static void WriteCsvFile<T>()
        {
            
            string path = GetPath();
            List<T> list = new List<T>();
            Type t = typeof(T);
            if (t.Name != "String")
            {
                list = JsonTaxi.JsonToList<T>(path);
                path = WriteToPath();
                JsonTaxi.ListToCsv(list, path);
            }
            else
            {
                list = JsonTaxi.JsonToList<T>(path);
                path = WriteToPath();
                JsonTaxi.ConvertStringToCsV(list, path);
            }
        }
        /// <summary>
        /// writes to json file based on user csv file path
        /// </summary>
        static void WriteJsonFile<T>()
        {
            string path = GetPath();
            List<T> taxi = JsonTaxi.CsvToList<T>(path);
            path = WriteToPath();
            JsonTaxi.WriteToJson(taxi, path);
        }
        /// <summary>
        /// prompts the user for path
        /// </summary>
        /// <returns></returns>
        static string GetPath()
        {
            Console.WriteLine("Enter path to file");
            return Console.ReadLine();
        }
        /// <summary>
        /// prompts the user to write to path
        /// </summary>
        /// <returns></returns>
        static string WriteToPath()
        {
            Console.WriteLine("Enter path to write file");
           return Console.ReadLine();
        }
    }
  
}
