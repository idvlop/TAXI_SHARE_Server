using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class Messege
    {
        protected Messege() { }
        [Required]
        public long Id { get; set; }
        public Guid Guid { get; set; }
        [Required]
        public string Text { get; set; }
        public User Creator { get; set; }
        public Trip Trip { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastChanged { get; set; }
        public bool IsSystemMessege { get; set; }
        public bool InExistance { get; set; } = true;
    }
}
