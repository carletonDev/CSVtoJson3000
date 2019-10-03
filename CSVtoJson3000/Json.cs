using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //can parse to any class of your choice
           return dt.RowsAs<Taxi>().ToList();

            
        }

        /// <summary>
        /// converts a list to a json file
        /// </summary>
        /// <param name="taxiRides"></param>
        public static void WriteToJson(List<Taxi> taxiRides ,string jsonPath)
        {
            foreach(Taxi ride in taxiRides)
            {
                using(StreamWriter stream = File.AppendText(jsonPath))
                {
                    stream.WriteLine(JsonConvert.SerializeObject("{taxi:["+ride+"]}"));
                }
            }
        }
    }
}
