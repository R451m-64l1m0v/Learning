using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RegisterToDoc.Models;

namespace RegisterToDoc.BD
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkTimeGraphic> WorkTimeGraphics { get; set; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<WorkTime> WorkTimeFull { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interval>()
                .HasOne(p => p.WorkTimeGraphic)
                .WithMany(b => b.Intervals);

            modelBuilder.Entity<WorkTimeGraphic>()
                .HasOne(p => p.Doctor)
                .WithMany(b => b.WorkTimeGraphic);

            modelBuilder.Entity<WorkTime>()
                .HasOne(p => p.Doctor)
                .WithMany(b => b.WorkTimeFull);
        }
    }
}
