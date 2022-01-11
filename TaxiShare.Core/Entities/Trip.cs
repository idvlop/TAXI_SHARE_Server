using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class Trip
    {
        protected Trip() { }

        [Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Guid Guid { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public string DeparturePointAddress { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ArrivalPointAddress { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required]
        public int UserLimit { get; set; }
        public User Creator { get; set; }
        public int OverallCost { get; set; }
        public ICollection<User> Users { get; private set; } = new List<User>();
        public bool InExistance { get; set; } = true;

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
