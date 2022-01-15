using TaxiShare.Domain.Entities;
using TaxiShare.Domain.Enums;

namespace TaxiShare.Application.Models.Trips
{
    public class TripItemVM
    {
        public TripItemVM(Trip trip)
        {
            Id = trip.Id;
            Guid = trip.Guid;
            Title = trip.Title;
            Created = trip.Created;
            Closed = trip.Closed;
            DepartureTime = trip.DepartureTime;
            DeparturePointAddress = trip.DeparturePointAddress;
            ArrivalPointAddress = trip.ArrivalPointAddress;
            OverallCost = trip.OverallCost;
            UsersCount = trip.Users.Count;
            UserLimit = trip.UsersCountLimit;
        }

        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public TripStatus Status { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string DeparturePointAddress { get; set; }
        public string ArrivalPointAddress { get; set; }
        public int? OverallCost { get; set; }
        public int UsersCount { get; set; }
        public int UserLimit { get; set; }
    }
}
