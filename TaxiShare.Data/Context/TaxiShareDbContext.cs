using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiShare.Core.Entities;

namespace TaxiShare.Data.Context
{
    public class TaxiShareDbContext : DbContext
    {
        protected TaxiShareDbContext()
        {
        }
        public TaxiShareDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Messege> Messeges { get; set; }
        public DbSet<Trip> Lobbies { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
