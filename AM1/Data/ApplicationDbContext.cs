﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AM1.Models;

namespace AM1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<AM1.Models.Artist> Artist { get; set; }

        public DbSet<AM1.Models.Blog> Blog { get; set; }

        public DbSet<AM1.Models.Event> Event { get; set; }

        public DbSet<AM1.Models.VolForm> VolForm { get; set; }

        public DbSet<AM1.Models.MyArtist> MyArtist { get; set; }

        public DbSet<AM1.Models.Contact> Contact { get; set; }

        public DbSet<AM1.Models.ArtsDir> ArtsDir { get; set; }

        public DbSet<AM1.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<AM1.Models.Album> Album { get; set; }

        public DbSet<AM1.Models.Photos> Photos { get; set; }

        public DbSet<AM1.Models.Cart> Cart { get; set; }

        public DbSet<AM1.Models.Product> Product { get; set; }

        public DbSet<AM1.Models.GMapModel> GMapModel { get; set; }
        
    }
}