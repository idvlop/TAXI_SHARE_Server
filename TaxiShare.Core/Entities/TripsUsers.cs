//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaxiShare.Domain.Entities
//{
//    public class TripsUsers
//    {
//        [Required]
//        public long Id { get; set; }
        
//        [ForeignKey("TripId"), Required]
//        public Trip Trip { get; set; }
//        public long TripId { get; set; }
        
//        [ForeignKey("UserId"), Required]
//        public User User { get; set; }
//        public long UserId { get; set; }

//    }
//}
