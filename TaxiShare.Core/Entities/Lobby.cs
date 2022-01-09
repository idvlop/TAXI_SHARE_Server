using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class Lobby
    {
        protected Lobby() { }

        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int UserLimit { get; set; }
        public User Creator { get; set; }
        public int OverallCost { get; set; }
        public bool InExistance { get; set; }
        public ICollection<User> Users { get; private set; } = new List<User>();

        public bool Empty() =>
            Users.Count == 0;

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void RemoveUser(string connectionId)
        {
            var user = Users.FirstOrDefault(u => u.ConnectionId == connectionId);
            if (user != null)
            {
                Users.Remove(user);
            }
        }
    }
}
