using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTBS.MVC.Models
{
    public class RouteViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RouteViewModel()
        {
            this.Bookings = new HashSet<BookingViewModel>();
        }

        public int Route_No { get; set; }
        public string Route_Name { get; set; }
        public int Stops { get; set; }
        public decimal Stage_Cost { get; set; }
        public string Start_Stage { get; set; }
        public string End_Stage { get; set; }
        public System.TimeSpan Start_time { get; set; }
        public System.TimeSpan End_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingViewModel> Bookings { get; set; }
    }
}