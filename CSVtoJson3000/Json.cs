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
using System.Reflection;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Data;

namespace CSVtoJson3000
{
    public static class JsonTaxi
    {
        /// <summary>
        /// the best csv convert is mike stall's data table make a class and bind easy!
        /// </summary>
        public static List<T> CsvToList<T>(string path)
        {
            var dt = DataAccess.DataTable.New.ReadLazy(path);
            List<T> CsvList = new List<T>();
            foreach(var item in dt.RowsAs<object>().ToList())
            {
                CsvList.Add((T)item);
            }
            //can parse to any class of your choice
            return CsvList;
            
        }

        public static void ConvertStringToCsV<T>(List<T> list, string path)
        {
            string jsonString = string.Join(",", list);

            var csv = JsonConvertNoClass(jsonString);
            var dt = DataAccess.DataTable.New.ReadFromString(csv);
            dt.SaveCSV(path);
        }

        public static List<T> JsonToList<T>(string path)
        {
            List<T> list = new List<T>();
            JsonSerializer serializer = new JsonSerializer();
            using (var stream = File.OpenText(path))
            {
                StringReader json = new StringReader(stream.ReadToEnd());
                using (JsonReader jsonReader = new JsonTextReader(json))
                {

                        //deserialize based on class type
                        list = serializer.Deserialize<List<T>>(jsonReader);
       
                }
            }
            return list;
        }

        public static void ListToCsv<T>(List<T>list,string path)
        {
            var dt = DataAccess.DataTable.New.FromEnumerable(list);
            dt.SaveCSV(path);
        }
        /// <summary>
        /// converts a list to a json file
        /// </summary>
        /// <param name="list"></param>
        public static void WriteToJson<T>(List<T> list ,string jsonPath)
        {

                
                using(StreamWriter stream = File.AppendText(jsonPath))
                {
                    
                    stream.WriteLine(JsonConvert.SerializeObject(list));
                }
        }


        public static string JsonConvertNoClass(string json)
        {
            XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + json + "}}");
            XmlDocument xmldoc = new XmlDocument();
            //Create XmlDoc Object
            xmldoc.LoadXml(xml.InnerXml);
            //Create XML Steam 
            var xmlReader = new XmlNodeReader(xmldoc);
            DataSet dataSet = new DataSet();
            //Load Dataset with Xml
            dataSet.ReadXml(xmlReader);
            //return single table inside of dataset
            var csv = dataSet.Tables[0].ToCSV(",");
            return csv;
        }
        /// <summary>
        /// method to convert classes to CSV without  needing a class specified
        /// </summary>
        /// <param name="table"></param>
        /// <param name="delimator"></param>
        /// <returns></returns>
        public static string ToCSV(this System.Data.DataTable table, string delimator)
        {
            var result = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
            }
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
                }
            }
            return result.ToString().TrimEnd(new char[] { '\r', '\n' });
            //return result.ToString();
        }
    }
}
