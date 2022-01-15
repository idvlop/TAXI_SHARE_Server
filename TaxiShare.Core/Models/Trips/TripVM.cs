using TaxiShare.Domain.Entities;
using TaxiShare.Domain.Enums;
using TaxiShare.Domain.Extentions;
using TaxiShare.Domain.Models.Messages;

namespace TaxiShare.Domain.Models.Trips
{
    public class TripVM
    {
        public TripVM(Trip trip)
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
            Users = trip.Users.Select(x => new BaseItem<Guid>(x.Guid, UserExtentions.GetFullNameOrDefault(x.Firstname, x.Surname, x.PatronymicName))).ToList();
            Messeges = trip.Messeges.Select(x => new MessageItemVM(x)).ToList();
        }

        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public TripStatus Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DeparturePointAddress { get; set; }
        public string ArrivalPointAddress { get; set; }
        public int? OverallCost { get; set; }
        public int UsersCount { get; set; }
        public int UserLimit { get; set; }
        public List<BaseItem<Guid>> Users { get; set; }
        public List<MessageItemVM> Messeges { get; set; }
    }
}
