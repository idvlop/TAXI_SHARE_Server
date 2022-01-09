using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiShare.Core.Entities;

namespace TaxiShare.Data.Context
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions options) : base(options) { }

        public DbSet<Messege> Messeges { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
