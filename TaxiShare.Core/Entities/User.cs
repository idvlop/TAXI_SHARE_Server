using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Domain.Entities
{
    public class User
    {
        protected User() { }

        [Key, Required]
        public long Id { get; set; }
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Surname { get; set; }
        public string? PatronymicName { get; set; }
        public string? PhotoUrl { get; set; }
        public List<Trip>? Trips { get; set; }
        public List<Trip>? OwnedTrips { get; set; }
        public List<Message>? Messeges { get; set; }
        public bool InExistance { get; set; } = true;
        //public ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
