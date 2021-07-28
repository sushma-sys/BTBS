using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTBS.MVC.Models
{
    public class BusViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusViewModel()
        {
            this.Bookings = new HashSet<BookingViewModel>();
        }
        [Required]
        public int Bus_No { get; set; }
        [Required]
        [Display(Name = "From")]
        public string Starting_City { get; set; }
        [Required]
        [Display(Name = "To")]
        public string Destination { get; set; }
        [Required]
        public string Bus_type { get; set; }
        [Required]
        [Display(Name ="Child Cost")]
        [DataType(DataType.Currency)]
        public decimal Child_cost { get; set; }
        [Required]
        [Display(Name = "Adult Cost")]
        [DataType(DataType.Currency)]
        public decimal Adult_Cost { get; set; }
        [Required]
        [Display(Name ="Start From")]
        public string Broarding_Point { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Duration to Start")]
        public System.TimeSpan Broarding_Duration { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Arrival at Point")]
        public System.TimeSpan Arrival_At_Broarding { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Depature Time")]
        public System.TimeSpan Departure_Time { get; set; }
        [Required]
        public int Capacity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingViewModel> Bookings { get; set; }
    }
}