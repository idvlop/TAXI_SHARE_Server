﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiShare.Domain.Entities;

namespace TaxiShare.Infrastructure.Context
{
    public class TaxiShareDbContext : DbContext
    {
        protected TaxiShareDbContext() { }
        public TaxiShareDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Messege> Messeges { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<TripsUsers> TripsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Trip
            modelBuilder.Entity<Trip>()
                .HasAlternateKey(t => t.Guid);
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Creator)
                .WithMany(u => u.OwnedTrips);
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Users)
                .WithMany(u => u.Trips);
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Messeges)
                .WithOne(m => m.Trip);
            #endregion

            #region User
            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Guid);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Trips)
                .WithMany(t => t.Users);
            modelBuilder.Entity<User>()
                .HasMany(u => u.OwnedTrips)
                .WithOne(t => t.Creator);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Messeges)
                .WithOne(m => m.Creator);
            #endregion

            #region Messege
            modelBuilder.Entity<Messege>()
                .HasAlternateKey(m => m.Guid);
            modelBuilder.Entity<Messege>()
                .HasOne(m => m.Creator)
                .WithMany(u => u.Messeges);
            modelBuilder.Entity<Messege>()
                .HasOne(m => m.Trip)
                .WithMany(t => t.Messeges);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
