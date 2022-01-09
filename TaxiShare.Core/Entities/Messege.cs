using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Core.Entities
{
    public class Messege
    {
        protected Messege() { }

        public long Id { get; set; }
        public string Text { get; set; }
        public User Creator { get; set; }
        public Lobby Lobby { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastChanged { get; set; }
        public bool IsSystemMessege { get; set; }
        public bool InExistance { get; set; }
    }
}
