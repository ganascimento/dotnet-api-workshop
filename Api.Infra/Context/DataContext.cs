using Api.Domain.Entities;
using Api.Infra.Mappings;
using Api.Infra.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<AuthEntity> Auth { get; set; }
        public DbSet<ServiceEntity> Service { get; set; }
        public DbSet<WorkshopEntity> Workshop { get; set; }
        public DbSet<ScheduleEntity> Schedule { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<AuthEntity>(new AuthMapping().Configure);
            modelBuilder.Entity<ServiceEntity>(new ServiceMapping().Configure);
            modelBuilder.Entity<ScheduleEntity>(new ScheduleMapping().Configure);
            modelBuilder.Entity<WorkshopEntity>(new WorkshopMapping().Configure);

            ServiceSeed.Seed(modelBuilder);
        }

    }
}