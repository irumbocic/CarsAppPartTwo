using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Project.DAL.Entities;

namespace Project.DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base (options)
        {
        }

        public  DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        public  DbSet<VehicleModelEntity> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMakeEntity>()
                .HasMany(e => e.VehicleModels)
                .WithOne(e => e.VehicleMake)
                .HasForeignKey(e => e.MakeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
