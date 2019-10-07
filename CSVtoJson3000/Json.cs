using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CsvHelper;
using DataAccess;
using Newtonsoft.Json;
namespace CSVtoJson3000
{
    public static class JsonTaxi
    {
        /// <summary>
        /// the best csv convert is mike stall's data table make a class and bind easy!
        /// </summary>
        public static List<Taxi> CsvtoClass(string path)
        {
            var dt = DataTable.New.ReadLazy(path);
            List<Taxi>taxiRide = dt.RowsAs<Taxi>().ToList();
            //can parse to any class of your choice
            return taxiRide;
            
        }

      

        public static List<Taxi> JsonToList(string path)
        {
            List<Taxi> taxi = new List<Taxi>();

            using (var stream = File.OpenText(path))
            {
                StringReader json = new StringReader(stream.ReadToEnd());
                using (JsonReader jsonReader = new JsonTextReader(json))
                {
                 
                        JsonSerializer serializer = new JsonSerializer();
                        taxi=serializer.Deserialize<List<Taxi>>(jsonReader);
                }
            }
            return taxi;
        }
        public static void ListToCsv(List<Taxi> taxi,string path)
        {
            var dt = DataTable.New.FromEnumerable(taxi);
            dt.SaveCSV(path);
        }
        /// <summary>
        /// converts a list to a json file
        /// </summary>
        /// <param name="taxiRides"></param>
        public static void WriteToJson(List<Taxi> taxiRides ,string jsonPath)
        {

                
                using(StreamWriter stream = File.AppendText(jsonPath))
                {
                    
                    stream.WriteLine(JsonConvert.SerializeObject(taxiRides));
                }
        }
    }
}
