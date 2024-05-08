﻿using back_wachify.Business_Logic_Layer.Model;
using back_wachify.Data.Model;
using back_wachify.Model;
using Microsoft.EntityFrameworkCore;

namespace back_wachify.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Film> Film { get; set; }

        public DbSet<Pack> Pack { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }

        public DbSet<Series> Series { get; set; }
        public DbSet<Season> Season { get; set; }

        public DbSet<Episode> Episode { get; set; }



        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
            modelBuilder.Entity<Series>()
              .HasKey(u => u.SeriesID);
            modelBuilder.Entity<Season>()
            .HasKey(u => u.SeasonID);
        }


    }
}
