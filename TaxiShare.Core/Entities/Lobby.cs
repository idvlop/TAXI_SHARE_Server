using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class Lobby
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int UserLimit { get; set; }
        public long CreatorId { get; set; }
        public List<long> UserIds { get; set; }
        public bool inExistance { get; set; }
    }
}
