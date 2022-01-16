using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Application.Models.Users
{
    public class UserLoginVM
    {
        public UserLoginVM(string authorization)
        {
            Authorization = authorization;
        }
        public string Authorization { get; set; }
    }
}
