using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Domain.Entities
{
    public class Message
    {
        protected Message() { }

        public Message(string text, long tripId, long? creatorId = null)
        {
            Guid = Guid.NewGuid();
            Text = text;
            TripId = tripId;
            Created = DateTime.UtcNow;
            if(creatorId != null)
                CreatorId = creatorId;
            else
                IsSystemMessege = true;
        }

        [Key, Required]
        public long Id { get; set; }
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey("CreatorId")]
        public User? Creator { get; set; }
        public long? CreatorId { get; set; }
        [ForeignKey("TripId"), Required]
        public Trip Trip { get; set; }
        public long TripId { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? LastChanged { get; set; }
        [Required]
        public bool IsSystemMessege { get; set; }
        public bool InExistance { get; set; } = true;
    }
}
