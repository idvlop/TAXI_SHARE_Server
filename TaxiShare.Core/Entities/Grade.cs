using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class Grade
    {
        public long Id { get; set; }
        public int Score { get; set; }
        public long CreatorId { get; set; }
        public long UserId { get; set; }
        public long LobbyId { get; set; }
    }
}
