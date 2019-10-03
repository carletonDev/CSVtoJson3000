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
            //store csv file into list can change class and path
           List<Taxi> taxi=JsonTaxi.CsvtoClass("C:\\Csv\\Csv.csv");
            //write file to json or store into a databse
            JsonTaxi.WriteToJson(taxi,"C:\\Csv\\TaxiRide.json");
            Console.WriteLine("Check your file");
            Console.ReadKey();
        }
    }
}
