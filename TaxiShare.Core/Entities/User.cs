using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class User
    {
        protected User() { }


        public string Id { get; set; }
        public Guid Guid { get; set; }
        public string ConnectionId { get; private set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public bool InExistance { get; set; } = true;
        //public ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
