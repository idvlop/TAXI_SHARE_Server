using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Domain.Models.Trips
{
    public class NewTripVM
    {
        public NewTripVM(string title, string departurePointAddress, DateTime? departureTime, string arrivalPointAddress, int? overallCost, int userLimit, long creatorId)
        {
            Title = title;
            DeparturePointAddress = departurePointAddress;
            DepartureTime = departureTime;
            ArrivalPointAddress = arrivalPointAddress;
            OverallCost = overallCost;
            UserLimit = userLimit;
            CreatorId = creatorId;
        }

        public string Title { get; set; }
        public string DeparturePointAddress { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string ArrivalPointAddress { get; set; }
        public int? OverallCost { get; set; }
        public int UserLimit { get; set; }
        public long CreatorId { get; set; }
    }
}
