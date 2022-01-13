using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Domain.Entities
{
    public class Trip
    {
        protected Trip() { }

        public Trip(long creatorId, string title, string departurePointAddress, string arrivalPointAddress, int userLimit, int? overallCost = null)
        {
            CreatorId = creatorId;
            Guid = Guid.NewGuid();
            Title = title;
            DeparturePointAddress = departurePointAddress;
            ArrivalPointAddress = arrivalPointAddress;
            UserLimit = userLimit;
            Created = DateTime.Now;
            OverallCost = overallCost;
        }

        [Key, Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string DeparturePointAddress { get; set; }
        public DateTime DepartureTime { get; set; }
        [Required]
        public string ArrivalPointAddress { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required]
        public int UserLimit { get; set; }
        [ForeignKey("CreatorId"), Required]
        public User Creator { get; set; }
        public long CreatorId { get; set; }
        public int? OverallCost { get; set; }
        public List<User> Users { get; private set; }
        public List<Messege> Messeges { get; private set; }
        public bool InExistance { get; set; } = true;
    }
}
