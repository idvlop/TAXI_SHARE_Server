﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Domain.Entities
{
    //Not implemented
    public class Grade
    {
        protected Grade() { }

        public long Id { get; set; }
        public int Score { get; set; }
        public User Creator { get; set; }
        public User Holder { get; set; }
        public Trip Trip { get; set; }
        public bool InExistance { get; set; } = true;
    }
}
