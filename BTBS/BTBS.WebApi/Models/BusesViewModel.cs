using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTBS.WebApi.Models
{
    public class BusesViewModel
    {
        public int Bus_No { get; set; }
        public string Starting_City { get; set; }
        public string Destination { get; set; }
        public string Bus_type { get; set; }
        public decimal Child_cost { get; set; }
        public decimal Adult_Cost { get; set; }
        public string Broarding_Point { get; set; }
        public System.TimeSpan Broarding_Duration { get; set; }
        public System.TimeSpan Arrival_At_Broarding { get; set; }
        public System.TimeSpan Departure_Time { get; set; }
        public int Capacity { get; set; }

    }
}