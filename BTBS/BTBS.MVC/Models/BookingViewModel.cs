using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTBS.MVC.Models
{
    public class BookingViewModel
    {
        [Required]
        [Display(Name = "Booking Id")]
        public int Booking_Id { get; set; }
        [Required]
        [Display(Name ="Booking Date")]
        [DataType(DataType.Date)]
        public System.DateTime Booking_Date { get; set; }
        [Required]
        [Display(Name = "Route No")]
        public Nullable<int> Route_No { get; set; }
        [Required]
        [Display(Name = "Bus No")]
        public Nullable<int> Bus_No { get; set; }
        [Required]
        [Display(Name = "Passenger Id")]
        public Nullable<int> Passenger_Id { get; set; }
        [Required]
        [Display(Name ="From")]
        public string Starting_City { get; set; }
        [Required]
        [Display(Name ="To")]
        public string Destination { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Traveling Date")]
        public System.DateTime Date_Of_Travel { get; set; }
        [Required]
        [Display(Name = "Child Cost")]
        [DataType(DataType.Currency)]
        public decimal Child_Cost { get; set; }
        [Required]
        [Display(Name = "Adult Cost")]
        // [DataType(DataType.Currency)]
        public decimal Adult_Cost { get; set; }
        public string Status { get; set; }
        [Required]
        [Display(Name = "Seats No")]
        public int Seats_No { get; set; }
        [Required]
       // [DataType(DataType.Currency)]
        public decimal Total_Cost { get; set; }

        public virtual BusViewModel Bus { get; set; }
        public virtual PassengerViewModel Passenger { get; set; }
        public virtual RouteViewModel Route { get; set; }
    }
}