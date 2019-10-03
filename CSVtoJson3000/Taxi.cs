using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVtoJson3000
{
   public class Taxi
    {
        public string vendor_id { get; set; }
        [Optional]
        public string pickup_datetime { get; set; }
        [Optional]
        public string dropoff_datetime { get; set; }
        [Optional]
        public float pickup_longitude { get; set; }
        [Optional]
        public float pickup_latitude { get; set; }
        [Optional]
        public float dropoff_longitude { get; set; }
        [Optional]
        public float dropoff_latitude { get; set; }
        [Optional]
        public int rate_code { get; set; }
        [Optional]
        public int passenger_count { get; set; }
        [Optional]
        public float trip_distance { get; set; }
        [Optional]
        public string payment_type { get; set; }
        [Optional]
        public float fare_amount { get; set; }
        [Optional]
        public float extra { get; set; }
        [Optional]
        public float mta_tax { get; set; }
        [Optional]
        public float imp_surcharge { get; set; }
        [Optional]
        public float tip_amount { get; set; }
        [Optional]
        public float tolls_amount { get; set; }
        [Optional]
        public float total_amount { get; set; }
        [Optional]
        public string store_and_fwd_flag { get; set; }

    }
}
