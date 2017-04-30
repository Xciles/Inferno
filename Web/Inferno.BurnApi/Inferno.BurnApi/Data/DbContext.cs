using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inferno.BurnApi.Data
{
    public class InfernoDbContext : DbContext
    {
        //public InfernoDbContext() { }
        public InfernoDbContext(DbContextOptions<InfernoDbContext> builder) : base(builder) { }

        public DbSet<Domain.FireReport> FireReports { get; set; }
        public DbSet<Domain.DroneAssignment> DroneAssignments { get; set; }
        public DbSet<Domain.Drone> Drones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
