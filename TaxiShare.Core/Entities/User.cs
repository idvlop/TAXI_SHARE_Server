using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class User : IdentityUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
