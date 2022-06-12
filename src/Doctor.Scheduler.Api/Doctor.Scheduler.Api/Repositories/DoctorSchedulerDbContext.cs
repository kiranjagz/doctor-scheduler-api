using Doctor.Scheduler.Api.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Scheduler.Api.Repositories
{
    public class DoctorSchedulerDbContext : DbContext
    {
        public DoctorSchedulerDbContext()
        {

        }

        public DoctorSchedulerDbContext(DbContextOptions<DoctorSchedulerDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=DoctorSchedulerApiDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Attendees> Attendees { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes  { get; set; }
    }
}