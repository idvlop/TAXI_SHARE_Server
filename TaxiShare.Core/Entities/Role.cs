using System.ComponentModel.DataAnnotations;

namespace TaxiShare.Domain.Entities
{
    public class Role //: IdentityRole<string>
    {
        public Role(string name)
        {
            Guid = Guid.NewGuid();
            Name = name;
        }
        [Key, Required]
        public long Id { get; set; }
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
