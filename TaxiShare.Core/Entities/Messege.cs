using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class Messege
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long CreatorId { get; set; }
        public long LobbyId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public bool IsSystemMessege { get; set; }
        public bool InExistance { get; set; }
    }
}
